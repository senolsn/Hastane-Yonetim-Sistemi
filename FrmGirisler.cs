using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Yonetim_Sistemi
{
    public partial class FrmGirisler : Form
    {
        MovementBar move = new MovementBar();
        public FrmGirisler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmHastaGiris formAc = new FrmHastaGiris();
            formAc.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDoktorGiris formAc = new FrmDoktorGiris();
            formAc.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSekreterGiris formAc = new FrmSekreterGiris();
            formAc.Show();
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
