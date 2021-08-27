using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    public class FrogLegsDeco : Artefact
    {
        public FrogLegsDeco(Character _owner) : base(_owner, 0, false)
        { }

        public void PerformMagic() => PerformMagic(Owner, Power);

        public override void PerformMagic(Character character, int power)
        {
            СheckState();

            if (character == null)
                character = Owner;

            if (character.State != States.Poisoned)
                throw new ArgumentException();

            if ((double)character.MaxHealth / character.Health < 0.1)
                character.State = States.Weakened;
            else
                character.State = States.Healthy;
        }
    }
}
