using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogsSystem.Models
{
    /// <summary>
    /// Member表的操作类
    /// </summary>
    public class MemberProvider : IProvider<Member>
    {
        private BlogsDBEntities db = new BlogsDBEntities();
        public int Delete(Member t)
        {
            if(t == null)return 0;
            var model=db.Member.ToList().FirstOrDefault(item=> item.Id == t.Id);
            if(model == null) return 0;
            db.Member.Remove(model);
            int count = db.Member.Count();
            return count;
        }

        public int Insert(Member t)
        {
            if(t==null)return 0;
            db.Member.Add(t);
            int count=db.SaveChanges();
            return count;
        }

        public List<Member> Select()
        {
            return db.Member.ToList();
        }

        public int Update(Member t)
        {
            if(t==null)return 0;
           var model= db.Member.ToList().FirstOrDefault(item=>item.Id==t.Id);
            if(model==null) return 0;
            model.Name = t.Name;
            model.Password = t.Password;
            int count = db.SaveChanges();
            return count;

        }
    }
}