using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BlogAPI.Models;
using BlogAPI.Models.DTO;
using BlogAPI.Services.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BlogAPI.Services
{
    public class SUser(AppDbCtx ctx)
    {
        private readonly AppDbCtx _ctx = ctx;

        public bool DoesUserExist(string? username)
        {
            if (string.IsNullOrWhiteSpace(username)) return false;
            username = username.ToLower();
            return _ctx.UserInfo.SingleOrDefault(e => e.Username == username) != null;
        }

        public bool AddUser(CreateAccountDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password)) return false;

            var un = dto.Username.ToLower();
            var pw = dto.Password;

            // un
            if (char.IsWhiteSpace(un[0]) || char.IsWhiteSpace(un[^1])) return false;
            if (!un.All(c => char.IsAsciiLetterOrDigit(c) || c == '.' || c == '_')) return false;
            // pw
            if (char.IsWhiteSpace(pw[0]) || char.IsWhiteSpace(pw[^1])) return false;

            // db check
            if (DoesUserExist(un)) return false;

            // db add
            var sec = SaltHashPassword(pw);
            var obj = new MUser() { Id = 0, Username = un, Salt = sec.Salt, Hash = sec.Hash };
            _ctx.Add(obj);

            return _ctx.SaveChanges() > 0;
        }

        public PasswordDTO SaltHashPassword(string password)
        {
            var buf = new byte[64];
            RandomNumberGenerator.Create().GetNonZeroBytes(buf);

            var salt = Convert.ToBase64String(buf);
            var hash = Convert.ToBase64String(new Rfc2898DeriveBytes(password, buf, 10_000, HashAlgorithmName.SHA256).GetBytes(256));

            return new() { Salt = salt, Hash = hash };
        }

        public bool VerifyPassword(string? password, string? dbSalt, string? dbHash)
        {
            if (string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(dbSalt) ||
                string.IsNullOrWhiteSpace(dbHash))
            {
                return false;
            }

            var salt = Convert.FromBase64String(dbSalt);
            var hash = Convert.ToBase64String(new Rfc2898DeriveBytes(password, salt, 10_000, HashAlgorithmName.SHA256).GetBytes(256));

            return hash == dbHash;
        }
    }
}
