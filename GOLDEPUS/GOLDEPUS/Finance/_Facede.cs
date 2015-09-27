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
        public Facede()
        {
            corporationExpenses = new CorporationExpenses();
            corporationRevenues = new CorporationRevenues();
            expenseItem = new ExpenseItem();
            expenses = new Expenses();
            memberExpenses = new MemberExpenses();
            memberRevenues = new MemberRevenues();
            revenueItem = new RevenueItem();
            revenues = new Revenues();
        }
    }
}
