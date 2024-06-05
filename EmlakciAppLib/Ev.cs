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
            this.alani = alani;
        }

        public abstract void EvYazdir(); //
        public abstract void EvKaydet(); //

    }
}
