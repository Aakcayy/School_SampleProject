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
    public partial class FrmSınavNotlar : Form
    {
        public FrmSınavNotlar()
        {
            InitializeComponent();
        }
        sqlbaglanti baglan = new sqlbaglanti();
        private void FrmSınavNotlar_Load(object sender, EventArgs e)
        {
            SqlDataAdapter df = new SqlDataAdapter("Select * From dbo.Dersler", baglan.baglanti());
            DataTable dt = new DataTable();
            df.Fill(dt);
            cmbDers.DisplayMember = "DersAd";
            cmbDers.ValueMember = "DersID";
            cmbDers.DataSource = dt;

            baglan.baglanti().Close();
        }
        DataSet1TableAdapters.NotlarTableAdapter ds= new DataSet1TableAdapters.NotlarTableAdapter();
        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=ds.NotListesi(int.Parse(txtID.Text));
        }
        int NotID;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NotID= int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtdurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        int sınav1, sınav2, sınav3, proje;
        double ortalama;
        string durum;

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(cmbDers.SelectedValue.ToString()),int.Parse(txtID.Text),byte.Parse(txtSınav1.Text),byte.Parse(txtSınav2.Text), byte.Parse(txtSınav3.Text), byte.Parse(txtProje.Text),decimal.Parse(txtOrtalama.Text),int.Parse(txtdurum.Text),NotID);
        }

      
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            
          
            sınav1 = Convert.ToInt16(txtSınav1.Text);
            sınav2 = Convert.ToInt16(txtSınav2.Text);
            sınav3 = Convert.ToInt16(txtSınav3.Text);
            proje = Convert.ToInt16(txtProje.Text);
            ortalama = (double)(sınav1+sınav2+sınav3+proje)/4;
            txtOrtalama.Text =ortalama.ToString();
            if (ortalama >= 50)
            {
                txtdurum.Text = "Geçti";
            }
            else
            {
                txtdurum.Text = "Kaldı";
            }
        }
    }
}
