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

namespace MyStore
{
    public partial class cadCliente : Form
    {

        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;
        SqlDataReader dr;
        string strSQL;
        public cadCliente()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            menuPrincipal a = new menuPrincipal();
            a.ShowDialog();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            menuPrincipal a = new menuPrincipal();
            a.ShowDialog();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            if (txtCpf.Text == "" || txtNome.Text == "" || txtEndereco.Text == "" || txtTelefone.Text == "" || comboSexo.SelectedItem == null)
            {
                MessageBox.Show("Existem campos não preenchidos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                try
                {
                    conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\caleg\source\repos\MyStore\MyStore\bancoStore.mdf;Integrated Security=True");
                    conexao.Open();
                    strSQL = "INSERT INTO clientes (cpf , nome, sexo, endereco, telefone) VALUES (@cpf, @nome, @sexo, @endereco, @telefone);";
                    comando = new SqlCommand(strSQL, conexao);
                    comando.Parameters.AddWithValue("@cpf", txtCpf.Text);
                    comando.Parameters.AddWithValue("@nome", txtNome.Text);
                    comando.Parameters.AddWithValue("@sexo", comboSexo.SelectedItem.ToString());
                    comando.Parameters.AddWithValue("@endereco ", txtEndereco.Text);
                    comando.Parameters.AddWithValue("@telefone ", txtTelefone.Text);
                    comando.ExecuteNonQuery();
                    MessageBox.Show(txtNome.Text + " Inserido com Sucesso", "Aviso !");
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
            };
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }
    }
}
