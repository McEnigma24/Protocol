using Shutdown_Protocol.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Shutdown_Protocol
{
    public partial class Shutdown_Protocol : Form
    {   
        private string ending_program = "nothing";

        private string path_property_dir;
        private string path_user_text_dir;
        private string path_tytle;

        private List<string> list_user_protocol;        

        public Shutdown_Protocol()
        {
            InitializeComponent();            

            this.ActiveControl = textBox_user_text;
            list_user_protocol = new List<string>();

            path_property_dir = @"Application Files/what after last line.txt";
            path_user_text_dir = @"Application Files/user text.txt";
            path_tytle = @"Application Files/tytle.txt";

            // get the tytle
            string tytle = File.ReadAllText(path_tytle);
            label1.Text = tytle;

            // extract ending program
            var lines = File.ReadLines(path_property_dir);
            foreach (var line in lines)
            {
                if (line[0] == '-')
                {
                    if (line.Contains("nothing") && line.Contains("$")) ending_program = "nothing";
                    else if (line.Contains("closing app") && line.Contains("$")) ending_program = "closing app";
                    else if (line.Contains("shutdown pc") && line.Contains("$")) ending_program = "shutdown pc";
                }
            }

            // setting user protocol
            initProtocolList();
            updateTextBox();            
        }


        private void initProtocolList()
        {
            string[] file = File.ReadAllLines(path_user_text_dir);

            int i = 1;
            string tmp_line;
            string dummy_line;
            foreach (string line in file)
            {
                dummy_line = line;
                tmp_line = "";

                if (dummy_line != "")
                {
                    if (!dummy_line.Contains('&'))
                    {
                        tmp_line += i.ToString() + ". ";
                        i++;
                    }
                    else dummy_line = dummy_line.Replace("&", "");
                }                
                tmp_line += dummy_line;
                
                list_user_protocol.Add(tmp_line);
            }
        }
        
        private void updateTextBox()
        {
            textBox_user_text.Text = "";
            int full_size = list_user_protocol.Count();            

            foreach (string line in list_user_protocol)
            {
                textBox_user_text.AppendText(line);

                if(full_size != 0) textBox_user_text.AppendText(Environment.NewLine);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (list_user_protocol.Count() == 0)
                {
                    textBox_user_text.Text = "End of program";

                    if (ending_program == "nothing")
                    {
                        return;
                    }
                    else if (ending_program == "closing app")
                    {
                        this.Close();
                    }
                    else if (ending_program == "shutdown pc")
                    {
                        Process.Start("shutdown", "/s /t 0");
                    }
                }

                else
                {
                    removingEmptyElements();
                    {
                        list_user_protocol.RemoveAt(0);
                    }
                    removingEmptyElements();

                    updateTextBox();

                    if (list_user_protocol.Count() == 0)
                    {
                        textBox_user_text.Text = "End of program";

                        if (ending_program == "nothing")
                        {
                            return;
                        }
                        else if (ending_program == "closing app")
                        {
                            this.Close();
                        }
                        else if (ending_program == "shutdown pc")
                        {
                            Process.Start("shutdown", "/s /t 0");
                        }
                    }
                }
            }
        }

        private void removingEmptyElements()
        {
            if (list_user_protocol.Count() != 0)
            {
                while (list_user_protocol.ElementAt(0) == "")
                    list_user_protocol.RemoveAt(0);
            }
        }


        // Saving start up location        
        private void Shutdown_Protocol_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                Properties.Settings.Default.Form_Location = RestoreBounds.Location;
                Properties.Settings.Default.Form_Size = RestoreBounds.Size;                
                Properties.Settings.Default.Form_Maximised = true;
                Properties.Settings.Default.Form_Minimised = false;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.Form_Location = Location;
                Properties.Settings.Default.Form_Size = Size;
                Properties.Settings.Default.Form_Maximised = false;
                Properties.Settings.Default.Form_Minimised = false;
            }
            else
            {
                Properties.Settings.Default.Form_Location = RestoreBounds.Location;
                Properties.Settings.Default.Form_Size = RestoreBounds.Size;
                Properties.Settings.Default.Form_Maximised = false;
                Properties.Settings.Default.Form_Minimised = true;
            }
            Properties.Settings.Default.Save();
        }
        private void Shutdown_Protocol_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Form_Maximised)
            {
                Location = Properties.Settings.Default.Form_Location;
                WindowState = FormWindowState.Maximized;
                Size = Properties.Settings.Default.Form_Size;
            }
            else if (Properties.Settings.Default.Form_Minimised)
            {
                Location = Properties.Settings.Default.Form_Location;
                WindowState = FormWindowState.Minimized;
                Size = Properties.Settings.Default.Form_Size;
            }
            else
            {
                Location = Properties.Settings.Default.Form_Location;
                Size = Properties.Settings.Default.Form_Size;
            }
        }        
    }
}
