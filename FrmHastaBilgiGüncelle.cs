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
    public partial class FrmHastaBilgiGüncelle : Form
    {
        public FrmHastaBilgiGüncelle()
        {
            InitializeComponent();
        }
        public string TCno;
        SqlBaglantisi bgl = new SqlBaglantisi();
        MovementBar move = new MovementBar();
        private void FrmHastaBilgiGüncelle_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar where HastaTC="+TCno, bgl.baglanti());;
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
             {
               txtAd.Text = dr[1].ToString();
               txtSoyad.Text = dr[2].ToString();
               mskTC.Text = dr[3].ToString();
               mskTelefon.Text = dr[4].ToString();
               txtSifre.Text = dr[5].ToString();
               cmbCinsiyet.Text = dr[6].ToString();
             }
                bgl.baglanti().Close();
            
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update Tbl_Hastalar set HastaAd=@p1,HastaSoyad=@p2,HastaTelefon=@p3,HastaSifre=@p4,HastaCinsiyet=@p5 where HastaTC="+TCno, bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtAd.Text);
            komut2.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut2.Parameters.AddWithValue("@p3", mskTelefon.Text);
            komut2.Parameters.AddWithValue("@p4", txtSifre.Text);
            komut2.Parameters.AddWithValue("@p5", cmbCinsiyet.Text);
            komut2.ExecuteNonQuery();
            MessageBox.Show("Bilgileriniz Başarıyla Güncellendi","Bilgi Güncellemesi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            bgl.baglanti().Close();
            this.Hide();
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
