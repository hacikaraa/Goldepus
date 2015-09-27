using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aybala.Tool.Validations;
using Aybala.Tool.Cryptology;

namespace GOLDEPUS.Bll.User
{
    internal class Account : Base.Base
    {
        public ResultObject<Entity.User.Account> Login(string username,string password)
        {
            ResultObject<Entity.User.Account>  oResult = new ResultObject<Entity.User.Account>();
            if (AString.IsNotEmpty(username,password))
            {
                var user = Dal.User.Login(username, MD5.MD5Create(password));
                if(user != null && user.Id > 0)
                {
                    oResult.Result = true;
                    oResult.Value = user;
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
            return oResult;
        }

        public ResultObject<string> Register(string userName, string password, string eMail, string name)
        {
            ResultObject<string>  oResult = new ResultObject<string>();
            if (AString.IsNotEmpty(userName,password,eMail))
            {
                if (ARegex.IsMailFormat(eMail))
                {
                    GOLDEPUS.Dal.Base.RegisterResult result = base.Dal.User.Register(userName, MD5.MD5Create(password), eMail, name);
                    switch (result)
                    {
                        case GOLDEPUS.Dal.Base.RegisterResult.UserNameAlreadyExist:
                            oResult.Message = "Bu Kullanıcı Adı Zaten Kayıtlı";
                            oResult.Result = false;
                            break;
                        case GOLDEPUS.Dal.Base.RegisterResult.EMailAlreadyExist:
                            oResult.Message = "Bu Email Zaten Kayıtlı";
                            oResult.Result = false;
                            break;
                        case GOLDEPUS.Dal.Base.RegisterResult.Successful:
                            oResult.Message = "Kullanıcı Kaydı Gerçekleştirilmiştir.";
                            oResult.Result = true;
                            //buraya mail gönderme eklenecek onay veya hoşgeldin maili
                            break;
                        case GOLDEPUS.Dal.Base.RegisterResult.UnknowError:
                            oResult.Message = "Üzgünüz Bir Hata Oluştu";
                            oResult.Result = false;
                            break;
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
            return oResult;
        }



    }
}
