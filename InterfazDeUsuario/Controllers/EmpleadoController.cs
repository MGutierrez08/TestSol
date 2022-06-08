using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace InterfazDeUsuario.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult GetAll()
        {
            //CapaNegocio.Empleado empleado = new CapaNegocio.Empleado();
            //CapaNegocio.Result result = CapaNegocio.Empleado.GetAll();
            //if (result.Correct)
            //{
            //    empleado.Empleados = result.Objects;
            //    return View(empleado);
            //}
            //else
            //{
            //    ViewBag.Message = "Error al consultar los datos";
            //    return PartialView();
            //}
            CapaNegocio.Result resultempleados = new CapaNegocio.Result();
            CapaNegocio.Empleado empleado = new CapaNegocio.Empleado();
            resultempleados.Objects = new List<object>();
            string urlAPI = ConfigurationManager.AppSettings["WebAPI"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlAPI);
                var responseTask = client.GetAsync("Empleado/GetAll");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CapaNegocio.Result>();
                    readTask.Wait();
                    foreach (var resultList in readTask.Result.Objects)
                    {
                        CapaNegocio.Empleado resultItem = Newtonsoft.Json.JsonConvert.DeserializeObject<CapaNegocio.Empleado>(resultList.ToString());
                        resultempleados.Objects.Add(resultItem);
                    }
                }
                empleado.Empleados = resultempleados.Objects;
            }
            return View(empleado);
        }

        [HttpGet]
        public ActionResult Form(int? IdEmpleado)
        {
            CapaNegocio.Empleado empleado = new CapaNegocio.Empleado();
            CapaNegocio.Result resultAreas = CapaNegocio.Area.GetAll();
            empleado.Area = new CapaNegocio.Area();
            empleado.Area.Areas = resultAreas.Objects;
            if (IdEmpleado==null)
            {
                return View(empleado);
            }
            else
            {
                //CapaNegocio.Result result = CapaNegocio.Empleado.GetById(IdEmpleado.Value);
                //if (result.Correct)
                //{
                //    empleado = (CapaNegocio.Empleado)result.Object;
                //    empleado.Area.Areas = resultAreas.Objects;
                //}
                //return View(empleado);
                CapaNegocio.Result result = new CapaNegocio.Result();
                try
                {
                    string urlAPI = ConfigurationManager.AppSettings["WebAPI"];
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(urlAPI);
                        var responseTask = client.GetAsync("Empleado/GetById/" + IdEmpleado.Value);
                        responseTask.Wait();
                        var resultAPI = responseTask.Result;
                        if (resultAPI.IsSuccessStatusCode)
                        {
                            var readTask = resultAPI.Content.ReadAsAsync<CapaNegocio.Result>();
                            readTask.Wait();
                            CapaNegocio.Empleado empleadoItemList = new CapaNegocio.Empleado();
                            empleadoItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<CapaNegocio.Empleado>(readTask.Result.Object.ToString());
                            result.Object = empleadoItemList;
                            result.Correct = true;

                           
                            empleado = ((CapaNegocio.Empleado)result.Object);
                            empleado.Area.Areas = resultAreas.Objects;

                            return View(empleado);
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
                    result.ErrorMessage = ex.Message;
                }
            }
            return PartialView();
        }

        [HttpPost]
        public ActionResult Form(CapaNegocio.Empleado empleado)
        {
            if (empleado.IdEmpleado == 0)
            {
                //CapaNegocio.Result result = CapaNegocio.Empleado.Add(empleado);
                //if (result.Correct)
                //{
                //    ViewBag.Message = "Empleado Agregado Correctamente!!";
                //}
                //else
                //{
                //    ViewBag.Message = "Hubo un error al ingresar al Empleado: " + result.ErrorMessage;
                //}
                string urlAPI = ConfigurationManager.AppSettings["WebAPI"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    var postBack = client.PostAsJsonAsync<CapaNegocio.Empleado>("Empleado/Add/",empleado);
                    postBack.Wait();
                    var result = postBack.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Empleado Agregado Correctamente!!";
                    }
                    else
                    {
                        ViewBag.Message = "Hubo un error al ingresar al Empleado";
                    }
                }
                return View("ValidationModal");
            }
            else
            {
                //CapaNegocio.Result result = CapaNegocio.Empleado.Update(empleado);
                //if (result.Correct)
                //{
                //    ViewBag.Message = "Empleado Actualizado Correctamente!!";
                //}
                //else
                //{
                //    ViewBag.Message = "Hubo un error al actualizar al Empleado: " + result.ErrorMessage;
                //}
                string urlAPI = ConfigurationManager.AppSettings["WebAPI"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    var postTask = client.PutAsJsonAsync<CapaNegocio.Empleado>("Empleado/Update/" + empleado.IdEmpleado, empleado);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Empleado Actualizado Correctamente!!";
                    }
                    else
                    {
                        ViewBag.Message = "Hubo un error al actualizar al Empleado";
                    }
                }
            }
            return PartialView("ValidationModal");
        }

        public ActionResult Delete(int IdEmpleado)
        {
            //CapaNegocio.Result result = CapaNegocio.Empleado.Delete(IdEmpleado);
            //if (result.Correct)
            //{
            //    ViewBag.Message = "Empleado Eliminado Correctamente!!";
            //}
            //else
            //{
            //    ViewBag.Message = "Hubo un error al eliminar al Empleado: " + result.ErrorMessage;
            //}
            //return PartialView("ValidationModal");
            CapaNegocio.Result resultList = new CapaNegocio.Result();
            string urlAPI = ConfigurationManager.AppSettings["WebAPI"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlAPI);
                var postTask = client.DeleteAsync("Empleado/Delete/" + IdEmpleado);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Empleado Eliminado Correctamente!!";
                }
                else
                {
                    ViewBag.Message = "Hubo un error al eliminar al Empleado";
                }
            }
            return PartialView("ValidationModal");
        }
    }
}