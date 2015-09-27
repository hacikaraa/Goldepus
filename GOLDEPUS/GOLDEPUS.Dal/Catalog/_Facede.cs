
namespace GOLDEPUS.Dal.Catalog
{
    public class Facede
    {
        private Column column;
        private CorporationList corporationList;
        private List list;
        private ListColumn listColumn;
        private ListItem listItem;
        private MemberList memberList;
        public Facede(DBEngine.UnitOfWorks DataProcess)
        {
            column = new Column(DataProcess);
            corporationList = new CorporationList(DataProcess);
            list = new List(DataProcess);
            listColumn = new ListColumn(DataProcess);
            listItem = new ListItem(DataProcess);
            memberList = new MemberList(DataProcess);
        }


    }
}
