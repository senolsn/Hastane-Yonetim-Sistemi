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
    public partial class FrmBransPaneli : Form
    {
        public FrmBransPaneli()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        MovementBar move = new MovementBar();
        private void FrmBransPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Branslar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komutEkle = new SqlCommand("insert into Tbl_Branslar (BransAd) values (@p1)", bgl.baglanti());
            komutEkle.Parameters.AddWithValue("@p1", txtBransAd.Text);
            komutEkle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş  Oluşturuldu !", "Branş Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutSil = new SqlCommand("Delete from Tbl_Branslar where Bransid=@p1", bgl.baglanti());
            komutSil.Parameters.AddWithValue("@p1", txtBransId.Text);
            komutSil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Silindi !", "Branş Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenHücre = dataGridView1.SelectedCells[0].RowIndex;
            txtBransId.Text = dataGridView1.Rows[secilenHücre].Cells[0].Value.ToString();
            txtBransAd.Text = dataGridView1.Rows[secilenHücre].Cells[1].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutGüncelle = new SqlCommand("Update Tbl_Branslar set BransAd=@p1 where Bransid=@p2", bgl.baglanti());
            komutGüncelle.Parameters.AddWithValue("@p1", txtBransAd.Text);
            komutGüncelle.Parameters.AddWithValue("@p2", txtBransId.Text);
            komutGüncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Güncellendi !", "Branş Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
