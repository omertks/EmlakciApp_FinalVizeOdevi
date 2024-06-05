using System;
using System.Collections.Generic;
using System.Text;

namespace EmlakciAppLib
{
    public abstract class Ev:Object
    {
        protected string odaSayisi { get; set; }
        protected int katNumarasi { get; set; }
        protected int alani { get; set; }
        public Ev(string odaSayisi, int katNumarasi, int alani)
        {
            this.odaSayisi = odaSayisi;
            this.katNumarasi = katNumarasi;
            this.alani = Ev.PozitifKontrol(alani,"Alan");
        }

        public abstract void EvYazdir(); //
        public abstract void EvKaydet(); //

        public static int PozitifKontrol(int deger,string degerAdi)
        {
            for (; ; ) 
            {
                if (deger <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(degerAdi+" Değeri 0'dan Büyük Olmalıdır !!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Yeni Bir Değer Giriniz: ");
                    deger = Convert.ToInt32(Console.ReadLine());
                }
                else { break; }
            }
            return deger;
        }

    }
}
