using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aybala.Tool.Validations;
using Aybala.Tool.Cryptology;

namespace GOLDEPUS.Bll.User
{
    internal class Account : Base.Base<Entity.User.Account>
    {
        public Account(Entity.DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }

        public ResultObject<Entity.User.Account> Login(string username, string password)
        {
            ResultObject<Entity.User.Account> oResult = new ResultObject<Entity.User.Account>();
            try
            {
                if (AString.IsNotEmpty(username, password))
                {
                    var user = base.DBAction.Select(w => (w.AccountName == username || w.Email == username) && w.AccountPasword == password);
                    if (user != null && user.Count() > 0)
                    {
                        oResult.Result = true;
                        oResult.Value = user.FirstOrDefault();
                    }
                    else
                    {
                        oResult.Result = false;
                        oResult.Message = "Kullanıcı Adı ve Parolanızı Kontrol Edin";
                    }
                }
                else
                {
                    oResult.Message = "Kullanıcı Adı ve Parola Boş Girilemez";
                    oResult.Result = false;
                }
            }
            catch (Exception ex)
            {
                base.CreateExceptionLog(ex);
                oResult.Result = false;
                oResult.Message = "Üzgünüz Bir Hata Oluştu";
            }
            return oResult;
        }

        public ResultObject<Entity.User.Account> Register(string userName, string password, string eMail, string name)
        {
            ResultObject<Entity.User.Account> oResult = new ResultObject<Entity.User.Account>();
            try
            {
                if (AString.IsNotEmpty(userName, password, eMail))
                {
                    if (ARegex.IsMailFormat(eMail))
                    {
                        var user = base.DBAction.Select(w => w.AccountName == userName).FirstOrDefault();
                        if (user != null)
                        {
                            oResult.Message = "Bu Kullanıcı Adı Zaten Kayıtlı";
                            oResult.Result = false;
                            return oResult;
                        }
                        user = base.DBAction.Select(w => w.Email == eMail).FirstOrDefault();
                        if (user != null)
                        {
                            oResult.Message = "Bu Email Zaten Kayıtlı";
                            oResult.Result = false;
                            return oResult;
                        }

                        Entity.User.Account _account = new Entity.User.Account();
                        _account.AccountName = userName;
                        _account.AccountPasword = password;
                        _account.Email = eMail;
                        _account.Name = name;

                        base.DBAction.Insert(ref _account);
                        if (base.DataProcess.Save())
                        {
                            oResult.Message = "Kullanıcı Kaydı Gerçekleştirilmiştir.";
                            oResult.Result = true;
                            oResult.Value = _account;
                            //buraya mail gönderme eklenecek onay veya hoşgeldin maili
                        }
                        else
                        {
                            oResult.Message = "Üzgünüz Bir Hata Oluştu";
                            oResult.Result = false;
                        }
                    }
                    else
                    {
                        oResult.Message = "Mail Formata Uygun Değil";
                        oResult.Result = false;
                    }
                }
                else
                {
                    oResult.Message = "Değerler Boş Girilemez";
                    oResult.Result = false;
                }
            }
            catch (Exception ex)
            {
                base.CreateExceptionLog(ex);
                oResult.Message = "Üzgünüz Belirlenemeyen Bir Hata Oluştu";
                oResult.Result = false;
            }
            return oResult;
        }
    }
}
