using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public static class ColumnNames
    {
        public static string[] klienci = { "Imię", "Nazwisko", "Pesel (11-cyfrowy)", "Adres", "Miasto", "Kod pocztowy (**-***)", "Kraj", "Telefon ([5-9]********)", "Email (*@domena.com)", "Nazwa_firmy", "Regon" };
        public static string[] uczestnicy = { "ID klienta", "Imię", "Nazwisko", "Pesel (11-cyfowy)", "Data urodzenia (YYYY-MM-DD)", "Miejsce urodzenia", "Adres", "Miasto", "Kod pocztowy (**-***)", "Kraj", "Telefon ([5-9]********)" };
        public static string[] zamowienia = { "ID wycieczki", "ID klienta", "Data zamówienia (YYYY-MM-DD)", "Ilość miejsc", "Status", "Data płatności (YYYY-MM-DD)", "Typ płatności" };
        public static string[] wycieczki = { "ID rezydenta", "Kraj", "Cena za osobe", "Ilość dostępnych miejsc", "Ilość miejsc", "Data wyjazdu (YYYY-MM-DD)", "Data powrotu (YYYY-MM-DD)" };
        public static string[] hotele = { "Nazwa", "Standard", "Kraj", "Miasto", "Adres", "Telefon ([5-9]********)", "Witryna" };
        public static string[] rezydenci = { "Imię", "Nazwisko", "Telefon ([5-9]********)", "Adres", "Miasto", "Kraj", "Email (*@domena.com)" };
        public static string[] uslugi = { "ID wycieczki", "Wyżywienie", "Ubezpieczenie", "Bagaż" };
        public static string[] atrakcje = { "ID wycieczki", "Rodzaj" };

        public static string[] id = { "ID" };
        public static string contentDodaj = "Dodaj";
        public static string contentUsun = "Usuń";
    }
}