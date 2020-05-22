using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TravelAgency
{
    /// <summary>
    /// Logika interakcji dla klasy UpdateRecord.xaml
    /// </summary>
    public partial class UpdateRecord : Window
    {
        ColumnNames columnNames = new ColumnNames();
        int index;
        string recordToUpdate;

        public UpdateRecord(MainWindow mainWindow, string indexToUpdate)
        {
            InitializeComponent();

            index = mainWindow.comboBox.SelectedIndex;
            recordToUpdate = indexToUpdate;

            switch (index)
            {
                case 0:
                    this.DataContext = columnNames.klienci;
                    break;
                case 1:
                    this.DataContext = columnNames.uczestnicy;
                    break;
                case 2:
                    this.DataContext = columnNames.zamowienia;
                    break;
                case 3:
                    this.DataContext = columnNames.wycieczki;
                    break;
                case 4:
                    this.DataContext = columnNames.hotele;
                    break;
                case 5:
                    this.DataContext = columnNames.rezydenci;
                    break;
                case 6:
                    this.DataContext = columnNames.uslugi;
                    break;
                case 7:
                    this.DataContext = columnNames.atrakcje;
                    break;
                default:
                    break;
            }
        }

        private void ButtonUpdateRecord_Click(object sender, RoutedEventArgs e)
        {
            string column1 = TextBoxImie.Text;
            string column2 = TextBoxNazwisko.Text;
            string column3 = TextBoxPesel.Text;
            string column4 = TextBoxAdres.Text;
            string column5 = TextBoxMiasto.Text;
            string column6 = TextBoxKodPocztowy.Text;
            string column7 = TextBoxKraj.Text;
            string column8 = TextBoxTelefon.Text;
            string column9 = TextBoxEmail.Text;
            string column10 = TextBoxNazwaFirmy.Text;
            string column11 = TextBoxRegon.Text;

            using (var context = new BiuroPodrozyEntities())
            {
                try
                {
                    var aktualRecord = context.Klienci.First(x => x.Id_klienta == int.Parse(recordToUpdate));
                    var updatedRecord = context.Klienci.First(x => x.Id_klienta == int.Parse(recordToUpdate));
                    updatedRecord.Imię = column1;
                    updatedRecord.Nazwisko = column2;
                    updatedRecord.Pesel = column3;
                    updatedRecord.Adres = column4;
                    updatedRecord.Miasto = column5;
                    updatedRecord.Kod_pocztowy = column6;
                    updatedRecord.Kraj = column7;
                    updatedRecord.Telefon = column8;
                    updatedRecord.Email = column9;
                    updatedRecord.Nazwa_firmy = column10;
                    updatedRecord.Regon = column11;
                    //aktualRecord = updatedRecord;
                    context.Klienci.Remove(aktualRecord);
                    context.Klienci.Add(updatedRecord);

                    context.SaveChanges();

                    MessageBox.Show("Dodano nowy rekord!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Coś poszło nie tak!");
                }
            }
        }
    }
}
