using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using memorama.Ctrl;

namespace memorama
{
    public partial class Form6 : Form
    {
        public static int Grid_Size = 4;

        //Mem_Ctrl2 mctrl = new Mem_Ctrl2(Grid_Size);
        Memorama1 mctrl = new Memorama1(Grid_Size);
        

        public Form6()
        {
            InitializeComponent();
            
            Form frmM = this;
            mctrl.Location = new Point(0, 0);
            mctrl.Name = "mem_Ctrl1";
            mctrl.Size = new Size(450, 300);
            
            
            Controls.Add(mctrl);
            
            //var a = this.Size.Width;
            //var b = this.Size.Height;
            
        }
    }
}
