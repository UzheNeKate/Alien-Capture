using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    public class Cure : Spell
    {
        public Cure(Magician _magician) : base(_magician, 20)
        { }

        public void PerformMagic() => PerformMagic(CastSpell, MinMana);

        public override void PerformMagic(Character character, int power)
        {
            СheckState();
            СheckMana(MinMana);

            if (character.State != States.Sick)
                throw new ArgumentException("Character isn't sick.");

            magician.Mana -= MinMana;

            if ((double)character.Health / character.MaxHealth < 0.1)
                character.State = States.Weakened;
            else
                character.State = States.Healthy;
        }
    }
}
