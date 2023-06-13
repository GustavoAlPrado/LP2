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
    public partial class FrmContato : Form
    {
        private BindingSource bnContato = new BindingSource();
        private bool bInclusao = false;
        private DataSet dsContato = new DataSet();
        private DataSet dsCidade = new DataSet();
        public FrmContato()
        {
            InitializeComponent();
        }

        private void Btnnovo_Click(object sender, EventArgs e)
        {

            if (tbcontato.SelectedIndex == 0)
            {
                tbcontato.SelectTab(1);
            }

            bnContato.AddNew();
            txtnomecontato.Enabled = true;
            cbxcidadecontato.Enabled = true;
            cbxcidadecontato.SelectedIndex = 0;
            txtcelularcontato.Enabled = true;
            txtemailcontato.Enabled = true;
            txtenderecocontato.Enabled = true;
            dtpdtcadastrocontato.Enabled = true;

            btnnovo.Enabled = false;
            btnalterar.Enabled = false;
            btnexcluir.Enabled = false;
            btnsalvar.Enabled = true;
            btncancelar.Enabled = true;
            bInclusao = true;

        }

        private void Btnsalvar_Click(object sender, EventArgs e)
        {
            if (txtnomecontato.Text == "")
            {
                MessageBox.Show("Nome do Contato Inválido");


            }
            else if (txtenderecocontato.Text == "")
            {
                MessageBox.Show("endereço inválido");
            }
            else if (txtcelularcontato.Text == "")
            {
                MessageBox.Show("Celular inválido");
            }
            else if (txtidcontato.Text == "")
            {
                MessageBox.Show("id inválido");
            }
            else if (txtemailcontato.Text == "")
            {
                MessageBox.Show("E-Mail inválido");
            }
            else
            {
                contato regcont = new contato();
                regcont.Cidadeidcidade = Convert.ToInt32(cbxcidadecontato.SelectedValue.ToString());
                regcont.Nomecontato = txtnomecontato.Text;
                regcont.Endcontato = txtenderecocontato.Text;
                regcont.Celcontato = txtcelularcontato.Text;
                regcont.Emailcontato = txtemailcontato.Text;
                regcont.Dtcadastrocontato = dtpdtcadastrocontato.Value;

                // regcont.Cidadeidcidade = cbxcidadecontato.SelectedItem.ToString();

                if (bInclusao)
                {
                    if (regcont.Salvar() > 0)
                    {
                        MessageBox.Show("Contato Adcionada com Sucesso");

                        txtnomecontato.Enabled = false;
                        cbxcidadecontato.Enabled = false;
                        txtenderecocontato.Enabled = false;
                        txtcelularcontato.Enabled = false;
                        txtemailcontato.Enabled = false;
                        dtpdtcadastrocontato.Enabled = false;

                        btnnovo.Enabled = true;
                        btnalterar.Enabled = true;
                        btnexcluir.Enabled = true;
                        btnsalvar.Enabled = false;
                        btncancelar.Enabled = false;
                        bInclusao = false;



                        dsContato.Tables.Clear();
                        dsContato.Tables.Add(regcont.Listar());
                        bnContato.DataSource = dsContato.Tables["Contato"];

                    }
                    else
                    {
                        MessageBox.Show("Erro ao gravar contato!", "ERRO");
                    }
                }
                else
                {

                    //contato regcont = new contato();
                    regcont.Idcontato = Convert.ToInt16(txtidcontato.Text);


                    if (regcont.Alterar() > 0)
                    {
                        MessageBox.Show("Contato alterada com sucesso!");
                        dsContato.Tables.Clear();
                        dsContato.Tables.Add(regcont.Listar());
                        txtidcontato.Enabled = false;
                        txtnomecontato.Enabled = false;
                        txtenderecocontato.Enabled = false;
                        txtcelularcontato.Enabled = false;
                        txtemailcontato.Enabled = false;
                        dtpdtcadastrocontato.Enabled = false;

                        cbxcidadecontato.Enabled = false;
                        btnsalvar.Enabled = false;
                        btnalterar.Enabled = true;
                        btnnovo.Enabled = true;
                        btnexcluir.Enabled = true;
                        btncancelar.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Erro ao alterar contato!");
                    }
                }
            }
        }

        private void Btnalterar_Click(object sender, EventArgs e)
        {
            if (tbcontato.SelectedIndex == 0)
            {
                tbcontato.SelectTab(1);
            }
            txtnomecontato.Enabled = true;
            cbxcidadecontato.Enabled = true;
            txtenderecocontato.Enabled = true;
            txtcelularcontato.Enabled = true;
            txtemailcontato.Enabled = true;
            dtpdtcadastrocontato.Enabled = true;

            txtnomecontato.Focus();
            btnsalvar.Enabled = true;
            btnalterar.Enabled = false;
            btnnovo.Enabled = false;
            btnexcluir.Enabled = false;
            btncancelar.Enabled = true;
            bInclusao = false;
        }

        private void Btnexcluir_Click(object sender, EventArgs e)
        {
            if (tbcontato.SelectedIndex == 0)
            {
                tbcontato.SelectTab(1);
            }
            if (MessageBox.Show("Confirma exclusão?", "Yes or No",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
           == DialogResult.Yes)
            {
                contato RegCont = new contato();
                RegCont.Idcontato = Convert.ToInt16(txtidcontato.Text);

                if (RegCont.Excluir() > 0)
                {
                    MessageBox.Show("Contato excluída com sucesso!");
                    contato R = new contato();
                    dsContato.Tables.Clear();
                    dsContato.Tables.Add(R.Listar());
                    bnContato.DataSource = dsContato.Tables["contato"];
                }
                else
                {
                    MessageBox.Show("Erro ao excluir contato!");
                }

            }
        }

        private void Btncancelar_Click(object sender, EventArgs e)
        {
            bnContato.CancelEdit();
            btnsalvar.Enabled = false;
            btnalterar.Enabled = true;
            btnnovo.Enabled = true;
            btnexcluir.Enabled = true;
            txtnomecontato.Enabled = false;
            cbxcidadecontato.Enabled = false;
            btncancelar.Enabled = false;
        }

        private void Btnsair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmContato_Load(object sender, EventArgs e)
        {

            try
            {

                 contato contatoObje = new contato();
                dsContato.Tables.Add(contatoObje.Listar());
                bnContato.DataSource = dsContato.Tables["Contato"];
                dgvcontato.DataSource = bnContato;
                bnvcontato.BindingSource = bnContato;

                txtidcontato.DataBindings.Add("TEXT", bnContato, "id_contato");
                txtnomecontato.DataBindings.Add("TEXT", bnContato, "nome_contato");
                txtenderecocontato.DataBindings.Add("TEXT", bnContato, "end_contato");
                txtcelularcontato.DataBindings.Add("TEXT", bnContato, "cel_contato");
                txtemailcontato.DataBindings.Add("TEXT", bnContato, "email_contato");
                dtpdtcadastrocontato.DataBindings.Add("TEXT", bnContato, "dtcadastro_contato");


                cidade cid = new cidade();
                dsCidade.Tables.Add(cid.Listar());
                cbxcidadecontato.DataSource = dsCidade.Tables["Cidade"];

                cbxcidadecontato.DisplayMember = "nome_cidade";
                cbxcidadecontato.ValueMember = "id_cidade";

                cbxcidadecontato.DataBindings.Add("SelectedValue", bnContato, "cidade_id_cidade");

            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar contatos");
            }

        }
    }
}
