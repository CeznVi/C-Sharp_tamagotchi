using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi
{
	class Tamagochi
	{
        public delegate void Request();

        public string Eat() { return "Нагодуй мене";}
        public string Walk() { return "Пішли гуляти"; }
        public string Sleap() { return "Я хочу спати"; }
        public string Heal() { return "Вилікуй мене"; }
        public string Play() { return "Давай пограємось"; }
        public void avatar()
        {
            Console.WriteLine("______§§____________§§");
            Console.WriteLine("_____§__§__________§__§");
            Console.WriteLine("___§§____§_________§___§");
            Console.WriteLine("__§___§___§_______§____§");
            Console.WriteLine("_§____§____§_____§____§");
            Console.WriteLine("_§___§_§____§___§____§");
            Console.WriteLine("_§§§§___§___§§§§§___§");
            Console.WriteLine("_________§_________§___§§_§§");
            Console.WriteLine("________§___§§_§§___§_§§§c§§§");
            Console.WriteLine("_______§_____________§_§d§§§");
            Console.WriteLine("_______§______§______§__§§§");
            Console.WriteLine("_______§____§___§____§___§");
            Console.WriteLine("________§____§§§____§___§");
            Console.WriteLine("_______§§§§§_____§§§§§_§");
            Console.WriteLine("_§§§__§_____§§§§§_____§__§§§");
            Console.WriteLine("§_§_§§____§_______§__§_§§_§_§");
            Console.WriteLine("§____§_____§_____§__§__§____§");
            Console.WriteLine("_§____§____§_____§_§__§____§");
            Console.WriteLine("__§____§§§§_______§§§§____§");
            Console.WriteLine("___§____§___________§____§");
            Console.WriteLine("____§____§§§_____§§§____§");
            Console.WriteLine("_____§§§§___§§§§§___§§§§");
        }
    }



}
