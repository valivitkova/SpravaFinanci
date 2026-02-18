using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpravaFinanci
{
    public class FiltrData
    {
        public DateTime? DatumOd { get; set; }
        public DateTime? DatumDo { get; set; }
        public decimal? CastkaOd { get; set; }
        public decimal? CastkaDo { get; set; }
        public string? Kategorie { get; set; }
        public bool? JePrijem { get; set; } //true - prijem  false - vydaj null - vsechno
    }
}
