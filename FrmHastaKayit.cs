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
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void btnKaydol_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert  Into Tbl_Hastalar (HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTC.Text);
            komut.Parameters.AddWithValue("@p4", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p5", txtSifre.Text);
            komut.Parameters.AddWithValue("@p6", cmbCinsiyet.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt İşlemi Tamamlandı!"+" "+"Şifreniz :"+txtSifre.Text, "Kaydınız Oluşturuldu.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();

        }
    }
}
