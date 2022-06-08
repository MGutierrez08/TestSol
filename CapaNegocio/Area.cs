using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Area
    {
        public byte IdArea { get; set; }
        public string Nombre { get; set; }
        public List<object> Areas { get; set; }

        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using (CapaDeDatos.TestSolEntities context = new CapaDeDatos.TestSolEntities())
                {
                    var query = context.AreaGetAll();
                    result.Objects = new List<object>();

                    if (query!=null)
                    {
                        foreach (var obj in query)
                        {
                            Area area = new Area();
                            area.IdArea = obj.IdArea;
                            area.Nombre = obj.Nombre;
                            result.Objects.Add(area);
                        }
                        result.Correct = true;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
