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

namespace Hastane_Yonetim_Sistemi
{
    public partial class FrmDoktorPaneli : Form
    {
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
 
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Doktorlar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlCommand komutVeriCekme = new SqlCommand("Select BransAd from Tbl_Branslar", bgl.baglanti());
            SqlDataReader drVeri = komutVeriCekme.ExecuteReader();
            while (drVeri.Read())
            {
                cmbBrans.Items.Add(drVeri[0].ToString());
            }
            bgl.baglanti().Close();




        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komutEkle = new SqlCommand("insert into Tbl_Doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
            komutEkle.Parameters.AddWithValue("@p1", txtAd.Text);
            komutEkle.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komutEkle.Parameters.AddWithValue("@p3", cmbBrans.Text);
            komutEkle.Parameters.AddWithValue("@p4", mskTC.Text);
            komutEkle.Parameters.AddWithValue("@p5", txtSifre.Text);
            komutEkle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Ekleme Başarılı !", "Doktor Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Datagridview ile tıklayarak txtboxlara veriyi çekme
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskTC.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutSil = new SqlCommand("Delete from Tbl_Doktorlar where DoktorTC=@p1",bgl.baglanti());
            komutSil.Parameters.AddWithValue("@p1", mskTC.Text);
            komutSil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Silme Başarılı !", "Doktor Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutGüncelle = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p5 where DoktorTC=@p4", bgl.baglanti());
            komutGüncelle.Parameters.AddWithValue("@p1", txtAd.Text);
            komutGüncelle.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komutGüncelle.Parameters.AddWithValue("@p3", cmbBrans.Text);
            komutGüncelle.Parameters.AddWithValue("@p4", mskTC.Text);
            komutGüncelle.Parameters.AddWithValue("@p5", txtSifre.Text);
            komutGüncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Güncelleme Başarılı !", "Güncelleme Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
