using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektNr1_Piwowarski62024
{
    public partial class LaboratoriumNr1 : Form
    {
        // deklaracjce stałych
        const int Margines = 10;
        const int PromienOA = 5; // OA - Obiekt Animowany
        // deklaracja granic zbieżności szeregu
        const double DGprzedzialuX = double.MinValue;
        const double GGprzedzialuX = double.MaxValue;
        Graphics Rysownica;
        double Xd, Xg;
        double h;
        int LiczbaPrzedzialowH;
        Pen PioroXY = new Pen(Color.Blue, 1);
        Pen PioroLiniiToru = new Pen(Color.Black, 1.5f);
        Pen apTlo = new Pen(Color.DarkRed, 2.0f);
        int IndexPOA; // POA - Położenie Obiektu Animowanego
        int MaxIndexPOA;
        double[,] TWS; // TWS - Tablica Wartości Szeregu
        static LaboratoriumNr1 UchwytFormularza;

        public LaboratoriumNr1()
        {
            InitializeComponent();
            UchwytFormularza = this;
            // wstępne sformatowanie kontrolki PictureBox
            pbRysownica.BackColor = Color.LightGray;
            pbRysownica.BorderStyle = BorderStyle.Fixed3D;
            // "podpięcie" do kontrolki PictureBox mapy bitowej
            pbRysownica.Image = new Bitmap(pbRysownica.Width, pbRysownica.Height);
            // utworzenie powierzchni graficznej na BitMapie
            Rysownica = Graphics.FromImage(pbRysownica.Image);

            PioroLiniiToru.DashStyle = DashStyle.Dot;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // sprawdzenie czy OA (Obiekt Animacji) "doszedł" do prawej krawędzi
            if (IndexPOA >= MaxIndexPOA)
                // cofnięcie oA do lewej krawędzi
                IndexPOA = 0;
            else
                IndexPOA++;
            // odświeżenie powierzchni graficznej (przerysowanie całego obrazu z przesuniętym OA)
            pbRysownica.Refresh();
        }

        private void LaboratoriumNr1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // utworzenie okna dialogowego dla spytania Użytkownika o potwierdzenie przejścia do Kokpitu
            DialogResult OknoMessage = MessageBox.Show("Samoocena Sprawdzianu nr 1 = 5.0, gdyż zostały\nzrealizowane wszystkie zadania sprawdzianu.\nAutor programu: Antoni Piwowarski: 62024", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // sprawdzenie "decyzji" Użytkownika programu
            if (OknoMessage == DialogResult.Yes)
            {// odszukanie formularza głównego Kokpit w OpenForms
                foreach (Form Formularz in Application.OpenForms)
                {
                    // ukrycie bieżącego formularza
                    this.Hide();
                    // odsłonięcie znalezionego formularza głównego
                    Formularz.Show();
                    // bezwarunkowe zakończenie obsługi zdarzenia
                    return;
                }
                // gdy jesteśmy tutaj, to jest to sytuacja awaryjna
                // wyświetlenie komunikatu o awarii
                MessageBox.Show("UWAGA: wystąpiła awaria w działaniu programu i program musi zostać zamknięty", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                // zamknięcie wszystkich formularzy i zakończenie działania programu
                Application.ExitThread();
            }
            else
                // skasowanie zdarzenia FormClosing
                e.Cancel = true;
        }

        private void pbRysownica_Paint(object sender, PaintEventArgs e)
        {
            // "bezpiecznik" nie można kontynuować animacji gdy nie ma egzemplarza tablicy TWS
            if (TWS is null)
                return;
            // wyczyszczenie powierzchni graficznej 
            Rysownica.Clear(Color.LightGreen);

            AdjustableArrowCap apdużeGrotyStrzalek = new AdjustableArrowCap(5, 5);
            PioroXY.CustomEndCap = apdużeGrotyStrzalek;
            PioroXY.EndCap = LineCap.Flat;
            PioroXY.CustomStartCap = apdużeGrotyStrzalek;
            // wykreślenie osi Y
            Rysownica.DrawLine(PioroXY, PrzeliczanieWspolrzednych.WspX(0), PrzeliczanieWspolrzednych.WspY(PrzeliczanieWspolrzednych.Ymin), PrzeliczanieWspolrzednych.WspX(0), PrzeliczanieWspolrzednych.WspY(PrzeliczanieWspolrzednych.Ymax));
            PioroXY.StartCap = LineCap.Flat;
            PioroXY.CustomEndCap = apdużeGrotyStrzalek;
            Rysownica.DrawLine(PioroXY, PrzeliczanieWspolrzednych.WspX(PrzeliczanieWspolrzednych.Xmin), PrzeliczanieWspolrzednych.WspY(0), PrzeliczanieWspolrzednych.WspX(PrzeliczanieWspolrzednych.Xmax), PrzeliczanieWspolrzednych.WspY(0));

            Rysownica.DrawRectangle(apTlo, 10, 10, pbRysownica.Width-30, pbRysownica.Height-30);

            // wykreślenie linii toru 
            for (int j = 0; j < TWS.GetLength(0) - 1; j++)
                Rysownica.DrawLine(PioroLiniiToru, PrzeliczanieWspolrzednych.WspX(TWS[j, 0]), PrzeliczanieWspolrzednych.WspY(TWS[j, 1]), PrzeliczanieWspolrzednych.WspX(TWS[j + 1, 0]), PrzeliczanieWspolrzednych.WspY(TWS[j + 1, 1]));
            // wykreślenie w nowym położeniu OA (obiektu animowanego)
            Rysownica.FillEllipse(Brushes.Yellow, PrzeliczanieWspolrzednych.WspX(TWS[IndexPOA, 0]) - PromienOA, PrzeliczanieWspolrzednych.WspY(TWS[IndexPOA, 1]) - PromienOA, 2 * PromienOA, 2 * PromienOA);
        }

        bool PobranieDanychWejsciowych(out double Xd, out double Xg, out double h)
        {// pomocnicze przypisanie wartości technicznych parametrom wyjściowym
            Xd = Xg = h = 0;
            // pobranie Xd
            if (!double.TryParse(txtXd.Text, out Xd))
            {// wystąpił błąd, to go sygnalizujemy 
                errorProvider1.SetError(txtXd, "ERROR: w zapisie wartości Xd wystąpił niedozwolony znak!");
                // przerwanie pobierania danych 
                return false;
            }
            // sprawdzenie czy pobrane Xd należy do przedziału zbieżności szeregu
            if ((Xd < DGprzedzialuX) || (Xd > GGprzedzialuX))
            {
                errorProvider1.SetError(txtXd, "ERROR: pobrane Xd nie należy do przedziału zbieżności szeregu!");
                // przerwanie pobierania danych 
                return false;
            }
            if (!double.TryParse(txtXg.Text, out Xg))
            {// wystąpił błąd, to go sygnalizujemy 
                errorProvider1.SetError(txtXg, "ERROR: w zapisie wartości Xd wystąpił niedozwolony znak!");
                // przerwanie pobierania danych 
                return false;
            }
            if ((Xg < DGprzedzialuX) || (Xg > GGprzedzialuX))
            {
                errorProvider1.SetError(txtXg, "ERROR: pobrane Xd nie należy do przedziału zbieżności szeregu!");
                // przerwanie pobierania danych 
                return false;
            }
            // sprawdzenie tzw. warunku wejściowego na granice przedziału
            if (Xd > Xg)
            {
                errorProvider1.SetError(txtXd, "ERROR: nie jest spełniony warunek wejściowy: Xd < Xg, nakładany na granice przedziału zmian wartości zmiennej X!");
                // przerwanie pobierania danych 
                return false;
            }
            //pobranie przyrostu h zmian wartości zmiennej X
            if (!double.TryParse(txtH.Text, out h))
            {
                errorProvider1.SetError(txtH, "ERROR: wystąpił niedozwolony znak w zapisie wartości przyrostu 'h'");
                // przerwanie pobierania danych
                return false;
            }

            // sprawdzenie warunku wejściowego dla przyrostu 'h': 0 < h < 1
            if ((h <= 0) || (h >= 1))
            {// sygnalizacja błędu 
                errorProvider1.SetError(txtH, "ERROR: dla przyrostu h nie jest spełniony warunek wejściowy: 0 < h < 1");
                return false;
            }
            // zwrotne przekazanie informacji, że nie było błędu
            return true;
        }

        void TablicowanieSzeregu(double[,] TWS, double Xd, double Xg, double h)
        {
            // deklaracje pomocnicze
            double X;
            int i; // numer przedziału
            // tablicowanie
            for (X = Xd, i = 0; i < TWS.GetLength(0); X = Xd + i * h, i++)
            {
                TWS[i, 0] = X;
                TWS[i, 1] = ObliczenieWartosciSzeregu(X);
            }
        }
        double ObliczenieWartosciSzeregu(double X)
        {// deklaracje pomocnicze
            const double Eps = 0.0000001;
            ushort k;
            double w, S;
            // ustalenie początkowego stanu obliczeń
            w = X;
            k = 0;
            S = w;
            // sumowanie wyrazów szeregu
            while (Math.Abs(w) > Eps)
            {
                k++; // zwiększenie licznika wyrazów 
                // obliczenie k-tego wyrazu szeregu
                w = w * ((-1) * X * X) / (double)((2 * k) * (2 * k + 1));
                S = S + w;
            }
            // zwrotne przekazanie wyniku obliczeń
            return S;
        }
        private void btnAnimacja_Click(object sender, EventArgs e)
        {
            // "zgaszenie" kontrolki errorProvider
            errorProvider1.Dispose();
            // obranie danych wejściowych
            if (!PobranieDanychWejsciowych(out Xd, out Xg, out h))
                // przerwanie obsługi zdarzenia Click, gdyż w danych wejściowych wykryto błąd
                return;
            // określenie liczby przedziałow o szerokości 'h' w przedziale: [Xd, Xg]
            LiczbaPrzedzialowH = (int)((Xg - Xd) / h) + 1;
            // utworzenie egzemplarza tablicy TWS
            TWS = new double[LiczbaPrzedzialowH, 2];
            // stablicowanie szeregu
            TablicowanieSzeregu(TWS, Xd, Xg, h);
            // początkowe położenie OA (OA: Obiekt Animowany)
            IndexPOA = 0;
            // końcowe położenie OA
            MaxIndexPOA = TWS.GetLength(0) - 1;
            // włączenie zegara 
            timer1.Enabled = true;
            // ustawienie przycisku poleceń: btnAnimacja w stan brak aktywności
            btnAnimacja.Enabled = false;
        }

        // deklaracja klasy statycznej dla przeliczenia wspołrzędnych punktów rzeczywistej powierzchni graficznej
        public static class PrzeliczanieWspolrzednych
        {
            // deklaracja zmiennych dla przechowania wartości współczynników skali dla osi X oraz Y
            static double Sx, Sy;
            // deklaracja zmiennych dla przechowania wartości przesunięć wzdłuż osi X oraz Y
            static double Dx, Dy;
            // deklaracja zmiennych opisujących rozmiar graficznej powierzchni graficznej
            static int Xe_min, Xe_max, Ye_min, Ye_max;
            // deklaracja właściwości ("zmiennych") opisujących rozmiar rzeczywistej powierzchni graficznej
            public static double Xmin
            {
                get; // Xmin będzie tylko do odczytu
                private set;
            }
            public static double Xmax
            {
                get;
                private set;
            }

            public static double Ymin
            {
                get;
                private set;
            }
            public static double Ymax
            {
                get;
                private set;
            }
            // deklaracja konstruktora klasy statycznej
            static PrzeliczanieWspolrzednych()
            { // określenie wartości dla Xmin oraz Xmax
                Xmin = UchwytFormularza.Xd;
                Xmax = UchwytFormularza.Xg;
                // określenie wartości Ymin oraz Ymax
                Ymin = EkstremumSzeregu.MinSx(UchwytFormularza.TWS);
                Ymax = EkstremumSzeregu.MaxSx(UchwytFormularza.TWS);
                // określenie wartości: Xe_min, Xe_max, Ye_min i Ye_max
                Xe_min = Margines;
                Xe_max = UchwytFormularza.pbRysownica.Width - (2 * Margines);
                Ye_min = Margines;
                Ye_max = UchwytFormularza.pbRysownica.Height - (2 * Margines);
                // wyznaczenie współczynników skali po osi X oraz Y
                Sx = (Xe_max - Xe_min) / (Xmax - Xmin);
                Sy = (Ye_max - Ye_min) / (Ymax - Ymin);
                // wyznaczenie wwartości przesunięć wzdłuż osi X oraz Y
                Dx = Xe_min - Xmin * Sx;
                Dy = Ye_min - Ymin * Sy;
            } // koniec konstruktora
            /* deklaracja dwóch metod: WspX, WspY, któe umożliwiają odwzorowanie punktów z powierzchni rzeczywistej
             na punkt powierzchni graficznej formularza */
            public static int WspX(double x)
            {
                return (int)(x * Sx + Dx);
            }
            static public int WspY(double y)
            {
                return (int)(y * Sy + Dy);
            }
        }
        private void liniaKreskowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apTlo.DashStyle = DashStyle.Dash;
        }

        private void liniaKreskowoKropkowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apTlo.DashStyle = DashStyle.DashDot;
        }

        private void liniaKreskowoKropkowaKropkowaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            apTlo.DashStyle = DashStyle.DashDotDot;
        }

        private void liniaKropkowaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            apTlo.DashStyle = DashStyle.Dot;
        }

        private void liniaCiągłaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            apTlo.DashStyle = DashStyle.Solid;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            apTlo.Width = 1;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            apTlo.Width = 2;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            apTlo.Width = 3;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            apTlo.Width = 4;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            apTlo.Width = 5;
        }

        private void kolorLiniiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog apPaletaKolorow = new ColorDialog();
            if (apPaletaKolorow.ShowDialog() == DialogResult.OK)
            {
                apTlo.Color = apPaletaKolorow.Color;
            }
        }
    }
}
