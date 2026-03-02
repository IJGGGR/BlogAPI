using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Services.Context
{
    public class AppDbCtx(DbContextOptions opt) : DbContext(opt)
    {
        public DbSet<MUser> UserInfo { get; set; }
        public DbSet<MBlogItem> BlogInfo { get; set; }
    }
}