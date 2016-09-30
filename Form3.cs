using System;
using System.Collections;
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
    public partial class Form3 : Form
    {
        int TamanioColumnasFilas = 4;
        int Movimientos = 0;
        int CantidadDeCartasVolteadas = 0;
        List<string> CartasEnumeradas;
        List<string> CartasRevueltas;
        ArrayList CartasSeleccionadas;
        PictureBox CartaTemporal1;
        PictureBox CartaTemporal2;
        int CartaActual = 0;

        public Form3()
        {
            InitializeComponent();
            

            iniciarJuego2();
        }

        public void iniciarJuego()
        {
            var tablaPanel = new TableLayoutPanel();
            tablaPanel.RowCount = TamanioColumnasFilas;
            tablaPanel.ColumnCount = TamanioColumnasFilas;
            for (int i = 0; i < TamanioColumnasFilas; i++)
            {
                var Porcentaje = 150f / (float)TamanioColumnasFilas - 10;
                tablaPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, Porcentaje));
                tablaPanel.RowStyles.Add(new RowStyle(SizeType.Percent, Porcentaje));
            }

            List<Button> buttons = new List<Button>();

            for (var i = 0; i < TamanioColumnasFilas; i++)
            {
                for (var j = 0; j < TamanioColumnasFilas; j++)
                {
                    Button newButton = new Button();
                    newButton.Location = new System.Drawing.Point(371, 12 + (i * 21));
                    newButton.Name = i.ToString() + "-" + j.ToString();
                    newButton.Size = new System.Drawing.Size(95, 23);
                    newButton.TabIndex = 2;
                    newButton.Text = i.ToString() + " - " + j.ToString();
                    newButton.UseVisualStyleBackColor = true;
                    //newButton.Click += bt0_Click;
                    newButton.Click += test0;
                    buttons.Add(newButton);
                    tablaPanel.Controls.Add(newButton, j, i);
                }
            }
            tablaPanel.Dock = DockStyle.Fill;
            panel1.Controls.Add(tablaPanel);
        }

        public void iniciarJuego2()
        {
            var tablaPanel = new TableLayoutPanel();
            tablaPanel.RowCount = TamanioColumnasFilas;
            tablaPanel.ColumnCount = 1;
            for (int i = 0; i < TamanioColumnasFilas; i++)
            {
                var Porcentaje = 150f / (float)TamanioColumnasFilas - 10;
                tablaPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, Porcentaje));
                tablaPanel.RowStyles.Add(new RowStyle(SizeType.Percent, Porcentaje));
            }

            List<Button> buttons = new List<Button>();

            for (var i = 0; i < TamanioColumnasFilas; i++)
            {
                    Button newButton = new Button();
                    newButton.Location = new System.Drawing.Point(371, 12 + (i * 21));
                    newButton.Name = i.ToString() + "-" + i.ToString();
                    newButton.Size = new System.Drawing.Size(95, 23);
                    newButton.TabIndex = 2;
                    newButton.Text = i.ToString() + " - " + i.ToString();
                    newButton.UseVisualStyleBackColor = true;
                    //newButton.Click += bt0_Click;
                    newButton.Click += test0;
                    buttons.Add(newButton);
                    tablaPanel.Controls.Add(newButton, 0, i);
            }
            tablaPanel.Dock = DockStyle.Fill;
            panel1.Controls.Add(tablaPanel);
        }

        private void btnCarta_Click(object sender, EventArgs e)
        {
            if (CartasSeleccionadas.Count < 2)
            {
                Movimientos++;
                //lblRecord.Text = Convert.ToString(Movimientos);
                var CartasSeleccionadasUsuario = (PictureBox)sender;

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
        
        private void Form3_Load(object sender, EventArgs e)
        {
            List<Button> buttons = new List<Button>();
            for (int i = 0; i < 5; i++)
            {
                Button newButton = new Button();
                newButton.Location = new System.Drawing.Point(371, 12 + (i * 21));
                newButton.Name = "bt" + i.ToString();
                newButton.Size = new System.Drawing.Size(95, 23);
                newButton.TabIndex = 2;
                newButton.Text = "bt11" + i.ToString();
                newButton.UseVisualStyleBackColor = true;
                string nom = "bt" + i.ToString() + "_Click";
                
                newButton.Click += new System.EventHandler(bt0_Click);

                buttons.Add(newButton);
                
                Controls.Add(newButton);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void test0(object sender, EventArgs e)
        {
            var result = sender.GetType().GetProperties().Single(x => x.Name == "Name").GetValue(sender, null);
            var result2 = sender.GetType().GetProperties().Single(x => x.Name == "Text").GetValue(sender, null);
        }

        private void bt0_Click(object sender, EventArgs e)
        {
            var result = sender.GetType().GetProperties().Single(x => x.Name == "Name").GetValue(sender, null);
            var result2 = sender.GetType().GetProperties().Single(x => x.Name == "Text").GetValue(sender, null);
        }


    }
}
