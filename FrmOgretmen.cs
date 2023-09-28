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
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }
        sqlbaglanti baglan = new sqlbaglanti();
        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulup fr=new FrmKulup();
            fr.Show();
        }

        private void buttonGeri_Click(object sender, EventArgs e)
        {
            FrmHocaGiris fr = new FrmHocaGiris();
            fr.Show();
            this.Hide();
        }

        private void buttonCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDers_Click(object sender, EventArgs e)
        {
            FrmDersler fb = new FrmDersler();
            fb.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmOgrenciler fh = new FrmOgrenciler();
            fh.Show();
            this.Hide();
        }

        private void btnSınavNotları_Click(object sender, EventArgs e)
        {
            FrmSınavNotlar fp = new FrmSınavNotlar();
            fp.Show();
            this.Hide();
        }
    }
}
