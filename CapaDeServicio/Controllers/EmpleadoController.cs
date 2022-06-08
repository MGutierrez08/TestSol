using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CapaDeServicio.Controllers
{
    [Route("api/Empleado")]
    public class EmpleadoController : ApiController
    {
        [Route("api/Empleado/GetAll")]
        public IHttpActionResult GetAll()
        {
            CapaNegocio.Result result = CapaNegocio.Empleado.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("api/Empleado/GetById/{IdEmpleado}")]
        public IHttpActionResult GetById(int IdEmpleado)
        {
            CapaNegocio.Result result = CapaNegocio.Empleado.GetById(IdEmpleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("api/Empleado/Add")]
        public IHttpActionResult Add([FromBody] CapaNegocio.Empleado empleado)
        {
            CapaNegocio.Result result = CapaNegocio.Empleado.Add(empleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("api/Empleado/Update/{IdEmpleado}")]
        public IHttpActionResult Update(int IdEmpleado, [FromBody] CapaNegocio.Empleado empleado)
        {
            empleado.IdEmpleado = IdEmpleado;
            CapaNegocio.Result result = CapaNegocio.Empleado.Update(empleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("api/Empleado/Delete/{IdEmpleado}")]
        public IHttpActionResult Delete(int IdEmpleado)
        {
            CapaNegocio.Result result = CapaNegocio.Empleado.Delete(IdEmpleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
