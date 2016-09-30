using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace memorama.Ctrl
{
    public partial class Memorama1 : UserControl
    {
        int Movimientos = 0;
        int CantidadDeCartasVolteadas = 0;
        List<string> CartasEnumeradas;// = new List<string>();
        List<string> CartasRevueltas;// = new List<string>();
        ArrayList CartasSeleccionadas;// = new ArrayList();
        PictureBox CartaTemporal1;
        PictureBox CartaTemporal2;
        int CartaActual = 0;

        

        public static int Grid_Size;

        Form frm;

        public Memorama1(int Gs)
        {
            InitializeComponent();
            
            Grid_Size = Gs;
             /*
            Random_Cards();
            Dimension_Define();
            panel1.Controls.Add(Fill_Panel());
              */
            master();
        }


        public void master()
        {
            timer1.Enabled = false;
            timer1.Stop();
            label1.Text = "0";
            CantidadDeCartasVolteadas = 0;
            Movimientos = 0;
            panel1.Controls.Clear();
            CartasEnumeradas = new List<string>();
            CartasRevueltas = new List<string>();
            CartasSeleccionadas = new ArrayList();

            //for (int i = 0; i < 8; i++)
            for (int i = 0; i < ((Grid_Size * Grid_Size) / 2); i++) 
            {
                CartasEnumeradas.Add(i.ToString());
                CartasEnumeradas.Add(i.ToString());
            }
            var NumeroAleatorio = new Random();
            var Resultado = CartasEnumeradas.OrderBy(item => NumeroAleatorio.Next());
            var a = Resultado.Count();

            foreach (string ValorCarta in Resultado)
            {
                CartasRevueltas.Add(ValorCarta);
            }
            //----
            TableLayoutPanel tablaPanel = new TableLayoutPanel();
            tablaPanel.RowCount = Grid_Size;
            tablaPanel.ColumnCount = Grid_Size;
            for (int i = 0; i < Grid_Size; i++)
            {
                var Porcentaje = 150f / (float)Grid_Size - 10;
                //tablaPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, Porcentaje));
                tablaPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,1));
                tablaPanel.RowStyles.Add(new RowStyle(SizeType.Percent, Porcentaje));
            }
            //----
            int contadorFichas = 1;
            for (var i = 0; i < Grid_Size; i++)
            {
                for (var j = 0; j < Grid_Size; j++)
                {
                    var CartasJuego = new PictureBox();
                    CartasJuego.Name = string.Format("{0}", contadorFichas);
                    CartasJuego.Dock = DockStyle.Fill;
                    CartasJuego.SizeMode = PictureBoxSizeMode.StretchImage;
                    //CartasJuego.Image = Properties.Resources.Girada;
                    CartasJuego.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("Aimg" + CartasJuego.Name);
                    //default: TmpImg = (Bitmap)Properties.Resources.ResourceManager.GetObject("Aimg" + NumeroImagen);
                    CartasJuego.Cursor = Cursors.Hand;
                    CartasJuego.Click += btnCarta_Click;
                    tablaPanel.Controls.Add(CartasJuego, j, i);
                    contadorFichas++;
                }
            }
            tablaPanel.Dock = DockStyle.Fill;
            panel1.Controls.Add(tablaPanel);
        }

        /*
        public void Random_Cards()
        {
            timer1.Enabled = false;
            timer1.Stop();
            //L_Mov = "0";
            label1.Text = "0";
  
            CantidadDeCartasVolteadas = 0;
            Movimientos = 0;
            panel1.Controls.Clear();

            for (int i = 0; i < 8; i++)
            {
                CartasEnumeradas.Add(i.ToString());
                CartasEnumeradas.Add(i.ToString());
            }
            var NumeroAleatorio = new Random();
            var Resultado = CartasEnumeradas.OrderBy(item => NumeroAleatorio.Next());

            foreach (string ValorCarta in Resultado)
            {
                CartasRevueltas.Add(ValorCarta);
            }
        }

        public void Dimension_Define()
        {
            tablaPanel.RowCount = Grid_Size;
            tablaPanel.ColumnCount = Grid_Size;
            for (int i = 0; i < Grid_Size; i++)
            {
                var Porcentaje = 150f / (float)Grid_Size - 10;
                tablaPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, Porcentaje));
                tablaPanel.RowStyles.Add(new RowStyle(SizeType.Percent, Porcentaje));
            }
        }

        public TableLayoutPanel Fill_Panel()
        {
            int contadorFichas = 1;
            for (var i = 0; i < Grid_Size; i++)
            {
                for (var j = 0; j < Grid_Size; j++)
                {
                    var CartasJuego = new PictureBox();
                    CartasJuego.Name = string.Format("{0}", contadorFichas);
                    CartasJuego.Dock = DockStyle.Fill;
                    CartasJuego.SizeMode = PictureBoxSizeMode.StretchImage;
                    CartasJuego.Image = Properties.Resources.Girada;
                    CartasJuego.Cursor = Cursors.Hand;
                    //CartasJuego.Click += test0;
                    CartasJuego.Click += btnCarta_Click;
                    tablaPanel.Controls.Add(CartasJuego, j, i);
                    contadorFichas++;
                }
            }
            tablaPanel.Dock = DockStyle.Fill;
            return tablaPanel;
        }

        private void test0(object sender, EventArgs e)
        {
            var result = sender.GetType().GetProperties().Single(x => x.Name == "Name").GetValue(sender, null);
            var result2 = sender.GetType().GetProperties().Single(x => x.Name == "Text").GetValue(sender, null);
        }

        
        */
        private void btnCarta_Click(object sender, EventArgs e)
        {
            if (CartasSeleccionadas.Count < 2)
            {
                Movimientos++;
                //L_Mov = Convert.ToString(Movimientos);
                label1.Text = Convert.ToString(Movimientos);
                var CartasSeleccionadasUsuario = (PictureBox)sender;
                var ubisel = CartasSeleccionadasUsuario.Name;

                CartaActual = Convert.ToInt32(CartasRevueltas[Convert.ToInt32(CartasSeleccionadasUsuario.Name) - 1]);
                CartasSeleccionadasUsuario.Image = RecuperarImagen(CartaActual);
                CartasSeleccionadas.Add(CartasSeleccionadasUsuario);
                //  2 Veces se realizo el evento del click
                if (CartasSeleccionadas.Count == 2)
                {
                    CartaTemporal1 = (PictureBox)CartasSeleccionadas[0];
                    CartaTemporal2 = (PictureBox)CartasSeleccionadas[1];
                    int Carta1 = Convert.ToInt32(CartasRevueltas[Convert.ToInt32(CartaTemporal1.Name) - 1]);
                    int Carta2 = Convert.ToInt32(CartasRevueltas[Convert.ToInt32(CartaTemporal2.Name) - 1]);

                    if (Carta1 != Carta2)
                    {
                        timer1.Enabled = true;
                        timer1.Start();
                    }
                    else
                    {
                        CantidadDeCartasVolteadas++;
                        if (CantidadDeCartasVolteadas > 7)
                        {
                            MessageBox.Show("El juego termino");
                        }
                        CartaTemporal1.Enabled = false; CartaTemporal2.Enabled = false;
                        CartasSeleccionadas.Clear();
                    }
                }
            }
        }

        public Bitmap RecuperarImagen(int NumeroImagen)
        {
            Bitmap TmpImg = new Bitmap(200, 100);
            switch (NumeroImagen)
            {
                case 0: TmpImg = Properties.Resources.Aimg11;
                    break;
                default: TmpImg = (Bitmap)Properties.Resources.ResourceManager.GetObject("Aimg" + NumeroImagen);
                    break;
            }
            return TmpImg;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int TiempoVirarCarta = 1;
            if (TiempoVirarCarta == 1)
            {
                CartaTemporal1.Image = Properties.Resources.Girada;
                CartaTemporal2.Image = Properties.Resources.Girada;
                CartasSeleccionadas.Clear();
                TiempoVirarCarta = 0;
                timer1.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            master();
        }
    }
}
