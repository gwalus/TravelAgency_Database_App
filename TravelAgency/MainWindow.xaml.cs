using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
        WindowViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new WindowViewModel();
        }

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            int choose = comboBox.SelectedIndex;

            using (var context = new BiuroPodrozyEntities())
            {
                switch (choose)
                {
                    case 0:
                        viewModel.TableName = ColumnNames.klienci;
                        viewModel.TableContent = context.Klienci.ToList();
                        DataContext = viewModel;
                        break;
                    case 1:
                        viewModel.TableName = ColumnNames.uczestnicy;
                        viewModel.TableContent = context.Uczestnicy.ToList();
                        DataContext = viewModel;
                        break;
                    case 2:
                        viewModel.TableName = ColumnNames.zamowienia;
                        viewModel.TableContent = context.Zamówienia.ToList();
                        DataContext = viewModel;
                        break;
                    case 3:
                        viewModel.TableName = ColumnNames.wycieczki;
                        viewModel.TableContent = context.Wycieczki.ToList();
                        DataContext = viewModel;
                        break;
                    case 4:
                        viewModel.TableName = ColumnNames.hotele;
                        viewModel.TableContent = context.Hotele.ToList();
                        DataContext = viewModel;
                        break;
                    case 5:
                        viewModel.TableName = ColumnNames.rezydenci;
                        viewModel.TableContent = context.Rezydenci.ToList();
                        DataContext = viewModel;
                        break;
                    case 6:
                        viewModel.TableName = ColumnNames.uslugi;
                        viewModel.TableContent = context.Usługi.ToList();
                        DataContext = viewModel;
                        break;
                    case 7:
                        viewModel.TableName = ColumnNames.atrakcje;
                        viewModel.TableContent = context.Atrakcje.ToList();
                        DataContext = viewModel;
                        break;
                    default:
                        break;
                }
            }
        }

        private void ButtonAddNewRecord_Click(object sender, RoutedEventArgs e)
        {
            int choose = comboBox.SelectedIndex;

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
                            catch (Exception)
                            {
                                MessageBox.Show("Coś poszło nie tak!");
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
                            catch (Exception)
                            {
                                MessageBox.Show("Coś poszło nie tak!");
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
                            catch (Exception)
                            {
                                MessageBox.Show("Coś poszło nie tak!");
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
                            catch (Exception)
                            {
                                MessageBox.Show("Coś poszło nie tak!");
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
                            catch (Exception)
                            {
                                MessageBox.Show("Coś poszło nie tak!");
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
                            catch (Exception)
                            {
                                MessageBox.Show("Coś poszło nie tak!");
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
                            catch (Exception)
                            {
                                MessageBox.Show("Coś poszło nie tak!");
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
                            catch (Exception)
                            {
                                MessageBox.Show("Coś poszło nie tak!");
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
                            catch (Exception)
                            {
                                MessageBox.Show("Coś poszło nie tak");
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
                            catch (Exception)
                            {
                                MessageBox.Show("Coś poszło nie tak");
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
                            catch (Exception)
                            {
                                MessageBox.Show("Coś poszło nie tak");
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
                            catch (Exception)
                            {
                                MessageBox.Show("Coś poszło nie tak");
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
                            catch (Exception)
                            {
                                MessageBox.Show("Coś poszło nie tak");
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
                            catch (Exception)
                            {
                                MessageBox.Show("Coś poszło nie tak");
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
                            catch (Exception)
                            {
                                MessageBox.Show("Coś poszło nie tak");
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
                            catch (Exception)
                            {
                                MessageBox.Show("Coś poszło nie tak");
                            }
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
    }
}