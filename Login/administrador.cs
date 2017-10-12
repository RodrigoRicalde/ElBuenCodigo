using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class administrador : Form
    {
        public administrador(string nombre)
        {
            InitializeComponent();
            adminlbl.Text = nombre;
        }

        ConsultaSQL sql = new ConsultaSQL();

        private void administrador_Load(object sender, EventArgs e)
        {
            dgv.DataSource = sql.Mostrar();

        }

        

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgv.Rows[e.RowIndex];
            txtid.Text = Convert.ToString(fila.Cells[0].Value);
            txtnombre.Text = Convert.ToString(fila.Cells[1].Value);
            txtedad.Text = Convert.ToString(fila.Cells[2].Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtid.Text = dgv.Rows.Count.ToString();
            if (sql.Insertar(txtid.Text ,txtnombre.Text,txtedad.Text))
            {
                MessageBox.Show("Datos correctamente insertados");
                dgv.DataSource = sql.Mostrar();
                            }
            else MessageBox.Show("No se pudieron insertar datos");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sql.Eliminar(txtid.Text))
            {
                MessageBox.Show("Datos correctamente eliminados");
                dgv.DataSource = sql.Mostrar();
            }
            else MessageBox.Show("No se pudieron eliminar datos");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sql.Actualizar(txtid.Text, txtnombre.Text, txtedad.Text))
            {
                MessageBox.Show("Datos correctamente actualizados");
                dgv.DataSource = sql.Mostrar();
            }
            else MessageBox.Show("No se pudieron actualizar los datos");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(txtbuscar.Text != "")dgv.DataSource = sql.Buscar(txtbuscar.Text);

            else dgv.DataSource = sql.Mostrar();
        }
    }
}
