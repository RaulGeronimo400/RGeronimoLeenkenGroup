using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RGeronimoLeenkenGroupEntities context = new DL.RGeronimoLeenkenGroupEntities())
                {
                    var query = context.EmpleadoAdd(
                        empleado.Nombre,
                        empleado.ApellidoPaterno,
                        empleado.ApellidoMaterno,
                        empleado.Estado.Id);
                    if (query > 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMEssage = "Ocurrio un problema al insertar";
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
        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RGeronimoLeenkenGroupEntities context = new DL.RGeronimoLeenkenGroupEntities())
                {
                    var query = context.EmpleadoUpdate(
                        empleado.Nombre,
                        empleado.ApellidoPaterno,
                        empleado.ApellidoMaterno,
                        empleado.Estado.Id,
                        empleado.Id);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMEssage = "Ocurrio un problema al actualizar";
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
        public static ML.Result Delete(int Id)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RGeronimoLeenkenGroupEntities context = new DL.RGeronimoLeenkenGroupEntities())
                {
                    var query = context.EmpleadoDelete(Id);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMEssage = "Ocurrio un problema al eliminar";
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
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RGeronimoLeenkenGroupEntities context = new DL.RGeronimoLeenkenGroupEntities())
                {
                    var query = context.EmpleadoGetAll().ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.Estado = new ML.EntidadFederativa();

                            empleado.Id = obj.Id;
                            empleado.NumeroNomina = obj.NumeroNomina;
                            empleado.Nombre = obj.Nombre;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;
                            empleado.Estado.Id = obj.IdEstado;
                            empleado.Estado.Estado = obj.Estado;

                            result.Objects.Add(empleado);
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
        public static ML.Result GetById(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RGeronimoLeenkenGroupEntities context = new DL.RGeronimoLeenkenGroupEntities())
                {
                    var query = context.EmpleadoGetById(IdEmpleado).SingleOrDefault();
                    if (query != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();
                        empleado.Estado = new ML.EntidadFederativa();
                        empleado.Id = query.Id;
                        empleado.NumeroNomina = query.NumeroNomina;
                        empleado.Nombre = query.Nombre;
                        empleado.ApellidoPaterno = query.ApellidoPaterno;
                        empleado.ApellidoMaterno = query.ApellidoMaterno;
                        empleado.Estado.Id = query.IdEstado.Value;

                        result.Object = empleado;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMEssage = "No se encontro el empleado";
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
