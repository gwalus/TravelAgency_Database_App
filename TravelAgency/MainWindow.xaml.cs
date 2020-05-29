using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Migrations;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml;

namespace TravelAgency
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public WindowViewModel viewModel;
        string idRecord;

        Klienci recordKlienci;
        Uczestnicy recordUczestnicy;
        Zamówienia recordZamowienia;
        Wycieczki recordWycieczki;
        Hotele recordHotele;
        Rezydenci recordRezydenci;
        Usługi recordUslugi;
        Atrakcje recordAtrakcje;
        Functions functions;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new WindowViewModel();
            functions = new Functions();
        }

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            functions.SetDataContextComboBoxSelected(this);
        }

        private void ButtonAddNewRecord_Click(object sender, RoutedEventArgs e)
        {
            int choose = comboBox.SelectedIndex;

            string column1 = TextBox1.Text;
            string column2 = TextBox2.Text;
            string column3 = TextBox3.Text;
            string column4 = TextBox4.Text;
            string column5 = TextBox5.Text;
            string column6 = TextBox6.Text;
            string column7 = TextBox7.Text;
            string column8 = TextBox8.Text;
            string column9 = TextBox9.Text;
            string column10 = TextBox10.Text;
            string column11 = TextBox11.Text;

            if (RadioButtonDodaj.IsChecked == true)
            {
                switch (choose)
                {
                    case 0:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            try
                            {
                                var record = new Klienci
                                {
                                    Imię = column1,
                                    Nazwisko = column2,
                                    Pesel = column3,
                                    Adres = column4,
                                    Miasto = column5,
                                    Kod_pocztowy = column6,
                                    Kraj = column7,
                                    Telefon = column8,
                                    Email = column9,
                                    Nazwa_firmy = column10,
                                    Regon = column11
                                };                                
                                context.Klienci.Add(record);
                                context.SaveChanges();

                                MessageBox.Show("Dodano nowy rekord!");                                
                                viewModel.TableContent = context.Klienci.ToList();
                            }
                            catch (Exception ex)
                            {                                
                                MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        break;
                    case 1:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            try
                            {
                                var record = new Uczestnicy
                                {
                                    Id_klienta = int.Parse(column1),
                                    Imię = column2,
                                    Nazwisko = column3,
                                    Pesel = column4,
                                    DataUrodzenia = DateTime.Parse(column5),
                                    MiejsceUrodzenia = column6,
                                    Adres = column7,
                                    Miasto = column8,
                                    Kod_pocztowy = column9,
                                    Kraj = column10,
                                    Telefon = column11
                                };

                                context.Uczestnicy.Add(record);
                                context.SaveChanges();

                                MessageBox.Show("Dodano nowy rekord!");
                                viewModel.TableContent = context.Uczestnicy.ToList();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        break;
                    case 2:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            try
                            {
                                var record = new Zamówienia
                                {
                                    Id_wycieczki = int.Parse(column1),
                                    Id_Klienta = int.Parse(column2),
                                    Data_zamówienia = DateTime.Parse(column3),
                                    Ilość_miejsc = int.Parse(column4),
                                    Status = column5,
                                    Data_płatności = DateTime.Parse(column6),
                                    Typ_płatności = column7
                                };

                                context.Zamówienia.Add(record);
                                context.SaveChanges();

                                MessageBox.Show("Dodano nowy rekord!");
                                viewModel.TableContent = context.Zamówienia.ToList();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        break;
                    case 3:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            try
                            {
                                var record = new Wycieczki
                                {
                                    Id_rezydenta = int.Parse(column1),
                                    Kraj = column2,
                                    Cena_za_osobe = decimal.Parse(column3),
                                    Ilość_dostępnych_miejsc = int.Parse(column4),
                                    Ilość_miejsc = int.Parse(column5),
                                    Data_wyjazdu = DateTime.Parse(column6),
                                    Data_powrotu = DateTime.Parse(column7)
                                };

                                context.Wycieczki.Add(record);
                                context.SaveChanges();

                                MessageBox.Show("Dodano nowy rekord!");
                                viewModel.TableContent = context.Wycieczki.ToList();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        break;
                    case 4:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            try
                            {
                                var record = new Hotele
                                {
                                    Nazwa = column1,
                                    Standard = int.Parse(column2),
                                    Kraj = column3,
                                    Miasto = column4,
                                    Adres = column5,
                                    Telefon = column6,
                                    Witryna = column7
                                };

                                context.Hotele.Add(record);
                                context.SaveChanges();

                                MessageBox.Show("Dodano nowy rekord!");
                                viewModel.TableContent = context.Hotele.ToList();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        break;
                    case 5:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            try
                            {
                                var record = new Rezydenci
                                {
                                    Imię = column1,
                                    Nazwisko = column2,
                                    Telefon = column3,
                                    Adres = column4,
                                    Miasto = column5,
                                    Kraj = column6,
                                    Email = column7
                                };

                                context.Rezydenci.Add(record);
                                context.SaveChanges();

                                MessageBox.Show("Dodano nowy rekord!");
                                viewModel.TableContent = context.Rezydenci.ToList();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        break;

                    case 6:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            try
                            {
                                var record = new Usługi
                                {
                                    Id_wycieczki = int.Parse(column1),
                                    Wyżywienie = column2,
                                    Ubezpieczenie = column3,
                                    Bagaż = column4
                                };

                                context.Usługi.Add(record);
                                context.SaveChanges();

                                MessageBox.Show("Dodano nowy rekord!");
                                viewModel.TableContent = context.Usługi.ToList();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        break;
                    case 7:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            try
                            {
                                var record = new Atrakcje
                                {
                                    Id_wycieczki = int.Parse(column1),
                                    Rodzaj = column2
                                };

                                context.Atrakcje.Add(record);
                                context.SaveChanges();

                                MessageBox.Show("Dodano nowy rekord!");
                                viewModel.TableContent = context.Atrakcje.ToList();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            else if (RadioButtonUsun.IsChecked == true)
            {
                switch (choose)
                {
                    case 0:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            try
                            {
                                int index = int.Parse(column1);
                                var record = context.Klienci.First(x => x.Id_klienta == index);

                                MessageBoxResult messageBoxResult = MessageBox.Show("Usunąć rekord?", "Usuwanie", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                                switch (messageBoxResult)
                                {
                                    case MessageBoxResult.OK:
                                        context.Klienci.Remove(record);
                                        context.SaveChanges();
                                        MessageBox.Show("Usunięto rekord!");
                                        viewModel.TableContent = context.Klienci.ToList();
                                        break;
                                    case MessageBoxResult.Cancel:
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {                                
                                MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        break;
                    case 1:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            try
                            {
                                int index = int.Parse(column1);
                                var record = context.Uczestnicy.First(x => x.Id_uczestnika == index);

                                MessageBoxResult messageBoxResult = MessageBox.Show("Usunąć rekord?", "Usuwanie", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                                switch (messageBoxResult)
                                {
                                    case MessageBoxResult.OK:
                                        context.Uczestnicy.Remove(record);
                                        context.SaveChanges();
                                        MessageBox.Show("Usunięto rekord!");
                                        viewModel.TableContent = context.Uczestnicy.ToList();
                                        break;
                                    case MessageBoxResult.Cancel:
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        break;
                    case 2:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            try
                            {
                                int index = int.Parse(column1);
                                var record = context.Zamówienia.First(x => x.Id_zamówienia == index);

                                MessageBoxResult messageBoxResult = MessageBox.Show("Usunąć rekord?", "Usuwanie", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                                switch (messageBoxResult)
                                {
                                    case MessageBoxResult.OK:
                                        context.Zamówienia.Remove(record);
                                        context.SaveChanges();
                                        MessageBox.Show("Usunięto rekord!");
                                        viewModel.TableContent = context.Zamówienia.ToList();
                                        break;
                                    case MessageBoxResult.Cancel:
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        break;
                    case 3:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            try
                            {
                                int index = int.Parse(column1);
                                var record = context.Wycieczki.First(x => x.Id_wycieczki == index);

                                MessageBoxResult messageBoxResult = MessageBox.Show("Usunąć rekord?", "Usuwanie", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                                switch (messageBoxResult)
                                {
                                    case MessageBoxResult.OK:
                                        context.Wycieczki.Remove(record);
                                        context.SaveChanges();
                                        MessageBox.Show("Usunięto rekord!");
                                        viewModel.TableContent = context.Wycieczki.ToList();
                                        break;
                                    case MessageBoxResult.Cancel:
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        break;
                    case 4:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            try
                            {
                                int index = int.Parse(column1);
                                var record = context.Hotele.First(x => x.Id_hotelu == index);

                                MessageBoxResult messageBoxResult = MessageBox.Show("Usunąć rekord?", "Usuwanie", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                                switch (messageBoxResult)
                                {
                                    case MessageBoxResult.OK:
                                        context.Hotele.Remove(record);
                                        context.SaveChanges();
                                        MessageBox.Show("Usunięto rekord!");
                                        viewModel.TableContent = context.Hotele.ToList();
                                        break;
                                    case MessageBoxResult.Cancel:
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        break;
                    case 5:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            try
                            {
                                int index = int.Parse(column1);
                                var record = context.Rezydenci.First(x => x.Id_rezydenta == index);

                                MessageBoxResult messageBoxResult = MessageBox.Show("Usunąć rekord?", "Usuwanie", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                                switch (messageBoxResult)
                                {
                                    case MessageBoxResult.OK:
                                        context.Rezydenci.Remove(record);
                                        context.SaveChanges();
                                        MessageBox.Show("Usunięto rekord!");
                                        viewModel.TableContent = context.Rezydenci.ToList();
                                        break;
                                    case MessageBoxResult.Cancel:
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        break;
                    case 6:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            try
                            {
                                int index = int.Parse(column1);
                                var record = context.Usługi.First(x => x.Id_usługi == index);

                                MessageBoxResult messageBoxResult = MessageBox.Show("Usunąć rekord?", "Usuwanie", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                                switch (messageBoxResult)
                                {
                                    case MessageBoxResult.OK:
                                        context.Usługi.Remove(record);
                                        context.SaveChanges();
                                        MessageBox.Show("Usunięto rekord!");
                                        viewModel.TableContent = context.Usługi.ToList();
                                        break;
                                    case MessageBoxResult.Cancel:
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        break;
                    case 7:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            try
                            {
                                int index = int.Parse(column1);
                                var record = context.Atrakcje.First(x => x.Id_atrakcji == index);

                                MessageBoxResult messageBoxResult = MessageBox.Show("Usunąć rekord?", "Usuwanie", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                                switch (messageBoxResult)
                                {
                                    case MessageBoxResult.OK:
                                        context.Atrakcje.Remove(record);
                                        context.SaveChanges();
                                        MessageBox.Show("Usunięto rekord!");
                                        viewModel.TableContent = context.Atrakcje.ToList();
                                        break;
                                    case MessageBoxResult.Cancel:
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            else if (RadioButtonAktualizuj.IsChecked == true)
            {
                switch (choose)
                {
                    case 0:
                        try
                        {
                            using (var context = new BiuroPodrozyEntities())
                            {
                                recordKlienci.Imię = column1;
                                recordKlienci.Nazwisko = column2;
                                recordKlienci.Pesel = column3;
                                recordKlienci.Adres = column4;
                                recordKlienci.Miasto = column5;
                                recordKlienci.Kod_pocztowy = column6;
                                recordKlienci.Kraj = column7;
                                recordKlienci.Telefon = column8;
                                recordKlienci.Email = column9;
                                recordKlienci.Nazwa_firmy = column10;
                                recordKlienci.Regon = column11;

                                context.Entry(recordKlienci).State = EntityState.Modified;
                                context.SaveChanges();

                                MessageBox.Show("Zaktualizowano rekord!");
                                viewModel.TableContent = context.Klienci.ToList();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    case 1:
                        try
                        {
                            using (var context = new BiuroPodrozyEntities())
                            {
                                recordUczestnicy.Id_klienta = int.Parse(column1);
                                recordUczestnicy.Imię = column2;
                                recordUczestnicy.Nazwisko = column3;
                                recordUczestnicy.Pesel = column4;
                                recordUczestnicy.DataUrodzenia = DateTime.Parse(column5);
                                recordUczestnicy.MiejsceUrodzenia = column6;
                                recordUczestnicy.Adres = column7;
                                recordUczestnicy.Miasto = column8;
                                recordUczestnicy.Kod_pocztowy = column9;
                                recordUczestnicy.Kraj = column10;
                                recordUczestnicy.Telefon = column11;

                                context.Entry(recordUczestnicy).State = EntityState.Modified;
                                context.SaveChanges();

                                MessageBox.Show("Zaktualizowano rekord!");
                                viewModel.TableContent = context.Uczestnicy.ToList();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    case 2:
                        try
                        {
                            using (var context = new BiuroPodrozyEntities())
                            {
                                recordZamowienia.Id_wycieczki = int.Parse(column1);
                                recordZamowienia.Id_Klienta = int.Parse(column2);
                                recordZamowienia.Data_zamówienia = DateTime.Parse(column3);
                                recordZamowienia.Ilość_miejsc = int.Parse(column4);
                                recordZamowienia.Status = column5;
                                recordZamowienia.Data_płatności = DateTime.Parse(column6);
                                recordZamowienia.Typ_płatności = column7;

                                context.Entry(recordZamowienia).State = EntityState.Modified;
                                context.SaveChanges();

                                MessageBox.Show("Zaktualizowano rekord!");
                                viewModel.TableContent = context.Zamówienia.ToList();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    case 3:
                        try
                        {
                            using (var context = new BiuroPodrozyEntities())
                            {
                                recordWycieczki.Id_rezydenta = int.Parse(column1);
                                recordWycieczki.Kraj = column2;
                                recordWycieczki.Cena_za_osobe = int.Parse(column3);
                                recordWycieczki.Ilość_dostępnych_miejsc = int.Parse(column4);
                                recordWycieczki.Ilość_miejsc = int.Parse(column5);
                                recordWycieczki.Data_wyjazdu = DateTime.Parse(column6);
                                recordWycieczki.Data_powrotu = DateTime.Parse(column7);

                                context.Entry(recordWycieczki).State = EntityState.Modified;
                                context.SaveChanges();

                                MessageBox.Show("Zaktualizowano rekord!");
                                viewModel.TableContent = context.Wycieczki.ToList();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    case 4:
                        try
                        {
                            using (var context = new BiuroPodrozyEntities())
                            {
                                recordHotele.Nazwa = column1;
                                recordHotele.Standard = int.Parse(column2);
                                recordHotele.Kraj = column3;
                                recordHotele.Miasto = column4;
                                recordHotele.Adres = column5;
                                recordHotele.Telefon = column6;
                                recordHotele.Witryna = column7;

                                context.Entry(recordHotele).State = EntityState.Modified;
                                context.SaveChanges();

                                MessageBox.Show("Zaktualizowano rekord!");
                                viewModel.TableContent = context.Hotele.ToList();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    case 5:
                        try
                        {
                            using (var context = new BiuroPodrozyEntities())
                            {
                                recordRezydenci.Imię = column1;
                                recordRezydenci.Nazwisko = column2;
                                recordRezydenci.Telefon = column3;
                                recordRezydenci.Adres = column4;
                                recordRezydenci.Miasto = column5;
                                recordRezydenci.Kraj = column6;
                                recordRezydenci.Email = column7;

                                context.Entry(recordRezydenci).State = EntityState.Modified;
                                context.SaveChanges();

                                MessageBox.Show("Zaktualizowano rekord!");
                                viewModel.TableContent = context.Rezydenci.ToList();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    case 6:
                        try
                        {
                            using (var context = new BiuroPodrozyEntities())
                            {
                                recordUslugi.Id_wycieczki = int.Parse(column1);
                                recordUslugi.Wyżywienie = column2;
                                recordUslugi.Ubezpieczenie = column3;
                                recordUslugi.Bagaż = column4;

                                context.Entry(recordUslugi).State = EntityState.Modified;
                                context.SaveChanges();

                                MessageBox.Show("Zaktualizowano rekord!");
                                viewModel.TableContent = context.Usługi.ToList();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    case 7:
                        try
                        {
                            using (var context = new BiuroPodrozyEntities())
                            {
                                recordAtrakcje.Id_wycieczki = int.Parse(column1);
                                recordAtrakcje.Rodzaj = column2;

                                context.Entry(recordAtrakcje).State = EntityState.Modified;
                                context.SaveChanges();

                                MessageBox.Show("Zaktualizowano rekord!");
                                viewModel.TableContent = context.Atrakcje.ToList();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void RadioButtonAddNewRekord_Click(object sender, RoutedEventArgs e)
        {
            int choose = comboBox.SelectedIndex;

            using (var context = new BiuroPodrozyEntities())
            {
                switch (choose)
                {
                    case 0:
                        viewModel.TableName = ColumnNames.klienci;
                        viewModel.TableContent = context.Klienci.ToList();
                        viewModel.ButtonContent = ColumnNames.contentDodaj;
                        DataContext = viewModel;
                        break;
                    case 1:
                        viewModel.TableName = ColumnNames.uczestnicy;
                        viewModel.TableContent = context.Uczestnicy.ToList();
                        viewModel.ButtonContent = ColumnNames.contentDodaj;
                        DataContext = viewModel;
                        break;
                    case 2:
                        viewModel.TableName = ColumnNames.zamowienia;
                        viewModel.TableContent = context.Zamówienia.ToList();
                        viewModel.ButtonContent = ColumnNames.contentDodaj;
                        DataContext = viewModel;
                        break;
                    case 3:
                        viewModel.TableName = ColumnNames.wycieczki;
                        viewModel.TableContent = context.Wycieczki.ToList();
                        viewModel.ButtonContent = ColumnNames.contentDodaj;
                        DataContext = viewModel;
                        break;
                    case 4:
                        viewModel.TableName = ColumnNames.hotele;
                        viewModel.TableContent = context.Hotele.ToList();
                        viewModel.ButtonContent = ColumnNames.contentDodaj;
                        DataContext = viewModel;
                        break;
                    case 5:
                        viewModel.TableName = ColumnNames.rezydenci;
                        viewModel.TableContent = context.Rezydenci.ToList();
                        viewModel.ButtonContent = ColumnNames.contentDodaj;
                        DataContext = viewModel;
                        break;
                    case 6:
                        viewModel.TableName = ColumnNames.uslugi;
                        viewModel.TableContent = context.Usługi.ToList();
                        viewModel.ButtonContent = ColumnNames.contentDodaj;
                        DataContext = viewModel;
                        break;
                    case 7:
                        viewModel.TableName = ColumnNames.atrakcje;
                        viewModel.TableContent = context.Atrakcje.ToList();
                        viewModel.ButtonContent = ColumnNames.contentDodaj;
                        DataContext = viewModel;
                        break;
                    default:
                        break;
                }
            }
        }

        private void RadioButtonDeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            int choose = comboBox.SelectedIndex;

            using (var context = new BiuroPodrozyEntities())
            {
                switch (choose)
                {
                    case 0:
                        viewModel.TableName = ColumnNames.id;
                        viewModel.TableContent = context.Klienci.ToList();
                        viewModel.ButtonContent = ColumnNames.contentUsun;
                        DataContext = viewModel;
                        break;
                    case 1:
                        viewModel.TableName = ColumnNames.id;
                        viewModel.TableContent = context.Uczestnicy.ToList();
                        viewModel.ButtonContent = ColumnNames.contentUsun;
                        DataContext = viewModel;
                        break;
                    case 2:
                        viewModel.TableName = ColumnNames.id;
                        viewModel.TableContent = context.Zamówienia.ToList();
                        viewModel.ButtonContent = ColumnNames.contentUsun;
                        DataContext = viewModel;
                        break;
                    case 3:
                        viewModel.TableName = ColumnNames.id;
                        viewModel.TableContent = context.Wycieczki.ToList();
                        viewModel.ButtonContent = ColumnNames.contentUsun;
                        DataContext = viewModel;
                        break;
                    case 4:
                        viewModel.TableName = ColumnNames.id;
                        viewModel.TableContent = context.Hotele.ToList();
                        viewModel.ButtonContent = ColumnNames.contentUsun;
                        DataContext = viewModel;
                        break;
                    case 5:
                        viewModel.TableName = ColumnNames.id;
                        viewModel.TableContent = context.Rezydenci.ToList();
                        viewModel.ButtonContent = ColumnNames.contentUsun;
                        DataContext = viewModel;
                        break;
                    case 6:
                        viewModel.TableName = ColumnNames.id;
                        viewModel.TableContent = context.Usługi.ToList();
                        viewModel.ButtonContent = ColumnNames.contentUsun;
                        DataContext = viewModel;
                        break;
                    case 7:
                        viewModel.TableName = ColumnNames.id;
                        viewModel.TableContent = context.Atrakcje.ToList();
                        viewModel.ButtonContent = ColumnNames.contentUsun;
                        DataContext = viewModel;
                        break;
                    default:
                        break;
                }
            }
        }

        private void RadioButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            int choose = comboBox.SelectedIndex;

            idRecord = TextBoxIdToUpdate.Text;

            if (string.IsNullOrWhiteSpace(idRecord) == false)
            {
                switch (choose)
                {
                    case 0:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            viewModel.TableName = ColumnNames.klienci;
                            viewModel.TableContent = context.Klienci.ToList();
                            viewModel.ButtonContent = ColumnNames.contentAktualizuj;
                            DataContext = viewModel;

                            int recordIndex = int.Parse(idRecord);

                            recordKlienci = context.Klienci.FirstOrDefault(x => x.Id_klienta == recordIndex);
                            TextBox1.Text = recordKlienci.Imię;
                            TextBox2.Text = recordKlienci.Nazwisko;
                            TextBox3.Text = recordKlienci.Pesel;
                            TextBox4.Text = recordKlienci.Adres;
                            TextBox5.Text = recordKlienci.Miasto;
                            TextBox6.Text = recordKlienci.Kod_pocztowy;
                            TextBox7.Text = recordKlienci.Kraj;
                            TextBox8.Text = recordKlienci.Telefon;
                            TextBox9.Text = recordKlienci.Email;
                            TextBox10.Text = recordKlienci.Nazwa_firmy;
                            TextBox11.Text = recordKlienci.Regon;
                        }
                        break;
                    case 1:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            viewModel.TableName = ColumnNames.uczestnicy;
                            viewModel.TableContent = context.Uczestnicy.ToList();
                            viewModel.ButtonContent = ColumnNames.contentAktualizuj;
                            DataContext = viewModel;

                            int recordIndex = int.Parse(idRecord);

                            recordUczestnicy = context.Uczestnicy.FirstOrDefault(x => x.Id_uczestnika == recordIndex);
                            TextBox1.Text = recordUczestnicy.Id_klienta.ToString();
                            TextBox2.Text = recordUczestnicy.Imię;
                            TextBox3.Text = recordUczestnicy.Nazwisko;
                            TextBox4.Text = recordUczestnicy.Pesel;
                            TextBox5.Text = recordUczestnicy.DataUrodzenia.ToString();
                            TextBox6.Text = recordUczestnicy.MiejsceUrodzenia;
                            TextBox7.Text = recordUczestnicy.Adres;
                            TextBox8.Text = recordUczestnicy.Miasto;
                            TextBox9.Text = recordUczestnicy.Kod_pocztowy;
                            TextBox10.Text = recordUczestnicy.Kraj;
                            TextBox11.Text = recordUczestnicy.Telefon;
                        }
                        break;
                    case 2:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            viewModel.TableName = ColumnNames.zamowienia;
                            viewModel.TableContent = context.Zamówienia.ToList();
                            viewModel.ButtonContent = ColumnNames.contentAktualizuj;
                            DataContext = viewModel;

                            int recordIndex = int.Parse(idRecord);

                            recordZamowienia = context.Zamówienia.FirstOrDefault(x => x.Id_zamówienia == recordIndex);
                            TextBox1.Text = recordZamowienia.Id_wycieczki.ToString();
                            TextBox2.Text = recordZamowienia.Id_Klienta.ToString();
                            TextBox3.Text = recordZamowienia.Data_zamówienia.ToString();
                            TextBox4.Text = recordZamowienia.Ilość_miejsc.ToString();
                            TextBox5.Text = recordZamowienia.Status;
                            TextBox6.Text = recordZamowienia.Data_płatności.ToString();
                            TextBox7.Text = recordZamowienia.Typ_płatności;
                        }
                        break;
                    case 3:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            viewModel.TableName = ColumnNames.wycieczki;
                            viewModel.TableContent = context.Wycieczki.ToList();
                            viewModel.ButtonContent = ColumnNames.contentAktualizuj;
                            DataContext = viewModel;

                            int recordIndex = int.Parse(idRecord);

                            recordWycieczki = context.Wycieczki.FirstOrDefault(x => x.Id_wycieczki == recordIndex);
                            TextBox1.Text = recordWycieczki.Id_rezydenta.ToString();
                            TextBox2.Text = recordWycieczki.Kraj;
                            TextBox3.Text = recordWycieczki.Cena_za_osobe.ToString();
                            TextBox4.Text = recordWycieczki.Ilość_dostępnych_miejsc.ToString();
                            TextBox5.Text = recordWycieczki.Ilość_miejsc.ToString();
                            TextBox6.Text = recordWycieczki.Data_wyjazdu.ToString();
                            TextBox7.Text = recordWycieczki.Data_powrotu.ToString();
                        }
                        break;
                    case 4:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            viewModel.TableName = ColumnNames.hotele;
                            viewModel.TableContent = context.Hotele.ToList();
                            viewModel.ButtonContent = ColumnNames.contentAktualizuj;
                            DataContext = viewModel;

                            int recordIndex = int.Parse(idRecord);

                            recordHotele = context.Hotele.FirstOrDefault(x => x.Id_hotelu == recordIndex);
                            TextBox1.Text = recordHotele.Nazwa;
                            TextBox2.Text = recordHotele.Standard.ToString();
                            TextBox3.Text = recordHotele.Kraj;
                            TextBox4.Text = recordHotele.Miasto;
                            TextBox5.Text = recordHotele.Adres;
                            TextBox6.Text = recordHotele.Telefon;
                            TextBox7.Text = recordHotele.Witryna;
                        }
                        break;
                    case 5:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            viewModel.TableName = ColumnNames.rezydenci;
                            viewModel.TableContent = context.Rezydenci.ToList();
                            viewModel.ButtonContent = ColumnNames.contentAktualizuj;
                            DataContext = viewModel;

                            int recordIndex = int.Parse(idRecord);

                            recordRezydenci = context.Rezydenci.FirstOrDefault(x => x.Id_rezydenta == recordIndex);
                            TextBox1.Text = recordRezydenci.Imię;
                            TextBox2.Text = recordRezydenci.Nazwisko;
                            TextBox3.Text = recordRezydenci.Telefon;
                            TextBox4.Text = recordRezydenci.Adres;
                            TextBox5.Text = recordRezydenci.Miasto;
                            TextBox6.Text = recordRezydenci.Kraj;
                            TextBox7.Text = recordRezydenci.Email;
                        }
                        break;
                    case 6:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            viewModel.TableName = ColumnNames.uslugi;
                            viewModel.TableContent = context.Usługi.ToList();
                            viewModel.ButtonContent = ColumnNames.contentAktualizuj;
                            DataContext = viewModel;

                            int recordIndex = int.Parse(idRecord);

                            recordUslugi = context.Usługi.FirstOrDefault(x => x.Id_usługi == recordIndex);
                            TextBox1.Text = recordUslugi.Id_wycieczki.ToString();
                            TextBox2.Text = recordUslugi.Wyżywienie;
                            TextBox3.Text = recordUslugi.Ubezpieczenie;
                            TextBox4.Text = recordUslugi.Bagaż;
                        }
                        break;
                    case 7:
                        using (var context = new BiuroPodrozyEntities())
                        {
                            viewModel.TableName = ColumnNames.atrakcje;
                            viewModel.TableContent = context.Atrakcje.ToList();
                            viewModel.ButtonContent = ColumnNames.contentAktualizuj;
                            DataContext = viewModel;

                            int recordIndex = int.Parse(idRecord);

                            recordAtrakcje = context.Atrakcje.FirstOrDefault(x => x.Id_atrakcji == recordIndex);
                            TextBox1.Text = recordAtrakcje.Id_wycieczki.ToString();
                            TextBox2.Text = recordAtrakcje.Rodzaj;
                        }
                        break;
                }
            }
        }
    }
}