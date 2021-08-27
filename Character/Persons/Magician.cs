using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    public class Magician : Character
    {
        private int mana;
        private int maxMana;

        private HashSet<Spell> spells;

        public Magician(string _name, Gender? _gender = null, Race? _race = null, int _maxHealth = 100, int? _age = null, int _maxMana = 200)
            : base(_name, _gender, _race, _maxHealth, _age)
        {
            if (_maxMana < 0)
                throw new ArgumentException("The mana value mustn`t be negative.");
            maxMana = _maxMana;
            mana = maxMana;
            spells = new HashSet<Spell>();
        }

        public override States State
        {
            get => base.State;
            set
            {
                if (value == States.Dead)
                    Mana = 0;

                base.State = value;
            }
        }

        public int Mana
        {
            get => mana;
            set
            {
                if(value < 0)
                    throw new ArgumentOutOfRangeException("The mana value mustn`t be negative.");
                else if (value > MaxMana)
                    throw new ArgumentOutOfRangeException("The mana value mustn`t be greater than maximum");

                mana = value;
            }
        }

        public int MaxMana
        {
            get => maxMana;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("The mana value mustn`t be negative.");
                if (MaxMana > value)
                    throw new ArgumentOutOfRangeException("The max value of mana must be greater than current!");

                maxMana = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(" Мана персонажа:{0}/{1}\n", Mana, MaxMana);
        }

        public bool CastSpell(Spell spell, Character character = null, int power = 0)
        {
            if (!spells.Contains(spell))
                return false;

            spell.PerformMagic(character, power);
            return true;
        }

        public bool LearnSpell(Spell spell)
        {
            spell.CastSpell = this;
            return spells.Add(spell);
        }

        public bool ForgetSpell(Spell spell)
        {
            spell.CastSpell = null;
            return spells.Remove(spell);
        }
    }
}
