using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStore
{
    public partial class menuPrincipal : Form
    {
        public menuPrincipal()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void incluirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 oldForm = new Form1();
            oldForm.Close();
            Application.Exit();
        }

        private void incluirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cadCliente cadCliente = new cadCliente();
            cadCliente.Show();
            this.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ManClientes manCliente = new ManClientes();
            manCliente.Show();
            this.Enabled = false;
        }
    }
}
