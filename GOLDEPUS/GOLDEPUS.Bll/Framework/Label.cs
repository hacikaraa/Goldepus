using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll.Framework
{
    internal class Label : Base.Base<Entity.Framework.Label>
    {
        public Label(Bll.Facede Application) : base(Application) { }

        public ResultObject<Entity.Framework.Label> GetLabel(int id)
        {
            ResultObject<Entity.Framework.Label> oResult = new ResultObject<Entity.Framework.Label>();
            try
            {
                var label = base.DBAction.FindById(id);
                if (label != null)
                {
                    oResult.Result = true;
                    oResult.Value = label;
                }
                else
                {
                    oResult.Result = false;
                    oResult.Message = "Böyle Bir Kayıt Bulunamadı";
                }
            }
            catch (Exception ex)
            {
                oResult.Result = false;
                oResult.Message = "Belirlenemeyen Bir Hata Oluştu";
            }
            return oResult;
        }

        public ResultObject<Entity.Framework.Label> GetLabel(string name)
        {
            ResultObject<Entity.Framework.Label> oResult = new ResultObject<Entity.Framework.Label>();
            try
            {
                var label = base.DBAction.Select(w => w.Name == name).FirstOrDefault();
                if (label == null)
                {
                    oResult = this.SaveLabel(name);
                }
                else
                {
                    oResult.Result = true;
                    oResult.Value = label;
                }
            }
            catch (Exception ex)
            {
                oResult.Result = false;
                oResult.Message = "Belirlenemeyen Bir Hata Oluştu";
            }
            return oResult;
        }

        public ResultObject<Entity.Framework.Label> SaveLabel(string name, string description = "", int categoryId = 0)
        {
            ResultObject<Entity.Framework.Label> oResult = new ResultObject<Entity.Framework.Label>();
            try
            {
                Entity.Framework.Label newLabel = new Entity.Framework.Label();
                if (string.IsNullOrEmpty(description)) description = name;
                if (categoryId == 0)
                    newLabel = base.DBAction.Select(w => w.Name == name).FirstOrDefault();
                else
                    newLabel = base.DBAction.Select(w => w.Name == name && w.Category.Id == categoryId).FirstOrDefault();
                if (newLabel == null)
                {
                    newLabel = new Entity.Framework.Label();
                    ResultObject<Entity.Framework.Category> cResult;
                    if (categoryId == 0)
                        cResult = base.Application.Framework.GetCategory("GENEL");
                    else
                        cResult = base.Application.Framework.GetCategory(categoryId);
                    if (cResult != null && cResult.Result)
                        newLabel.Category = cResult.Value;
                    newLabel.Name = name;
                    newLabel.Description = description;
                    base.DBAction.Insert(ref newLabel);
                    if (base.DataProcess.Save())
                    {
                        oResult.Value = newLabel;
                        oResult.Result = true;
                    }
                    else
                    {
                        oResult.Message = "Kayıt Esnasında Bilinmeyen Bir Hata Oluştu";
                        oResult.Result = false;
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

        public ResultObject<Entity.Framework.Label> UpdateLabel(int id, string name, string description, int categoryId = 0)
        {
            ResultObject<Entity.Framework.Label> oResult = new ResultObject<Entity.Framework.Label>();
            try
            {
                Entity.Framework.Label uLabel = base.DBAction.FindById(id);
                if (uLabel == null)
                {
                    oResult.Result = false;
                    oResult.Message = id + " 'li bir kayıt bulunamadı.";
                }
                else
                {
                    if (string.IsNullOrEmpty(description)) description = name;
                    ResultObject<Entity.Framework.Category> cResult;
                    if (categoryId == 0)
                        cResult = base.Application.Framework.GetCategory("GENEL");
                    else
                        cResult = base.Application.Framework.GetCategory(categoryId);
                    if (cResult != null && cResult.Result)
                        uLabel.Category = cResult.Value;
                    uLabel.Name = name;
                    uLabel.Description = description;
                    base.DBAction.Update(ref uLabel);
                    if (base.DataProcess.Save())
                    {
                        oResult.Value = uLabel;
                        oResult.Result = true;
                    }
                    else
                    {
                        oResult.Message = "Kayıt Esnasında Bilinmeyen Bir Hata Oluştu";
                        oResult.Result = false;
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

        public ResultObject<List<Entity.Framework.Label>> GetLabels()
        {
            ResultObject<List<Entity.Framework.Label>> oResult = new ResultObject<List<Entity.Framework.Label>>();
            try
            {
                oResult.Value = base.DBAction.Select().ToList();
                oResult.Result = false;
            }
            catch (Exception ex)
            {
                oResult.Result = false;
                oResult.Message = "Belirlenemeyen Bir Hata Oluştu";
            }
            return oResult;
        }

        public ResultObject<List<Entity.Framework.Label>> GetLabels(int categoryId)
        {
            ResultObject<List<Entity.Framework.Label>> oResult = new ResultObject<List<Entity.Framework.Label>>();
            try
            {
                oResult.Value = base.DBAction.Select(w => w.Category.Id == categoryId).ToList();
                oResult.Result = false;
            }
            catch (Exception ex)
            {
                oResult.Result = false;
                oResult.Message = "Belirlenemeyen Bir Hata Oluştu";
            }
            return oResult;
        }

        public bool DeleteLabel(int id)
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
