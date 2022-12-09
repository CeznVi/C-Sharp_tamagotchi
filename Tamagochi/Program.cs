using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tamagochi
{
    internal class Program
    {
        public delegate string Delegate();
            
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            
            Random random = new Random();
            List<int> list = new List<int>();

            //Кількість життів у зайки
            int life = 3;

            //Тривалість життя тамагочі у мілі секундах (1хв = 60 000 мілісекунд)
            int lifeLenght = 60000;

            //Кількість команд
            int count = 25;
            string name = "Тамагочі Зайка";

            Tamagochi zaika = new Tamagochi();
            //Таймери
            Stopwatch lifeCycle = new Stopwatch();

            Stopwatch st = new Stopwatch();
            Stopwatch st0 = new Stopwatch();

            Delegate[] d = new Delegate[]
            {
                zaika.Eat,
                zaika.Play,
                zaika.Sleap,
                zaika.Walk,
                zaika.Heal
            };
            Delegate method = null;
            

            int temp = random.Next(d.Length);
            list.Add(temp);

            //Генерація бажань зайки
            while(list.Count < count)
            {
                temp = random.Next(d.Length);
                if (temp != list[0])
                {
                    temp = random.Next(d.Length);
                    list.Add(temp);
                }
            }

            lifeCycle.Start();
            while (life > 0 && lifeCycle.ElapsedMilliseconds < lifeLenght)
            {
                
                int it  = 0;
                Console.Clear();
                zaika.Show();

                while (life > 1 && lifeCycle.ElapsedMilliseconds < lifeLenght)
                {
                    Thread.Sleep(800);
                    Console.Clear();

                    int index = list[it];

                    method = d[index];
                    string message = method();

                    if (message == zaika.Eat()) zaika.ShowWantEat();
                    else if(message == zaika.Walk()) zaika.ShowWantWalk();
                    else if (message == zaika.Sleap()) zaika.ShowWantSleap();
                    else if (message == zaika.Play()) zaika.ShowWantPlay();
                    else if (message == zaika.Heal()) zaika.ShowWantHeal();

                    st.Start();
                    var result = MessageBox.Show(message, name, MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK) 
                    {
                        st.Stop();
                        if (st.ElapsedMilliseconds > 10000)
                        {
                            life--;
                            Console.WriteLine("Поки ви думали. Зайка захворів.");
                        }
                        else
                            MessageBox.Show("Дякую!", name, MessageBoxButtons.OK);
                        st.Reset();
                    }
                    else
                    {
                        life--;
                        st.Stop();
                        Console.WriteLine("Поки ви думали. Зайка захворів.");
                        MessageBox.Show(":(", name, MessageBoxButtons.OK);
                        st.Reset();
                        Thread.Sleep(800);
                    }

                    it++;

                    if (it >= list.Count) 
                        it = 0; 
                }
                if(life < 3)
                {
                    Console.Clear();
                    zaika.ShowWantHeal();
                    st0.Start();
                    var needHeal = MessageBox.Show(d[4](), name, MessageBoxButtons.OKCancel);
                    if (needHeal == DialogResult.OK)
                    {
                        st0.Stop();
                        if (st0.ElapsedMilliseconds > 5000)
                        {
                            life = 0;
                            Console.Clear();
                            zaika.Death();
                            Console.WriteLine($"{name} помер поки ви думали...");
                            break;
                        }

                        MessageBox.Show("Ооо дякую!", name, MessageBoxButtons.OK);
                        if (life < 3)
                           life++;
                        st0.Reset();
                    }
                    else
                    {
                        st0.Stop();
                        life = 0;
                        Console.Clear();
                        Console.WriteLine("Зайка загинув.");
                        zaika.Death();
                        Console.ReadKey();
                    }
                    st0.Reset();
                }
            }
            lifeCycle.Stop();
            if (lifeCycle.ElapsedMilliseconds >= lifeLenght)
            {
                Console.Clear();
                zaika.ShowWantGoodBye();
                MessageBox.Show("Зайка прожила з вами щасливе життя!", name, MessageBoxButtons.OK);
            }
        }
    }
}
