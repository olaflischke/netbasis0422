using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public abstract class Tier
    {
        private string _name;

        public string Name
        {
            get { return _name; }
             set
            {
                _name = value;
                //OnEigenschaftGeaendert();
            }
        }
        public abstract void Fressen();
    }
}