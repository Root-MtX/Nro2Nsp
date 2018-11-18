using System;
using System.Windows.Forms;
using System.IO;
using MtX.Control;
using System.Drawing;
using System.Threading;
using MtX.Control.Properties;

namespace MtX.Nro2Nsp
{
    public partial class Nro : Form

    {
        string line = null;
        string nropath = null;
        string nroname = null;


        public Nro()
        {
            InitializeComponent();
           // Clean Working Directory to avoid unawated files during compile 
            if (Directory.Exists(MtX.Control.DircControl.root))
            { MtX.Control.DircControl.CleanTemp(); }
            if (File.Exists(MtX.Control.DircControl.current_directory + @"./Resources/log.txt"))
            { Control.DircControl.CleanLog(); }
            Reload("Preset Settings:");
        }


        // Import Picture and Convert as needed
        private void Import_Pictures(object sender, EventArgs e)
        {
            Stream fileStream = null;
            OpenFileDialog icon_dlg = new OpenFileDialog
            {
                Title = "Icon",
                Filter = "(*.jpg, *.png, *.bmp, *.jpeg|*.jpg;*.png;*.bmp;*.jpeg;*)"
            };
            if (icon_dlg.ShowDialog() == DialogResult.OK && (fileStream = icon_dlg.OpenFile()) != null)
            {
                Icon_Button.BackgroundImage = Properties.Resources._default;
                IconImport.IconConvert(icon_dlg.FileName);
                Icon_Button.BackgroundImage = Image.FromFile(DircControl.buildpath + DircControl.controlpath + @"icon_AmericanEnglish.dat");
            }
        }

        //Selection for romfs, sdmc, and meta import
        private void RadioButton_Checked(object sender, EventArgs e)
        {
            if (sdmc_select.Checked == true)
            {
                sdmc_path.Enabled = true;
                romfs_path.Enabled = false;
                romfs_path.Clear();
                romfs_path.AppendText("/application.nro");
                sdmc_path.Clear();
                line = "sdmc:";
            }
            else if (romfs_select.Checked == true)
            {
                sdmc_path.Enabled = false;
                sdmc_path.Clear();
                sdmc_path.AppendText("/switch/application/application.nro");
                romfs_path.Clear();
                line = "romfs:";

                //import .nro, add name to romfs_path, and copy to romfs folder
                Stream fileStream = null;
                OpenFileDialog romfs_dlg = new OpenFileDialog
                {
                    DefaultExt = ".nro",
                    Filter = "Hombrew App (*.nro)|*.nro"
                };

                if (romfs_dlg.ShowDialog() == DialogResult.OK && (fileStream = romfs_dlg.OpenFile()) != null)
                {
                    nropath = romfs_dlg.FileName;
                    nroname = romfs_dlg.SafeFileName;
                    romfs_path.AppendText("/" + nroname);
                    DialogResult dialogResult = MessageBox.Show("Would you like to import the Icon, App Name, Author, and Version from loaded Nro?", "Import Meta", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {  
                        ImportMeta.SetRequiredComponents();
                        if (Tools.RunningPlatform() == Tools.Platform.Windows)
                        { ImportMeta.ExtractNroWin("/C " + ImportMeta.SetCommand(@romfs_dlg.FileName), false, true); }
                        else if (Tools.RunningPlatform() == Tools.Platform.Linux || Tools.RunningPlatform() ==  Tools.Platform.Mac)
                        { ImportMeta.ExtractNroUni(@romfs_dlg.FileName); }

                        for (int x = 0; x < 3; x++)
                        {
                            if (x == 0)
                            {
                                name_box.Text = ImportMeta.GetMeta(x);
                                Tools.Logger("Imported Nro AppName: " + ImportMeta.GetMeta(0));
                            }
                            if (x == 1)
                            {
                                author_box.Text = ImportMeta.GetMeta(x);
                                Tools.Logger("Imported Nro Author: " + ImportMeta.GetMeta(1));
                            }
                            if (x == 2)
                            {
                                version_box.Text = ImportMeta.GetMeta(x);
                                Tools.Logger("Imported Nro Version: " + ImportMeta.GetMeta(2));
                            }
                        }

                        ImportMeta.GetIcon();
                        Icon_Button.BackgroundImage = Image.FromFile(DircControl.buildpath + DircControl.controlpath + @"icon_AmericanEnglish.dat");
                    }
                    else if (dialogResult == DialogResult.No)
                    {

                    }
                }
            }
        }


        // ID text box restiction
        private void Input_restrict(object sender, KeyPressEventArgs e)
        {
            Int32 AllowedLines = 16;
            id_box.MaxLength = AllowedLines;
            char c = e.KeyChar;
            {
                if (e.KeyChar != '\b')
                    e.Handled = !System.Uri.IsHexDigit(e.KeyChar);
            }
        }


        // Lets start building evrything 
        private void Compile_button_Click(object sender, EventArgs e)
        {
            Control.DircControl.BuildTemp();

            Tools Checks = new Tools
            {
                IdBox = id_box.Text,
                NameBox = name_box.Text,
                AuthorBox = author_box.Text,
                VersionBox = version_box.Text,
                Line = line
            };

            if (Checks.Compile_Checks() == true)
            {
                Nacp nacp = new Nacp
                {
                    TitleId = id_box.Text,
                    AppName = name_box.Text,
                    Author = author_box.Text,
                    Version = version_box.Text
                };
                nacp.Build();

                Source make = new Source
                {
                    TitleId = id_box.Text,
                    AppName = name_box.Text,
                    Author = author_box.Text,
                    Version = version_box.Text,
                    Path_Sd = sdmc_path.Text,
                    Path_Romfs = romfs_path.Text,
                    Line = line,
                    NroName = nroname,
                    NroPath = nropath
                };
                make.Meta();
                make.Build();
                Control.Tools.LsLog();

                new Thread(() => new PleaseWait().ShowDialog()).Start();
                try
                {
                    switch (Tools.RunningPlatform())
                    {
                        case Tools.Platform.Linux:
                            Tools.UnixCommand(id_box.Text);
                            break;
                        case Tools.Platform.Mac:
                            Tools.UnixCommand(id_box.Text);
                            break;
                        case Tools.Platform.Windows:
                            Tools.WinCommand(@"CMD.EXE", "/c make -C " + DircControl.buildpath, false, true);
                            if (File.Exists(DircControl.buildpath + "build/exefs/main") && File.Exists(DircControl.buildpath + "build/exefs/main.npdm"))
                            {
                                Tools.WinCommand(@"CMD.EXE", "/c " + Tools.HacPackBrew(), false, true);
                            }
                            else
                            { MessageBox.Show("First build step failed, Please Check Devkitpro install and verify Enviroment Varibles are set correctly"); }
                            break;

                        default:
                            MessageBox.Show("Couldnt Detect Operating System, This is probably a bug, please report it");
                            break;
                    }
                }
                catch (Exception f)
                { MessageBox.Show(f.Message); }

                Control.Tools.LsLog();
                PleaseWait w = new PleaseWait();
                w = (PleaseWait)Application.OpenForms["PleaseWait"];
                w.Invoke(new ThreadStart(delegate { w.Close(); }));
            }
            DircControl copy = new DircControl
            {
                TitleId = id_box.Text,
                AppName = name_box.Text
            };
            if (File.Exists(DircControl.buildpath + id_box.Text + ".nsp")) { copy.OutputCopy(); }
            else { MessageBox.Show("Builing of Nsp Failed, Please refer to logs"); }
            Icon_Button.BackgroundImage = Properties.Resources._default;
            if (Convert.ToBoolean(Settings.Default["RollingIdEnable"]) == true)
             { Control.Tools.IncreaseRollingId(); }
            if (Directory.Exists(MtX.Control.DircControl.root))
            { MtX.Control.DircControl.CleanTemp(); }
            Reload("Post Build:");
        }


        // Settings for additional features
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsMenu SettingsDialog = new SettingsMenu();
            SettingsDialog.ShowDialog();
            Reload("Settings Changed:");
        }



