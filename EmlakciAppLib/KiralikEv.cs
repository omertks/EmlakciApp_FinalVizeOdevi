using System;
using System.Collections.Generic;
using System.Text;


using System.IO; //
using System.Security.Cryptography;


namespace EmlakciAppLib
{
    public class KiralikEv : Ev
    {
        private int depozito { get; set; }  //
        private int kirasi { get; set; }    //

        public KiralikEv(int odaSayisi, int katNumarasi, int alani, int dep, int kira) : base(odaSayisi, katNumarasi, alani)
        {
            this.depozito = Ev.PozitifKontrol(dep, "Depozito"); //
            this.kirasi = Ev.PozitifKontrol(kira, "Kira");      //
        }

        public override void EvYazdir()
        {
            Console.WriteLine($"Oda Sayısı: {this.odaSayisi}\t KatNo: {this.katNumarasi}\t Alanı: {this.alani} m{Convert.ToChar(178)}\t Kira: {this.kirasi} TL\t Depozitosu: {this.depozito} Tl");
            Console.WriteLine();
        }
        public override void EvKaydet()
        {
            string line;
            StreamReader sr = new StreamReader("E:\\Visual_Studio_2022\\EmlakciApp_FinalVizeOdevi\\EmlakciAppLib\\media\\kiralikevler.txt");
            line = sr.ReadToEnd();
            sr.Close();

            StreamWriter sw = new StreamWriter("E:\\Visual_Studio_2022\\EmlakciApp_FinalVizeOdevi\\EmlakciAppLib\\media\\kiralikevler.txt");
            sw.Write(line + $",{this.odaSayisi},{this.katNumarasi},{this.alani},{this.depozito},{this.kirasi}");
            sw.Close();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ev Bilgileri Kaydedildi !!!");
            Console.ForegroundColor = ConsoleColor.White;

        }

        public static List<KiralikEv> KiralikEvleriGetir()
        {
            var kiralikEvler = new List<KiralikEv>();
            int odasay = 0;
            int katsay = 0, alan = 0, depoz = 0, kira = 0;
            StreamReader sr;
            string line;
            sr = new StreamReader("E:\\Visual_Studio_2022\\EmlakciApp_FinalVizeOdevi\\EmlakciAppLib\\media\\kiralikevler.txt");
            line = sr.ReadToEnd();
            sr.Close();

            int count = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ',')
                {
                    string deger = "";
                    int j = 0;
                    if (line.Length >= i + 1) //
                    {
                        j = i + 1;
                    }
                    else { break; }
                    while (line[j] != ',')
                    {
                        deger += line[j].ToString();
                        if (line.Length != j + 1) { j++; } // Arraydan taşmamak için
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
                        depoz = Convert.ToInt32(deger);
                    }
                    else if (count == 5)
                    {
                        kira = Convert.ToInt32(deger);
                        kiralikEvler.Add(new KiralikEv(odasay, katsay, alan, depoz, kira));  // Nesneleri oluşturup Col a atma
                        count = 0;
                    }
                    i = j - 1; // hız için
                }

            }
            return kiralikEvler;
        }

    }
}

