using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;

namespace MvcBlog.Controllers
{
    public class KullaniciController : Controller
    {
        //
        // GET: /Kullanici/
        BlogContext context = new BlogContext();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(string kullaniciAdi, string Parola)
        {
            if (System.Web.Security.Membership.ValidateUser(kullaniciAdi, Parola))
            {
                FormsAuthentication.RedirectFromLoginPage(kullaniciAdi, true);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı Adı veya Parola Yanlış";
                return View();
            }

        }

        public ActionResult KayitOl()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult KayitOl(Kullanici kullanici, HttpPostedFileBase Resim, string Parola)
        {
            MembershipUser user = System.Web.Security.Membership.CreateUser(kullanici.Nick, Parola, kullanici.Mail);
            kullanici.id = (Guid)user.ProviderUserKey;

            Session["Kullanici"] = kullanici;
            kullanici.Mail = kullanici.Mail;
            kullanici.Parola = Parola;
            kullanici.ResimID = YonetimController.ResimKaydet(Resim, HttpContext);
            kullanici.KayitTarihi = System.DateTime.Now;
            context.Kullanicis.Add(kullanici);
            context.SaveChanges();
            FormsAuthentication.RedirectFromLoginPage(kullanici.Nick, true);
            Session["Kullanici"] = kullanici;

           


            return RedirectToAction("Index", "Home");
        }
    }
    
}
