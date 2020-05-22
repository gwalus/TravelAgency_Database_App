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
        int indexTable;
        int indexToDelete;

        WindowViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonDeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            indexTable = comboBox.SelectedIndex;

            using (var context = new BiuroPodrozyEntities())
            {
                switch (indexTable)
                {
                    case 0:
                        try
                        {
                            indexToDelete = int.Parse(TextBoxIndexToDelete.Text);
                            var klient = context.Klienci.First(x => x.Id_klienta == indexToDelete);
                            context.Klienci.Remove(klient);
                            context.SaveChanges();
                            this.DataContext = context.Klienci.ToList();
                            MessageBox.Show("Usunięto rekord o indexie: " + indexToDelete.ToString());
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Nie istnieje rekord o takim indeksie!");
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            int choose = comboBox.SelectedIndex;

            using (var context = new BiuroPodrozyEntities())
            {
                switch (choose)
                {
                    case 0:
                        viewModel = new WindowViewModel
                        {
                            TableName = new Table
                            {
                                Columns = new string[] { "Imię", "Nazwisko", "Pesel (11-cyfrowy)", "Adres", "Miasto", "Kod pocztowy (**-***)", "Kraj", "Telefon ([5-9]********)", "Email (*@domena.com)", "Nazwa_firmy", "Regon" }
                            },
                            TableContent = context.Klienci.ToList()
                        };
                        DataContext = viewModel;
                        break;
                    case 1:
                        viewModel = new WindowViewModel
                        {
                            TableName = new Table
                            {
                                Columns = new string[] { "ID klienta", "Imię", "Nazwisko", "Pesel (11-cyfowy)", "Data urodzenia (YYYY-MM-DD)", "Miejsce urodzenia", "Adres", "Miasto", "Kod pocztowy (**-***)", "Kraj", "Telefon ([5-9]********)" }
                            },
                            TableContent = context.Uczestnicy.ToList()
                        };
                        DataContext = viewModel;
                        break;
                    case 2:
                        viewModel = new WindowViewModel
                        {
                            TableName = new Table
                            {
                                Columns = new string[] { "ID wycieczki", "ID klienta", "Data zamówienia (YYYY-MM-DD)", "Ilość miejsc", "Status", "Data płatności (YYYY-MM-DD)", "Typ płatności" }
                            },
                            TableContent = context.Zamówienia.ToList()
                        };
                        DataContext = viewModel;
                        break;
                    case 3:
                        viewModel = new WindowViewModel
                        {
                            TableName = new Table
                            {
                                Columns = new string[] { "ID rezydenta", "Kraj", "Cena za osobe", "Ilość dostępnych miejsc", "Ilość miejsc", "Data wyjazdu (YYYY-MM-DD)", "Data powrotu (YYYY-MM-DD)" }
                            },
                            TableContent = context.Wycieczki.ToList()
                        };
                        DataContext = viewModel;
                        break;
                    case 4:
                        viewModel = new WindowViewModel
                        {
                            TableName = new Table
                            {
                                Columns = new string[] { "Nazwa", "Standard", "Kraj", "Miasto", "Adres", "Telefon ([5-9]********)", "Witryna" }
                            },
                            TableContent = context.Hotele.ToList()
                        };
                        DataContext = viewModel;
                        break;
                    case 5:
                        viewModel = new WindowViewModel
                        {
                            TableName = new Table
                            {
                                Columns = new string[] { "Imię", "Nazwisko", "Telefon ([5-9]********)", "Adres", "Miasto", "Kraj", "Email (*@domena.com)" }
                            },
                            TableContent = context.Rezydenci.ToList()
                        };
                        DataContext = viewModel;
                        break;
                    case 6:
                        viewModel = new WindowViewModel
                        {
                            TableName = new Table
                            {
                                Columns = new string[] { "ID wycieczki", "Wyżywienie", "Ubezpieczenie", "Bagaż" }
                            },
                            TableContent = context.Usługi.ToList()
                        };
                        DataContext = viewModel;
                        break;
                    case 7:
                        viewModel = new WindowViewModel
                        {
                            TableName = new Table
                            {
                                Columns = new string[] { "ID wycieczki", "Rodzaj" }
                            },
                            TableContent = context.Atrakcje.ToList()
                        };
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
                            DataContext = viewModel;
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
                            DataContext = viewModel;
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
                            DataContext = viewModel;
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
                            DataContext = viewModel;
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
                            DataContext = viewModel;
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
                            DataContext = viewModel;
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
                            DataContext = viewModel;
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
                            DataContext = viewModel;
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

        private void ButtonRefreshTable_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}