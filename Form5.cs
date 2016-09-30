using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memorama
{
    public partial class Form5 : Form
    {
        public static int Grid_Size = 4;


        Mem_Ctrl2 mctrl = new Mem_Ctrl2(Grid_Size);
        Label lbl2 = new Label();
        public Form5()
        {
            InitializeComponent();
            Form frmM = this;
            
            mctrl.frm1(frmM);
            mctrl.Location = new Point(13, 13);
            mctrl.Name = "mem_Ctrl1";
            mctrl.Size = new Size(368, 150);
            Controls.Add(mctrl);
            
        }

        public void labl(Label lbl)
        {
            label1.Text = lbl.Text;

        }
    }
}
