using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.Finance
{
    public class Facede
    {
        private CorporationExpenses corporationExpenses;
        private CorporationRevenues corporationRevenues;
        private ExpenseItem expenseItem;
        private Expenses expenses;
        private MemberExpenses memberExpenses;
        private MemberRevenues memberRevenues;
        private RevenueItem revenueItem;
        private Revenues revenues;
        public Facede(Entity.DBEngine.UnitOfWorks DataProcess)
        {
            corporationExpenses = new CorporationExpenses(DataProcess);
            corporationRevenues = new CorporationRevenues(DataProcess);
            expenseItem = new ExpenseItem(DataProcess);
            expenses = new Expenses(DataProcess);
            memberExpenses = new MemberExpenses(DataProcess);
            memberRevenues = new MemberRevenues(DataProcess);
            revenueItem = new RevenueItem(DataProcess);
            revenues = new Revenues(DataProcess);
        }
    }
}
