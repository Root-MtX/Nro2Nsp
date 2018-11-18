using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using MtX.Control.Properties;



namespace MtX.Control
{
    public class Tools
    {
        public string NameBox { get; set; }
        public string AuthorBox { get; set; }
        public string IdBox { get; set; }
        public string VersionBox { get; set; }
        public string Line { get; set; }
        
        // Building source and nsp for win
        public static void WinCommand(string Excu, string Args, bool Input, bool Window)
        {
            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = Excu,
                Arguments = Args,
                CreateNoWindow = Window,
                RedirectStandardInput = Input,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
            };
            Process p = Process.Start(info);
            Logger(p.StandardOutput.ReadToEnd());
            Logger(p.StandardError.ReadToEnd());
            p.WaitForExit();
        }


        // Building source and nsp for unix
        public static void UnixCommand(string TitleId)
        {
            String[] Args = { "export DEVKITPRO=/opt/devkitpro", "export DEVKITARM=/opt/devkitpro/devkitARM", "export DEVKITARM=/opt/devkitpro/devkitA64",
                          "make -C " + DircControl.buildpath, "sudo chmod -R g+rwx " + DircControl.root, HacPackBrew() };

            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo
            {
                FileName = "/bin/bash",
                RedirectStandardInput = true,
                UseShellExecute = false,
            };
            p.StartInfo = info;
            p.Start();
            using (StreamWriter sw = p.StandardInput)
            {
                for (int x = 0; x < 6; x++)
                { sw.WriteLine(Args[x]); }
                for (int i = 0; !File.Exists(DircControl.buildpath + TitleId + ".nsp") && i <= 10; i++)
                {
                    Thread.Sleep(2000);
                    if (i == 10 && !File.Exists(DircControl.buildpath + TitleId + ".nsp"))
                    {
                        if (!File.Exists(DircControl.buildpath + "build/exefs/main") && !File.Exists(DircControl.buildpath + "build/exefs/main"))
                        { MessageBox.Show("First build phase failed --Devkitpro error, Please verify install and enviroment varibles"); }
                        else
                        { MessageBox.Show("Build Process took to long to complete, Please check logs for errors --Hacbrewpack error"); }
                    }
                }
            }
        }


