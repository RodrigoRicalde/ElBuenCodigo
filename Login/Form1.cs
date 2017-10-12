using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source = (local); Initial Catalog = Pruebaf; Integrated Security = True");
        public void logear(string usuario, string contraseña)
        {
            try
            {
                con.Open();
                SqlCommand into = new SqlCommand("SELECT Nombre, Tipo_usuario FROM Usuarios WHERE Usuario = @usuario AND Password =@pass", con);
                into.Parameters.AddWithValue("usuario", usuario);
                into.Parameters.AddWithValue("pass",contraseña);
                SqlDataAdapter asd = new SqlDataAdapter(into);
                DataTable dt = new DataTable();
                asd.Fill(dt);
                if (dt.Rows.Count == 1)
                {

                    this.Hide();
                    if (dt.Rows[0][1].ToString() == "admin")
                    {

                     new administrador(dt.Rows[0][0].ToString()).Show();



                    }else if(dt.Rows[0][1].ToString() == "usuario")
                    {
                        new usuario(dt.Rows[0][0].ToString()).Show();
                    } 
                    
                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña incorrectos");
                    textBox1.Text = ("");
                    textBox2.Text = ("");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            logear(this.textBox1.Text, this.textBox2.Text);
        }
    }
}
