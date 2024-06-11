using System;
using System.Collections.Generic;
using System.IO; //
using System.Text;

namespace EmlakciAppLib
{
    public class SatilikEv:Ev
    {
        private int fiyati { get; set; }   //

        public SatilikEv(int odaSayisi, int katNumarasi, int alani,int fiyati) :base(odaSayisi,katNumarasi,alani)
        {
            this.fiyati = Ev.PozitifKontrol(fiyati,"Fiyat"); //
        }

        public override void EvYazdir()
        {
            Console.WriteLine($"Oda Sayısı: {this.odaSayisi}\t KatNo: {this.katNumarasi}\t Alanı: {this.alani} m{Convert.ToChar(178)}\t Fiyat: {this.fiyati} TL");
            Console.WriteLine();
        }

        public override void EvKaydet()
        {
            string line;
            StreamReader sr = new StreamReader("E:\\Visual_Studio_2022\\EmlakciApp_FinalVizeOdevi\\EmlakciAppLib\\media\\satilikevler.txt"); //
            line = sr.ReadToEnd();
            sr.Close();

            StreamWriter sw = new StreamWriter("E:\\Visual_Studio_2022\\EmlakciApp_FinalVizeOdevi\\EmlakciAppLib\\media\\satilikevler.txt"); //
            sw.Write(line + $",{this.odaSayisi},{this.katNumarasi},{this.alani},{this.fiyati}");
            sw.Close();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ev Bilgileri Kaydedildi !!!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static List<SatilikEv> SatilikEvleriGetir()
        {
            var satilikEvler = new List<SatilikEv>();
            int odasay = 0;
            int katsay = 0, alan = 0, fiyati = 0;
            StreamReader sr;
            string line;
            sr = new StreamReader("E:\\Visual_Studio_2022\\EmlakciApp_FinalVizeOdevi\\EmlakciAppLib\\media\\satilikevler.txt");
            line = sr.ReadToEnd();
            sr.Close();
            int count = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ',')
                {
                    string deger = "";
                    int j = 0;
                    if (line.Length >= i + 1) 
                    {
                        j = i + 1;
                    }
                    else { break; }
                    while (line[j] != ',')
                    {
                        deger += line[j].ToString();
                        if (line.Length != j + 1) { j++; } // 
                        else { break; }
                    }
                    count++;
                    if (count == 1)
                    {
                        odasay = Convert.ToInt32(deger);
                    }
                    else if (count == 2)
                    {
                        katsay = Convert.ToInt32(deger);
                    }
                    else if (count == 3)
                    {
                        alan = Convert.ToInt32(deger);
                    }
                    else if (count == 4)
                    {
                        fiyati = Convert.ToInt32(deger);
                        satilikEvler.Add(new SatilikEv(odasay, katsay, alan, fiyati));  // 
                        count = 0;
                    }
                    i = j - 1; // 
                }

            }
            return satilikEvler;
        }




        // Filtreleme İstenmezse Sil
        public static List<SatilikEv> Filtrele()
        {
            List<SatilikEv> kiralikEvler = SatilikEvleriGetir(); //
            List<SatilikEv> cikti = new List<SatilikEv>();

            Console.WriteLine("Hangisine Göre Filtrelensin:\n1-)Oda Sayısı\n2-)Alan\n3-)Fiyat");
            string secim = Console.ReadLine();
            Console.WriteLine("Minimum değer: ");
            int minDeger = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Maximum değer: ");
            int maxDeger = Convert.ToInt32(Console.ReadLine());
            int kosulDegeri = 0;

            foreach (SatilikEv item in kiralikEvler)
            {
                switch (secim)
                {
                    case "1":
                        kosulDegeri = item.odaSayisi;
                        break;
                    case "2":
                        kosulDegeri = item.alani;
                        break;
                    case "3":
                        kosulDegeri = item.fiyati;
                        break;
                    default:
                        Console.WriteLine("Hatalı Seçim Yaptınız!!!");
                        break;
                }

                if (kosulDegeri >= minDeger && kosulDegeri <= maxDeger)
                {
                    cikti.Add(item);
                }

            }
            return cikti;
        }
    }
}
