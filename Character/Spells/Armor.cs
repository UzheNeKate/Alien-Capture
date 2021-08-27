using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Character
{
    public class Armor : Spell
    {
        private Character immunityCharacter;
        private int time;

        public Armor(Magician _magician) : base(_magician, 50)
        {
            immunityCharacter = _magician;
            time = 0;
        }

        public void PerformMagic(int power) => PerformMagic(CastSpell, power);

        public override void PerformMagic(Character character, int power)
        {
            immunityCharacter = character;

            СheckState();
            СheckMana(power);

            power = power / 50 * 50;

            magician.Mana -= power;
            immunityCharacter.Immunity = true;

            time = power / 50;

            //Выставляет броню. Единица времени - 10 секунд.

            Timer armorTimer = new Timer(10000);
            armorTimer.Elapsed += new ElapsedEventHandler(ArmorCheckHandler);
            armorTimer.Start();
        }

        private void ArmorCheckHandler(object sender, ElapsedEventArgs e)
        {
            time--;
            if (time == 0)
            {
                ((Timer)sender).Stop();
                immunityCharacter.Immunity = false;
                return;
            }
        }
    }
}
