using System;
using System.Linq;
using System.Windows.Forms;
using MtX.Control.Properties;


namespace MtX.Nro2Nsp
{
    public partial class SettingsMenu : Form
    {
        string DevKitProCustPath = null;

        public SettingsMenu()
        {           
            InitializeComponent();
            CustomAuthorClick.Checked = Convert.ToBoolean(Settings.Default["SetAuthorEnable"]);
            CustomDevClick.Checked = Convert.ToBoolean(Settings.Default["CustomDevkitEnable"]);
            RollingIdClick.Checked = Convert.ToBoolean(Settings.Default["RollingIdEnable"]);
            PerserveDataClick.Checked = Convert.ToBoolean(Settings.Default["PerserveDataEnable"]);
            OldKeyCheck.Checked = Convert.ToBoolean(Settings.Default["OldTitleKeyEnable"]);
            if (Convert.ToBoolean(Settings.Default["SetAuthorEnable"]) == true){ CustomAuthorBox.Text = Settings.Default["SetAuthor"].ToString(); }
            if (Convert.ToBoolean(Settings.Default["CustomDevkitEnable"]) == true) { CustomDevkitBox.Text = Settings.Default["CustomDevkitPath"].ToString(); }
            if (Convert.ToBoolean(Settings.Default["RollingIdEnable"]) == true) { RollingIdBox.Text = Settings.Default["BaseRollingId"].ToString(); }
        }


