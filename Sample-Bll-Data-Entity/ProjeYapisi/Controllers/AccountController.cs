using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeYapisi.Models;
using ProjeYapisi.Dal.EntityFramework;

namespace ProjeYapisi.Controllers
{
    public class AccountController : BaseController
    {
        //
        // GET: /Account/

        public ActionResult Register()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Register(MemberModel member)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EfMemberDal.MemberRegisterStatus Status = this.MemberManager.MemberRegister(member.Name, member.Email, member.Password);
                    if (Status == EfMemberDal.MemberRegisterStatus.Success)
                    {
                        ViewBag.status = "success";
                        ViewBag.info = "İşlem başarıyla gerçekleştirildi. Giriş sayfasına yönlendiriliyorsunuz.";
                    }
                    else if (Status == EfMemberDal.MemberRegisterStatus.EmailError)
                    {
                        ViewBag.status = "error";
                        ViewBag.info = "Sistemimizde email adresine ait bir kayıt mevcuttur.";
                    }
                    else
                    {
                        ViewBag.status = "error";
                        ViewBag.info = "Teknik bir hata oluştu lütfen tekrar deneyiniz.";
                    }
                }
            }
            catch
            {
                ViewBag.status = "error";
                ViewBag.info = "Teknik bir hata oluştu lütfen tekrar deneyiniz.";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel member)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int Status = this.MemberManager.MemberLogin(member.Email, member.Password);
                    if (Status != -1)
                    {
                        Session.Add("MemberID", Status);
                        ViewBag.status = "success";
                        ViewBag.info = "Giriş başarıyla gerçekleştirildi.";
                    }
                    else
                    {
                        ViewBag.status = "error";
                        ViewBag.info = "Girmiş olduğunuz şifre konbinasyonu birbirine uyumlu değildir.";
                    }
                }
            }
            catch
            {
                ViewBag.status = "error";
                ViewBag.info = "Teknik bir hata oluştu lütfen tekrar deneyiniz.";
                //gerekli hata - log kayıtdı alınır.
            }
            return View();
        }
    }
}
