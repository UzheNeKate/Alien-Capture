using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    public class AddHealth : Spell
    {
        public AddHealth(Magician _magician) : base(_magician)
        { }

        public void PerformMagic(int power) => PerformMagic(CastSpell, power);

        public override void PerformMagic(Character character, int power)
        {
            СheckState();
            СheckMana(power);

            if (power % 2 == 1)
                power--;

            if (character.MaxHealth - character.Health < power / 2)
            {
                magician.Mana -= (character.MaxHealth - character.Health) * 2;
                character.Health = character.MaxHealth;
            }
            else
            {
                magician.Mana -= power;
                character.Health += power / 2;
            }
        }
    }
}