        private void CustomDevClick_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomDevClick.Checked == true)
            {
                Settings.Default["CustomDevkitEnable"] = true;
                CustomDevkitBox.Enabled = true;
                CustomDevkitBox.Clear();
                DevKitProCustPath = null;
                CustomDevkitBox.Text = DevKitProCustPath;
            }
            else
            {
                Settings.Default["CustomDevkitEnable"] = false;
                CustomDevkitBox.Enabled = false;
                CustomDevkitBox.Text = "Set Custom DevkitPro Location";
            }
        }


        private void CustomAuthorClick_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomAuthorClick.Checked == true)
            {
                Settings.Default["SetAuthorEnable"] = true;
                CustomAuthorBox.Enabled = true;
                CustomAuthorBox.Clear();
            }
            else
            {
                Settings.Default["SetAuthorEnable"] = false;
                CustomAuthorBox.Enabled = false;
                CustomAuthorBox.Text = "Set Default Author to Speed Things Up";
                CustomAuthorClick.Checked = false;               
            }
        }


        private void RollingIdClick_CheckedChanged(object sender, EventArgs e)
        {
            if (RollingIdClick.Checked == true)
            {
                Settings.Default["RollingIdEnable"] = true;
                RollingIdBox.Enabled = true;
                RollingIdBox.Clear();
            }
            else
            {
                Settings.Default["RollingIdEnable"] = false;
                RollingIdBox.Enabled = false;
                RollingIdBox.Text = "Set Base Title Id, Will Auto Increment";
                RollingIdClick.Checked = false;                
            }
        }


        private void Input_Restrict(object sender, KeyPressEventArgs e)
        {
            if (RollingIdClick.Checked == true)
            {
                Int32 AllowedLines = 16;
                RollingIdBox.MaxLength = AllowedLines;
                char c = e.KeyChar;
                {
                    if (e.KeyChar != '\b')
                        e.Handled = !System.Uri.IsHexDigit(e.KeyChar);
                }
            }
        }


        private void PerserveDataClick_CheckedChanged(object sender, EventArgs e)
        {
            if (PerserveDataClick.Checked == true)
            {
                Settings.Default["PerserveDataEnable"] = true;
                PerserveDataBox.Text = "Enabled";
            }
            else
            {
                Settings.Default["PerserveDataEnable"] = false;
                PerserveDataBox.Text = "Saves Nca, Exefs, and Control Data";
                PerserveDataClick.Checked = false;
            }
        }

        private void SettingSaveButton_Click(object sender, EventArgs e)
        {
            if (SettingsChecks() == true)       
            {
                Settings.Default["PerserveDataEnable"] = PerserveDataClick.Checked;
                Settings.Default["OldTitleKeyEnable"] = OldKeyCheck.Checked;

            if (CustomAuthorClick.Checked == true)
            {
                Settings.Default["SetAuthor"] = CustomAuthorBox.Text;
                Settings.Default["SetAuthorEnable"] = true;
            }
            else
            {
                Settings.Default["SetAuthor"] = null;
                Settings.Default["SetAuthorEnable"] = false;
            }
            if (CustomDevClick.Checked == true)
            {
                Settings.Default["CustomDevkitPath"] = CustomDevkitBox.Text;
                Settings.Default["CustomDevkitEnable"] = true;
            }
            else
            {
                Settings.Default["CustomDevkitPath"] = null;
                Settings.Default["CustomDevkitEnable"] = false;
            }
            if (RollingIdClick.Checked == true)
            {
                Settings.Default["BaseRollingId"] = RollingIdBox.Text;
                Settings.Default["RollingIdEnable"] = true;
            }
            else
            {
                Settings.Default["BaseRollingId"] = null;
                Settings.Default["RollingIdEnable"] = false;
            }
            Settings.Default.Save();
            this.Close();
        }
            else{ };
    }

        private void CustomDevkitClick(object sender, EventArgs e)
        {
            if (CustomDevClick.Checked == true)
            {
                FolderBrowserDialog DevKitProDialog = new FolderBrowserDialog();
                if (!(DevKitProDialog.ShowDialog() == DialogResult.OK && (DevKitProCustPath = DevKitProDialog.SelectedPath) != null))
                {
                    CustomDevkitBox.Enabled = false;
                    CustomDevkitBox.Text = "Set Custom DevkitPro Location";
                    CustomDevClick.Checked = false;
                    DevKitProCustPath = null;
                }
                else if ((DevKitProCustPath = DevKitProDialog.SelectedPath) != null)
                {
                    CustomDevkitBox.Text = DevKitProCustPath;
                }
            }          
        }


        public bool SettingsChecks()
        {
            bool[] ArrayCheck = new bool[3];
            char[] IdChar = RollingIdBox.Text.ToCharArray();
            bool OldKeyStyle = Convert.ToBoolean(Settings.Default["OldTitleKeyEnable"]);
            ArrayCheck[0] = (CustomDevClick.Checked == true && CustomDevkitBox.Text != "") || CustomDevClick.Checked == false;
            ArrayCheck[1] = (CustomAuthorClick.Checked == true && CustomAuthorBox.Text != "") || CustomAuthorClick.Checked == false;
            ArrayCheck[2] = (OldKeyStyle == true && RollingIdClick.Checked == true && RollingIdBox.Text != "" && RollingIdBox.Text.Length == 16 && IdChar[0] == '0' && IdChar[1] == '5') ||
                            (OldKeyStyle == false && RollingIdClick.Checked == true && RollingIdBox.Text != "" && RollingIdBox.Text.Length == 16 && IdChar[0] == '0' && IdChar[1] == '5' && IdChar[12] == '0' && IdChar[13] == '0' && IdChar[14] == '0' && IdChar[15] == '0') || (RollingIdClick.Checked == false) ;
           
            string[] Errors = {"Custom Devkitpro is enabled but the value is null, please change to a proper path", "Preset Author is enabled but the vaule is null," +
                              " please change to a vaild value", "Rolling Title Id is enabled but the vaule is invalid, please set to a 16 char hex string starting with 05, and ending in 0000 ex \"05xxxxxxxxxx0000\" or set \"Old T-Key Format\" in Settings"};

            for (int x = 0; x < ArrayCheck.Length; x++)
                if (ArrayCheck[x] == false)
                { MessageBox.Show(Errors[x]); }

            return ArrayCheck.All(a => a);
        }


        private void OldKeyClick_Checked(object sender, EventArgs e)
        {
            if (OldKeyCheck.Checked == true)
            {
                Settings.Default["OldTitleKeyEnable"] = true;
                OldKeyBox.Text = "Enabled";
            }
            else
            {
                Settings.Default["PerserveDataEnable"] = false;
                OldKeyBox.Text = "Old Style T-Key 05XXXXXXXXXXXXXXXX";
                OldKeyCheck.Checked = false;
            }
        }
    }
}