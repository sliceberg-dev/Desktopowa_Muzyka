using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Desktopowa_Muzyka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int j = 0;
        Utwor[] utwory = new Utwor[100];
        private int actualCount = 14; // Liczba faktycznie załadowanych wpisów

        public MainWindow()
        {
            InitializeComponent();
           
           // using StreamReader reader = new("/Assets/Data.txt");

            string[] linie = File.ReadAllLines("C:\\Users\\5Tp\\source\\repos\\Desktopowa_Muzyka\\Desktopowa_Muzyka\\Assets\\Data.txt");

     //   C: \Users\5Tp\source\repos\Desktopowa_Muzyka
            int i = 0;
            foreach (string linia in linie)
            {
                if (linia == "") { i++; }
                else
                {
                    utwory[i] = new Utwor((linie[i * 6 + 0]), (linie[i * 6 + 1]), int.Parse(linie[i * 6 + 2]), int.Parse(linie[i * 6 + 3]), long.Parse(linie[i * 6 + 4]));
                }
            }

           

            wykonawca.Content = utwory[j].artist;
            album.Content = utwory[j].album;
            liczba.Content = utwory[j].songsNumber;
            rok.Content = utwory[j].year;
            pobrania.Content = utwory[j].downloadNumber;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (j < actualCount - 1)
            {
                j++;
            }
            else
            {
                j = 0;
            }
            
            wykonawca.Content = utwory[j].artist;
            album.Content = utwory[j].album;
            liczba.Content = utwory[j].songsNumber;
            rok.Content = utwory[j].year;
            pobrania.Content = utwory[j].downloadNumber;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (j > 0 && j < utwory.Length && utwory[j] != null)  // Zmieniony warunek
            {
                j--;
                
            }
            else
            {
                j = actualCount - 1;  // Zmień na indeks ostatniego elementu
               
            }
            wykonawca.Content = utwory[j].artist;
            album.Content = utwory[j].album;
            liczba.Content = utwory[j].songsNumber;
            rok.Content = utwory[j].year;
            pobrania.Content = utwory[j].downloadNumber;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            utwory[j].downloadNumber += 1;
            pobrania.Content = utwory[j].downloadNumber;
        }
    }

    class Utwor
    {
        public string artist;
        public string album;
        public int songsNumber;
        public int year;
        public long downloadNumber;

        public Utwor(string artist, string album, int songsNumber, int year, long downloadNumber)
        {
            this.artist = artist;
            this.album = album;
            this.songsNumber = songsNumber;
            this.year = year;
            this.downloadNumber = downloadNumber;
        }
        public void Wyswietl()
        {
            Console.WriteLine(artist);
            Console.WriteLine(album);
            Console.WriteLine(songsNumber);
            Console.WriteLine(year);
            Console.WriteLine(downloadNumber);
            Console.WriteLine();

        }

    }
}