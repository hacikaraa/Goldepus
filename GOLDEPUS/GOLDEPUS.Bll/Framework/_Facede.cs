using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.Framework
{
    public class Facede
    {
        private Category category;
        private Label label;
        public Facede(Bll.Facede Application)
        {
            category = new Category(Application);
            label = new Label(Application);
        }

        public ResultObject<Entity.Framework.Category> GetCategory(int id)
        {
            return this.category.GetCategory(id);
        }

        public ResultObject<Entity.Framework.Category> GetCategory(string name)
        {
            return this.category.GetCategory(name);
        }

        public ResultObject<Entity.Framework.Category> SaveCategory(string name, int baseCategoryID = 0)
        {
            return this.category.SaveCategory(name, baseCategoryID);
        }

        public ResultObject<Entity.Framework.Category> UpdateCategory(int id, string name, int baseCategoryID = 0)
        {
            return this.category.UpdateCategory(id, name, baseCategoryID);
        }

        public ResultObject<List<Entity.Framework.Category>> GetBaseCategories()
        {
            return this.category.GetBaseCategories();
        }

        public ResultObject<List<Entity.Framework.Category>> GetSubCategories(int categoryId)
        {
            return this.category.GetSubCategories(categoryId);
        }

        public bool DeleteCategory(int id)
        {
            return this.category.DeleteCategory(id);
        }

        public ResultObject<Entity.Framework.Label> GetLabel(int id)
        {
            return this.label.GetLabel(id);
        }

        public ResultObject<Entity.Framework.Label> GetLabel(string name)
        {
            return this.label.GetLabel(name);
        }

        public ResultObject<Entity.Framework.Label> SaveLabel(string name,string description = "", int categoryId = 0)
        {
            return this.label.SaveLabel(name, description, categoryId);
        }

        public ResultObject<Entity.Framework.Label> UpdateLabel(int id, string name, string description, int categoryId = 0)
        {
            return this.label.UpdateLabel(id, name, description, categoryId);
        }

        public ResultObject<List<Entity.Framework.Label>> GetLabels()
        {
            return this.label.GetLabels();
        }

        public ResultObject<List<Entity.Framework.Label>> GetLabels(int categoryId)
        {
            return this.label.GetLabels(categoryId);
        }

        public bool DeleteLabel(int id)
        {
            return this.label.DeleteLabel(id);
        }
    }
}
