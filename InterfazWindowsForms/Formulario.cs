using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazWindowsForms
{
    public partial class Formulario : Form
    {
        public int? IdEmpleado;
        public Formulario(int? IdEmpleado = null)
        {
            InitializeComponent();
            CapaNegocio.Empleado empleado = new CapaNegocio.Empleado();
            empleado.Area = new CapaNegocio.Area();
            CapaNegocio.Result result = CapaNegocio.Area.GetAll();
            if (result.Correct)
            {

                cbBoxArea.DataSource = result.Objects;
                cbBoxArea.ValueMember = "IdArea";
                cbBoxArea.DisplayMember = "Nombre";
                
                cbBoxArea.Text="Selecciona Departamento";
            }
            this.IdEmpleado = IdEmpleado;
            if (IdEmpleado != null)
            {
                CargaDatos();
            }
        }

        private void Formulario_Load(object sender, EventArgs e)
        {

        }

        private void CargaDatos()
        {
            CapaNegocio.Empleado empleado = new CapaNegocio.Empleado();
            empleado.Area = new CapaNegocio.Area();
            CapaNegocio.Result result = CapaNegocio.Empleado.GetById(IdEmpleado.Value);

            empleado.IdEmpleado = ((CapaNegocio.Empleado)result.Object).IdEmpleado;
            empleado.Nombre = ((CapaNegocio.Empleado)result.Object).Nombre;
            empleado.ApellidoPaterno = ((CapaNegocio.Empleado)result.Object).ApellidoPaterno;
            empleado.ApellidoMaterno = ((CapaNegocio.Empleado)result.Object).ApellidoMaterno;
            empleado.Area.Nombre = ((CapaNegocio.Empleado)result.Object).Area.Nombre;
            empleado.FechaDeNacimiento = ((CapaNegocio.Empleado)result.Object).FechaDeNacimiento;
            empleado.Sueldo = ((CapaNegocio.Empleado)result.Object).Sueldo;
            empleado.Area.IdArea = ((CapaNegocio.Empleado)result.Object).Area.IdArea;

            txtIdEmpleado.Text = Convert.ToString(empleado.IdEmpleado);
            txtNombre.Text = empleado.Nombre;
            txtApellidoPaterno.Text = empleado.ApellidoPaterno;
            txtApellidoMaterno.Text = empleado.ApellidoMaterno;
            FechaNacimiento.Value = Convert.ToDateTime(empleado.FechaDeNacimiento);
            txtSueldo.Text = empleado.Sueldo.ToString();
            //comboBox1.Text = empleado.Area.Nombre;

            CapaNegocio.Area area = new CapaNegocio.Area();
            CapaNegocio.Result resultArea = CapaNegocio.Area.GetAll();
            area.Areas = resultArea.Objects;
            cbBoxArea.DataSource = area.Areas;
            cbBoxArea.ValueMember = "IdArea";
            cbBoxArea.DisplayMember = "Nombre";
            cbBoxArea.Text = ((CapaNegocio.Empleado)result.Object).Area.Nombre;
            // comboBox1.Text = ("Seleccionar área");
            cbBoxArea.SelectedItem = ((CapaNegocio.Empleado)result.Object).Area.IdArea;
            //  comboBox1.SelectedIndex = comboBox1.Items.IndexOf(((ML.Empleado)result.Object).Area.Nombre); 
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CapaNegocio.Empleado empleado = new CapaNegocio.Empleado();
            empleado.Area = new CapaNegocio.Area();
            if (IdEmpleado == null)
            {

                empleado.Nombre = txtNombre.Text;
                empleado.ApellidoPaterno = txtApellidoPaterno.Text;
                empleado.ApellidoMaterno = txtApellidoMaterno.Text;
                empleado.FechaDeNacimiento = (FechaNacimiento.Value).ToString();
                empleado.Sueldo = Convert.ToInt32(txtSueldo.Text);
                var obj = cbBoxArea.SelectedItem;

                empleado.Area.IdArea = ((CapaNegocio.Area)obj).IdArea;
                //empleado.Area.Nombre = obj.ToString();

                CapaNegocio.Result result = CapaNegocio.Empleado.Add(empleado);

                if (result.Correct == true)
                {

                    MessageBox.Show("Registro agregado correctamente");

                }
                else
                {
                    MessageBox.Show("El registro no se agrego ");
                }

                this.Close();
            }
            else
            {

                empleado.IdEmpleado = Convert.ToInt32(txtIdEmpleado.Text);
                empleado.Nombre = txtNombre.Text;
                empleado.ApellidoPaterno = txtApellidoPaterno.Text;
                empleado.ApellidoMaterno = txtApellidoMaterno.Text;
                var obj = cbBoxArea.SelectedItem;
                empleado.Area.IdArea = ((CapaNegocio.Area)obj).IdArea;
                empleado.FechaDeNacimiento = FechaNacimiento.Value.ToString();
                empleado.Sueldo = Convert.ToInt32(txtSueldo.Text);

                CapaNegocio.Result result = CapaNegocio.Empleado.Update(empleado);
                if (result.Correct == true)
                {
                    MessageBox.Show("Registro actualizado correctamente");
                }
                else
                {
                    MessageBox.Show("El registro no se actualizo ");
                }
                this.Close();
            }
        }
    }
}
