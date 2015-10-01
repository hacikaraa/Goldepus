using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.Framework
{
    internal class Category : Base.Base<Entity.Framework.Category>
    {
        public Category(Bll.Facede Application) : base(Application) { }

        public ResultObject<Entity.Framework.Category> GetCategory(int id)
        {
            ResultObject<Entity.Framework.Category> oResult = new ResultObject<Entity.Framework.Category>();
            try
            {
                var category = base.DBAction.FindById(id);
                if (category == null)
                {
                    oResult.Result = false;
                    oResult.Message = "Böyle Bir Kayıt Bulunamadı";
                }
                else
                {
                    oResult.Result = true;
                    oResult.Value = category;
                }
            }
            catch (Exception ex)
            {
                oResult.Result = false;
                oResult.Message = "Belirlenemeyen Bir Hata Oluştu";
            }
            return oResult;
        }

        public ResultObject<Entity.Framework.Category> GetCategory(string name)
        {
            ResultObject<Entity.Framework.Category> oResult = new ResultObject<Entity.Framework.Category>();
            try
            {
                var category = base.DBAction.Select(w => w.Name == name).FirstOrDefault();
                if (category == null)
                {
                    oResult = this.SaveCategory(name);
                }
                else
                {
                    oResult.Result = true;
                    oResult.Value = category;
                }
            }
            catch (Exception ex)
            {
                oResult.Result = false;
                oResult.Message = "Belirlenemeyen Bir Hata Oluştu";
            }
            return oResult;
        }

        public ResultObject<Entity.Framework.Category> SaveCategory(string name, int baseCategoryID = 0)
        {
            ResultObject<Entity.Framework.Category> oResult = new ResultObject<Entity.Framework.Category>();
            try
            {
                Entity.Framework.Category newCategory = new Entity.Framework.Category();
                newCategory = base.DBAction.Select(w => w.Name == name && w.BaseCategory.Id == baseCategoryID).FirstOrDefault();
                if (newCategory == null)
                {
                    newCategory = new Entity.Framework.Category();
                    newCategory.Name = name;
                    if (baseCategoryID != 0)
                    {
                        oResult = this.GetCategory(baseCategoryID);
                        if (oResult.Result)
                            newCategory.BaseCategory = oResult.Value;
                        else
                            newCategory.BaseCategory = null;
                    }
                    base.DBAction.Insert(ref newCategory);
                    if (base.DataProcess.Save())
                    {
                        oResult.Result = true;
                        oResult.Value = newCategory;
                    }
                    else
                    {
                        oResult.Result = false;
                        oResult.Message = "Kayıt İşlemi Sırasında Bir Hata Oluştu";
                    }
                }
                else
                {
                    oResult.Message = "Varolan Bir Kaydı Tekrar Oluşturulamaz.";
                    oResult.Result = false;
                }
            }
            catch (Exception ex)
            {
                oResult.Result = false;
                oResult.Message = "Belirlenemeyen Bir Hata Oluştu";
            }
            return oResult;
        }

        public ResultObject<Entity.Framework.Category> UpdateCategory(int id, string name, int baseCategoryID = 0)
        {
            ResultObject<Entity.Framework.Category> oResult = new ResultObject<Entity.Framework.Category>();
            try
            {
                Entity.Framework.Category uCategory = base.DBAction.FindById(id);
                if (uCategory == null)
                {
                    oResult.Result = false;
                    oResult.Message = id + " 'li bir kayıt bulunamadı.";
                }
                else
                {
                    if (baseCategoryID != 0)
                    {
                        oResult = this.GetCategory(baseCategoryID);
                        if (oResult.Result)
                            uCategory.BaseCategory = oResult.Value;
                        else
                            uCategory.BaseCategory = null;
                    }
                    uCategory.Name = name;
                    base.DBAction.Update(ref uCategory);
                    if (base.DataProcess.Save())
                    {
                        oResult.Result = true;
                        oResult.Value = uCategory;
                    }
                    else
                    {
                        oResult.Result = false;
                        oResult.Message = "Güncelleme İşlemi Sırasında Bir Hata Oluştu";
                    }
                }
            }
            catch (Exception ex)
            {
                oResult.Result = false;
                oResult.Message = "Belirlenemeyen Bir Hata Oluştu";
            }
            return oResult;
        }

        public ResultObject<List<Entity.Framework.Category>> GetBaseCategories()
        {
            ResultObject<List<Entity.Framework.Category>> oResult = new ResultObject<List<Entity.Framework.Category>>();
            try
            {
                oResult.Value = base.DBAction.Select(w => w.BaseCategory == null).ToList();
                oResult.Result = true;
            }
            catch (Exception ex)
            {
                oResult.Result = false;
                oResult.Message = "Belirlenemeyen Bir Hata Oluştu";
            }
            return oResult;
        }

        public ResultObject<List<Entity.Framework.Category>> GetSubCategories(int categoryId)
        {
            ResultObject<List<Entity.Framework.Category>> oResult = new ResultObject<List<Entity.Framework.Category>>();
            try
            {
                oResult.Value = base.DBAction.Select(w => w.BaseCategory.Id == categoryId).ToList();
                oResult.Result = true;
            }
            catch (Exception ex)
            {
                oResult.Result = false;
                oResult.Message = "Belirlenemeyen Bir Hata Oluştu";
            }
            return oResult;
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                base.DBAction.Delete(id);
                return base.DataProcess.Save();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
