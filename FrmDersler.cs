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
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.DerslerTableAdapter ds = new DataSet1TableAdapters.DerslerTableAdapter();//Her yerden ulaşabilmek için globale yazdım
        private void FrmDersler_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = ds.DersListesi(); //Datasette belirttiğim method
           
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(txtAd.Text);
            MessageBox.Show("Ders eklenme işlemi yapılmıştır", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
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

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(txtID.Text));
            MessageBox.Show("Ders silme işlemi yapılmıştır", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {

            ds.DersGuncelle(txtAd.Text,byte.Parse(txtID.Text));
            MessageBox.Show("Ders güncelleme işlemi yapılmıştır", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
