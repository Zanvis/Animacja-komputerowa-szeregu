using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static ProjektNr1_Piwowarski62024.LaboratoriumNr1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ProjektNr1_Piwowarski62024
{
    public partial class ProjektNr1_Piwowarski : Form
    {
        // deklaracjce stałych
        const int apMargines = 10;
        const int apPromienOA = 5; // OA - Obiekt Animowany
        // deklaracja granic zbieżności szeregu
        const float apDGprzedzialuX = -4.0f;
        const float apGGprzedzialuX = 4.0f;
        Graphics apRysownica;
        float apXd, apXg;
        float aph;
        int apLiczbaPrzedzialowH;
        Pen apPioroXY = new Pen(Color.Blue, 1);
        Pen apPioroLiniiToru = new Pen(Color.Black, 1.5f);
        int apIndexPOA; // POA - Położenie Obiektu Animowanego
        int apMaxIndexPOA;
        float[,] apTWS; // TWS - Tablica Wartości Szeregu
        static ProjektNr1_Piwowarski apUchwytFormularza;
        public int apFigura = 0;
        private Color apKolorTla = Color.LightGreen;
        SolidBrush apPedzel = new SolidBrush(Color.Yellow);
        // rozmiary obiektu animowanego
        private float apRozmiar1X = 3 * apPromienOA;
        private float apRozmiarY = 3 * apPromienOA;
        private float apRozmiar2X = 5 * apPromienOA;

        public ProjektNr1_Piwowarski()
        {
            InitializeComponent();
            apUchwytFormularza = this;
            // wstępne sformatowanie kontrolki PictureBox
            pbRysownica.BackColor = Color.LightGray;
            pbRysownica.BorderStyle = BorderStyle.Fixed3D;
            // "podpięcie" do kontrolki PictureBox mapy bitowej
            pbRysownica.Image = new Bitmap(pbRysownica.Width, pbRysownica.Height);
            // utworzenie powierzchni graficznej na BitMapie
            apRysownica = Graphics.FromImage(pbRysownica.Image);
            apPioroXY.Width = 2;
            apPioroLiniiToru.Width = 2;
            apPioroLiniiToru.DashStyle = DashStyle.Dot;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // sprawdzenie czy OA (Obiekt Animacji) "doszedł" do prawej krawędzi
            if (apIndexPOA >= apMaxIndexPOA)
                // cofnięcie oA do lewej krawędzi
                apIndexPOA = 0;
            else
                apIndexPOA++;

            string apTickString = trackBar1.Value.ToString();
            int apLiczbaTickow = int.Parse(apTickString) - 4;

            timer1.Interval = 100 - apLiczbaTickow * 20;
            // odświeżenie powierzchni graficznej (przerysowanie całego obrazu z przesuniętym OA)
            pbRysownica.Refresh();
        }

        private void ProjektNr1_Piwowarski_FormClosing(object sender, FormClosingEventArgs e)
        {
            // utworzenie okna dialogowego dla spytania Użytkownika o potwierdzenie przejścia do Kokpitu
            DialogResult apOknoMessage = MessageBox.Show("Czy rzeczywiście chcesz przejść do Kokpitu?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // sprawdzenie "decyzji" Użytkownika programu
            if (apOknoMessage == DialogResult.Yes)
            {// odszukanie formularza głównego Kokpit w OpenForms
                foreach (Form apFormularz in Application.OpenForms)
                {
                    // ukrycie bieżącego formularza
                    this.Hide();
                    // odsłonięcie znalezionego formularza głównego
                    apFormularz.Show();
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
            if (apTWS is null)
                return;
            // wyczyszczenie powierzchni graficznej 
            //Rysownica.Clear(Color.LightGreen);
            apRysownica.Clear(apKolorTla);

            // ustawienie dużych grot srzałek na końcu osi X i Y
            AdjustableArrowCap apdużeGrotyStrzalek = new AdjustableArrowCap(5, 5);
            apPioroXY.CustomEndCap = apdużeGrotyStrzalek;
            apPioroXY.EndCap = LineCap.Flat;
            apPioroXY.CustomStartCap = apdużeGrotyStrzalek;
            apRysownica.DrawLine(apPioroXY, PrzeliczanieWspolrzednych.WspX(0), PrzeliczanieWspolrzednych.WspY(PrzeliczanieWspolrzednych.apYmin), PrzeliczanieWspolrzednych.WspX(0), PrzeliczanieWspolrzednych.WspY(PrzeliczanieWspolrzednych.apYmax));
            apPioroXY.StartCap = LineCap.Flat;
            apPioroXY.CustomEndCap = apdużeGrotyStrzalek;
            apRysownica.DrawLine(apPioroXY, PrzeliczanieWspolrzednych.WspX(PrzeliczanieWspolrzednych.apXmin), PrzeliczanieWspolrzednych.WspY(0), PrzeliczanieWspolrzednych.WspX(PrzeliczanieWspolrzednych.apXmax), PrzeliczanieWspolrzednych.WspY(0));

            // wykreślenie linii toru 
            for (int j = 0; j < apTWS.GetLength(0) - 1; j++)
                apRysownica.DrawLine(apPioroLiniiToru, PrzeliczanieWspolrzednych.WspX(apTWS[j, 0]), PrzeliczanieWspolrzednych.WspY(apTWS[j, 1]), PrzeliczanieWspolrzednych.WspX(apTWS[j + 1, 0]), PrzeliczanieWspolrzednych.WspY(apTWS[j + 1, 1]));
            // wykreślenie w nowym położeniu OA (obiektu animowanego)
            // apFigura wykrywa, który kształt ma obiekt animowany przyjąć
            if (apFigura == 1)
                apRysownica.FillRectangle(apPedzel, PrzeliczanieWspolrzednych.WspX(apTWS[apIndexPOA, 0]) - apPromienOA, PrzeliczanieWspolrzednych.WspY(apTWS[apIndexPOA, 1]) - apPromienOA, apRozmiar1X, apRozmiarY);
            else if (apFigura == 2)
                apRysownica.FillRectangle(apPedzel, PrzeliczanieWspolrzednych.WspX(apTWS[apIndexPOA, 0]) - apPromienOA, PrzeliczanieWspolrzednych.WspY(apTWS[apIndexPOA, 1]) - apPromienOA, apRozmiar2X, apRozmiarY);
            else if (apFigura == 3)
                apRysownica.FillEllipse(apPedzel, PrzeliczanieWspolrzednych.WspX(apTWS[apIndexPOA, 0]) - apPromienOA, PrzeliczanieWspolrzednych.WspY(apTWS[apIndexPOA, 1]) - apPromienOA, apRozmiar2X, apRozmiarY);
            else
                apRysownica.FillEllipse(apPedzel, PrzeliczanieWspolrzednych.WspX(apTWS[apIndexPOA, 0]) - apPromienOA, PrzeliczanieWspolrzednych.WspY(apTWS[apIndexPOA, 1]) - apPromienOA, apRozmiar1X, apRozmiarY);
        }
        private void btnAnimacja_Click(object sender, EventArgs e)
        {
            // "zgaszenie" kontrolki errorProvider
            errorProvider1.Dispose();
            // obranie danych wejściowych
            if (!PobranieDanychWejsciowych(out apXd, out apXg, out aph))
                // przerwanie obsługi zdarzenia Click, gdyż w danych wejściowych wykryto błąd
                return;
            // określenie liczby przedziałow o szerokości 'h' w przedziale: [Xd, Xg]
            apLiczbaPrzedzialowH = (int)((apXg - apXd) / aph) + 1;
            // utworzenie egzemplarza tablicy TWS
            apTWS = new float[apLiczbaPrzedzialowH, 3];
            // stablicowanie szeregu
            TablicowanieSzeregu(apTWS, apXd, apXg, aph);
            // początkowe położenie OA (OA: Obiekt Animowany)
            apIndexPOA = 0;
            // końcowe położenie OA
            apMaxIndexPOA = apTWS.GetLength(0) - 1;
            pictureBox1.Visible = false;
            pbRysownica.Visible = true;
            // włączenie zegara
            timer1.Enabled = true;
            trackBar1.Visible = true;
            lblPredkosc.Visible = true;
            // ustawienie przycisku poleceń: btnAnimacja w stan brak aktywności
            btnAnimacja.Enabled = false;
            btnWizualizacjaTabelaryczna.Enabled = true;
            dgvTWS.Visible = false;
            chtWykresSzeregu.Visible = false;
            btnWizualizacjaGraficzna.Enabled = true;
        }
        private void btnWizualizacjaTabelaryczna_Click(object sender, EventArgs e)
        {
            // "zgaszenie" kontrolki errorProvider
            errorProvider1.Dispose();
            // obranie danych wejściowych
            if (!PobranieDanychWejsciowych(out apXd, out apXg, out aph))
                // przerwanie obsługi zdarzenia Click, gdyż w danych wejściowych wykryto błąd
                return;
            // określenie liczby przedziałow o szerokości 'h' w przedziale: [Xd, Xg]
            apLiczbaPrzedzialowH = (int)((apXg - apXd) / aph) + 1;
            // utworzenie egzemplarza tablicy TWS
            apTWS = new float[apLiczbaPrzedzialowH, 3];
            // stablicowanie szeregu
            TablicowanieSzeregu(apTWS, apXd, apXg, aph);

            // Stablicowanie szeregu
            // sprawdzenie, czy został już utworzony egzemplarz tablicy TWS i szereg został stablicowany
            if (apTWS is null)
                TablicowanieSzeregu(apTWS, apXd, apXg, aph);
            // wpisanie wyników tablicowania wartości szeregu do kontrolki DataGridView
            apWpisanieWynikowDoKontrolkiDataGridView(apTWS, dgvTWS);
            pictureBox1.Visible = false;
            // odsłonięcie kontrolki dgvTWS
            dgvTWS.Visible = true;
            // ustawienie stanu braku aktywności dla obsługiwanego przycisku poleceń
            btnWizualizacjaTabelaryczna.Enabled = false;
            btnAnimacja.Enabled = true;
            pbRysownica.Visible = false;
            trackBar1.Visible = false;
            lblPredkosc.Visible = false;
            chtWykresSzeregu.Visible = false;
            btnWizualizacjaGraficzna.Enabled = true;
        }
        private void btnWizualizacjaGraficzna_Click(object sender, EventArgs e)
        {
            // "zgaszenie" kontrolki errorProvider, która mogła zostać zapalona podczas pobierania danych
            errorProvider1.Dispose();

            // Pobranie danych wejściowych z formularza Xd, Xg, h, Eps
            if (!PobranieDanychWejsciowych(out apXd, out apXg, out aph))
            { // był błąd
                errorProvider1.SetError(btnWizualizacjaGraficzna, "ERROR: przy pobieraniu danych wejściowych wykryto błąd i dlatego ta funkcjonalność nie może być zrealizowana");
                // przerwanie obłsugi zdarzenia Click: btnWizualizacjaTabelaryczna_Click
                return;
            }

            // określenie liczby przedziałow o szerokości 'h' w przedziale: [Xd, Xg]
            apLiczbaPrzedzialowH = (int)((apXg - apXd) / aph) + 1;
            // utworzenie egzemplarza tablicy TWS
            apTWS = new float[apLiczbaPrzedzialowH, 3];
            // stablicowanie szeregu
            TablicowanieSzeregu(apTWS, apXd, apXg, aph);

            // sprawdzenie czy egzemplarz tablicy TWS został już utworzony i szereg został stablicowany
            if (apTWS is null)
                TablicowanieSzeregu(apTWS, apXd, apXg, aph);
            // Wpisanie wyników tablicowania do kontrolki Chart
            WpisanieWynikowDoKontrolkiChart(apTWS, chtWykresSzeregu);
            pictureBox1.Visible = false;
            // ukrycie i odsłonięcie kontrolek dla potrzeb obsłuigiwanego przycisku poleceń
            dgvTWS.Visible = false;
            chtWykresSzeregu.Visible = true;
            btnWizualizacjaGraficzna.Enabled = false;
        }
        private void btnResetuj_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void zapiszBitMapęWPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // zapisanie rysownicy w pliku
            using (SaveFileDialog apPlikDoZapisu = new SaveFileDialog() { Filter = @"PNG|*.png" })
            {
                if (apPlikDoZapisu.ShowDialog() == DialogResult.OK)
                {
                    pbRysownica.Image.Save(apPlikDoZapisu.FileName);
                }
            }
        }

        private void odczytajBitMapęZPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // odczytanie rysownicy z pliku
            OpenFileDialog apPlikDoOdczytu = new OpenFileDialog();
            apPlikDoOdczytu.ShowDialog();
            string apsciezka = apPlikDoOdczytu.FileName;
            try
            {
                pbRysownica.Image = Image.FromFile(apsciezka);
            }
            catch (ArgumentException) { }

            apRysownica = Graphics.FromImage(pbRysownica.Image);
        }

        private void exitZFormularzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // zamknięcie formularza
            Close();
        }

        private void restartProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // restart programu
            Application.Restart();
        }
        #region Metody odpowiedzialne za Kolory
        // ustawienie koloru tła rysownicy
        private void kolorTłaRysownicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog apPaletaKolorow = new ColorDialog();
            if (apPaletaKolorow.ShowDialog() == DialogResult.OK)
            {
                apKolorTla = apPaletaKolorow.Color;
                // nadpisuje obecną rysownicę
                pbRysownica.Invalidate();
            }
        }
        // ustawienie koloru osi XY
        private void kolorOsiXYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog apPaletaKolorow = new ColorDialog();
            if (apPaletaKolorow.ShowDialog() == DialogResult.OK)
            {
                apPioroXY.Color = apPaletaKolorow.Color;
                // nadpisuje obecną rysownicę
                pbRysownica.Invalidate();
            }
        }
        // ustawienie koloru linii toru
        private void kolorLiniiToruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog apPaletaKolorow = new ColorDialog();
            if (apPaletaKolorow.ShowDialog() == DialogResult.OK)
            {
                apPioroLiniiToru.Color = apPaletaKolorow.Color;
                // nadpisuje obecną rysownicę
                pbRysownica.Invalidate();
            }
        }
        // ustawienie koloru obiektu animowanego
        private void kolorObiektuAnimowanegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog apPaletaKolorow = new ColorDialog();
            if (apPaletaKolorow.ShowDialog() == DialogResult.OK)
                apPedzel.Color = apPaletaKolorow.Color;
        }
        #endregion
        #region Metody odpowiedzialne za Atrybuty linii toru i obiektu animowanego
        // ustawienie grubości linii toru
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            apPioroLiniiToru.Width = 1;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            apPioroLiniiToru.Width = 2;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            apPioroLiniiToru.Width = 3;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            apPioroLiniiToru.Width = 4;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            apPioroLiniiToru.Width = 5;
        }
        // ustawienie stylu linii toru
        private void liniaKreskowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apPioroLiniiToru.DashStyle = DashStyle.Dash;
        }

        private void liniaKreskowoKropkowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apPioroLiniiToru.DashStyle = DashStyle.DashDot;
        }

        private void liniaKreskowoKropkowaKropkowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apPioroLiniiToru.DashStyle = DashStyle.DashDotDot;
        }

        private void liniaKropkowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apPioroLiniiToru.DashStyle = DashStyle.Dot;
        }

        private void ciągłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apPioroLiniiToru.DashStyle = DashStyle.Solid;
        }
        // ustaweinei wielkości obiektu animowanego
        private void małyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apRozmiar1X = 3 * apPromienOA;
            apRozmiarY = 3 * apPromienOA;
            apRozmiar2X = 5 * apPromienOA;

            apRozmiar2X /= 2;
            apRozmiarY /= 2;
            apRozmiar1X /= 2;
        }

        private void średniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apRozmiar1X = 3 * apPromienOA;
            apRozmiarY = 3 * apPromienOA;
            apRozmiar2X = 5 * apPromienOA;
        }

        private void dużyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apRozmiar1X = 3 * apPromienOA;
            apRozmiarY = 3 * apPromienOA;
            apRozmiar2X = 5 * apPromienOA;

            apRozmiar2X *= 2;
            apRozmiarY *= 2;
            apRozmiar1X *= 2;
        }
        #endregion
        #region Metody odpowiedzialne za Kształt obiektu animowanego
        // ustawienie danej wartości zmiennej apFigura w zależności od wybranego kształtu obiektu animowanego
        private void kołoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apFigura = 0;
        }

        private void kwadratToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apFigura = 1;
        }

        private void prostokątToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apFigura = 2;
        }

        private void elipsaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apFigura = 3;
        }
        #endregion
        #region Metody pomocnicze
        bool PobranieDanychWejsciowych(out float apXd, out float apXg, out float aph)
        {// pomocnicze przypisanie wartości technicznych parametrom wyjściowym
            apXd = apXg = aph = 0.0f;
            // pobranie Xd
            if (!float.TryParse(txtXd.Text, out apXd))
            {// wystąpił błąd, to go sygnalizujemy 
                errorProvider1.SetError(txtXd, "ERROR: w zapisie wartości Xd wystąpił niedozwolony znak!");
                // przerwanie pobierania danych 
                return false;
            }
            // sprawdzenie czy pobrane Xd należy do przedziału zbieżności szeregu
            if ((apXd <= apDGprzedzialuX) || (apXd >= apGGprzedzialuX))
            {
                errorProvider1.SetError(txtXd, "ERROR: pobrane Xd nie należy do przedziału zbieżności szeregu!");
                // przerwanie pobierania danych 
                return false;
            }
            if (!float.TryParse(txtXg.Text, out apXg))
            {// wystąpił błąd, to go sygnalizujemy 
                errorProvider1.SetError(txtXg, "ERROR: w zapisie wartości Xg wystąpił niedozwolony znak!");
                // przerwanie pobierania danych 
                return false;
            }
            if ((apXg <= apDGprzedzialuX) || (apXg >= apGGprzedzialuX))
            {
                errorProvider1.SetError(txtXg, "ERROR: pobrane Xg nie należy do przedziału zbieżności szeregu!");
                // przerwanie pobierania danych 
                return false;
            }
            // sprawdzenie tzw. warunku wejściowego na granice przedziału
            if (apXd > apXg)
            {
                errorProvider1.SetError(txtXd, "ERROR: nie jest spełniony warunek wejściowy: Xd < Xg, nakładany na granice przedziału zmian wartości zmiennej X!");
                // przerwanie pobierania danych 
                return false;
            }
            //pobranie przyrostu h zmian wartości zmiennej X
            if (!float.TryParse(txtH.Text, out aph))
            {
                errorProvider1.SetError(txtH, "ERROR: wystąpił niedozwolony znak w zapisie wartości przyrostu 'h'");
                // przerwanie pobierania danych
                return false;
            }

            // sprawdzenie warunku wejściowego dla przyrostu 'h': 0 < h < 1
            if ((aph <= 0.0f) || (aph >= 1.0f))
            {// sygnalizacja błędu 
                errorProvider1.SetError(txtH, "ERROR: dla przyrostu h nie jest spełniony warunek wejściowy: 0 < h < 1");
                return false;
            }
            // zwrotne przekazanie informacji, że nie było błędu
            return true;
        }

        void TablicowanieSzeregu(float[,] apTWS, float apXd, float apXg, float aph)
        {
            // deklaracje pomocnicze
            float apX;
            int api; // numer przedziału
            // tablicowanie
            ushort apLicznikZsumowanychWyrazow = 0;
            for (apX = apXd, api = 0; api < apTWS.GetLength(0); apX = apXd + api * aph, api++)
            {
                apTWS[api, 0] = apX;
                apTWS[api, 1] = ObliczenieWartosciSzeregu(apX, out apLicznikZsumowanychWyrazow);
                apTWS[api, 2] = apLicznikZsumowanychWyrazow;
            }
        }

        float ObliczenieWartosciSzeregu(float apX, out ushort apk)
        {// deklaracje pomocnicze
            const float apEps = 0.0000001f;
            float apw, apS;
            // ustalenie początkowego stanu obliczeń
            apk = 0;
            apS = 0.0f;
            apw = 1.0f;

            // sumowanie wyrazów szeregu
            while (Math.Abs(apw) > apEps)
            {
                apk++; // zwiększenie licznika wyrazów 
                // obliczenie k-tego wyrazu szeregu
                //w = w * (-1) * X / k;
                apw = apw * apk * apX / (4 * apk - 2);
                apS = apS + apw;
            }
            // zwrotne przekazanie wyniku obliczeń
            return apS;
        }    

        // deklaracja klasy statycznej dla przeliczenia wspołrzędnych punktów rzeczywistej powierzchni graficznej
        public static class PrzeliczanieWspolrzednych
        {
            // deklaracja zmiennych dla przechowania wartości współczynników skali dla osi X oraz Y
            static float apSx, apSy;
            // deklaracja zmiennych dla przechowania wartości przesunięć wzdłuż osi X oraz Y
            static float apDx, apDy;
            // deklaracja zmiennych opisujących rozmiar graficznej powierzchni graficznej
            static int apXe_min, apXe_max, apYe_min, apYe_max;
            // deklaracja właściwości ("zmiennych") opisujących rozmiar rzeczywistej powierzchni graficznej
            public static float apXmin
            {
                get; // Xmin będzie tylko do odczytu
                private set;
            }
            public static float apXmax
            {
                get;
                private set;
            }

            public static float apYmin
            {
                get;
                private set;
            }
            public static float apYmax
            {
                get;
                private set;
            }
            // deklaracja konstruktora klasy statycznej
            static PrzeliczanieWspolrzednych()
            { // określenie wartości dla Xmin oraz Xmax
                apXmin = apUchwytFormularza.apXd;
                apXmax = apUchwytFormularza.apXg;
                // określenie wartości Ymin oraz Ymax
                apYmin = EkstremumSzeregu2.MinSx(apUchwytFormularza.apTWS);
                apYmax = EkstremumSzeregu2.MaxSx(apUchwytFormularza.apTWS);
                // określenie wartości: Xe_min, Xe_max, Ye_min i Ye_max
                apXe_min = apMargines;
                apXe_max = apUchwytFormularza.pbRysownica.Width - (2 * apMargines);
                apYe_min = apMargines;
                apYe_max = apUchwytFormularza.pbRysownica.Height - (2 * apMargines);
                // wyznaczenie współczynników skali po osi X oraz Y
                apSx = (apXe_max - apXe_min) / (apXmax - apXmin);
                apSy = (apYe_max - apYe_min) / (apYmax - apYmin);
                // wyznaczenie wwartości przesunięć wzdłuż osi X oraz Y
                apDx = apXe_min - apXmin * apSx;
                apDy = apYe_min - apYmin * apSy;
            } // koniec konstruktora
            /* deklaracja dwóch metod: WspX, WspY, któe umożliwiają odwzorowanie punktów z powierzchni rzeczywistej
             na punkt powierzchni graficznej formularza */
            public static int WspX(float apx)
            {
                return (int)(apx * apSx + apDx);
            }
            static public int WspY(float apy)
            {
                return (int)(apy * apSy + apDy);
            }
        }
        
        void apWpisanieWynikowDoKontrolkiDataGridView(float[,] apTWS, DataGridView apdgvTWS)
        {// wyczyszczenie kontrolki DataGridView
            apdgvTWS.Rows.Clear();
            // wpisywanie danych z tablicy TWS do kontrolki DataGridView
            for (int i = 0; i < apTWS.GetLength(0); i++)
            {// dodajemy do kontrolki DataGridView nowy (i pusty) wiersz
                apdgvTWS.Rows.Add();
                // wpisanie danych z TWS do kolejnych komórek do danego wiersza kontrolki DataGridView
                apdgvTWS.Rows[i].Cells[0].Value = string.Format("{0:0.00}", apTWS[i, 0]);
                apdgvTWS.Rows[i].Cells[1].Value = string.Format("{0:0.00}", apTWS[i, 1]);
                apdgvTWS.Rows[i].Cells[2].Value = string.Format("{0}", (ushort)apTWS[i, 2]);
            }
        }

        void WpisanieWynikowDoKontrolkiChart(float[,] apTWS, Chart apchtWykresSzeregu)
        {
            // ustalenie atrybutów dla kontrolki chtWykresSzeregu
            // ustalenie atrybutów obramowania kontrolki chtWykresSzeregu
            apchtWykresSzeregu.BorderlineWidth = 3;
            apchtWykresSzeregu.BorderlineColor = Color.Green;
            apchtWykresSzeregu.BorderlineDashStyle = ChartDashStyle.DashDot;
            // sformatowanie kontrolki chtWykresSzeregu
            // ustalenie tytułu wykresu
            // próba usunięcia tytułu, jeżeli taki był ustawiony
            try
            {
                apchtWykresSzeregu.Titles.RemoveAt(0);
            }
            catch (Exception){}
            apchtWykresSzeregu.Titles.Add("Wykres zmian wartości szeregu S(X)");
            // umieszczenie legendy pod wykresem 
            apchtWykresSzeregu.Legends.FindByName("Legend1").Docking = Docking.Bottom;
            // ustalenie koloru tła dla kontrolki chtWykresSzeregu
            apchtWykresSzeregu.BackColor = Color.LightGreen;
            // opis osi układu współrzędnych wykresu
            apchtWykresSzeregu.ChartAreas[0].AxisX.Title = "Wartość zmiennej niezależnej X";
            apchtWykresSzeregu.ChartAreas[0].AxisY.Title = "Wartość szeregu S(X)";
            // ustalenie formatu opisu liczbowego osi układu współrzędnych
            apchtWykresSzeregu.ChartAreas[0].AxisX.LabelStyle.Format = "{0:F2}";
            apchtWykresSzeregu.ChartAreas[0].AxisY.LabelStyle.Format = "{0:F3}";
            // wyzerowanie serii danych kontrolki Chart
            apchtWykresSzeregu.Series.Clear();
            // dodajemy nową serię danych (dwie pierwsze kolumny z TWS, czyli: X oraz S(X)
            apchtWykresSzeregu.Series.Add("Seria 0");
            // ustalenie (sformatowanie) atrybutów dla dodanej serii danych
            apchtWykresSzeregu.Series[0].XValueMember = "X";
            apchtWykresSzeregu.Series[0].YValueMembers = "Y";
            // ustalenie widocznośći legendy
            apchtWykresSzeregu.Series[0].IsVisibleInLegend = true;
            // określenie nazwy tej serii danych
            apchtWykresSzeregu.Series[0].Name = "Wartość szeregu potęgowego S(X)";
            apchtWykresSzeregu.Series[0].ChartType = SeriesChartType.Line;
            apchtWykresSzeregu.Series[0].Color = Color.Red;
            apchtWykresSzeregu.Series[0].BorderDashStyle = ChartDashStyle.Solid;
            apchtWykresSzeregu.Series[0].BorderWidth = 2;
            // wpisanie do serii danych współrzędnych punktów z tablicy TWS
            for (int api = 0; api < apTWS.GetLength(0); api++)
                apchtWykresSzeregu.Series[0].Points.AddXY(apTWS[api, 0], apTWS[api, 1]);

            btnWizualizacjaGraficzna.Enabled = false;
            btnAnimacja.Enabled = true;
            btnWizualizacjaTabelaryczna.Enabled = true;
            pbRysownica.Visible = false;
            trackBar1.Visible = false;
            lblPredkosc.Visible = false;
            dgvTWS.Visible = false;
        }
        #endregion
    }
}
