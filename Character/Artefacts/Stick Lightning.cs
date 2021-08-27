using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    public class StaffLightning : Artefact
    {
        public StaffLightning(Character _owner, int _Power) : base(_owner, _Power, true)
        { }

        public void PerformMagic(Character character) => PerformMagic(character, Power);

        public override void PerformMagic(Character character, int power)
        {
            СheckState();
            СheckMana(power);

            if (character.Health - power <= 0)
                character.State = States.Dead;
            else
                character.Health -= power;

            Power -= power;
        }
    }
}
