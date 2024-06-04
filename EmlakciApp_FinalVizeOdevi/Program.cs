﻿using EmlakciAppLib;
using System.IO;

namespace EmlakciApp_FinalVizeOdevi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (; ;) // ben ekledim aslında yoktu 
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------------------------------------------------------------------"); // Arada Boşluk Olaası İçin
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("1- Kiralık Ev \n2- Satılık Ev \n3- Programdan Çık");
                string secim1 = Console.ReadLine();
                if (secim1 == "1")
                {
                    Console.WriteLine("1- Kayıtlı Ev Görüntüle \n2- Yeni Ev Gir");
                    string secim2 = Console.ReadLine();
                    if (secim2 == "1")
                    {
                        var kayitlikiralikevler = KiralikEv.KiralikEvleriGetir();
                        Console.WriteLine();
                        foreach (KiralikEv item in kayitlikiralikevler)
                        {
                            Console.WriteLine($"Oda Sayısı: {item.odaSayisi} KatNo: {item.katNumarasi} Alanı: {item.alani} metrekare Kira: {item.kirasi} Tl Depozitosu: {item.depozito} Tl");
                            Console.WriteLine();
                        }
                    }
                    else if (secim2 == "2")
                    {
                        bool td;
                        do
                        {
                            Console.WriteLine("Evin Oda Sayısı: ");
                            int odaSayisi = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Evin Kat Numarası: ");
                            int katNo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Evin Alanı: ");
                            int alan = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Evin Kirası: ");
                            int kira = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Evin Depozitosu: ");
                            int depozito = Convert.ToInt32(Console.ReadLine());

                            KiralikEv ke = new KiralikEv(odaSayisi, katNo, alan, depozito, kira);
                            KiralikEv.KiralikEvKaydet(ke);

                            Console.WriteLine("Tamam(t)/ Devam(d)? ");
                            td = Console.ReadLine().ToLower().Trim() == "d" ? true : false;
                        } while (td);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Hatalı Seçim"); // Burayı Düzenle
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                if (secim1 == "2")
                {
                    Console.WriteLine("1- Kayıtlı Ev Görüntüle \n2- Yeni Ev Gir");
                    string secim2 = Console.ReadLine();
                    if (secim2 == "1")
                    {
                        var kayitliSatilikEvler = SatilikEv.SatilikEvleriGetir();
                        Console.WriteLine();
                        foreach (SatilikEv item in kayitliSatilikEvler)
                        {
                            Console.WriteLine($"Oda Sayısı: {item.odaSayisi} KatNo: {item.katNumarasi} Alanı: {item.alani} metrekare Fiyat: {item.fiyati} Tl");
                            Console.WriteLine();
                        }

                    }
                    else if (secim1 == "2")
                    {
                        bool td;
                        do
                        {
                            Console.WriteLine("Evin Oda Sayısı: ");
                            int odaSayisi = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Evin Kat Numarası: ");
                            int katNo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Evin Alanı: ");
                            int alan = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Evin Fiyatı: ");
                            int fiyati = Convert.ToInt32(Console.ReadLine());

                            SatilikEv ke = new SatilikEv(odaSayisi, katNo, alan, fiyati);
                            SatilikEv.SatilikEvKaydet(ke);

                            Console.WriteLine("Tamam(t)/ Devam(d)? ");
                            td = Console.ReadLine().ToLower().Trim() == "d" ? true : false;
                        } while (td);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Hatalı Seçim"); // Burayı Düzenle
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                if (secim1 == "3")
                {
                    break;
                }
            }
        }
    }
}