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
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }
        public string tcNo;
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            //Ad Soyad 
            lblKimlikNo.Text = tcNo;
            SqlCommand komut = new SqlCommand("Select SekreterAdSoyad From Tbl_Sekreter where SekreterTC=" + tcNo, bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();


            //Branşları çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Branslar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Doktorları Listeye çekme
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select (DoktorAd + ' ' + DoktorSoyad) as 'Doktorlar',DoktorBrans From Tbl_Doktorlar", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;

            //Branşları Getirme
            SqlCommand komutbrans = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr2 = komutbrans.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            


        }

        private void btnRandevuKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into Tbl_Randevular(RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values (@r1,@r2,@r3,@r4)", bgl.baglanti());
            komutkaydet.Parameters.AddWithValue("@r1", mskTarih.Text);
            komutkaydet.Parameters.AddWithValue("@r2", mskSaat.Text);
            komutkaydet.Parameters.AddWithValue("@r3", cmbBrans.Text);
            komutkaydet.Parameters.AddWithValue("@r4", cmbDoktor.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu !", "Randevu Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();
            // Doktorları Çekme
            SqlCommand komutdoktor = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@p1", bgl.baglanti());
            komutdoktor.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader drdoktor = komutdoktor.ExecuteReader();
            while (drdoktor.Read())
            {
                cmbDoktor.Items.Add(drdoktor[0] +" "+ drdoktor[1]);
            }
            bgl.baglanti().Close();
        }

        private void btnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand komutDuyuru = new SqlCommand("insert into Tbl_Duyurular (Duyuru) values (@p1)", bgl.baglanti());
            komutDuyuru.Parameters.AddWithValue("@p1", rtbDuyuru.Text);
            komutDuyuru.ExecuteNonQuery();
            bgl.baglanti().Close();
            rtbDuyuru.Text = "";
            MessageBox.Show("Duyuru Oluşturuldu !", "Duyuru Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDoktorPaneli_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli formAc = new FrmDoktorPaneli();
            formAc.Show();
        }

        private void btnBransPaneli_Click(object sender, EventArgs e)
        {
            FrmBransPaneli formAc = new FrmBransPaneli();
            formAc.Show();
        }

        private void btnRandevuListesi_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi formAc = new FrmRandevuListesi();
            formAc.Show();
        }

        private void btnDuyuruListesi_Click(object sender, EventArgs e)
        {
            FrmDuyurular formAc = new FrmDuyurular();
            formAc.Show();
        }
    }
}
