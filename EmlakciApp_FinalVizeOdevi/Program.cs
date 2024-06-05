using EmlakciAppLib;
using System.IO;

namespace EmlakciApp_FinalVizeOdevi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (; ;) // ben ekledim aslında yoktu 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-----------------------------Emlakçı---App----------------------------"); // Arada Boşluk Olaası İçin
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("1- Kiralık Ev \n2- Satılık Ev \n3- Programdan Çık");
                string secim1 = Console.ReadLine();
                if (secim1 == "1")
                {
                    Console.Clear(); /*   Silinebilir*/
                    Console.WriteLine("1- Kayıtlı Ev Görüntüle \n2- Yeni Ev Gir");
                    string secim2 = Console.ReadLine();
                    if (secim2 == "1")
                    {
                        Console.Clear(); /*    Silinebilir*/
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Kiralık Evler: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        var kayitlikiralikevler = KiralikEv.KiralikEvleriGetir();
                        Console.WriteLine();
                        foreach (KiralikEv item in kayitlikiralikevler)
                        {
                            item.EvYazdir();
                        }
                    }
                    else if (secim2 == "2")
                    {
                        Console.Clear(); /*    Silinebilir*/
                        bool td;
                        do
                        {
                            Console.WriteLine("Evin Oda Sayısı: ");
                            string odaSayisi = Console.ReadLine();
                            Console.WriteLine("Evin Kat Numarası: ");
                            int katNo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Evin Alanı: ");
                            int alan = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Evin Kirası: ");
                            int kira = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Evin Depozitosu: ");
                            int depozito = Convert.ToInt32(Console.ReadLine());

                            KiralikEv ke = new KiralikEv(odaSayisi, katNo, alan, depozito, kira);
                            ke.EvKaydet();

                            Console.WriteLine("Tamam(t)/ Devam(d)? ");
                            td = Console.ReadLine().ToLower().Trim() == "d" ? true : false;
                        } while (td);
                    }
                    else
                    {
                        HataDondur("Hatalı Seçim");
                    }
                }
                else if (secim1 == "2")
                {
                    Console.Clear(); /*    Silinebilir*/
                    Console.WriteLine("1- Kayıtlı Ev Görüntüle \n2- Yeni Ev Gir");
                    string secim2 = Console.ReadLine();
                    if (secim2 == "1")
                    {
                        Console.Clear(); /*    Silinebilir*/
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Satılık Evler: ");
                        Console.ForegroundColor= ConsoleColor.White;
                        Console.WriteLine();
                        var kayitliSatilikEvler = SatilikEv.SatilikEvleriGetir();
                        Console.WriteLine();
                        foreach (SatilikEv item in kayitliSatilikEvler)
                        {
                            item.EvYazdir();
                        }
                    }
                    else if (secim1 == "2")
                    {
                        Console.Clear(); /*    Silinebilir*/
                        bool td;
                        do
                        {
                            Console.WriteLine("Evin Oda Sayısı: ");
                            string odaSayisi = Console.ReadLine();
                            Console.WriteLine("Evin Kat Numarası: ");
                            int katNo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Evin Alanı: ");
                            int alan = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Evin Fiyatı: ");
                            int fiyati = Convert.ToInt32(Console.ReadLine());

                            SatilikEv se = new SatilikEv(odaSayisi, katNo, alan, fiyati);
                            se.EvKaydet(); //

                            Console.WriteLine("Tamam(t)/ Devam(d)? ");
                            td = Console.ReadLine().ToLower().Trim() == "d" ? true : false;
                        } while (td);
                    }
                    else
                    {
                        HataDondur("Hatalı Seçim");
                    }
                }
                else if (secim1 == "3")
                {
                    break; // 
                }
                else
                {
                    HataDondur("Hatalı Seçim");
                }
            }
        }

        public static void HataDondur(string mesaj) // static ?
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mesaj); // Burayı Düzenle
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}