using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using memorama.Clase;

namespace memorama
{
    public partial class Form4 : Form
    {
        Mem_Ctrl mctrl = new Mem_Ctrl();
        
        public Form4()
        {
            InitializeComponent();
            mctrl.Location = new Point(13, 13);
            mctrl.Name = "mem_Ctrl1";
            mctrl.Size = new Size(368, 150);
            Controls.Add(mctrl);
            label1.Text = mctrl.L_Mov2;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = mctrl.L_Mov;
        }


        
          


        
    }
}
