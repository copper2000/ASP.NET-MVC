using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using OnlineShop.Common;
using PagedList.Mvc;
using PagedList;
namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /Admin/User/

        public ActionResult Index(string SearchString, int page = 1, int pageSize = 5)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(SearchString, page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();

                var ecryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                user.Password = ecryptedMd5Pas;

                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm người dùng không thành công");
                }
            }
            
                return View("Index");
            
            
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var ecryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                    user.Password = ecryptedMd5Pas;
                }              
                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật người dùng không thành công");
                }
            }

            return View("Index");


        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }

    }
}
