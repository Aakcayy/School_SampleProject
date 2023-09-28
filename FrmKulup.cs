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
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
        sqlbaglanti baglan = new sqlbaglanti();
        void listele()
        {
            SqlDataAdapter dt = new SqlDataAdapter("Select * From dbo.Kulupler", baglan.baglanti());
            DataTable dm = new DataTable();
            dt.Fill(dm);
            dataGridView1.DataSource = dm;
            baglan.baglanti().Close();
        }
        private void FrmKulup_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("Insert into dbo.Kulupler (KulupAd) values('"+txtAd.Text+"')",baglan.baglanti());
            komut.ExecuteNonQuery();
            MessageBox.Show("Kulüp listeye eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            baglan.baglanti().Close();
            listele();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmOgretmen fr = new FrmOgretmen();
            fr.Show();
            this.Hide();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Black;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Red;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) //Tek başına olan e >> Hücre görünümü olaylarına çalışan bir parametre
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
           SqlCommand dt= new SqlCommand("Delete From dbo.Kulupler where KulupID='"+txtID.Text+"'",baglan.baglanti());
            dt.ExecuteNonQuery();
            baglan.baglanti().Close();
            MessageBox.Show("Kulüp silme işlemi gerçekleşmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Update dbo.Kulupler set KulupAD='"+txtAd.Text+"'"+"where KulupId='"+txtID.Text+"'",baglan.baglanti());
            komut2.ExecuteNonQuery();
            baglan.baglanti().Close();
            MessageBox.Show("Kulüp güncelleme işlemi gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
    }
}
