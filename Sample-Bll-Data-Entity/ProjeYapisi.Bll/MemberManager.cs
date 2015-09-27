using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjeYapisi.Dal.Abstracts;
using ProjeYapisi.Dal.EntityFramework;

namespace ProjeYapisi.Bll
{
    public class MemberManager
    {
        private IMemberDal oMemberDal;

        public MemberManager(IMemberDal _memberDal)
        {
            oMemberDal = _memberDal;
        }

        public EfMemberDal.MemberRegisterStatus MemberRegister(string Name, string Email, string Password)
        {
            EfMemberDal.MemberRegisterStatus result = EfMemberDal.MemberRegisterStatus.SystemError;
            try
            {
                //varsa gerekli loglar alınır
                if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                {
                    return EfMemberDal.MemberRegisterStatus.SystemError;
                }
                result = oMemberDal.MemberRegister(Name, Email, Password);
            }
            catch 
            { 
                //gerekli hata logları alınır. 
            }
            return result;
        }

        public int MemberLogin(string Email, string Password)
        {
            int result = -1;
            try
            {
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                {
                    return -1;
                }
                result = oMemberDal.MemberLogin(Email, Password);
            }
            catch { }
            return result;
        }
    }
}
