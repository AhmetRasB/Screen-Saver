using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screen_Saver
{
    public partial class FormSCSaver : Form
    {
        List<Image> imagesBB = new List<Image>();
        List<Britpic> britPics = new List<Britpic>();
        Random rnd = new Random();
        class Britpic
        {
            public int Picnum;
            public float X;
            public float Y;
            public float Speed;
            
        }
        public FormSCSaver()
        {
            InitializeComponent();
        }

        private void FormSCSaver_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        private void FormSCSaver_Load(object sender, EventArgs e)
        {
            string[] images =  System.IO.Directory.GetFiles("img") ;
            foreach (string image in images) { 
                imagesBB.Add(new Bitmap(image));

            }
            for(int i = 0; i<50;i++)
            {
                Britpic britpicz = new Britpic();
                britpicz.Picnum = i%imagesBB.Count;
                britpicz.X = rnd.Next(0,Width);
                britpicz.Y = rnd.Next(0,Height);
                britPics.Add(britpicz);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void FormSCSaver_Paint(object sender, PaintEventArgs e)
        {
            foreach (Britpic bp in britPics) {
                e.Graphics.DrawImage(imagesBB[bp.Picnum],bp.X,bp.Y);
                bp.X -= 2 ;
                if (bp.X < -250)
                {
                    bp.X=Width+rnd.Next(20,200);
                }

            }
        }
    }
}
