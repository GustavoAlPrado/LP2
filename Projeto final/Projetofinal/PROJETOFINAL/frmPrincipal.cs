using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace PROJETOFINAL
{
    public partial class Form1 : Form
    {
        public static SqlConnection conexao;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try {
                conexao = new SqlConnection("Data Source = APOLO; Initial Catalog = LP2; Persist Security Info = True; User ID = BD2121040 ; PASSWORD = Senhafatecgui01");
                conexao.Open();
            } catch (SqlException ex)
            {
                MessageBox.Show("Erro de banco de dados =/" + ex.Message);
            }   catch (Exception ex )
            {
                MessageBox.Show("Outros erros =/" + ex.Message);
            }
        }

        private void CidadeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FrmCidade>().Count()>0)
            {
                MessageBox.Show("Formulário já existe!");
                Application.OpenForms["FrmCidade"].BringToFront();
            }
            else
            {
                FrmCidade Objc = new FrmCidade();
                Objc.MdiParent = this;
                Objc.WindowState = FormWindowState.Maximized;
                Objc.Show();
            }
        }
        private void ContatoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FrmContato>().Count() > 0)
            {
                MessageBox.Show("Formulário já existe!");
                Application.OpenForms["FrmContato"].BringToFront();
            }
            else
            {
                FrmContato Objc = new FrmContato();
                Objc.MdiParent = this;
                Objc.WindowState = FormWindowState.Maximized;
                Objc.Show();
            }
        }

        private void SairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FrmSobre>().Count() > 0)
            {
                MessageBox.Show("Formulário já existe!");
                Application.OpenForms["FrmSobre"].BringToFront();
            }
            else
            {
                FrmSobre Objc = new FrmSobre();
                Objc.MdiParent = this;
                Objc.WindowState = FormWindowState.Maximized;
                Objc.Show();
            }
        }
    }
}
