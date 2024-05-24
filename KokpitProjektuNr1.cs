using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektNr1_Piwowarski62024
{
    public partial class KokpitProjektuNr1 : Form
    {
        public KokpitProjektuNr1()
        {
            InitializeComponent();
        }

        private void btnLaboratoriumNr1_Click(object sender, EventArgs e)
        {// sprawdzenie czy już był utworzony egzemplarz formularza LaboratoriumNr1
            foreach (Form Formularz in Application.OpenForms)
                // sprawdzenie, czy został znaleziony formularz LaboratoriumNr1
                if (Formularz.Name == "LaboratoriumNr1")
                {
                    // ukrycie bieżącego formularza
                    this.Hide();
                    // odsłonięcie formularza znalezionego
                    Formularz.Show();
                    // bezwarunkowe zakończenie obsługi zdarzenia Click
                    return;
                }
            /* gdy będziemy tutaj, to poszukiwany fomrularz LaboratoriumNr1 nie został znaleziony,
             a to oznacza, że należy utworzyć egzemplarz tego formularza i go odsłonić */
            LaboratoriumNr1 FormLaboratoriumNr1 = new LaboratoriumNr1();
            // ukrycie bieżącego formularza
            this.Hide();
            // odsłonięcie formularza FormLaboratoriumNr1
            FormLaboratoriumNr1.Show();
        }

        private void btnProjektNr1_Click(object sender, EventArgs e)
        {
            // sprawdzenie, czy był już utworzony egzemplarz formularza ProjektNr1_Piwowarski
            foreach (Form Formularz in Application.OpenForms)
                // sprawdzenie, czy to jest formularz ProjektNr1_Nazwisko
                if (Formularz.Name == "ProjektNr1_Piwowarski")
                {// ukrycie bieżącego formularza
                    this.Hide();
                    // odsłonięcie znalezionego formularza
                    Formularz.Show();
                    // bezwarunkowe zakończenie obsługi zdarzenia Click
                    return;
                }
            /* formularz ProjektNr1_Nazwisko nie został znaleziony w kolekcji Application.OpenForms i
               musimy utworzyć jego egzemplarz */
            ProjektNr1_Piwowarski FormProjektNr1_Piwowarski = new ProjektNr1_Piwowarski();
            // ukrycie bieżącego formularza
            this.Hide();
            // odsłonięcie utworzonego egzemplarza formularza ProjektNr1_Piwowarski
            FormProjektNr1_Piwowarski.Show();
        }

        private void KokpitProjektuNr1_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* utworzenie okna dialogowego i jego wyświetlenia dla spytania Użytkownika,
               czy aby na pewno chce zamknąć formularz i zakończyć działanie programu */
            DialogResult OknoMessage = MessageBox.Show("Czy na pewno chcesz zamknąć formularz główny i zakończyć działanie programu", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // sprawdzenie podjętej decyzji przez Użytkownika programu
            if (OknoMessage == DialogResult.Yes)
                // zamknięcie wszystkich formularzy i zakończenie działania programu
                Application.ExitThread();
            else
                // skasowanie zdarzenia FormClosing
                e.Cancel = true;
        }
    }
}
