using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpravaFinanci
{
    public class Transakce
    {
         public int Id { get; set; }
         public string Typ { get; set; }     //příjem nebo výdaj
         public decimal Castka { get; set; }
         public string Kategorie { get; set; }
         public string Ucel { get; set; }
         public DateTime Datum { get; set; }
    }
}

