using System;
using System.Windows.Forms;
using System.IO;
using MtX.Control;
using System.Drawing;
using System.Threading;

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
            //Clean Working Directory to avoid unawated files during compile 
            if (Directory.Exists(MtX.Control.DircControl.root))
            { MtX.Control.DircControl.CleanTemp(); }
        }

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
                Control.IconImport.IconConvert(icon_dlg.FileName);
                Icon_Button.BackgroundImage = Image.FromFile(DircControl.buildpath + DircControl.controlpath + @"icon_AmericanEnglish.dat");
            }
        }
    

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
                }
            }
        }
        
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

        private void Compile_button_Click(object sender, EventArgs e)
        {
            // Make Directories and copy required files before checking system setup
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
                if (Directory.Exists(MtX.Control.DircControl.root))
                { MtX.Control.DircControl.CleanTemp(); }
            }
        }
    }