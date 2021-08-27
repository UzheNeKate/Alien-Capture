using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    public class BottleOfDeadWater : Artefact
    {
        public BottleOfDeadWater(Character _owner, Volume volume) : base(_owner, (int)volume, false)
        { }

        public void PerformMagic() => PerformMagic(Owner, Power);

        public override void PerformMagic(Character character, int power)
        {
            СheckState();

            if (!(character is Magician))
                throw new ArgumentException();

            Magician magician = character as Magician;

            if (magician.MaxMana - magician.Mana <= Power)
                magician.Mana = magician.MaxMana;
            else
                magician.Mana += Power;
        }
    }
}
