using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class ColumnNames
    {
        public string[] klienci = { "Imię", "Nazwisko", "Pesel", "Adres", "Miasto", "Kod pocztowy", "Kraj", "Telefon", "Email", "Nazwa firmy", "Regon" };
        public string[] uczestnicy = { "Imię", "Nazwisko", "Pesel", "Data urodzenia", "Miejsce urodzenia", "Adres", "Miasto", "Kod pocztowy", "Kraj", "Telefon"};
        public string[] zamowienia = { "Data zamówienia", "Ilość miejsc", "Status", "Data płatności", "Typ płatności"};
        public string[] wycieczki = { "Kraj", "Cena za osobe", "Ilość dostępnych miejsc", "Ilość miejsc", "Data wyjazdu", "Data powrotu" };
        public string[] rezydenci = { "Imię", "Nazwisko", "Telefon", "Adres", "Miasto", "Kraj", "Email" };
        public string[] uslugi = { "Wyżywienie", "Ubezpieczenie", "Bagaż" };
        public string[] atrakcje = { "Rodzaj" };
        public string[] hotele = { "Nazwa", "Standard", "Kraj", "Miasto", "Adres", "Telefon", "Witryna" };

        public ColumnNames()
        {
            
        }
    }
}