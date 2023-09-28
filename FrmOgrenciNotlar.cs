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
    public partial class FrmOgrenciNotlar : Form
    {
        
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }
        public string Ad;
        sqlbaglanti baglan = new sqlbaglanti();
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void yenile()
        {
            this.Text = "Öğrenci:  " + Ad.ToString();
            SqlCommand cm = new SqlCommand("Select DersAd,Sinav1,Sinav2,Sinav3,Proje,Ortalama,Durum From dbo.Notlar\r\nINNER JOIN dbo.Dersler on dbo.Notlar.DersID=dbo.Dersler.DersID where OgrID=1", baglan.baglanti());
            cm.Parameters.AddWithValue("@p1", Ad);
            DataTable dm = new DataTable();
            SqlDataAdapter dt = new SqlDataAdapter(cm);

            dt.Fill(dm);
            dataGridView1.DataSource = dm;
        }
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            yenile();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            yenile();
        }
    }
}