        // Reload data from setting changes
        public void Reload(String Called)
        {
            Settings.Default.Reload();
            Tools.Logger(Called);
            Tools.Logger("Custom Devkit Enable: " + Convert.ToBoolean(Settings.Default["CustomDevkitEnable"]));
            Tools.Logger("Custom Devkit Path: " + Settings.Default["CustomDevkitPath"].ToString());
            Tools.Logger("Preset Author Enable: " + Convert.ToBoolean(Settings.Default["SetAuthorEnable"]));
            Tools.Logger("Preset Authot Value: " + Settings.Default["SetAuthor"].ToString());
            Tools.Logger("Rolling Id Enable: " + Convert.ToBoolean(Settings.Default["RollingIdEnable"]));
            Tools.Logger("Rolling Id Value: " + Settings.Default["BaseRollingId"].ToString());
            Tools.Logger("Perserve Data Enable: " + Convert.ToBoolean(Settings.Default["PerserveDataEnable"]));
            Tools.Logger("Old Style Title Key Enable: " + Convert.ToBoolean(Settings.Default["OldTitleKeyEnable"]));

            if (Convert.ToBoolean(Settings.Default["RollingIdEnable"]) == true)
            { id_box.Text = Settings.Default["BaseRollingId"].ToString(); }
            if (Convert.ToBoolean(Settings.Default["SetAuthorEnable"]) == true)
            { author_box.Text = Settings.Default["SetAuthor"].ToString(); }
        }


        //Button for randomizing the title id
        private void Randomize_Click(object sender, EventArgs e)
        {
            bool RollingId = Convert.ToBoolean(Settings.Default["RollingIdEnable"]);
            if (RollingId == false)
            {
               id_box.Text = Control.Tools.RandomizeTitleId();
            }
            else
            { MessageBox.Show("Disable \"Rolling Title Id\" in settings to use randomize feature"); }
        }
    }

}