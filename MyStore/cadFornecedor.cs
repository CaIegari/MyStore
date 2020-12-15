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
    public partial class cadFornecedor : Form
    {
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;
        SqlDataReader dr;
        string strSQL;
        public cadFornecedor()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            menuPrincipal a = new menuPrincipal();
            a.ShowDialog();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtCnpj.Text == "" || txtRazaoSocial.Text == "" || txtEndereco.Text == "" || txtTelefone.Text == "" || txtTipoProd.Text == "")
            {
                MessageBox.Show("Existem campos não preenchidos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\caleg\source\repos\MyStore\MyStore\bancoStore.mdf;Integrated Security=True");
                    conexao.Open();
                    strSQL = "INSERT INTO fornecedores (cnpj , razaoSocial, endereco, telefone, tipoProd) VALUES (@cnpj, @razaoSocial, @endereco, @telefone, @tipoProd);";
                    comando = new SqlCommand(strSQL, conexao);
                    comando.Parameters.AddWithValue("@cnpj", txtCnpj.Text);
                    comando.Parameters.AddWithValue("@razaoSocial", txtRazaoSocial.Text);
                    comando.Parameters.AddWithValue("@tipoProd", txtTipoProd.Text);
                    comando.Parameters.AddWithValue("@endereco ", txtEndereco.Text);
                    comando.Parameters.AddWithValue("@telefone ", txtTelefone.Text);
                    comando.ExecuteNonQuery();
                    MessageBox.Show(txtRazaoSocial.Text + " Inserido com Sucesso", "Aviso !");
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
    }
}
