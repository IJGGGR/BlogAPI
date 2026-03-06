using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Models;
using BlogAPI.Services.Context;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Services
{
    public class SBlogItem(AppDbCtx ctx) : ControllerBase
    {
        private readonly AppDbCtx _ctx = ctx;

        internal bool Create(MBlogItem mdl)
        {
            _ctx.Add(mdl);
            var res = _ctx.SaveChanges() > 0;

            return res;
        }

        internal IEnumerable<MBlogItem> GetAll()
        {
            return _ctx.BlogInfo;
            // return _ctx.BlogInfo.AsNoTracking().AsEnumerable();
        }

        internal IEnumerable<MBlogItem> GetAllByCategory(string category)
        {
            return _ctx.BlogInfo.Where(e => e.Category == category);
        }

        internal IEnumerable<MBlogItem> GetAllByDate(string date)
        {
            return _ctx.BlogInfo.Where(e => e.Date == date);
        }

        internal IEnumerable<MBlogItem> GetAllByTag(string tag)
        {
            return _ctx.BlogInfo.Where(e => (e.Tags ?? "").Split(',', StringSplitOptions.None).Any(e => e == tag));
        }

        internal IEnumerable<MBlogItem> GetAllByIsPublished()
        {
            return _ctx.BlogInfo.Where(e => e.IsPublished);
        }

        internal bool Update(MBlogItem mdl)
        {
            _ctx.Update(mdl);
            var res = _ctx.SaveChanges() > 0;

            return res;
        }

        internal bool Delete(MBlogItem mdl)
        {
            _ctx.Update(mdl);
            var res = _ctx.SaveChanges() > 0;

            return res;
        }
    }
}
