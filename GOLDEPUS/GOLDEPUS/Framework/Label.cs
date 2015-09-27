using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.Framework
{
    internal class Label : Base.Base
    {
        public Entity.Framework.Label GetLabel(int id)
        {
            return base.Dal.Framework.GetLabel(id);
        }

        public Entity.Framework.Label GetLabel(string name)
        {
            return base.Dal.Framework.GetLabel(name);
        }

        public Entity.Framework.Label SaveLabel(string name,string description = "", int categoryId = 0)
        {
            return base.Dal.Framework.SaveLabel(name, description, categoryId);
        }

        public Entity.Framework.Label UpdateLabel(int id, string name, string description, int categoryId = 0)
        {
            return base.Dal.Framework.UpdateLabel(id, name, description, categoryId);
        }

        public List<Entity.Framework.Label> GetLabels()
        {
             return base.Dal.Framework.GetLabels();
        }

        public List<Entity.Framework.Label> GetLabels(int categoryId)
        {
            return base.Dal.Framework.GetLabels(categoryId);
        }

        public bool DeleteLabel(int id)
        {
            return base.Dal.Framework.DeleteLabel(id);
        }
    }
}
