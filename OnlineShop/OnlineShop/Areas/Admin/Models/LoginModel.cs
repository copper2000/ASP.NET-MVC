using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Nhập lại tên đăng nhập")]
        public String UserName { set; get; }
        [Required(ErrorMessage = "Nhập lại mật khẩu")]
        public String Password { set; get; }
        public Boolean Remember { set; get; }          
    }
}