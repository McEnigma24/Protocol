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
        private XmlSerializer serializer;
        private string serialize_dir;

        private string user_text_dir;
        private List<string> list_user_protocol;
        private bool last_chance = true;

        public Shutdown_Protocol()
        {
            InitializeComponent();

            this.ActiveControl = textBox_user_text;

            serialize_dir = @"Application Files/properties.txt";
            user_text_dir = @"Application Files/user text.txt";

            list_user_protocol = new List<string>();



            // setting user protocol
            initProtocolList();
            updateTextBox();

            // applying serialized preferences
            {

            }
        }


        private void initProtocolList()
        {
            string[] file = File.ReadAllLines(user_text_dir);

            int i = 1;
            string tmp_line;
            string dummy_line;
            foreach (string line in file)
            {
                dummy_line = line;
                tmp_line = "";

                if (dummy_line != "")
                {
                    if (!dummy_line.Contains('&')) tmp_line += i.ToString() + ". ";
                    else dummy_line = dummy_line.Replace("&", " ");
                    i++;
                }                
                tmp_line += dummy_line;

                //if (tmp_line.Length > 0) list_user_protocol.Add(tmp_line.Remove(tmp_line.IndexOf('&'), 1));
                //else
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
                if (!last_chance)                    
                {
                    textBox_user_text.Text = "SHUTDOWN";
                    //Process.Start("shutdown", "/s /t 0");
                    return;
                }                

                /*if (list_user_protocol.Count() == 0)
                {
                    textBox_user_text.Text = "no longer shutdown";
                    return;
                }*/

                removingEmptyElements();
                {
                    list_user_protocol.RemoveAt(0);
                }
                removingEmptyElements();

                updateTextBox();

                if (list_user_protocol.Count() == 0)
                {
                    if (last_chance)
                    {
                        textBox_user_text.Text = "SHUTDOWN AFTER THIS";
                        last_chance = false;
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
    }
}
