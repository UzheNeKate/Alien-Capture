using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    public abstract class Artefact : IMagic
    {
        protected int power;
        protected readonly bool isRenewable;

        public Artefact(Character _owner, int _Power, bool _isRenewable)
        {
            Owner = _owner;
            power = _Power;
            isRenewable = _isRenewable;
        }

        public Character Owner { get; set; }

        public int Power
        {
            get => power;
            set
            {
                if (value < 0)
                    throw new ArgumentException();

                power = value;
            }
        }

        public bool IsRenewable => isRenewable;


        public abstract void PerformMagic(Character character, int power);

        protected void СheckState()
        {
            if (Owner == null | Owner.State == States.Dead)
                throw new Exception();
        }

        protected void СheckMana(int power)
        {
            if (Power < power)
                throw new Exception("The amount of artifact power is smaller than required.");
        }
    }
}
