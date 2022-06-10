using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public Area Area { get; set; }
        public string FechaDeNacimiento { get; set; }
        public decimal Sueldo { get; set; }
        public List<object> Empleados { get; set; }

        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using (CapaDeDatos.TestSolEntities context = new CapaDeDatos.TestSolEntities())
                {
                    var query = context.EmpleadoGetAll();
                    result.Objects = new List<object>();

                    if (query!=null)
                    {
                        foreach (var obj in query)
                        {
                            Empleado empleado = new Empleado();
                            empleado.IdEmpleado = obj.IdEmpleado;
                            empleado.Nombre = obj.Nombre;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;
                            empleado.Area = new Area();
                            empleado.Area.IdArea = Convert.ToByte(obj.IdArea);
                            empleado.Area.Nombre = obj.NombreArea;
                            empleado.FechaDeNacimiento = obj.FechaDeNacimiento.Value.ToString("dd/MM/yyyy");
                            empleado.Sueldo = Convert.ToDecimal(obj.Sueldo);

                            result.Objects.Add(empleado);
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

        public static Result Add(Empleado empleado)
        {
            Result result = new Result();
            try
            {
                using (CapaDeDatos.TestSolEntities context = new CapaDeDatos.TestSolEntities())
                {
                    var query = context.EmpleadoAdd(empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Area.IdArea, empleado.FechaDeNacimiento, empleado.Sueldo);
                    if (query>0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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

        public static Result GetById(int IdEmpleado)
        {
            Result result = new Result();
            try
            {
                using (CapaDeDatos.TestSolEntities context = new CapaDeDatos.TestSolEntities())
                {
                    var query = context.EmpleadoGetById(IdEmpleado).FirstOrDefault();
                    if (query!=null)
                    {
                        Empleado empleado = new Empleado();
                        empleado.IdEmpleado = query.IdEmpleado;
                        empleado.Nombre = query.Nombre;
                        empleado.ApellidoPaterno = query.ApellidoPaterno;
                        empleado.ApellidoMaterno = query.ApellidoMaterno;
                        empleado.Area = new Area();
                        empleado.Area.IdArea = Convert.ToByte(query.IdArea);
                        empleado.Area.Nombre = query.NombreArea;
                        empleado.FechaDeNacimiento = query.FechaDeNacimiento.Value.ToString("yyyy/MM/dd");
                        empleado.Sueldo = Convert.ToDecimal(query.Sueldo);
                        result.Object = empleado;
                    }
                    result.Correct = true;
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

        public static Result Update(Empleado empleado)
        {
            Result result = new Result();
            try
            {
                using (CapaDeDatos.TestSolEntities context = new CapaDeDatos.TestSolEntities())
                {
                    var query = context.EmpleadoUpdate(empleado.IdEmpleado, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Area.IdArea, empleado.FechaDeNacimiento, empleado.Sueldo);
                    if (query>0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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

        public static Result Delete(int IdEmpleado)
        {
            Result result = new Result();
            try
            {
                using (CapaDeDatos.TestSolEntities context = new CapaDeDatos.TestSolEntities())
                {
                    var query = context.EmpleadoDelete(IdEmpleado);
                    if (query>0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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
