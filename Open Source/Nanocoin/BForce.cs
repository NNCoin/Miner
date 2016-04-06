using System;
using System.Net;
using System.IO;
using System.Text;
using System.Web;
using System.Diagnostics;
using System.Threading;
using SMSDevelopmentAndSupport.RmsV.bi.Common;

namespace MiningBForce
{
    class BForce
    {
        public static string Shuffle(string str)
        {
            char[] array = str.ToCharArray();
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return new string(array);
        }
        public static string force1(int line){
            string A = "0123456789abcdef0123456789abcdef0123456789abcdef"+
                       "0123456789abcdef0123456789abcdef0123456789abcdef"+
                       "0123456789abcdef0123456789abcdef0123456789abcdef"+
                       "0123456789abcdef0123456789abcdef0123456789abcdef"+
                       "0123456789abcdef";
        	string B = "012345678901234567890123456789012345678901234567890123456789";
            string hash = Shuffle(A);
            string code = Shuffle(B);
	        string C = Shuffle(hash).Substring(0,13)+"doc"+Shuffle(code);
	        string K = C.Substring(0,16+5);
            string[] end = {
                K
            };
            return end[line];
        }
        public static string force2(int line)
        {
            string A = "0123456789abcdef0123456789abcdef0123456789abcdef" +
                       "0123456789abcdef0123456789abcdef0123456789abcdef" +
                       "0123456789abcdef0123456789abcdef0123456789abcdef" +
                       "0123456789abcdef0123456789abcdef0123456789abcdef" +
                       "0123456789abcdef";
            string B = "012345678901234567890123456789012345678901234567890123456789";
            string hash = Shuffle(A);
            string code = Shuffle(B);
            string C = Shuffle(hash).Substring(0, 13) + "doc" + Shuffle(code);
            string K = C.Substring(0, 16 + 4);
            string[] end = {
                K
            };
            return end[line];
        }
        static void FuncS(string address, string hash){
            string seeker = address;
            string search = hash;
            var id = force1(0);
            Console.WriteLine("[code] " + id);
            string page = string.Format("http://nanocoin-global.com/blockchain/mine?address=" + seeker + "&hash=" + search + "&id=" + id);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(page);
            req.Method = "GET";
            req.ContentType = "application/x-www-form-urlencoded";
            using (var response1 = req.GetResponse())
            {
                using (var responseStream = response1.GetResponseStream())
                {
                    Stream dataStream1 = response1.GetResponseStream();
                    StreamReader reader1 = new StreamReader(dataStream1);
                    string result1 = reader1.ReadToEnd();
                    if (result1 == "1")
                    {
                        Console.WriteLine("======================================================================");
                        Console.WriteLine("[MINED] HASH  :::  " + search + "  _  ID  :::  " + id);
                        Console.WriteLine("======================================================================");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to back to the menu!");
                        Console.ReadKey();
                        Main();
                    }
                    reader1.Close();
                    req.Abort();
                    responseStream.Close();
                }
            }
            var id2 = force2(0);
            Console.WriteLine("[code] " + id2);
            string page2 = string.Format("http://nanocoin-global.com/blockchain/mine?address=" + seeker + "&hash=" + search + "&id=" + id2);
            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create(page2);
            req2.Method = "GET";
            req2.ContentType = "application/x-www-form-urlencoded";
            using (var response2 = req2.GetResponse())
            {
                using (var responseStream = response2.GetResponseStream())
                {
                    Stream dataStream2 = response2.GetResponseStream();
                    StreamReader reader2 = new StreamReader(dataStream2);
                    string result2 = reader2.ReadToEnd();
                    if (result2 == "1")
                    {
                        Console.WriteLine("======================================================================");
                        Console.WriteLine("[MINED] HASH  :::  " + search + "  _  ID  :::  " + id2);
                        Console.WriteLine("======================================================================");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to back to the menu!");
                        Console.ReadKey();
                        Main();
                    }
                    reader2.Close();
                    req2.Abort();
                    responseStream.Close();
                }
            }
        }
        static void FuncR(string address)
        {
            string seeker = address;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            var id = force1(0);
            var hash_code = BCrypt.HashPassword(id, "$2a$08$WGtSTDQ4dkhjNTNrejB3Mw==$");
            stopwatch.Stop();
            TimeSpan timems = stopwatch.Elapsed;
            string ms = String.Format("{0:00}s {1:00}ms", timems.Seconds, timems.Milliseconds / 10);
            Console.WriteLine("======================================================================");
            Console.WriteLine("[Hash/ms: " + ms + "]");
            Console.WriteLine("[hash] " + hash_code);
            string trynote = "======  TRYING COMBINATIONS  ======";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (trynote.Length / 2)) + "}", trynote));
            Console.WriteLine("[code] " + id);
            string page = string.Format("http://nanocoin-global.com/blockchain/mine?address=" + seeker + "&hash=" + hash_code + "&id=" + id);
            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(page);
            req.Method = "GET";
            req.ContentType = "application/x-www-form-urlencoded";
            //WebResponse response1 = req.GetResponse();
            using (var response1 = req.GetResponse())
            {
                using (var responseStream = response1.GetResponseStream())
                {
                    Stream dataStream1 = response1.GetResponseStream();
                    StreamReader reader1 = new StreamReader(dataStream1);
                    string result1 = reader1.ReadToEnd();
                    Console.WriteLine(result1);
                    Console.WriteLine(result1);
                    Console.WriteLine(result1);
                    Console.WriteLine(result1);
                    Console.WriteLine(result1);
                    Console.WriteLine(result1);
                    if (result1 == "1")
                    {
                        Console.WriteLine("======================================================================");
                        Console.WriteLine("[MINED] HASH  :::  " + hash_code + "  _  ID  :::  " + id);
                        Console.WriteLine("======================================================================");
                    }
                    reader1.Close();
                    req.Abort();
                    responseStream.Close();
                }
            }
            stopwatch2.Stop();
            TimeSpan timems2 = stopwatch2.Elapsed;
            string ms2 = String.Format("{0:00}m {1:00}s {2:00}ms", timems2.Minutes, timems2.Seconds, timems2.Milliseconds / 10);
            Console.WriteLine("[Timing: " + ms2 + "]");
            var stopwatch3 = new Stopwatch();
            stopwatch3.Start();
            var stopwatch4 = new Stopwatch();
            stopwatch4.Start();
            var id2 = force2(0);
            var hash_code2 = BCrypt.HashPassword(id2, "$2a$08$WGtSTDQ4dkhjNTNrejB3Mw==$");
            stopwatch3.Stop();
            TimeSpan timemst = stopwatch3.Elapsed;
            string mst = String.Format("{0:00}s {1:00}ms", timems.Seconds, timemst.Milliseconds / 10);
            Console.WriteLine("======================================================================");
            Console.WriteLine("[Hash/ms: " + mst + "]");
            Console.WriteLine("[hash] " + hash_code2);
            string trynotet = "======  TRYING COMBINATIONS  ======";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (trynote.Length / 2)) + "}", trynotet));
            Console.WriteLine("[code] " + id2);
            string page2 = string.Format("http://nanocoin-global.com/blockchain/mine?address=" + seeker + "&hash=" + hash_code2 + "&id=" + id2);
            System.Net.HttpWebRequest req2 = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(page2);
            req2.Method = "GET";
            req2.ContentType = "application/x-www-form-urlencoded";
            //WebResponse response2 = req2.GetResponse();
            using (var response2 = req2.GetResponse())
            {
                using (var responseStream = response2.GetResponseStream())
                {
                    Stream dataStream2 = response2.GetResponseStream();
                    StreamReader reader2 = new StreamReader(dataStream2);
                    string result2 = reader2.ReadToEnd();
                    Console.WriteLine(result2);
                    Console.WriteLine(result2);
                    Console.WriteLine(result2);
                    Console.WriteLine(result2);
                    Console.WriteLine(result2);
                    Console.WriteLine(result2);
                    if (result2 == "1")
                    {
                        Console.WriteLine("======================================================================");
                        Console.WriteLine("[MINED] HASH  :::  " + hash_code2 + "  _  ID  :::  " + id2);
                        Console.WriteLine("======================================================================");
                    }
                    reader2.Close();
                    req2.Abort();
                    responseStream.Close();
                }
            }
            stopwatch4.Stop();
            TimeSpan timemst2 = stopwatch4.Elapsed;
            string mst2 = String.Format("{0:00}m {1:00}s {2:00}ms", timemst2.Minutes, timemst2.Seconds, timemst2.Milliseconds / 10);
            Console.WriteLine("[Timing: " + mst2 + "]");
        }

        static void Main()
        {
            Console.Title = "Nanocoin Miner :: Brute Force";
            try
            {
                string server = string.Format("http://nanocoin-global.com/blockchain/mine");
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(server);
                WebResponse respons = request.GetResponse();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Welcome to software Nanocoin \u00A9 Mining BForce!");
                Console.WriteLine();
                Console.WriteLine("This is a generic version of the code, BForce is open source,");
                Console.WriteLine("so you can enhances it can then achieve better performance and mining speed.");
                Console.WriteLine("Good Farm!");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[your public address] ");
                Console.ForegroundColor = ConsoleColor.White;
                var seeker = Console.ReadLine();
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("========");
                Console.WriteLine("  MENU  ");
                Console.WriteLine("========");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Enter key [S]: To mine a specific hash.");
                Console.WriteLine("Enter key [R]: To try random combinations.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                string menu = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                if (menu.ToUpper() == "S" || menu.ToUpper() == "R") {
                    Console.Clear();
                    if (menu.ToUpper() == "S") {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Enter the hash code:");
                        Console.Write(">> ");
                        Console.ForegroundColor = ConsoleColor.White;
                        string find = Console.ReadLine();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        var search = find;
                        Console.WriteLine("======================================================================");
                        Console.WriteLine("[hash] " + search);
                        string trynote = "======  TRYING COMBINATIONS  ======";
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (trynote.Length / 2)) + "}", trynote));
                        for (int i = 0; i == 0;)
                        {
                            FuncS(seeker,search);
                        }
                    }else if (menu.ToUpper() == "R") {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        for (int i = 0; i == 0;)
                        {
                        FuncR(seeker);
                        }
                    } else {
                        Console.WriteLine("Invalid command, will be restarting in 5 seconds.");
                        Thread.Sleep(5000);
                        Main();
                    }
                }
            }
            catch (WebException ex)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error, you can't connect to the network...");
                Console.WriteLine("Check your internet connection.");
                Console.WriteLine("If the problem persists, please contact: http://fb.com/Nanocoin");
                Console.WriteLine();
                Console.WriteLine("Press any key to try again!");
                Console.ReadKey();
                Console.Clear();
                Main();
            }
        }
    }
}