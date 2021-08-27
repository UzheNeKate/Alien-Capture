using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    public class Revive : Spell
    {
        public Revive(Magician _magician) : base(_magician, 150)
        { }

        public void PerformMagic(Character character) => PerformMagic(character, MinMana);

        public override void PerformMagic(Character character, int power)
        {
            СheckState();
            СheckMana(MinMana);

            if (character.State != States.Dead)
                throw new ArgumentException("Character isn't dead.");

            magician.Mana -= power;
            character.Health = 1;
            character.State = States.Weakened;
        }
    }
}
