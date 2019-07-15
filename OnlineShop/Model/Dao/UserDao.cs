using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.Dao{
    public class UserDao
    {
        OnlineShopDbContext db = null;
        public UserDao() 
        {
            db = new OnlineShopDbContext();
        }
        public long Insert(User entity) // INSERT
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(User entity) // UPDATE
        {
            try {
                var user = db.Users.Find(entity.ID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(user.Password))
                {
                    user.Password = entity.Password;
                }
                user.Address = entity.Address;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch(Exception e) {
                Console.Write(e.ToString());
                return false;
            }
           
        }
        public IEnumerable<User> ListAllPaging(string SearchString, int page, int pageSize) // SEARCH
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(SearchString))
            {
                model = model.Where(x => x.UserName.Contains(SearchString) || x.Name.Contains(SearchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }
        public int Login(string userName, string passWord) 
        {
            var result = db.Users.FirstOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWord)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }
        public bool Delete(int id) // DELETE
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                return false;
            }
            
        }
    }
}

