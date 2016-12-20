using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcBlog.Controllers
{ 
    using Models;
    public class YonetimController : Controller
    {
        //
        // GET: /Yonetim/

        BlogContext context = new BlogContext();
        public ActionResult MakaleYaz()

        {
            ViewBag.Tip = 1;
            ViewBag.Kategoriler = context.Kategoris.ToList();
            return View();
            }
        [HttpPost]
        public ActionResult MakaleYaz(Makale makale,HttpPostedFileBase Resim,string etiketler)
        {
            if(makale!=null)
            {
                Kullanici aktif = Session["Kullanici"] as Kullanici;
                makale.YayimTarihi = DateTime.Now;
                makale.MakaleTipID=1;
                makale.YazarID = aktif.id;
                makale.KapakResimID = ResimKaydet(Resim,HttpContext);
                context.Makales.Add(makale);
                context.SaveChanges();

                string[]etikets=etiketler.Split(',');
                foreach (string etiket in etikets)
	{
                    Etiket etk= context.Etikets.FirstOrDefault((x=>x.Adi.ToLower()==etiket.ToLower().Trim()));
                    if(etk==null)
                   
                    {
                        etk = new Etiket();
                        etk.Adi = etiket;
                        context.Etikets.Add(etk);
                    } makale.Etikets.Add(etk);
                        context.SaveChanges();
		 
	}

            }
            return View();
        }

        public static int  ResimKaydet(HttpPostedFileBase Resim, HttpContextBase ctx)
        {
            BlogContext context = new BlogContext();
           
            int kucukWidth = Convert.ToInt32(ConfigurationManager.AppSettings["kw"]);
            int kucukHeight = Convert.ToInt32(ConfigurationManager.AppSettings["kh"]);
            int ortaWidth = Convert.ToInt32(ConfigurationManager.AppSettings["ow"]);
            int ortaHeight = Convert.ToInt32(ConfigurationManager.AppSettings["oh"]);
            int buyukWidth = Convert.ToInt32(ConfigurationManager.AppSettings["bw"]);
            int buyukHeight = Convert.ToInt32(ConfigurationManager.AppSettings["bh"]);
            string newName = Path.GetFileNameWithoutExtension(Resim.FileName)+"-"+ Guid.NewGuid() + Path.GetExtension(Resim.FileName);

            Image orjRes = Image.FromStream(Resim.InputStream);
            Bitmap kucukRes = new Bitmap(orjRes, kucukWidth, kucukHeight);
            Bitmap ortaRes = new Bitmap(orjRes, ortaWidth, ortaHeight);
            Bitmap buyukRes = new Bitmap(orjRes);
            kucukRes.Save(ctx.Server.MapPath("~/Content/content/resimler/kucuk/" + newName));
            ortaRes.Save(ctx.Server.MapPath("~/Content/content/resimler/orta/" + newName));
            buyukRes.Save(ctx.Server.MapPath("~/Content/content/resimler/buyuk/" + newName));
            
            Kullanici k = (Kullanici)ctx.Session["Kullanici"];

            Resim dbRes=new Resim();
            dbRes.Adi= Resim.FileName;
            dbRes.BuyukResimYol="/Content/content/resimler/buyuk/"+newName;
            dbRes.OrtaResimYol="/Content/content/resimler/orta/"+newName;
            dbRes.KucukResimYol="/Content/content/resimler/kucuk/"+newName;
            dbRes.EklenmeTarihi = DateTime.Now;
            dbRes.EkleyenID=k.id;
            
            context.Resims.Add(dbRes);
            context.SaveChanges();
            return dbRes.Id;
        }
    }
}