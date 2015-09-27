using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.Framework
{
    internal class Category : Base.Base
    {
        public Entity.Framework.Category GetCategory(int id)
        {
            return base.Dal.Framework.GetCategory(id);
        }

        public Entity.Framework.Category GetCategory(string name)
        {
            return base.Dal.Framework.GetCategory(name);
        }

        public Entity.Framework.Category SaveCategory(string name, int baseCategoryID = 0)
        {
            return base.Dal.Framework.SaveCategory(name, baseCategoryID);
        }

        public Entity.Framework.Category UpdateCategory(int id, string name, int baseCategoryID = 0)
        {
            return base.Dal.Framework.UpdateCategory(id, name,baseCategoryID);
        }

        public List<Entity.Framework.Category> GetBaseCategories()
        {
            return base.Dal.Framework.GetBaseCategories();
        }

        public List<Entity.Framework.Category> GetSubCategories(int categoryId)
        {
            return base.Dal.Framework.GetSubCategories(categoryId);
        }

        public bool DeleteCategory(int id)
        {
            return base.Dal.Framework.DeleteCategory(id);
        }
    }
}
