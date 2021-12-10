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
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Sekreter where SekreterTC=@p1 and SekreterSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTC.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmSekreterDetay formAc = new FrmSekreterDetay();
                formAc.tcNo = mskTC.Text;
                formAc.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC veya Şifre Lütfen Tekrar Deneyin !", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            bgl.baglanti().Close();
        }

    }
}
