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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        MovementBar move = new MovementBar();
        private void lnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit formAc = new FrmHastaKayit();
            formAc.Show();
            
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar Where HastaTC =@p1 and HastaSifre =@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTC.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmHastaDetay formAc = new FrmHastaDetay();
                formAc.tc = mskTC.Text;
                formAc.Show();
                this.Hide();
              
            }
            else
            {
                MessageBox.Show("Hatalı TC veya Şifre Lütfen Tekrar Deneyin !", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            bgl.baglanti().Close();
            

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

            move.mov = 1;
            move.movX = e.X;
            move.movY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move.mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - move.movX, MousePosition.Y - move.movY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move.mov = 0;
        }
    }
}
