using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    public class PoisonousSaliva : Artefact
    {
        public PoisonousSaliva(Character _owner, int _Power) : base(_owner, _Power, true)
        { }

        public void PerformMagic(Character character) => PerformMagic(character, Power);

        public override void PerformMagic(Character character, int power)
        {
            СheckState();

            if (character.State != States.Healthy & character.State != States.Weakened)
                throw new ArgumentException();

            if (character.Health - Power <= 0)
                character.State = States.Dead;
            else
            {
                character.Health -= Power;
                character.State = States.Poisoned;
            }

            Power = 0;
        }
    }
}
