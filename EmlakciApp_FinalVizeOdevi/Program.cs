using EmlakciAppLib;

namespace EmlakciApp_FinalVizeOdevi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (; ; ) // ben ekledim aslında yoktu 
            {
                BaslikGoster("Emlakçı Uygulaması"); //

                Console.WriteLine("1- Kiralık Ev \n2- Satılık Ev \n3- Programdan Çık");
                string? secim1 = Console.ReadLine();
                if (secim1 == "1")
                {
                    Console.Clear(); /*   Silinebilir*/
                    BaslikGoster("Kiralık Evler");

                    Console.WriteLine("1- Kayıtlı Ev Görüntüle \n2- Yeni Ev Gir");
                    string? secim2 = Console.ReadLine();
                    if (secim2 == "1")
                    {
                        Console.Clear(); /*    Silinebilir*/
                        BaslikGoster("Kiralık Evler"); //

                        Console.WriteLine();
                        List<KiralikEv> kayitlikiralikevler = KiralikEv.KiralikEvleriGetir(); //
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
                        int kacinciEv = 1;
                        do
                        {
                            BaslikGoster("Kiralık Ev Kayıt"); //

                            Console.WriteLine(kacinciEv + ". Evin Oda Sayısı: ");
                            int odaSayisi = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(kacinciEv + ".Evin Kat Numarası: ");
                            int katNo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(kacinciEv + ".Evin Alanı: ");
                            int alan = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(kacinciEv + ".Evin Kirası: ");
                            int kira = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(kacinciEv + ".Evin Depozitosu: ");
                            int depozito = Convert.ToInt32(Console.ReadLine());

                            KiralikEv ke = new KiralikEv(odaSayisi, katNo, alan, depozito, kira);
                            ke.EvKaydet();

                            Console.WriteLine("Tamam(t)/ Devam(d)? ");

                            kacinciEv++; //

                            td = Console.ReadLine().ToLower().Trim() == "d" ? true : false; //
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
                    BaslikGoster("Satılık Evler");
                    Console.WriteLine("1- Kayıtlı Ev Görüntüle \n2- Yeni Ev Gir");
                    string secim2 = Console.ReadLine();
                    if (secim2 == "1")
                    {
                        Console.Clear(); /*    Silinebilir*/
                        BaslikGoster("Satılık Evler: "); //

                        Console.WriteLine();
                        List<SatilikEv> kayitliSatilikEvler = SatilikEv.SatilikEvleriGetir(); //
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
                        int kacinciEv = 1;
                        do
                        {
                            BaslikGoster("Satılık Ev Kayıt"); //

                            Console.WriteLine(kacinciEv + ". Evin Oda Sayısı: ");
                            int odaSayisi = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(kacinciEv + ". Evin Kat Numarası: ");
                            int katNo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(kacinciEv + ". Evin Alanı: ");
                            int alan = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(kacinciEv + ". Evin Fiyatı: ");
                            int fiyati = Convert.ToInt32(Console.ReadLine());

                            SatilikEv se = new SatilikEv(odaSayisi, katNo, alan, fiyati); //
                            se.EvKaydet(); //

                            kacinciEv++;
                            
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
                    BaslikGoster("Ömer Tekeş");
                    BaslikGoster("23380101054");
                    Console.WriteLine();
                    BaslikGoster("Çıkış Yapıldı");
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

        public static void BaslikGoster(string baslik)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"----------------------------- {baslik} -----------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}