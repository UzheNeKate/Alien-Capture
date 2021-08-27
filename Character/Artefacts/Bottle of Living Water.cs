using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    public enum Volume
    {
        Little = 10,
        Medium = 25,
        Big = 50
    }

    public class BottleOfLivingWater : Artefact
    {
        public BottleOfLivingWater(Character _owner, Volume volume) : base(_owner, (int)volume, false)
        { }

        public void PerformMagic() => PerformMagic(Owner, Power);

        public override void PerformMagic(Character character, int power)
        {
            СheckState();

            if (character.MaxHealth - character.Health <= Power)
                character.Health = character.MaxHealth;
            else
                character.Health += Power;
        }
    }
}
