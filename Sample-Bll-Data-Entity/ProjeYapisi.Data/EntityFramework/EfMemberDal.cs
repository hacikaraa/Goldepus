using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjeYapisi.Dal.Abstracts;
using ProjeYapisi.Entity.Entities;

namespace ProjeYapisi.Dal.EntityFramework
{
    public class EfMemberDal : EfBaseDal, IMemberDal
    {
        public MemberRegisterStatus MemberRegister(string Name, string Email, string Password)
        {
            MemberRegisterStatus result = MemberRegisterStatus.SystemError;
            try
            {
                var queryMemberStatus = this.MemberContext.Members.Where(w => w.Email == Email && w.MemberStatus == true).Count();
                if (queryMemberStatus > 0)
                {
                    result = MemberRegisterStatus.EmailError;
                }
                else
                {
                    Member insertMember = new Member
                    {
                        Name = Name,
                        Password = Password,
                        Email = Email,
                        MemberStatus = true
                    };
                    this.MemberContext.Members.Add(insertMember);
                    this.MemberContext.SaveChanges();
                    result = MemberRegisterStatus.Success;
                }
            }
            catch{}
            return result;
        }

        public int MemberLogin(string Email, string Password)
        {
            int result = -1;
            try
            {
                var query = this.MemberContext.Members.Where(w => w.Email == Email && w.Password == Password && w.MemberStatus == true).FirstOrDefault();
                if (query != null)
                {
                    result = query.ID;
                }
            }
            catch { }
            return result;
        }

        public enum MemberRegisterStatus
        {
            Success = 0,
            SystemError = 1,
            EmailError = 2
        }
    }
}
