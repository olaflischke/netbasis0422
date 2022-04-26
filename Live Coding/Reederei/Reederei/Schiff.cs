using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reederei
{
    public class Schiff
    {
        public string Name { get; set; }

        public int BruttoRegistertonnen { get; set; }

        public List<Mitarbeiter> Besatzung { get; set; }
    }
}