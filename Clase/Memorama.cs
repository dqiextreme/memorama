using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using memorama.Clase;

namespace memorama.Clase
{
    /*
public class Adjunto2
{
public int ID { get; set; }
public string Archivo { get; set; }
public string Ruta { get; set; }
        
public Adjunto2()
{
            
}

//agregar referencia "System.Data.Linq" en agregar refencia al proyecto para pode rusar sqlmethods
//Requerido para cualquier funcion que retorne algun valor
private Adjunto2(Models.Adjunto pTicket)
{
ID = pTicket.ID;
Ruta = pTicket.Ruta;
Archivo = pTicket.Archivo;
}
    */

    public class Memorama
    {
              
        
        public static int Grid_Size = 4;
        public static int Movimientos = 0;
        public static int CantidadDeCartasVolteadas = 0;
        public static List<string> CartasEnumeradas = new List<string>();
        public static List<string> CartasRevueltas = new List<string>();
        public static ArrayList CartasSeleccionadas;
        public static PictureBox CartaTemporal1;
        public static PictureBox CartaTemporal2;
        public static int CartaActual = 0;

        public static TableLayoutPanel tablaPanel = new TableLayoutPanel();

        public static int Grid_Size2 { get; set; }

        public static void Value_Define(int Grid_Size_Val)
        {
            Grid_Size = Grid_Size_Val;
        }

        public static void Random_Cards()
        {
            CantidadDeCartasVolteadas = 0;
            Movimientos = 0;
            
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

        public static void Dimension_Define()
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
                    //CartasJuego.Click += button1;
                    tablaPanel.Controls.Add(CartasJuego, j, i);
                    contadorFichas++;
                }
            }
            tablaPanel.Dock = DockStyle.Fill;
            return tablaPanel;
        }

        public static void master()
        {
            ////lblRecord.Text = "0";
            //CantidadDeCartasVolteadas = 0;
            //Movimientos = 0;
            ////PanelJuego.Controls.Clear();
            //CartasEnumeradas = new List<string>();
            //CartasRevueltas = new List<string>();
            //CartasSeleccionadas = new ArrayList();
            //for (int i = 0; i < 8; i++)
            //{
            //    CartasEnumeradas.Add(i.ToString());
            //    CartasEnumeradas.Add(i.ToString());
            //}
            //var NumeroAleatorio = new Random();
            //var Resultado = CartasEnumeradas.OrderBy(item => NumeroAleatorio.Next());
            //foreach (string ValorCarta in Resultado)
            //{
            //    CartasRevueltas.Add(ValorCarta);
            //}


            //var tablaPanel = new TableLayoutPanel();
            //tablaPanel.RowCount = Grid_Size;
            //tablaPanel.ColumnCount = Grid_Size;
            //for (int i = 0; i < Grid_Size; i++)
            //{
            //    var Porcentaje = 150f / (float)Grid_Size - 10;
            //    tablaPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, Porcentaje));
            //    tablaPanel.RowStyles.Add(new RowStyle(SizeType.Percent, Porcentaje));
            //}


            //int contadorFichas = 1;

            //for (var i = 0; i < Grid_Size; i++)
            //{
            //    for (var j = 0; j < Grid_Size; j++)
            //    {
            //        var CartasJuego = new PictureBox();
            //        CartasJuego.Name = string.Format("{0}", contadorFichas);
            //        CartasJuego.Dock = DockStyle.Fill;
            //        CartasJuego.SizeMode = PictureBoxSizeMode.StretchImage;
            //        CartasJuego.Image = Properties.Resources.Girada;
            //        CartasJuego.Cursor = Cursors.Hand;
            //        //CartasJuego.Click += btnCarta_Click;
            //        tablaPanel.Controls.Add(CartasJuego, j, i);
            //        contadorFichas++;
            //    }
            //}
            //tablaPanel.Dock = DockStyle.Fill;
            //PanelJuego.Controls.Add(tablaPanel);
        }

        

    }
}
