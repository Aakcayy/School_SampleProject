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
    public partial class FrmSistemeGiris : Form
    {
        public FrmSistemeGiris()
        {
            InitializeComponent();
        }
        sqlbaglanti baglan = new sqlbaglanti();
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            
                SqlCommand cmd = new SqlCommand(@"Select  * From dbo.Ogrenciler where OgrID=@p1 and OgrAd=@p2", baglan.baglanti());
                cmd.Parameters.AddWithValue("@p1", txtID.Text);
                cmd.Parameters.AddWithValue("@p2", txtAdSoyad.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    FrmOgrenciNotlar fr = new FrmOgrenciNotlar();
                    fr.Ad = txtAdSoyad.Text;
                   
                    fr.Show();
                }
            
           
        }
    }
}
