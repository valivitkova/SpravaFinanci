using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpravaFinanci
{
    public class FinancniZaznam
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public string Popis {  get; set; }
        public string? Poznamka { get; set; }
        public decimal Castka { get; set; }
        public bool JePrijem { get; set; }
        public string TypTextem
        {
            get
            {
                if (JePrijem == true)
                    return "Příjem";
                else
                    return "Výdaj";
            }
        }
    }
}
