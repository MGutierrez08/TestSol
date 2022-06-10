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
    public partial class GetAll : Form
    {
        public GetAll()
        {
            InitializeComponent();
        }

        private void GetAll_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Formulario tabla = new Formulario();
            tabla.ShowDialog();

            Refrescar();
        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? IdEmpleado = GetId();
            if (IdEmpleado != null)
            {
                Formulario tabla = new Formulario(IdEmpleado);
                tabla.ShowDialog();
                Refrescar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? IdEmpleado = GetId();
            if (MessageBox.Show("¿Desea eliminar el registro?", "Eliminar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (IdEmpleado != null)
                {
                    CapaNegocio.Result result = CapaNegocio.Empleado.Delete(IdEmpleado.Value);
                    MessageBox.Show("Registro eliminado con exito");
                    Refrescar();
                }
                //MessageBox.Show("Pago realizado");

            }

            else
            {

                MessageBox.Show("Registro no eliminado");

            }
        }


        public void Refrescar()
        {
            CapaNegocio.Empleado empleado = new CapaNegocio.Empleado();
            empleado.Area = new CapaNegocio.Area();
            CapaNegocio.Result result = CapaNegocio.Empleado.GetAll();
            empleado.Empleados = result.Objects;
            dataGridView1.DataSource = empleado.Empleados;  //AGREGAR SIN FOREACH
            dataGridView1.Columns[4].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
