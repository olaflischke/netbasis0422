using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public class Huehnerei : Ei
    {
        const int Gewichtsuntergrenze = 45;
        const int Gewichtsobergrenze = 81;

        public Huehnerei(Henne mutter) : base(Gewichtsobergrenze, Gewichtsuntergrenze, mutter)
        {
            //this.Gewicht=(new Random()).Next(Gewichtsuntergrenze, Gewichtsobergrenze);
        }
    }
}