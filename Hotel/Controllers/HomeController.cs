using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class HomeController : Controller

    {

        public ActionResult Index()

        {

            LoginModel obj = new LoginModel();

            return View(obj);

        }

        [HttpPost]

        public ActionResult Index(LoginModel objuserlogin)

        {

            var display = Userloginvalues().Where(m => m.UserName == objuserlogin.UserName && m.UserPassword == objuserlogin.UserPassword).FirstOrDefault();

            if (display != null)

            {

                ViewBag.Status = "Usuario incorrecto o Contraseña incorrecta";

            }

            else

            {

                ViewBag.Status = "Usuario incorrecto o Contraseña incorrecta";

            }

            return View(objuserlogin);

        }

        public List<LoginModel> Userloginvalues()

        {

            List<LoginModel> objModel = new List<LoginModel>();

            objModel.Add(new LoginModel { UserName = "Pedro", UserPassword = "gr123456" });

            objModel.Add(new LoginModel { UserName = "Angel", UserPassword = "12345" });

            objModel.Add(new LoginModel { UserName = "user3", UserPassword = "password3" });

            objModel.Add(new LoginModel { UserName = "user4", UserPassword = "password4" });

            objModel.Add(new LoginModel { UserName = "user5", UserPassword = "password5" });

            return objModel;

        }

    }

}

