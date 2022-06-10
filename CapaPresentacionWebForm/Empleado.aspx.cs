using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacionWebForm
{
    public partial class Empleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CapaNegocio.Empleado empleado = new CapaNegocio.Empleado();
            CapaNegocio.Result result = CapaNegocio.Empleado.GetAll();
            if (result.Correct)
            {
                GridView1.DataSource = result.Objects;
                GridView1.DataBind();
            }
            CapaNegocio.Result resultArea = CapaNegocio.Area.GetAll();
            if (resultArea.Correct)
            {
                DropDownList1.DataSource = resultArea.Objects;        
                DropDownList1.DataTextField="Nombre";
                DropDownList1.DataValueField = "IdArea";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("Selecciona Departamento","0"));
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            CapaNegocio.Empleado empleado = new CapaNegocio.Empleado();
            empleado.Nombre = txtNombre.Text;
            empleado.ApellidoPaterno = txtApellidoPaterno.Text;
            empleado.ApellidoMaterno = txtApellidoMaterno.Text;
            empleado.Sueldo = Convert.ToDecimal(txtSueldo.Text);
            empleado.FechaDeNacimiento = txtFechaNacimiento.Text;
            empleado.Area = new CapaNegocio.Area();
            empleado.Area.IdArea = Convert.ToByte(DropDownList1.DataValueField);
            CapaNegocio.Result result = CapaNegocio.Empleado.Add(empleado);
            if (result.Correct)
            {

            }
        }
    }
}