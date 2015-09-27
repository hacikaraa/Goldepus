
namespace GOLDEPUS.Dal.Formal
{
    public class Facede
    {
        private Corporation corporation;
        private CorporationMember corporationMember;
        public Facede(DBEngine.UnitOfWorks DataProcess)
        {
            corporation = new Corporation(DataProcess);
            corporationMember = new CorporationMember(DataProcess);
        }        


    }
}
