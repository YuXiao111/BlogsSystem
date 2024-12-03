using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogsSystem.Models
{
    /// <summary>
    /// Blogs表的操作类
    /// </summary>
    public class BlogsProvider : IProvider<Blogs>
    {
        private BlogsDBEntities db=new BlogsDBEntities();
        public int Delete(Blogs t)
        {
            if (t == null) return 0;
            var model = db.Blogs.ToList().FirstOrDefault(item => item.Id == t.Id);
            if (model == null) return 0;
            db.Blogs.Remove(model);
            int count = db.Member.Count();
            return count;
        }

        public int Insert(Blogs t)
        {
            if(t==null)return 0;
            db.Blogs.Add(t);
            int count=db.SaveChanges();
            return count;
        }

        public List<Blogs> Select()
        {
            return db.Blogs.ToList();
        }

        public int Update(Blogs t)
        {
            if(t==null)return 0;
            var model=db.Blogs.ToList().FirstOrDefault(item=>item.Id==t.Id);
            if (model == null) return 0;
            model.Title = t.Title;
            model.Text = t.Text;
            int count = db.SaveChanges();
            return count;
        }
    }
}