using System.IO;


namespace MtX.Control
{

    public class Source
    {
        public string AppName { get; set; }
        public string TitleId { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public string Line { get; set; }
        public string Path_Romfs { get; set; }
        public string Path_Sd { get; set; }
        public string NroPath { get; set; }
        public string NroName { get; set; }

        public void Meta()
        {
            //Log varibles for debug use
            Tools.Logger("App Name = " + AppName);
            Tools.Logger("Title Id = " + TitleId);
            Tools.Logger("Author = " + Author);
            Tools.Logger("Version = " + Version);

            //replace inputed meta data to .json for building .nacp
            File.WriteAllBytes(Control.DircControl.buildpath + "app.json", Properties.Resources.mct);
            string Json = File.ReadAllText(Control.DircControl.buildpath + "app.json");
            Json = Json.Replace("Title_ID", TitleId);
            Json = Json.Replace("App_Name", AppName);
            Json = Json.Replace("Created_By", Author);
            Json = Json.Replace("Version_Number", Version);
            File.WriteAllText(Control.DircControl.buildpath + "app.json", Json);

            //replace inputed meta data to .json for building makefile
            File.WriteAllBytes(Control.DircControl.buildpath + "makefile", Properties.Resources.mkf);
            string Make = File.ReadAllText(Control.DircControl.buildpath + "makefile");
            Make = Make.Replace("Title_ID", TitleId);
            Make = Make.Replace("App_Name", AppName);
            Make = Make.Replace("Created_By", Author);
            Make = Make.Replace("Version_Number", Version);
            File.WriteAllText(Control.DircControl.buildpath + "makefile", Make);
        }

        public void Build()
        {
            File.WriteAllBytes(Control.DircControl.buildpath + Control.DircControl.sourcepath + "main.c", Properties.Resources.insc);
            Tools.Logger("Line = " + Line);
            Tools.Logger("SdmcPath = " + Path_Sd);
            Tools.Logger("RomfsPath = " + Path_Romfs);
            Tools.Logger("NroName = " + NroName);
            Tools.Logger("NroPath = " + NroPath);
            Tools.Logger("");
            // patch main.c for romfs .nro name
            if (Line == "romfs:")
            {
                string[] lines = File.ReadAllLines(Control.DircControl.buildpath + Control.DircControl.sourcepath + "main.c");
                lines[216] = "         strcpy(g_nextNroPath, \"" + Line + Path_Romfs + "\");";
                lines[217] = "         strcpy(g_nextArgv,    \"" + Line + Path_Romfs + "\");";
                File.WriteAllLines(Control.DircControl.buildpath + Control.DircControl.sourcepath + "main.c", lines);

                if (Directory.Exists(Control.DircControl.buildpath + Control.DircControl.romfspath))
                { System.IO.File.Copy(NroPath, Control.DircControl.buildpath + Control.DircControl.romfspath + NroName, true); }
                else
                {
                    System.IO.Directory.CreateDirectory(Control.DircControl.buildpath + Control.DircControl.romfspath);
                    System.IO.File.Copy(NroPath, Control.DircControl.buildpath + Control.DircControl.romfspath + NroName, true);
                }
            }

            //patch main.c for redirection path
            else if (Line == "sdmc:")
            {
                string[] lines = File.ReadAllLines(Control.DircControl.buildpath + Control.DircControl.sourcepath + "main.c");
                lines[216] = "         strcpy(g_nextNroPath, \"" + Line + Path_Sd + "\");";
                lines[217] = "         strcpy(g_nextArgv,    \"" + Line + Path_Sd + "\");";
                File.WriteAllLines(Control.DircControl.buildpath + Control.DircControl.sourcepath + "main.c", lines);

                //Needed to fill romfs with a file, doesnt like when the romfs is empty even with --noromfs for some reason, temp fix until resolsed
                if (Directory.Exists(Control.DircControl.buildpath + Control.DircControl.romfspath))
                { File.WriteAllBytes(Control.DircControl.buildpath + Control.DircControl.romfspath + "main.nro", Properties.Resources.insc); }
                else
                {
                    System.IO.Directory.CreateDirectory(Control.DircControl.buildpath + Control.DircControl.romfspath);
                    File.WriteAllBytes(Control.DircControl.buildpath + Control.DircControl.romfspath + "main.nro", Properties.Resources.insc);
                }
            }
        }
    }
}