        //Remove special characters from AppName to Prevent errors during build 
        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_' || c == '-')
                { sb.Append(c); }
            }
            return sb.ToString();
        }


        // Hackbrewpac command per OS
        public static string HacPackBrew()
        {
            string buildnsp;
            switch (RunningPlatform())
            {
                case Platform.Mac:
                    buildnsp = DircControl.buildpath + "hacbrewpack ";
                    break;

                case Platform.Linux:
                    buildnsp = DircControl.buildpath + "hacbrewpack ";
                    break;
                default:
                    buildnsp = DircControl.buildpath + "hacbrewpack.exe ";
                    break;
            }
            buildnsp += "--keyset " + DircControl.buildpath + "keys.dat ";
            buildnsp += "--tempdir " + DircControl.buildpath + "raw --ncadir " + DircControl.buildpath;
            buildnsp += "nca " + "--nspdir " + DircControl.buildpath + " --exefsdir " + DircControl.buildpath;
            buildnsp += @"build/exefs" + " --romfsdir " + DircControl.buildpath + DircControl.romfspath;
            buildnsp += " --logodir " + DircControl.buildpath + DircControl.logopath + " --controldir ";
            buildnsp += DircControl.buildpath + DircControl.controlpath + " --keepncadir";
            return buildnsp;
        }


        // Check running platform 
        public enum Platform
        {
            Windows,
            Linux,
            Mac
        }
        public static Platform RunningPlatform()
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Unix:
                    if (Directory.Exists("/Applications")
                        & Directory.Exists("/System")
                        & Directory.Exists("/Users")
                        & Directory.Exists("/Volumes"))
                        return Platform.Mac;
                    else
                        return Platform.Linux;

                case PlatformID.MacOSX:
                    return Platform.Mac;

                default:
                    return Platform.Windows;
            }
        }


        // Compile checkes for building
        public bool Compile_Checks()
        {
            bool OldKeyStyle = Convert.ToBoolean(Settings.Default["OldTitleKeyEnable"]);
            string Keys = Control.DircControl.buildpath + "keys.dat";
            string root = System.IO.Path.GetPathRoot(Environment.CurrentDirectory);
            string dev_kit_win = @"C:\DEVKITPRO\libnx\include\switch.h";
            string dev_kit_unix = root + @"/opt/devkitpro/libnx/include/switch.h";
            string CustomDevkitPath = Settings.Default["CustomDevkitPath"].ToString() + @"\libnx\include\switch.h";
            string imgfind = (Control.DircControl.buildpath + Control.DircControl.controlpath + "icon_AmericanEnglish.dat");
            bool[] ArrayCheck = new bool[8];
            char[] IdChar = IdBox.ToCharArray();

            //Array of checks to enable compiling
            ArrayCheck[0] = File.Exists(Keys); ArrayCheck[1] = File.Exists(dev_kit_win) || File.Exists(dev_kit_unix) || File.Exists(CustomDevkitPath);
            ArrayCheck[2] = NameBox.Length > 0 && NameBox != "App Name"; ArrayCheck[3] = (OldKeyStyle == true && IdBox.Length == 16 && IdBox != "05000A0000000000" && IdChar[0] == '0' && IdChar[1] == '5') ||
                            (OldKeyStyle == false && IdBox.Length == 16 && IdBox != "05000A0000000000" && IdChar[0] == '0' && IdChar[1] == '5' && IdChar[12] == '0' && IdChar[13] == '0' && IdChar[14] == '0' && IdChar[15] == '0');
            ArrayCheck[4] = AuthorBox.Length > 0 && AuthorBox != "Author"; ArrayCheck[5] = VersionBox.Length > 0;
            ArrayCheck[6] = File.Exists(imgfind); ArrayCheck[7] = Line != null;

            //Array of messgages corrosponding to the check if failed
            string[] Errors = { "Could not locate \"Keys.dat\", Please verify its named correctly and located in the \"Resources\" folder", "Devkitpro missing, Make sure its installed or set the custom path in the settings",
            "Entered \"App Name\" is not vaild, Please change and retry", "Entered \"Title Id\" is not vaild, Please change and retry *Vaild Title Id is to start with a 05, ends in 0000, and be 16 Hex char long ex. 05XXXXXXXXXX0000 or revert to old title key style in settings*",
            "Entered \"Author\" is not vaild, Please change and retry","Entered \"Version\" is not vaild, Please change and retry", "Icon is Missing, Please verify a Icon was provided and rety",
            "\"Romfs\" or \"Sdmc\" was not selected, Please select as required and retry" };
            for (int x = 0; x < ArrayCheck.Length; x++)
                if (ArrayCheck[x] == false)
                { MessageBox.Show(Errors[x]); }
            return ArrayCheck.All(a => a);
        }


        // Log streamwriter for log.txt
        public static void Logger(string LogInput)
        {
            string logPath = @"./Resources/log.txt";
            using (StreamWriter Logger = new StreamWriter(logPath, true))
            {  Logger.WriteLine(LogInput); }
        }


        //Directory content logging
        public static void LsLog()
        {
            foreach (string file in Directory.EnumerateFiles(DircControl.buildpath,
           "*.*",
           SearchOption.AllDirectories))
            {
                Logger(file); // Display file path.
            }
            Logger("");
        }


        //  Increase Title Id after successful build
        public static void IncreaseRollingId()
        {
            string BaseRollingId = Settings.Default["BaseRollingId"].ToString();
            char[] BaseRollingIdCharArray = BaseRollingId.ToCharArray();
            
            bool Continue = false;
            bool OldKeyStyle = Convert.ToBoolean(Settings.Default["OldTitleKeyEnable"]);

            if (OldKeyStyle == true)
            {
                int x = BaseRollingId.Length - 1;
                do
                {
                    if (BaseRollingIdCharArray[x] == '9')
                    {
                        BaseRollingIdCharArray[x] = 'A';
                        Continue = false;
                    }
                    else if (!(BaseRollingIdCharArray[x] == 'F' || BaseRollingIdCharArray[x] == 'f'))
                    {
                        BaseRollingIdCharArray[x] = ++BaseRollingIdCharArray[x];
                        Continue = false;
                    }
                    else if ((BaseRollingIdCharArray[x] == 'F' || BaseRollingIdCharArray[x] == 'f'))
                    {
                        BaseRollingIdCharArray[x] = '0';
                        Continue = true;
                        x--;
                    }
                }
                while (Continue == true);
            }
            else
            {
                int x = BaseRollingId.Length - 5;
                do
                {
                    if (BaseRollingIdCharArray[x] == '9')
                    {
                        BaseRollingIdCharArray[x] = 'A';
                        Continue = false;
                    }
                    else if (!(BaseRollingIdCharArray[x] == 'F' || BaseRollingIdCharArray[x] == 'f'))
                    {
                        BaseRollingIdCharArray[x] = ++BaseRollingIdCharArray[x];
                        Continue = false;
                    }
                    else if ((BaseRollingIdCharArray[x] == 'F' || BaseRollingIdCharArray[x] == 'f'))
                    {
                        BaseRollingIdCharArray[x] = '0';
                        Continue = true;
                        x--;
                    }
                }
                while (Continue == true) ;
            }
            Settings.Default["BaseRollingId"] = new string(BaseRollingIdCharArray);
            Settings.Default.Save();
        }


        // Title id randomizer
        public static string RandomizeTitleId()
        {
            int length = 10;
            Random rnd = new Random();
            string RandomId = "05";
            bool OldStyleKey = Convert.ToBoolean(Settings.Default["OldTitleKeyEnable"]);

            if (OldStyleKey == true) { length = 14; }

            for (int x = 0; x < length; x++)
            {
                int hex = rnd.Next(15);
                switch (hex)
                {
                    case 15:
                        RandomId += 'F';
                        break;
                    case 14:
                        RandomId += 'E';
                        break;
                    case 13:
                        RandomId += 'D';
                        break;
                    case 12:
                        RandomId += 'C';
                        break;
                    case 11:
                        RandomId += 'B';
                        break;
                    case 10:
                        RandomId += 'A';
                        break;

                    default:
                        RandomId += hex;
                        break;
                }  
                }
            if (OldStyleKey == true) { return RandomId; }
            else { return RandomId + "0000";  }
            }
    }
    }





        