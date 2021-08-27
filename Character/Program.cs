using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    class Program
    {
        static void Main(string[] args)
        {
            string name1, name2;
            Console.WriteLine("Введите имя первого персонажа:");
            name1 = Console.ReadLine();
            Console.WriteLine("Введите имя второго персонажа:");
            name2 = Console.ReadLine();
            Character a = new Character(name1);
            Magician mag = new Magician(name2);
            Console.WriteLine("Информация о первом персонаже:");
            Console.WriteLine(a.ToString());
            Console.WriteLine("Информация о втором персонаже:");
            Console.WriteLine(mag.ToString());
            mag.Experience = 20;
            BottleOfDeadWater bot = new BottleOfDeadWater(mag, Volume.Big);
            mag.PickUpArtefact(bot);
            bot.PerformMagic();
            Console.WriteLine("Значение маны персонажа {0} после использования артефакта Бутылка мертвой воды: {1}", mag.Name, mag.Mana);
            if (a.CompareTo(mag) == 1)
                Console.WriteLine("Опыт персонажа {0} больше опыта персонажа {1}", a.Name, mag.Name);
            else if(a.CompareTo(mag) == -1)
                Console.WriteLine("Опыт персонажа {0} меньше опыта персонажа {1}", a.Name, mag.Name);
            else
                Console.WriteLine("Персонажи {0} и {1} равны по опыту", a.Name, mag.Name);
            PoisonousSaliva ps = new PoisonousSaliva(mag, 30);
            mag.PickUpArtefact(ps);
            mag.GiveArtefact(a, ps);
            a.UseArtefact(ps, mag);
            Console.WriteLine("Состояние персонажа {0} после применения к нему артефакта: {1}", mag.Name, mag.State);
            Revive rev = new Revive(mag);
            a.State = States.Dead;
            mag.LearnSpell(rev);
            mag.CastSpell(rev, a);
            Console.WriteLine("Состояние персонажа {0} после заклинания Оживить: {1}", a.Name, a.State);
            Console.ReadKey();
        }
    }
}
