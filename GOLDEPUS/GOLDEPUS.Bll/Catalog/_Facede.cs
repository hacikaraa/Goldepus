using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.Catalog
{
    public class Facede
    {
        private Column column;
        private CorporationList corporationList;
        private List list;
        private ListColumn listColumn;
        private ListItem listItem;
        private MemberList memberList;
        public Facede()
        {
            column = new Column();
            corporationList = new CorporationList();
            list = new List();
            listColumn = new ListColumn();
            listItem = new ListItem();
            memberList = new MemberList();
        }
    }
}
