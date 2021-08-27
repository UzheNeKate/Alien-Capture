using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    public class Unfreeze : Spell
    {
        public Unfreeze(Magician _magician) : base(_magician, 85)
        { }

        public void PerformMagic(Character character) => PerformMagic(character, MinMana);

        public override void PerformMagic(Character character, int power)
        {
            СheckState();
            СheckMana(MinMana);

            if (character.State != States.Paralyzed)
                throw new ArgumentException("Character isn't paralyzed.");

            magician.Mana -= MinMana;
            character.Health = 1;
        }
    }
}
