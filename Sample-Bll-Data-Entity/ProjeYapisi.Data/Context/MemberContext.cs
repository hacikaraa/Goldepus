using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ProjeYapisi.Entity.Entities;

namespace ProjeYapisi.Dal.Context
{
    public class MemberContext: DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Note> Notes { get; set; }

        public MemberContext()
            : base("MemberContext") 
        {
            Database.SetInitializer<MemberContext>(new DropCreateDatabaseIfModelChanges<MemberContext>());
        }
    }
}
