using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MtX.Control
{
    public class ImportMeta
    {
    
        // Build folders and copy required files
        public static void SetRequiredComponents()
        {
            if (Directory.Exists(DircControl.buildpath + "Extract")) { }
            else { System.IO.Directory.CreateDirectory(DircControl.buildpath + "Extract"); }

            switch (Tools.RunningPlatform())
            {
                case Tools.Platform.Linux:
                    File.WriteAllBytes(DircControl.buildpath + "nstool", Properties.Resources.nstool_linux);
                    break;

                case Tools.Platform.Mac:
                    File.WriteAllBytes(DircControl.buildpath + "nstool", Properties.Resources.nstool_mac);
                    break;

                case Tools.Platform.Windows:
                    if (Environment.Is64BitOperatingSystem) { File.WriteAllBytes(DircControl.buildpath + "nstool.exe", Properties.Resources.nstool); }
                    else { File.WriteAllBytes(DircControl.buildpath + "nstool.exe", Properties.Resources.nstool); }
                    break;
                default:
                    MessageBox.Show("Couldnt Detect Operating System, This is probably a bug, please report it");
                    break;
            } 
        }
        

        // Win command to extact .nro
        public static void ExtractNroWin(string Args, bool Input, bool Window)
        {
                    ProcessStartInfo info = new ProcessStartInfo()
                    {
                        FileName = @"CMD.EXE",
                        Arguments = Args,
                        CreateNoWindow = Window,
                        RedirectStandardInput = Input,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                    };
            Process p = Process.Start(info);
            Tools.Logger(p.StandardOutput.ReadToEnd());
            Tools.Logger(p.StandardError.ReadToEnd());
            p.WaitForExit();
        }

        // unix command to extact .nro
        public static void ExtractNroUni(String NroName)
        {

            String[] Args = { "sudo chmod -R g+rwx " + DircControl.root, SetCommand(NroName) };

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
                for (int x = 0; x < Args.Length; x++)
                { sw.WriteLine(Args[x]); }
                for (int i = 0; !File.Exists(DircControl.buildpath + "Extract/Control.nacp") && i <= 10; i++)
                {
                    Thread.Sleep(2000);
                    if (i == 10 && !File.Exists(DircControl.buildpath + "Extract/Control.nacp"))
                    { MessageBox.Show("Importing Nro data failed, an issue occured with nstool -- refer to logs"); }
                }

            }
        }
            

        // Get Author from extracted Nacp
        public static string GetMeta(int Selection)
        {
            long Patch;
            if (Selection == 0) { Patch = 0x0000; } //AppName
            else if (Selection == 1) { Patch = 0x0200; } //Author
            else if (Selection == 2) { Patch = 0x3060; } //Version
            else { Patch = 0x0100; } //Some how failed?

            try {
                string FilePath = DircControl.buildpath + "Extract/Control.nacp";
                bool Complete = false;
                int Runs = 0;
                byte[] data = new byte[400];
                BinaryReader reader = new BinaryReader(new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.None));
                reader.BaseStream.Position = Patch;
                while (Complete == false)
                {
                    data[Runs] = reader.ReadByte();
                    if (data[Runs] == 0x00)
                    { Complete = true; }
                    Runs++;
                }
                reader.Close();
                string result = Encoding.ASCII.GetString(data, 0, Runs - 1);
                return result;
            }
            catch (Exception f)
            { MessageBox.Show(f.Message); return null; }
        }
       

        //Pull image and covert as needed
        public static void GetIcon()
        { IconImport.IconConvert(DircControl.buildpath + "Extract/Icon.jpg"); }


        // Nro Extraction string per OS
        public static string SetCommand(string NroName)
        {
            string Command;
            switch (Tools.RunningPlatform())
            {
                case Tools.Platform.Mac:
                    Command = DircControl.buildpath + "nstool ";
                    break;

                case Tools.Platform.Linux:
                    Command = DircControl.buildpath + "nstool ";
                    break;
                default:
                    Command = DircControl.buildpath + "nstool.exe ";
                    break;
            }
            Command += " --type nro --icon " + DircControl.buildpath + "Extract/Icon.jpg --nacp " + DircControl.buildpath + "Extract/Control.nacp " + "\"" + NroName + "\"";
            return Command;
        }

}
}