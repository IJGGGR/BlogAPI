using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // function to add our user type of CreateAccountID call UserToAdd this will return bool once our user is added
        // add user
        public bool AddUser(CreateAccountDTO UserToAdd)
        {
            return _svc.AddUser(UserToAdd);
        }
    }
}
