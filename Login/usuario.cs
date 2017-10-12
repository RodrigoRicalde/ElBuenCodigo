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
    public partial class usuario : Form
    {
        public usuario(string nombre)
        {
            InitializeComponent();
            mensajeuser.Text = nombre;
        }

        ConsultaSQL sql = new ConsultaSQL();

        private void usuario_Load(object sender, EventArgs e)
        {
            dgv.DataSource = sql.Mostrar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtid.Text = dgv.Rows.Count.ToString();
            if (sql.Insertar(txtid.Text, txtnombre.Text, txtedad.Text))
            {
                MessageBox.Show("Datos correctamente insertados");
                dgv.DataSource = sql.Mostrar();
            }
            else MessageBox.Show("No se pudieron insertar datos");
        }
    }
}
