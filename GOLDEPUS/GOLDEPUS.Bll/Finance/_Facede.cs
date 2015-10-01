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
        public Facede(Bll.Facede Application)
        {
            corporationExpenses = new CorporationExpenses(Application);
            corporationRevenues = new CorporationRevenues(Application);
            expenseItem = new ExpenseItem(Application);
            expenses = new Expenses(Application);
            memberExpenses = new MemberExpenses(Application);
            memberRevenues = new MemberRevenues(Application);
            revenueItem = new RevenueItem(Application);
            revenues = new Revenues(Application);
        }
    }
}
