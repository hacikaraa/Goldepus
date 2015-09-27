using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Dal.Framework
{
    internal class Label : Base.Base<Entity.Framework.Label>
    {
        public Label(DBEngine.UnitOfWorks DataProcess) : base(DataProcess) { }

        public Entity.Framework.Label GetLabel(int id)
        {
            return base.Reponsitory.FindById(id);
        }

        public Entity.Framework.Label GetLabel(string name)
        {
            var result = base.Reponsitory.Select(w => w.Name == name).FirstOrDefault();
            if(result == null)
                return this.SaveLabel(name,name);
            return result;
        }

        public Entity.Framework.Label SaveLabel(string name,string description ,int categoryId = 0)
        {
            Entity.Framework.Label _label = new Entity.Framework.Label();
            if (string.IsNullOrEmpty(description)) description = name;
            if(categoryId == 0)
                _label = base.Reponsitory.Select(w => w.Name == name).FirstOrDefault();
            else
                _label = base.Reponsitory.Select(w => w.Name == name && w.Category.Id == categoryId).FirstOrDefault();
            if (_label == null)
            {
                _label = new Entity.Framework.Label();
                if (categoryId == 0)
                    _label.Category = base.Dal.Framework.GetCategory("GENEL");  
                else
                    _label.Category = base.Dal.Framework.GetCategory(categoryId);
                _label.Name = name;
                _label.Description = description;
                base.Reponsitory.Insert(ref _label);
                if (base.DataProcess.Save())
                    return _label;
                return null;
            }
            return _label;
        }

        public Entity.Framework.Label UpdateLabel(int id,string name,string description, int categoryId = 0)
        {
            Entity.Framework.Label _label = base.Reponsitory.FindById(id);
            if (string.IsNullOrEmpty(description)) description = name;
            if (categoryId == 0)
                _label.Category = base.Dal.Framework.GetCategory("GENEL");
            else
                _label.Category = base.Dal.Framework.GetCategory(categoryId);
            _label.Name = name;
            _label.Description = description;
            base.Reponsitory.Update(ref _label);
            if (base.DataProcess.Save())
                return _label;
            return null;
        }

        public List<Entity.Framework.Label> GetLabels()
        {
            return base.Reponsitory.Select().ToList();
        }

        public List<Entity.Framework.Label> GetLabels(int categoryId)
        {
            return base.Reponsitory.Select(w=>w.Category.Id == categoryId).ToList();
        }

        public bool DeleteLabel(int id)
        {
            base.Reponsitory.Delete(id);
            return base.DataProcess.Save();
        }
    }
}
