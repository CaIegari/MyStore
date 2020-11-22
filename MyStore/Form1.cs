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
using System.Threading;

namespace MyStore
{
    public partial class Form1 : Form
    {
        Thread t1;
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlDataReader dx;
        string strSQL;
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Que pena, contate o administrador do sistema", "Triste isso ne");
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\caleg\source\repos\MyStore\MyStore\bancoStore.mdf;Integrated Security=True");
                conexao.Open();
                strSQL = "select * from usuarios WHERE usuario = '" + txtUser.Text + "' and senha = '" + txtSenha.Text + "';";
                comando = new SqlCommand(strSQL, conexao);
                dr = comando.ExecuteReader();
                bool verificado = false;
                while (dr.Read())
                {

                    verificado = true;
                }
                if(verificado == false)
                {
                    MessageBox.Show("Usuário ou senha incorretos");
                }
                if(verificado == true)
                {
                    //Fluxo continua aqui
                    menuPrincipal newScreen = new menuPrincipal();
                    newScreen.Show();
                    this.Hide();
                   // t1 = new Thread(abrirJanela);
                    ///t1.SetApartmentState(ApartmentState.STA);
                    //t1.Start();
                }
         
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }

            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }

        }
        private void abrirJanela(object obj) {
            Application.Run(new menuPrincipal());
        }
    }
}
