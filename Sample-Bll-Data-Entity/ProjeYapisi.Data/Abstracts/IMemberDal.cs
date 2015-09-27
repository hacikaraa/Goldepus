using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjeYapisi.Dal.EntityFramework;

namespace ProjeYapisi.Dal.Abstracts
{
    public interface IMemberDal
    {
        EfMemberDal.MemberRegisterStatus MemberRegister(string Name, string Email, string Password);

        int MemberLogin(string Email, string Password);
    }
}
