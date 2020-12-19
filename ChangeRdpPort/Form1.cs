using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace ChangeRdpPort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Textbox can't be empty!.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = textBox1;
            }
            else
            {
                string newPort = textBox1.Text;
                if (MessageBox.Show("Do you want the save ?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    RegistryKey myKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Terminal Server\\WinStations\\RDP-Tcp", true);
                    if (myKey != null)
                    {
                        myKey.SetValue("PortNumber", newPort, RegistryValueKind.DWord);
                        myKey.Close();
                        MessageBox.Show(newPort + " has been set as the new port number.\nYou should restart the Remote Desktop Services.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.ResetText();
                    }
                    else
                    {
                        MessageBox.Show("Registry key can not open!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
