using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Models;
using BlogAPI.Models.DTO;
using BlogAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(SUser svc) : ControllerBase
    {
        private readonly SUser _svc = svc;

        [HttpPost("Create")]
        public bool Create(CreateAccountDTO UserToAdd)
        {
            return _svc.Create(UserToAdd);
        }

        [HttpGet("GetAll")]
        public IEnumerable<MUser> GetAll()
        {
            return _svc.GetAll();
        }

        [HttpGet("GetOneById")]
        public MUser? GetOneById(int id)
        {
            return _svc.GetOneById(id);
        }

        [HttpGet("GetOneByUsername")]
        public MUser? GetOneByUsername(string username)
        {
            return _svc.GetOneByUsername(username);
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDTO dto)
        {
            return _svc.Login(dto);
        }

        [HttpPost("Update")]
        public bool Update(int id, string username)
        {
            return _svc.Update(id, username);
        }

        [HttpPost("Delete")]
        public bool Delete(string username)
        {
            return _svc.Delete(username);
        }
    }
}
