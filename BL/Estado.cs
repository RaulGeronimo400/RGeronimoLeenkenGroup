using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RGeronimoLeenkenGroupEntities context = new DL.RGeronimoLeenkenGroupEntities())
                {
                    var query = context.CatEntidadFederativaGetAll().ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            ML.EntidadFederativa entidadFederativa = new ML.EntidadFederativa();
                            entidadFederativa.Id = item.Id;
                            entidadFederativa.Estado = item.Estado;

                            result.Objects.Add(entidadFederativa);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMEssage = "Lista vacia";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMEssage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
