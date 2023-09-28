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

namespace Okul_OrnekProje
{
    public partial class FrmGirisler : Form
    {
        public FrmGirisler()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSistemeGiris frm = new FrmSistemeGiris();
            frm.Show();
        }

        private void btnOgretmenGiris_Click(object sender, EventArgs e)
        {
            FrmHocaGiris fr = new FrmHocaGiris();
            fr.Show();
        }
    }
}
