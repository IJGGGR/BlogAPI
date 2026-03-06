using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Models;
using BlogAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController(SBlogItem svc) : ControllerBase
    {
        private readonly SBlogItem _svc = svc;

        [HttpPost("Create")]
        public bool Create(MBlogItem mdl)
        {
            return _svc.Create(mdl);
        }

        [HttpGet("GetAll")]
        public IEnumerable<MBlogItem> GetAll()
        {
            return _svc.GetAll();
        }

        [HttpGet("GetAllByCategory")]
        public IEnumerable<MBlogItem> GetAllByCategory(string category)
        {
            return _svc.GetAllByCategory(category);
        }

        [HttpGet("GetAllByTag")]
        public IEnumerable<MBlogItem> GetAllByTag(string tag)
        {
            return _svc.GetAllByTag(tag);
        }

        [HttpGet("GetAllByDate")]
        public IEnumerable<MBlogItem> GetAllByDate(string date)
        {
            return _svc.GetAllByDate(date);
        }

        [HttpGet("GetAllByIsPublished")]
        public IEnumerable<MBlogItem> GetAllByIsPublished()
        {
            return _svc.GetAllByIsPublished();
        }

        [HttpPost("Update")]
        public bool Update(MBlogItem mdl)
        {
            return _svc.Update(mdl);
        }

        [HttpPost("Delete")]
        public bool Delete(MBlogItem mdl)
        {
            return _svc.Delete(mdl);
        }
    }
}
