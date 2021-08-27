using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    public enum States
    {
        Healthy,
        Weakened,
        Sick,
        Poisoned,
        Paralyzed,
        Dead
    }

    public enum Race
    {
        Human,
        Gnome,
        Elf,
        Orc,
        Goblin
    }

    public enum Gender
    {
        Male,
        Female
    }

    public class Character : IComparable
    {
        static int nextID = 0;
        protected readonly int id;

        protected readonly string name;
        protected readonly Gender gender;
        protected readonly Race race;
        protected int age;

        protected int health;
        protected int maxHealth;

        protected int experience;

        protected States state;

        private List<Artefact> inventory;
        Random random = new Random();

        public Character(string _name, Gender? _gender = null, Race? _race = null, int _maxHealth = 100, int? _age = null,
            bool _canWalk = true, bool _canTalk = true)
        {
            id = nextID++;

            if (_name == null)
                throw new ArgumentNullException();

            name = _name;
            State = States.Healthy;

            CanTalk = _canTalk;
            CanMove = _canWalk;

            Immunity = false;

            inventory = new List<Artefact>();

            age = _age ?? random.Next(18, 99);
            gender = _gender ?? (Gender)random.Next(2);
            race = _race ?? (Race)random.Next(5);

            if (_maxHealth < 0)
                throw new ArgumentException("The health value must be positive.");

                maxHealth = _maxHealth;
            Health = maxHealth;
        }


        public int ID => id;
        public string Name => name;

        public Race CharacterRace => race;
        public Gender CharacterGender => gender;

        public bool CanTalk { get; set; }
        public bool CanMove { get; set; }
        public bool Immunity { get; set; }

        public int Age
        {
            get => age;
            set
            {
                if (value < 0 | value >= Int32.MaxValue)
                    throw new ArgumentOutOfRangeException("The value of the character`s age must be in the range from 0 to 2147483647");

                age = value;
            }
        }

        public int Health
        {
            get => health;
            set
            {
                if (Immunity & value < Health)
                    throw new ArgumentException();
                if (value < 0)
                    throw new ArgumentOutOfRangeException("The health value mustn`t be negative.");
                else if (value > maxHealth)
                    throw new ArgumentOutOfRangeException("The health value mustn`t be greater than the max health.");
                if (value > 0)
                {
                    if ((double)value / maxHealth < 0.1 & state == States.Healthy)
                        state = States.Weakened;
                    if ((double)value / maxHealth >= 0.1 & state == States.Weakened)
                        state = States.Healthy;
                }
                else
                    state = States.Dead;

                health = value;
            }
        }

        public int MaxHealth
        {
            get => maxHealth;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("The health value mustn`t be negative.");
                if (maxHealth > value)
                    throw new ArgumentOutOfRangeException("Max health value must be greater than current value!");

                maxHealth = value;
            }
        }

        public int Experience
        {
            get => experience;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("The experience value mustn`t be negative");
                if (experience > value)
                    throw new ArgumentOutOfRangeException("Experience value must be greater than current value!");
                experience = value;
            }
        }

        public virtual States State
        {
            get => state;
            set
            {
                if (Immunity & value != States.Healthy)
                    throw new ArgumentException();

                if (value == States.Dead)
                {
                    CanMove = false;
                    CanTalk = false;
                    health = 0;
                }
                else if (value == States.Paralyzed)
                {
                    CanMove = false;
                }

                state = value;
            }
        }

        public int CompareTo(Object obj)
        {
            if (!(obj is Character))
                throw new ArgumentException("Object is not a Character");
            Character otherCharacter = obj as Character;
            if (this.experience < otherCharacter.experience)
                return -1;
            if (this.experience > otherCharacter.experience)
                return 1;
            return 0;
        }

        public override string ToString()
        {
            return String.Format("ID персонажа: {0}\n Имя персонажа: {1}\n Пол персонажа: {2}\n Раса персонажа: {3}\n Возраст персонажа: {4}\n Здоровье персонажа: {5}/{6}\n Опыт персонажа: {7}\n Состояние персонажа: {8}\n",
                                   ID, Name, CharacterGender, CharacterRace, Age, Health, MaxHealth, Experience, State);
        }

        public void PickUpArtefact(Artefact artefact)
        {
            artefact.Owner = this;
            inventory.Add(artefact);
        }

        public bool ThrowArtefact(Artefact artefact)
        {
            if (!inventory.Remove(artefact))
                return false;

            artefact.Owner = null;
            return true;
        }

        public bool GiveArtefact(Character character, Artefact artefact)
        {
            if (!ThrowArtefact(artefact))
                return false;

            artefact.Owner = character;
            character.PickUpArtefact(artefact);

            return true;
        }

        public bool UseArtefact(Artefact artefact, Character character = null, int power = 0)
        {
            if (!inventory.Contains(artefact))
                return false;

            artefact.PerformMagic(character, power);

            if (!artefact.IsRenewable)
                ThrowArtefact(artefact);

            return true;
        }
    }
}
