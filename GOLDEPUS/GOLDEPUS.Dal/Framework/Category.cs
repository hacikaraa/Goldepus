using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.Framework
{
    internal class Category : Base.Base<Entity.Framework.Category>
    {
        public Category(DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }

        public Entity.Framework.Category GetCategory(int id)
        {
            return base.Reponsitory.FindById(id);
        }

        public Entity.Framework.Category GetCategory(string name)
        {
            var result = base.Reponsitory.Select(w => w.Name == name).FirstOrDefault();
            if (result == null)
                return this.SaveCategory(name);
            return result;
        }

        public Entity.Framework.Category SaveCategory(string name, int baseCategoryID = 0)
        {
            Entity.Framework.Category _category = new Entity.Framework.Category();
            _category = base.Reponsitory.Select(w => w.Name == name && w.BaseCategory.Id == baseCategoryID).FirstOrDefault();
            if (_category == null)
            {
                _category = new Entity.Framework.Category();
                _category.Name = name;
                if (baseCategoryID != 0)
                    _category.BaseCategory = this.GetCategory(baseCategoryID);
                base.Reponsitory.Insert(ref _category);
                if (base.DataProcess.Save())
                    return _category;
                return null;
            }
            return _category;
           
        }

        public Entity.Framework.Category UpdateCategory(int id, string name, int baseCategoryID = 0)
        {
            Entity.Framework.Category _category = base.Reponsitory.FindById(id);
            if (_category == null) return null;
            if (baseCategoryID != 0)
                _category.BaseCategory = this.GetCategory(baseCategoryID);
            else
                _category.BaseCategory = null;
            _category.Name = name;
            base.Reponsitory.Update(ref _category);
            if (base.DataProcess.Save())
                return _category;
            return null;
        }

        public List<Entity.Framework.Category> GetBaseCategories()
        {
            return base.Reponsitory.Select(w => w.BaseCategory == null).ToList();
        }

        public List<Entity.Framework.Category> GetSubCategories(int categoryId)
        {
            return base.Reponsitory.Select(w => w.BaseCategory.Id == categoryId).ToList();
        }

        public bool DeleteCategory(int id)
        {
            base.Reponsitory.Delete(id);
            return base.DataProcess.Save();
        }

    }
}
