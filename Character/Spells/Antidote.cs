using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    public class Antidote : Spell
    {
        public Antidote(Magician _magician) : base(_magician, 30)
        { }

        public void PerformMagic() => PerformMagic(CastSpell, MinMana);

        public override void PerformMagic(Character character, int power)
        {
            СheckState();
            СheckMana(MinMana);

            if (character.State != States.Poisoned)
                throw new ArgumentException("Character isn't poisoned.");

            magician.Mana -= MinMana;

            if ((double)character.Health / character.MaxHealth < 0.1)
                character.State = States.Weakened;
            else
                character.State = States.Healthy;
        }
    }
}
