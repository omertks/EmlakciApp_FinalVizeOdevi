using System;
using System.Collections.Generic;
using System.Text;

namespace EmlakciAppLib
{
    public abstract class Ev:Object
    {
        public int odaSayisi { get; set; }
        public int katNumarasi { get; set; }
        public int alani { get; set; }


        public Ev(int odaSayisi, int katNumarasi, int alani)
        {
            this.odaSayisi = odaSayisi;
            this.katNumarasi = katNumarasi;
            this.alani = alani;
        }
    }
}
