using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SERVERLOG
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int totalExp = 0, amountSelfHPHeal = 0;
            string path = @"C:/Users/marco/AppData/Roaming/Tibia/Server Log.txt";
            List<string> youLog = new List<string>();
            string[] readText = File.ReadAllLines(path);

            foreach (string a in readText)
            {
                if (!a.StartsWith("Channel"))
                {
                    var subs = "";
                    try
                    {
                        subs = a.Substring(6, a.Length - 6);
                    }
                    catch (Exception)
                    {

                    }
                    // Console.WriteLine(subs);


                    if (subs.StartsWith("You")) youLog.Add(a);
                }
            }


            foreach (string a in youLog) // Obtém todas as info vindas do Player.
            {
                // Console.WriteLine(x);
                var x = a.Substring(6, a.Length - 6);
                var time = a.Substring(0, 5);
                if (x.Substring(4, x.Length - 4).StartsWith("gained"))
                {
                    var value = x.Substring(11, x.Length - 30);
                    //  Console.WriteLine("FORMAT:{0}", value);
                    totalExp += Convert.ToInt32(value);
                }
                else if (x.Substring(4, x.Length - 4).StartsWith("heal yourself"))
                {
                    var value = x.Substring(22, x.Length - 33);
                    // Console.WriteLine("FORMAT:{0}", value);
                    amountSelfHPHeal += Convert.ToInt32(value);
                }
                else if (x.Substring(4, x.Length - 4).StartsWith("lose"))
                {
                    if (x.Contains("hitpoints due") && !x.Contains("own attack"))
                    {
                        
                        var value = x.Substring(9, x.IndexOf(" hitpoints") - 9);
                        var articleString = x.Substring(40 + value.Length);
                        var Entity = "";
                        if (articleString.StartsWith("an"))
                        {
                            Entity = articleString.Substring(3, articleString.Length - 4);
                            Summary.addMonster(Entity, Convert.ToInt32(value));
                        }
                        else if (articleString.StartsWith("a"))
                        {
                            
                            Entity = articleString.Substring(2, articleString.Length - 3);
                            Summary.addMonster(Entity, Convert.ToInt32(value));

                        } else
                        {
                            Entity = articleString.Substring(0, articleString.Length - 1);
                            Summary.addPlayer(Entity, Convert.ToInt32(value));

                        }
                        //var value = x.Substring(22, x.Length - 33);
                       // Console.WriteLine("TIME: {0} ENTITY: {1} DAMAGE: {2}", time, Entity.ToUpper(), value);
                    }

                }
            }


            Console.WriteLine("Total Exp: " + totalExp);
            Console.WriteLine("Total Self Heal: " + amountSelfHPHeal);

            Console.WriteLine("Player Damage:");

            Summary.showOverallDamagePlayers();

            Console.WriteLine("");
            Console.WriteLine("Monster Damage:");

            Summary.showOverallDamageMonsters();

            Console.Read(); // ok
        }
    }
}
