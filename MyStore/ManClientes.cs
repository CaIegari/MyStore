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
                bool resultado = false;
                while (dr.Read())
                {
                    resultado = true;
                    txtNome.Text = Convert.ToString(dr["nome"]);
                    txtEndereco.Text = Convert.ToString(dr["endereco"]);
                    txtTelefone.Text = Convert.ToString(dr["telefone"]);
                    comboSexo.SelectedItem = Convert.ToString(dr["sexo"]);

                }
                if(resultado == false)
                {
                    MessageBox.Show("Cliente não encontrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Text = "";
                    txtEndereco.Text = "";
                    txtTelefone.Text = "";
                    comboSexo.SelectedItem = null;

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\caleg\source\repos\MyStore\MyStore\bancoStore.mdf;Integrated Security=True");
                strSQL = "UPDATE clientes SET nome = @nome, endereco = @endereco, telefone = @telefone, sexo = @sexo WHERE cpf = @cpf;";
                comando = new SqlCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@cpf", txtCpf.Text);
                comando.Parameters.AddWithValue("@nome", txtNome.Text);
                comando.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                comando.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                comando.Parameters.AddWithValue("@sexo", comboSexo.SelectedItem.ToString());
                conexao.Open();
                dr = comando.ExecuteReader();
                MessageBox.Show("Cliente alterado com sucesso", "", MessageBoxButtons.OK, MessageBoxIcon.Information);



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
