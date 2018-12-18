using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Grafic
{
    public partial class frmGrafic : Form
    {
        int[] LungimeBare=new int [10];
        int PozitieDreapta=100;
        int PozitieJos=400;
        int InaltimeMaximaBara = 100;
        int Aliniere = 30;
        int LatimeBara = 25;
        int LungimeAxaX=320;
        int LungimeAxaY = 300;
        int MarimeSageata = 4;
        Point inceput = new Point();
        Point sfarsit = new Point();
        System.Drawing.Graphics Desen;
        System.Drawing.Pen Creion_negru;
        System.Drawing.Pen Creion_albastru;
        Random random = new Random();
        public frmGrafic()
        {
            InitializeComponent();
        }
        public void NumereAleatorii()
        {
            int i;
            for (i = 0; i <= 9;i++)
            {
                LungimeBare[i]= random.Next(0, 100);
                inceput.X = PozitieDreapta + i * Aliniere;
                inceput.Y = PozitieJos;
                sfarsit.X = PozitieDreapta + i * Aliniere;
                sfarsit.Y = PozitieJos-InaltimeMaximaBara - LungimeBare[i];
                Desen.DrawRectangle(Creion_albastru, inceput.X + 5, 300 + LungimeBare[i], LatimeBara, InaltimeMaximaBara - LungimeBare[i]);
                Point LocText = new Point();
                Font font = new Font("Arial", 12);
                LocText.X = PozitieDreapta + 10 + i * Aliniere;
                LocText.Y = 280 + LungimeBare[i];
                string valoare = Convert.ToString(InaltimeMaximaBara - LungimeBare[i]);
                Desen.DrawString(valoare, font, Brushes.Green, LocText);
                LocText.X = PozitieDreapta + 20 + i * Aliniere;
                LocText.Y = PozitieJos;
               valoare = Convert.ToString(i);
               TextInclinat(Desen, 45, "Val" + valoare, LocText.X, LocText.Y, font, Brushes.Red);
               
            }
        }
         private void TextInclinat(Graphics gr, float angle,
            string txt, int x, int y, Font the_font, Brush the_brush)
        {
            // Salvare stare zona de desenare.
            GraphicsState state = gr.Save();
            gr.ResetTransform();
            // Rotim zona de desen.
            gr.RotateTransform(angle);
            // Deplasam textul la pozitia dorita.
            gr.TranslateTransform(x, y, MatrixOrder.Append);
             // desenam textul in origine.
            gr.DrawString(txt, the_font, the_brush, 0, 0);
            // Restabilim starea initiala a zonei de desen.
            gr.Restore(state);
        }
        private void TraseazaAxe()
        {
            Desen = this.CreateGraphics();
            Desen.Clear(this.BackColor);
            Creion_negru = new System.Drawing.Pen(System.Drawing.Color.Black);
            Creion_negru.Width = 2;
            Creion_albastru = new System.Drawing.Pen(System.Drawing.Color.Blue);
            inceput.X = PozitieDreapta;
            inceput.Y = PozitieJos;
            sfarsit.X = PozitieDreapta + LungimeAxaX;
            sfarsit.Y = PozitieJos;
            Desen.DrawLine(Creion_negru, inceput, sfarsit);
            Desen.DrawLine(Creion_negru, PozitieDreapta, PozitieJos - LungimeAxaY, PozitieDreapta + MarimeSageata, PozitieJos - LungimeAxaY + MarimeSageata);
            Desen.DrawLine(Creion_negru, PozitieDreapta, PozitieJos - LungimeAxaY, PozitieDreapta - MarimeSageata, PozitieJos - LungimeAxaY + MarimeSageata);
            sfarsit.X = PozitieDreapta;
            sfarsit.Y = PozitieJos - LungimeAxaY;
            Desen.DrawLine(Creion_negru, inceput, sfarsit);
            Desen.DrawLine(Creion_negru, PozitieDreapta + LungimeAxaX + MarimeSageata, PozitieJos, PozitieDreapta + LungimeAxaX, PozitieJos - MarimeSageata);
            Desen.DrawLine(Creion_negru, PozitieDreapta + LungimeAxaX + MarimeSageata, PozitieJos, PozitieDreapta + LungimeAxaX, PozitieJos + MarimeSageata);
 }


        private void timer1_Tick(object sender, EventArgs e)
        {
            TraseazaAxe();
            NumereAleatorii();
        }

       
    }
}

