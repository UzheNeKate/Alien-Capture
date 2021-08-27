using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    public abstract class Spell : IMagic
    {
        protected readonly Magician magician;
        protected readonly int minMana;

        protected readonly bool pronounce;
        protected readonly bool swing;

        public Spell(Magician _magician, int _minMana = 0, bool _pronounce = false, bool _swing = false)
        {
            minMana = _minMana;
            pronounce = _pronounce;
            swing = _swing;
            magician = _magician;
        }


        public Magician CastSpell { get; set; }

        public int MinMana => minMana;

        public bool Pronounce => pronounce;

        public bool Swing => swing;


        public abstract void PerformMagic(Character character, int power);

        protected void СheckState()
        {
            if (CastSpell == null)
                throw new ArgumentException("No one to cast a spell.");
            if (CastSpell.State == States.Dead)
                throw new ArgumentException("Magician is dead. He can't perform any magic.");
            if ((!CastSpell.CanMove & Swing) | (!CastSpell.CanTalk & Pronounce))
                throw new Exception("Magician can't pefrom an action needed for this spell.");
        }

        protected void СheckMana(int power)
        {
            if (CastSpell.Mana < power | power < MinMana)
                throw new ArgumentException("The amount of mana is too small for that spell.");
        }
    }
}
