using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    interface IMagic
    {
        void PerformMagic(Character character = null, int power = 0);
    }
}
