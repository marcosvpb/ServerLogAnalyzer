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
            List<Entity> damageEntities = new List<Entity>();
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


                    if (subs.StartsWith("You")) youLog.Add(subs);
                }
            }


            foreach (string x in youLog)
            {
                // Console.WriteLine(x);
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
                    if (x.Contains("hitpoints"))
                    {
                        var CurrentEntity = x.Substring(9, x.IndexOf(" hitpoints") - 9);
                        //var value = x.Substring(22, x.Length - 33);
                        Console.WriteLine("FORMAT:{0} ENTITY:{1}", "null", CurrentEntity);
                    }

                }
            }


            Console.WriteLine("Total Exp: " + totalExp);
            Console.WriteLine("Total Self Heal: " + amountSelfHPHeal);


            Console.Read(); // ok
        }
    }
}
