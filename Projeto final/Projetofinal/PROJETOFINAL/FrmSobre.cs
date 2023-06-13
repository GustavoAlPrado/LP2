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
    public partial class FrmSobre : Form
    {
        public FrmSobre()
        {
            InitializeComponent();
        }

        private void BtnObg_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Agradecimentos:\n" + 
                "--------------------------------------\n\n"+
                "Agradecemos a professora Denilce pelo carinho, pela atenção e pelo apoio\n\nMuito obrigado por tudo :)");
        }
    }
}
