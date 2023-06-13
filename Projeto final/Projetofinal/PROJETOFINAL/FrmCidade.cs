using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJETOFINAL
{
    public partial class FrmCidade : Form
    {
        private BindingSource bnCidade = new BindingSource();
        private bool bInclusao = false;
        private DataSet dsCidade = new DataSet();


        public FrmCidade()
        {
            InitializeComponent();
        }

        private void FrmCidade_Load(object sender, EventArgs e)
        {
            try
            {

                cidade cidadeObje = new cidade();
                dsCidade.Tables.Add(cidadeObje.Listar());
                bnCidade.DataSource = dsCidade.Tables["Cidade"];
                dgvcidade.DataSource = bnCidade;
                bnvcidade.BindingSource = bnCidade;

                txtidcidade.DataBindings.Add("TEXT", bnCidade, "id_cidade");
                txtnomecidade.DataBindings.Add("TEXT", bnCidade, "nome_cidade");
                cbxufcidade.DataBindings.Add("SELECTEDITEM", bnCidade, "uf_cidade");
            }
                catch (Exception)
            {
                MessageBox.Show("Erro ao listar cidades");
            }


        }

        private void Btnsair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btnnovo_Click(object sender, EventArgs e)
        {
            if (tbcidade.SelectedIndex == 0)
            {
                tbcidade.SelectTab(1);
            }

            bnCidade.AddNew();
            txtnomecidade.Enabled = true;
            cbxufcidade.Enabled = true;
            cbxufcidade.SelectedIndex = 0;

            btnnovo.Enabled = false;
            btnalterar.Enabled = false;
            btnexcluir.Enabled = false;
            btnsalvar.Enabled = true;
            btncancelar.Enabled = true;
            bInclusao = true;



        }

        private void Btnsalvar_Click(object sender, EventArgs e)
        {
            if (txtnomecidade.Text == "" && txtnomecidade.Text.Length < 3)
            {
                MessageBox.Show("Nome da Cidade Inválido");
            }
            else
            {
                cidade regcid = new cidade();
                regcid.Idcidade = Convert.ToInt32(txtidcidade.Text);
                regcid.Nomecidade = txtnomecidade.Text;
                regcid.Ufcidade = cbxufcidade.SelectedItem.ToString();

                if (bInclusao)
                {
                    if (regcid.Salvar() > 0)
                    {
                        MessageBox.Show("Cidade Adcionada com Sucesso");

                        txtnomecidade.Enabled = false;
                        cbxufcidade.Enabled = false;


                        btnnovo.Enabled = true;
                        btnalterar.Enabled = true;
                        btnexcluir.Enabled = true;
                        btnsalvar.Enabled = false;
                        btncancelar.Enabled = false;
                        bInclusao = false;



                        dsCidade.Tables.Clear();
                        dsCidade.Tables.Add(regcid.Listar());
                        bnCidade.DataSource = dsCidade.Tables["Cidade"];

                    }
                    else
                    {
                        MessageBox.Show("Erro ao gravar cidade!", "ERRO");
                    }
                }
                else
                {
                    if (regcid.Alterar() > 0)
                    {
                        MessageBox.Show("Cidade alterada com sucesso!");
                        dsCidade.Tables.Clear();
                        dsCidade.Tables.Add(regcid.Listar());
                        txtidcidade.Enabled = false;
                        txtnomecidade.Enabled = false;
                        cbxufcidade.Enabled = false;
                        btnsalvar.Enabled = false;
                        btnalterar.Enabled = true;
                        btnnovo.Enabled = true;
                        btnexcluir.Enabled = true;
                        btncancelar.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Erro ao alterar cidade!");
                    }
                }
            }
        }





        private void Btnalterar_Click(object sender, EventArgs e)
        {

            if (tbcidade.SelectedIndex == 0)
            {
                tbcidade.SelectTab(1);
            }
            txtnomecidade.Enabled = true;
            cbxufcidade.Enabled = true;
            txtnomecidade.Focus();
            btnsalvar.Enabled = true;
            btnalterar.Enabled = false;
            btnnovo.Enabled = false;
            btnexcluir.Enabled = false;
            btncancelar.Enabled = true;
            bInclusao = false;
        }


        private void Btnexcluir_Click(object sender, EventArgs e)
        {

            if (tbcidade.SelectedIndex == 0)
            {
                tbcidade.SelectTab(1);
            }
            if (MessageBox.Show("Confirma exclusão?", "Yes or No",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
           == DialogResult.Yes)
            {
                cidade RegCid = new cidade();
                RegCid.Idcidade = Convert.ToInt16(txtidcidade.Text);
               
                if (RegCid.Excluir() > 0)
                {
                    MessageBox.Show("Cidade excluída com sucesso!");
                    cidade R = new cidade();
                    dsCidade.Tables.Clear();
                    dsCidade.Tables.Add(R.Listar());
                    bnCidade.DataSource = dsCidade.Tables["cidade"];
                }
                else
                {
                    MessageBox.Show("Erro ao excluir cidade!");
                }

            }
        }

            private void Btncancelar_Click(object sender, EventArgs e)
        {
            bnCidade.CancelEdit();
            btnsalvar.Enabled = false;
            btnalterar.Enabled = true;
            btnnovo.Enabled = true;
            btnexcluir.Enabled = true;
            txtnomecidade.Enabled = false;
            cbxufcidade.Enabled = false; 
            btncancelar.Enabled = false;

        }
    }
}
