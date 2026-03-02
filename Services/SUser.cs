using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Models.DTO;
using BlogAPI.Services.Context;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Services
{
    public class SUser(AppDbCtx ctx) : DbContext
    {
        private readonly AppDbCtx _ctx = ctx;
        public bool AddUser(CreateAccountDTO userToAdd)
        {
            throw new NotImplementedException();
        }
    }
}
