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
        public Facede(Bll.Facede Application)
        {
            column = new Column(Application);
            corporationList = new CorporationList(Application);
            list = new List(Application);
            listColumn = new ListColumn(Application);
            listItem = new ListItem(Application);
            memberList = new MemberList(Application);
        }
    }
}
