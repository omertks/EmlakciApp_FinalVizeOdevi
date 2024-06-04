using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EmlakciAppLib
{
    public class SatilikEv:Ev
    {
        public int fiyati { get; set; }

        public SatilikEv(int odaSayisi, int katNumarasi, int alani,int fiyati) :base(odaSayisi,katNumarasi,alani)
        {
            this.fiyati = fiyati;
        }
        public static void SatilikEvKaydet(SatilikEv satilikEv) // bunu static yapmayada bilirdim
        {
            string line;
            StreamReader sr = new StreamReader("E:\\Visual_Studio_2022\\EmlakciApp_FinalVizeOdevi\\EmlakciAppLib\\media\\satilikevler.txt");
            line = sr.ReadToEnd();
            sr.Close();

            StreamWriter sw = new StreamWriter("E:\\Visual_Studio_2022\\EmlakciApp_FinalVizeOdevi\\EmlakciAppLib\\media\\satilikevler.txt");
            sw.Write(line + $",{satilikEv.odaSayisi},{satilikEv.katNumarasi},{satilikEv.alani},{satilikEv.fiyati}");
            sw.Close();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ev Bilgileri Kaydedildi !!!");
            Console.ForegroundColor = ConsoleColor.White;

        }


        public static List<SatilikEv> SatilikEvleriGetir()
        {
            var satilikEvler = new List<SatilikEv>();
            int odasay = 0, katsay = 0, alan = 0,  fiyati = 0;
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
                        fiyati = Convert.ToInt32(deger);
                        satilikEvler.Add(new SatilikEv(odasay, katsay, alan, fiyati));  // Nesneleri oluşturup Col a atma
                        count = 0;
                    }
                    i = j - 1; //
                }

            }
            return satilikEvler;
        }
    }
}
