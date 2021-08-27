using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    public class VasiliskEye : Artefact
    {
        public VasiliskEye(Character _owner) : base(_owner, 0, false)
        { }

        public void PerformMagic(Character character) => PerformMagic(character, Power);

        public override void PerformMagic(Character character, int power)
        {
            СheckState();

            if (character.State != States.Dead)
                character.State = States.Paralyzed;
        }
    }
}
