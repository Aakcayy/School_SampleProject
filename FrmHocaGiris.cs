using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okul_OrnekProje
{
    public partial class FrmHocaGiris : Form
    {
        public FrmHocaGiris()
        {
            InitializeComponent();
        }
        sqlbaglanti baglan = new sqlbaglanti();
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(@"Select  * From dbo.Ogretmenler where OgrtID=@p1 and OgrtAdSoyad=@p2", baglan.baglanti());
            cmd.Parameters.AddWithValue("@p1", txtID.Text);
            cmd.Parameters.AddWithValue("@p2", txtAdSoyad.Text);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                FrmOgretmen fr=new FrmOgretmen();
                

                fr.Show();
            }
            baglan.baglanti().Close();
        }
    }
}
