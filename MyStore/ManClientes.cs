using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyStore
{
    public partial class ManClientes : Form
    {
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlDataReader dx;
        string strSQL;
        public ManClientes()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            menuPrincipal a = new menuPrincipal();
            a.ShowDialog();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void PicPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\caleg\source\repos\MyStore\MyStore\bancoStore.mdf;Integrated Security=True");
                conexao.Open();
                strSQL = "select * from clientes WHERE cpf = @cpf ;";
                comando = new SqlCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@cpf", txtCpf.Text);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    txtNome.Text = Convert.ToString(dr["nome"]);
                    txtEndereco.Text = Convert.ToString(dr["endereco"]);
                    txtTelefone.Text = Convert.ToString(dr["telefone"]);
                    comboSexo.SelectedItem = Convert.ToString(dr["sexo"]);

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
    }
}
