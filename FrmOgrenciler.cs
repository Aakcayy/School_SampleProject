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
    public partial class FrmOgrenciler : Form
    {
        public FrmOgrenciler()
        {
            InitializeComponent();
        }
        sqlbaglanti baglan = new sqlbaglanti();
        string c = "";
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        void cinsiyet()
        {
            if (rbErkek.Checked == true)
            {
                c = "Erkek";
            }
            if (rbKız.Checked == true)
            {
                c = "Kız";
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            FrmOgretmen fr = new FrmOgretmen();
            fr.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmOgrenciler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            SqlDataAdapter df= new SqlDataAdapter("Select * From dbo.Kulupler", baglan.baglanti());
            DataTable dt = new DataTable();
            df.Fill(dt);
            cmbKulup.DisplayMember = "KulupAd";
            cmbKulup.ValueMember = "KulupID";
            cmbKulup.DataSource= dt;

            baglan.baglanti().Close();
        }
        
        private void btnekle_Click(object sender, EventArgs e)
        {
            cinsiyet();
            
            ds.OgrenciEkle(txtAd.Text, txtSoyad.Text, byte.Parse(cmbKulup.SelectedValue.ToString()), c);
            MessageBox.Show("Ders güncelleme işlemi yapılmıştır", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtID.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (rbKız.Text == dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString())
            {
                rbKız.Checked = true;
            }
            else if(rbErkek.Text == dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString())
            {
                rbErkek.Checked = true;
            }
            else
            {
                rbErkek.Checked = false;
                 rbKız.Checked = false;
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            cinsiyet();
            ds.OgrenciGuncelle(txtAd.Text, txtSoyad.Text, byte.Parse(cmbKulup.SelectedValue.ToString()), c,int.Parse(txtID.Text));
            MessageBox.Show("Güncelleme işlemi yapılmıştır", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciGetir(txtAra.Text);
        }
    }
}
