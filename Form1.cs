using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Xml;
using MetroFramework.Forms;
using System.Net;
using System.Net.Cache;
using FluentFTP;
using System.Diagnostics;

namespace PhoenixARC_XML_Toolkit
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            string currentversion = "1.8B";
            metroLabel21.Text = currentversion;
            File.Delete("Update.zip");
            Globals.counter = 0;
            try
            {

                var WebClient = new System.Net.WebClient();
                var client = new System.Net.WebClient();
                string updateversion1 = (WebClient.DownloadString("https://pastebin.com/raw/BXSD606q"));
                string updateversion = updateversion1.Split(';')[0];
                string changes = (WebClient.DownloadString("https://pastebin.com/raw/MdVrAdHn"));
                if (currentversion != updateversion)
                {
                    client.DownloadFile("https://www.dropbox.com/s/map1szqoxa0af75/Release.zip?dl=1", "Update.zip");
                    MessageBox.Show("Update Avaliable! \n Download now! \n" + changes);
                }
                else
                {
                    MessageBox.Show("You are on the latest Avaliable Version!");
                }
            }
            catch
            {

            }



        }

        static class Globals
        {
            // global int
            public static int counter;
            public static int counter2;

            // global function
            public static string HelloWorld()
            {
                return "Hello World";
            }

            // global int using get/set
            static int _getsetcounter;
            static int _getsetcounter2;
            public static int getsetcounter
            {
                set { _getsetcounter = value; }
                get { return _getsetcounter; }
            }
            public static int getsetcounter2
            {
                set { _getsetcounter2 = value; }
                get { return _getsetcounter2; }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Globals.counter2 = 5;

            if (File.Exists("Update.zip"))
            {
                System.Diagnostics.Process.Start("Updater.exe");
            }
            else
            {

            }
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = "PhoeniXML Tempfile |*.PhoList";
            OpenFileDialog1.FilterIndex = 1;
            List<string> newlist = new List<string>();
            if (OpenFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                listBox1.Items.Clear();
                string line = System.IO.File.ReadAllText(OpenFileDialog1.FileName);
                string[] seperated = line.Split(
    new[] { "\r\n", "\r", "\n" },
    StringSplitOptions.None
);
                string dir = OpenFileDialog1.FileName;
                foreach (string item in seperated)
                {
                    newlist.Add(item);
                    listBox1.Items.Add(item);
                }
            }

        }

        private void MetroButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.Filter = "PhoeniXML Tempfile |*.PhoList";
            SaveFileDialog1.FilterIndex = 1;
            if (SaveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string dir = SaveFileDialog1.FileName;
                TextWriter tw = new StreamWriter(dir);

                foreach (String s in listBox1.Items)
                    tw.WriteLine(s);

                tw.Close();
            }

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroRadioButton1.Checked == true)
            {
                string selected = listBox1.SelectedItem.ToString();
                string[] options = selected.Split(';');
                string titleid = options[0];
                string name = options[1];
                string type = options[2];
                string region = options[3];
                string url = options[4];
                string contentid = options[5];
                string sha256 = options[6];
                string description = options[7];
                string uploader = options[8];
                metroTextBox1.Text = titleid;
                metroTextBox2.Text = name;
                metroTextBox3.Text = url;
                metroTextBox4.Text = contentid;
                metroTextBox5.Text = sha256;
                metroTextBox6.Text = uploader;
                metroComboBox1.SelectedItem = type;
                metroComboBox2.SelectedItem = region;
            }
            if (metroRadioButton2.Checked == true)
            {
                string selected = listBox1.SelectedItem.ToString();
                string[] options = selected.Split(';');
                string entryname = options[0];
                string type = options[2];
                string region = options[3];
                string url = options[1];
                string length = options[5];
                string info = options[6];
                string iconpath = options[7];
                string uploader = options[4];
                metroTextBox18.Text = entryname;
                metroTextBox21.Text = url;
                metroTextBox19.Text = length;
                metroTextBox17.Text = iconpath;
                metroTextBox20.Text = uploader;
                metroTextBox15.Text = info;
            }
            if (metroRadioButton3.Checked == true)
            {
                string selected = listBox1.SelectedItem.ToString();
                string[] options = selected.Split(';');
                string entryname = options[0];
                string type = options[2];
                string region = options[3];
                string url = options[1];
                string length = options[5];
                string info = options[6];
                string iconpath = options[7];
                string uploader = options[4];
                metroTextBox25.Text = entryname;
                metroTextBox28.Text = url;
                metroTextBox26.Text = length;
                metroTextBox24.Text = iconpath;
                metroTextBox27.Text = uploader;
                metroTextBox22.Text = info;
            }
            if (metroRadioButton4.Checked == true)
            {
                string selected = listBox1.SelectedItem.ToString();
                string[] options = selected.Split(';');
                string entryname = options[0];
                string type = options[2];
                string region = options[3];
                string url = options[1];
                string length = options[5];
                string info = options[6];
                string iconpath = options[7];
                string uploader = options[4];
                metroTextBox10.Text = entryname;
                metroTextBox12.Text = url;
                metroTextBox11.Text = iconpath;

            }
            if (metroRadioButton5.Checked == true)
            {
                string selected = listBox1.SelectedItem.ToString();
                string[] options = selected.Split(';');
                string entryname = options[0];
                string type = options[2];
                string region = options[3];
                string linktoanother = options[1];
                string extlink = options[5];
                string info = options[6];
                string iconpath = options[7];
                string uploader = options[4];
                metroTextBox30.Text = entryname;
                metroTextBox31.Text = iconpath;
                metroTextBox32.Text = extlink;
                metroTextBox29.Text = info;

                if (linktoanother == "Yes")
                {
                    metroCheckBox2.Checked = true;
                }

                if (linktoanother == "No")
                {
                    metroCheckBox2.Checked = false;
                }
            }
            if (metroRadioButton4.Checked == true)
            {
                string selected = listBox1.SelectedItem.ToString();
                string[] options = selected.Split(';');
                string entryname = options[0];
                string type = options[2];
                string region = options[3];
                string copy1 = options[1];
                string copy2 = options[5];
                string info = options[6];
                string iconpath = options[7];
                string uploader = options[4];
                metroTextBox8.Text = entryname;
                metroTextBox13.Text = copy1;
                metroTextBox14.Text = copy2;
                metroTextBox9.Text = iconpath;

            }

        }

        private void MetroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MetroButton4_Click(object sender, EventArgs e)
        {
            List<string> test = new List<string>();
            string titleid = metroTextBox1.Text;
            string name = metroTextBox2.Text;
            string url = metroTextBox3.Text;
            string contentid = metroTextBox4.Text;
            string sha256 = metroTextBox5.Text;
            string uploader = metroTextBox6.Text;
            string type = metroComboBox1.SelectedItem.ToString();
            string region = metroComboBox2.SelectedItem.ToString();
            string description = metroTextBox7.Text;
            string add = titleid + ";" + name + ";" + type + ";" + region + ";" + url + ";" + contentid + ";" + sha256 + ";" + description + ";" + uploader;
            foreach (string item in listBox1.Items)
            {
                test.Add(item);
            }
            test.Add(add);
            listBox1.Items.Clear();
            foreach (string item in test)
            {
                listBox1.Items.Add(item);
            }

        }

        private void MetroButton3_Click(object sender, EventArgs e)
        {
            List<string> test = new List<string>();
            foreach (string item in listBox1.Items)
            {
                test.Add(item);
            }

            string asdf = listBox1.SelectedItem.ToString();
            test.Remove(asdf);
            listBox1.Items.Clear();
            foreach (string item in test)
            {
                listBox1.Items.Add(item);
            }

        }


        string text27 = "";

        private void MetroButton5_Click(object sender, EventArgs e)
        {

            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = "PhoeniXML Tempfile |*.PhoList| database file | db";
            OpenFileDialog1.FilterIndex = 1;
            if (OpenFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                metroLabel14.Text = OpenFileDialog1.FileName;
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox4.Items.Clear();
                string line = System.IO.File.ReadAllText(OpenFileDialog1.FileName);
                string[] seperated = line.Split(
    new[] { "\r\n", "\r", "\n" },
    StringSplitOptions.None
);
                string dir = OpenFileDialog1.FileName;
                List<string> list0 = new List<string>();
                List<string> pass = new List<string>();
                list0.Clear();
                string twelve = seperated[0];
                string[] twelve2 = twelve.Split(';');
                if (metroRadioButton10.Checked == false)
                {
                    foreach (string item in seperated)
                    {
                        if (string.IsNullOrEmpty(item))
                        {

                        }
                        else
                        {
                            pass.Add(item);
                        }
                    }
                    foreach (string item in pass)
                    {
                        if (metroRadioButton9.Checked == true)
                        {
                            switch (twelve2[2])
                            {
                                case "Podcast":
                                    list0.Add(item);
                                    break;

                                default:

                                    break;
                            }
                        }
                        if (metroRadioButton8.Checked == true)
                        {
                            switch (twelve2[2])
                            {
                                case "Video":
                                    list0.Add(item);
                                    break;

                                default:

                                    break;
                            }
                        }
                        if (metroRadioButton7.Checked == true)
                        {
                            switch (twelve2[2])
                            {
                                case "Link":
                                    list0.Add(item);
                                    break;

                                default:

                                    break;
                            }
                        }
                        if (metroRadioButton6.Checked == true)
                        {
                            switch (twelve2[2])
                            {
                                case "XMB":
                                    list0.Add(item);
                                    break;

                                default:

                                    break;
                            }
                        }
                        if (metroRadioButton12.Checked == true)
                        {
                            switch (twelve2[2])
                            {
                                case "fcopy":
                                    list0.Add(item);
                                    break;

                                default:

                                    break;
                            }
                        }
                    }
                    foreach (string item in list0)
                    {
                        string[] options = item.Split(';');
                        switch (item.Split(';')[3])
                        {
                            case "EU":
                                listBox4.Items.Add(item);
                                break;
                            case "US":
                                listBox2.Items.Add(item);
                                break;
                            case "JP":
                                listBox3.Items.Add(item);
                                break;
                            case "HK":
                                listBox3.Items.Add(item);
                                break;
                            default:

                                break;
                        }
                    }
                }
                else
                {


                    foreach (string item in seperated)
                    {
                        if (string.IsNullOrEmpty(item))
                        {

                        }
                        else
                        {
                            pass.Add(item);
                        }

                    }
                    foreach (string item in pass)
                    {
                        string[] options = item.Split(';');
                        string opt1 = metroComboBox3.SelectedItem.ToString();
                        if (opt1 == "Any")
                        {
                            switch (item.Split(';')[2])
                            {
                                default:
                                    list0.Add(item);
                                    break;
                            }
                        }
                        if (opt1 == "PS3")
                        {
                            switch (item.Split(';')[2])
                            {
                                case "PS3":
                                    list0.Add(item);
                                    break;
                                case "PSN":
                                    list0.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                        if (opt1 == "PS4")
                        {
                            switch (item.Split(';')[2])
                            {
                                case "PS4":
                                    list0.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                        if (opt1 == "PS2")
                        {
                            switch (item.Split(';')[2])
                            {
                                case "PS2":
                                    list0.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                        if (opt1 == "PSX (PS1)")
                        {
                            switch (item.Split(';')[2])
                            {
                                case "PS1":
                                    list0.Add(item);
                                    break;
                                case "PSX":
                                    list0.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                        if (opt1 == "C00")
                        {
                            switch (item.Split(';')[2])
                            {
                                case "C00":
                                    list0.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                        if (opt1 == "DLC")
                        {
                            switch (item.Split(';')[2])
                            {
                                case "DLC":
                                    list0.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                        if (opt1 == "Theme")
                        {
                            switch (item.Split(';')[2])
                            {
                                case "Theme":
                                    list0.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                        if (opt1 == "Homebrew")
                        {
                            switch (item.Split(';')[2])
                            {
                                case "Homebrew":
                                    list0.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                        if (opt1 == "Tool")
                        {
                            switch (item.Split(';')[2])
                            {
                                case "Tool":
                                    list0.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                    }

                    foreach (string item in list0)
                    {
                        string[] options = item.Split(';');
                        switch (item.Split(';')[3])
                        {
                            case "EU":
                                listBox4.Items.Add(item);
                                break;
                            case "US":
                                listBox2.Items.Add(item);
                                break;
                            case "JP":
                                listBox3.Items.Add(item);
                                break;
                            case "HK":
                                listBox3.Items.Add(item);
                                break;
                            default:

                                break;
                        }
                    }
                }
            }
        }

        private void MetroComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = metroComboBox3.SelectedItem.ToString();
            metroButton7.Enabled = true;
            System.IO.Directory.CreateDirectory(metroLabel15.Text + "/US" + "_" + type);
            System.IO.Directory.CreateDirectory(metroLabel15.Text + "/EU" + "_" + type);
            System.IO.Directory.CreateDirectory(metroLabel15.Text + "/JP" + "_" + type);
        }

        private void MetroButton7_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    metroButton5.Enabled = true;
                    metroButton6.Enabled = true;
                    if (metroComboBox3.Enabled == true)
                    {
                        metroLabel19.Text = metroComboBox3.SelectedItem.ToString();
                    }
                    else
                    {
                        if (metroRadioButton9.Checked == true)
                        {
                            metroLabel19.Text = "Podcast";
                        }
                        if (metroRadioButton8.Checked == true)
                        {
                            metroLabel19.Text = "Video";
                        }
                        if (metroRadioButton7.Checked == true)
                        {
                            metroLabel19.Text = "Link";
                        }
                        if (metroRadioButton6.Checked == true)
                        {
                            metroLabel19.Text = "XMB";
                        }
                        if (metroRadioButton12.Checked == true)
                        {
                            metroLabel19.Text = "fcopy";
                        }
                    }
                    string type = metroLabel19.Text;
                    metroLabel15.Text = fbd.SelectedPath;
                    if (metroRadioButton10.Checked == true)
                    {
                        System.IO.Directory.CreateDirectory(fbd.SelectedPath + "/US" + "_" + type);
                        System.IO.Directory.CreateDirectory(fbd.SelectedPath + "/EU" + "_" + type);
                        System.IO.Directory.CreateDirectory(fbd.SelectedPath + "/JP" + "_" + type);
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory(fbd.SelectedPath + "/US" + "_" + type);
                    }
                }
            }
        }

        private void MetroButton6_Click(object sender, EventArgs e)
        {

            string folderdir = metroLabel15.Text;
            string type = metroLabel19.Text;
            if (metroRadioButton10.Checked == true)
            {
                foreach (string item in listBox2.Items)
                {
                    string type0 = metroComboBox3.SelectedItem.ToString();
                    int number = Globals.counter;
                    string num = number.ToString();
                    string[] options = item.Split(';');
                    string titleid = options[0];
                    string name = options[1];
                    string type1 = options[2];
                    string region = options[3];
                    string url = options[4];
                    string contentid = options[5];
                    string sha256 = options[6];
                    string description = options[7];
                    string uploader = options[8];
                    this.text27 = options[5];






                    string path = folderdir + "/US" + "_" + type0;
                    // starting XML (Tables)
                    if (File.Exists(path + "/1.xml"))
                    {
                        using (StreamWriter sw = File.AppendText(path + "/1.xml"))
                        {
                            sw.WriteLine("<Attributes>");
                            sw.WriteLine("<Table key=\"item_" + num + "\"> ");
                            sw.WriteLine("<Pair key=\"icon\"><String>" + description + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"title\"><String>" + name + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"info\"><String>" + titleid);
                            sw.WriteLine("by" + uploader);
                            sw.WriteLine(type1);
                            sw.WriteLine(region + "</String></Pair>");
                            sw.WriteLine("</Table>");
                        }
                    }
                    else
                    {
                        // File.Create(path + "/1.xml");
                        string[] lines0 = { "<XMBML version = \"1.0\">", "<View id=\"" + region + "_" + type0 + "\">" };
                        foreach (string line in lines0)
                        {
                            File.WriteAllText(path + "/1.xml", line);
                        }
                        using (StreamWriter sw = File.AppendText(path + "/1.xml"))
                        {
                            sw.WriteLine("<Attributes>");
                            sw.WriteLine("<Table key=\"item_" + num + "\"> ");
                            sw.WriteLine("<Pair key=\"icon\"><String>" + description + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"title\"><String>" + name + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"info\"><String>" + titleid);
                            sw.WriteLine("by" + uploader);
                            sw.WriteLine(type1);
                            sw.WriteLine(region + "</String></Pair>");
                            sw.WriteLine("</Table>");
                        }

                    }
                    // 2nd XML (Items)
                    if (File.Exists(path + "/2.xml"))
                    {
                        using (StreamWriter sw = File.AppendText(path + "/2.xml"))
                        {
                            sw.WriteLine("<Items>");
                            sw.WriteLine("<Query ");
                            sw.WriteLine("class=\"type:x-xmb/folder-pixmap");
                            sw.WriteLine("key=\"item_" + num + "\"   attr =\"item_" + num + "\"  src = \"#item_" + num + "_link");
                            sw.WriteLine("/>");

                        }
                    }
                    else
                    {
                        // File.Create(path + "/2.xml");
                        string[] lines2 = { "</Attributes>" };
                        foreach (string line in lines2)
                        {
                            File.WriteAllText(path + "/2.xml", line);
                        }
                        using (StreamWriter sw = File.AppendText(path + "/2.xml"))
                        {
                            sw.WriteLine("<Items>");
                            sw.WriteLine("<Query ");
                            sw.WriteLine("class=\"type:x-xmb/folder-pixmap");
                            sw.WriteLine("key=\"item_" + num + "\"   attr =\"item_" + num + "\"  src = \"#item_" + num + "_link");
                            sw.WriteLine("/>");
                        }
                    }
                    // 3rd XML (content)
                    if (File.Exists(path + "/3.xml"))
                    {
                        using (StreamWriter sw = File.AppendText(path + "/3.xml"))
                        {
                            sw.WriteLine("<View id=\"item_" + num + "_link\"> ");
                            sw.WriteLine("<Attributes> ");
                            sw.WriteLine("<Table key=\"link_" + num + "\">");
                            sw.WriteLine("<Pair key =\"info\"><String>net_package_install</String></Pair> ");
                            sw.WriteLine("<Pair key=\"pkg_src\"><String>" + url + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"pkg_src_qa\"><String>" + url + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"content_name\"><String>tool_pkg_install_pc</String></Pair> ");
                            sw.WriteLine("<Pair key=\"content_id\"><String>" + contentid + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"prod_pict_path\"><String>" + description + "</String></Pair> ");
                            sw.WriteLine("</Table> ");
                            sw.WriteLine("</Attributes> ");
                            sw.WriteLine("<Items>  ");
                            sw.WriteLine("<Item class=\"type:x-xmb/xmlnpsignup\" key=\"link_" + num + "\" attr=\"link_" + num + "\"/> ");
                            sw.WriteLine("</Items> ");
                            sw.WriteLine("</View>");

                        }
                    }
                    else
                    {
                        // File.Create(path + "/3.xml");
                        string[] lines1 = { "</Items>", "</View>" };
                        foreach (string line in lines1)
                        {
                            File.WriteAllText(path + "/3.xml", line);
                        }
                        using (StreamWriter sw = File.AppendText(path + "/3.xml"))
                        {
                            sw.WriteLine("<View id=\"item_" + num + "_link\"> ");
                            sw.WriteLine("<Attributes> ");
                            sw.WriteLine("<Table key=\"link_" + num + "\">");
                            sw.WriteLine("<Pair key =\"info\"><String>net_package_install</String></Pair> ");
                            sw.WriteLine("<Pair key=\"pkg_src\"><String>" + url + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"pkg_src_qa\"><String>" + url + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"content_name\"><String>tool_pkg_install_pc</String></Pair> ");
                            sw.WriteLine("<Pair key=\"content_id\"><String>" + contentid + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"prod_pict_path\"><String>" + description + "</String></Pair> ");
                            sw.WriteLine("</Table> ");
                            sw.WriteLine("</Attributes> ");
                            sw.WriteLine("<Items>  ");
                            sw.WriteLine("<Item class=\"type:x-xmb/xmlnpsignup\" key=\"link_" + num + "\" attr=\"link_" + num + "\"/> ");
                            sw.WriteLine("</Items> ");
                            sw.WriteLine("</View>");
                        }

                    }

                    // File.Create(path + "/4.xml");
                    if (File.Exists(path + "/4.xml"))
                    {

                    }
                    else
                    {
                        string[] lines = { "" };
                        foreach (string line in lines)
                        {
                            File.WriteAllText(path + "/4.xml", line);
                        }
                        using (StreamWriter sw = File.AppendText(path + "/4.xml"))
                        {
                            sw.WriteLine("</XMBML>");
                            sw.WriteLine("<!-- Created using PhoenixARC's XML Generator -->");
                            sw.WriteLine("<!-- Sub to PhoenixARC on YT! -->");
                        }
                    }


                    Globals.counter = Globals.counter + 1;

                }
                foreach (string item in listBox4.Items)
                {
                    string type0 = metroComboBox3.SelectedItem.ToString();
                    int number = Globals.counter;
                    string num = number.ToString();
                    string[] options = item.Split(';');
                    string titleid = options[0];
                    string name = options[1];
                    string type1 = options[2];
                    string region = options[3];
                    string url = options[4];
                    string contentid = options[5];
                    string sha256 = options[6];
                    string description = options[7];
                    string uploader = options[8];






                    string path = folderdir + "/EU" + "_" + type0;
                    // starting XML (Tables)
                    if (File.Exists(path + "/1.xml"))
                    {
                        using (StreamWriter sw = File.AppendText(path + "/1.xml"))
                        {
                            sw.WriteLine("<Attributes>");
                            sw.WriteLine("<Table key=\"item_" + num + "\"> ");
                            sw.WriteLine("<Pair key=\"icon\"><String>" + description + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"title\"><String>" + name + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"info\"><String>" + titleid);
                            sw.WriteLine("by" + uploader);
                            sw.WriteLine(type1);
                            sw.WriteLine(region + "</String></Pair>");
                            sw.WriteLine("</Table>");
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.CreateText(path + "/1.xml"))
                        {
                            sw.WriteLine("<XMBML version = \"1.0\">");
                            sw.WriteLine("<View id=\"" + region + "_" + type0 + "\">");
                            sw.WriteLine("<Attributes>");
                            sw.WriteLine("<Table key=\"item_" + num + "\"> ");
                            sw.WriteLine("<Pair key=\"icon\"><String>" + description + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"title\"><String>" + name + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"info\"><String>" + titleid);
                            sw.WriteLine("by" + uploader);
                            sw.WriteLine(type);
                            sw.WriteLine(region + "</String></Pair>");
                            sw.WriteLine("</Table>");
                        }

                    }
                    // 2nd XML (Items)
                    if (File.Exists(path + "/2.xml"))
                    {
                        using (StreamWriter sw = File.AppendText(path + "/2.xml"))
                        {
                            sw.WriteLine("<Items>");
                            sw.WriteLine("<Query ");
                            sw.WriteLine("class=\"type:x-xmb/folder-pixmap");
                            sw.WriteLine("key=\"item_" + num + "\"   attr =\"item_" + num + "\"  src = \"#item_" + num + "_link");
                            sw.WriteLine("/>");

                        }
                    }
                    else
                    {
                        // File.Create(path + "/2.xml");
                        using (StreamWriter sw = File.CreateText(path + "/2.xml"))
                        {
                            sw.WriteLine("</Attributes>");
                            sw.WriteLine("<Items>");
                            sw.WriteLine("<Query ");
                            sw.WriteLine("class=\"type:x-xmb/folder-pixmap\" key=\"item_" + num + "\"   attr =\"item_" + num + "\"  src = \"#item_" + num + "_link");
                            sw.WriteLine("/>");
                        }
                    }
                    // 3rd XML (content)
                    if (File.Exists(path + "/3.xml"))
                    {
                        using (StreamWriter sw = File.AppendText(path + "/3.xml"))
                        {
                            sw.WriteLine("<View id=\"item_" + num + "_link\"> ");
                            sw.WriteLine("<Attributes> ");
                            sw.WriteLine("<Table key=\"link_" + num + "\">");
                            sw.WriteLine("<Pair key =\"info\"><String>net_package_install</String></Pair> ");
                            sw.WriteLine("<Pair key=\"pkg_src\"><String>" + url + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"pkg_src_qa\"><String>" + url + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"content_name\"><String>tool_pkg_install_pc</String></Pair> ");
                            sw.WriteLine("<Pair key=\"content_id\"><String>" + contentid + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"prod_pict_path\"><String>" + description + "</String></Pair> ");
                            sw.WriteLine("</Table> ");
                            sw.WriteLine("</Attributes> ");
                            sw.WriteLine("<Items>  ");
                            sw.WriteLine("<Item class=\"type:x-xmb/xmlnpsignup\" key=\"link_" + num + "\" attr=\"link_" + num + "\"/> ");
                            sw.WriteLine("</Items> ");
                            sw.WriteLine("</View>");

                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.CreateText(path + "/3.xml"))
                        {
                            sw.WriteLine("</Items>");
                            sw.WriteLine("</View>");
                            sw.WriteLine("<View id=\"item_" + num + "_link\"> ");
                            sw.WriteLine("<Attributes> ");
                            sw.WriteLine("<Table key=\"link_" + num + "\">");
                            sw.WriteLine("<Pair key =\"info\"><String>net_package_install</String></Pair> ");
                            sw.WriteLine("<Pair key=\"pkg_src\"><String>" + url + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"pkg_src_qa\"><String>" + url + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"content_name\"><String>tool_pkg_install_pc</String></Pair> ");
                            sw.WriteLine("<Pair key=\"content_id\"><String>" + contentid + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"prod_pict_path\"><String>" + description + "</String></Pair> ");
                            sw.WriteLine("</Table> ");
                            sw.WriteLine("</Attributes> ");
                            sw.WriteLine("<Items>  ");
                            sw.WriteLine("<Item class=\"type:x-xmb/xmlnpsignup\" key=\"link_" + num + "\" attr=\"link_" + num + "\"/> ");
                            sw.WriteLine("</Items> ");
                            sw.WriteLine("</View>");
                        }

                    }

                    // File.Create(path + "/4.xml");
                    if (File.Exists(path + "/4.xml"))
                    {

                    }
                    else
                    {
                        string[] lines = { "" };
                        foreach (string line in lines)
                        {
                            File.WriteAllText(path + "/4.xml", line);
                        }
                        using (StreamWriter sw = File.AppendText(path + "/4.xml"))
                        {
                            sw.WriteLine("</XMBML>");
                            sw.WriteLine("<!-- Created using PhoenixARC's XML Generator -->");
                            sw.WriteLine("<!-- Sub to PhoenixARC on YT! -->");
                        }
                    }


                    Globals.counter = Globals.counter + 1;

                }
                foreach (string item in listBox3.Items)
                {
                    string type0 = metroComboBox3.SelectedItem.ToString();
                    int number = Globals.counter;
                    string num = number.ToString();
                    string[] options = item.Split(';');
                    string titleid = options[0];
                    string name = options[1];
                    string type1 = options[2];
                    string region = options[3];
                    string url = options[4];
                    string contentid = options[5];
                    string sha256 = options[6];
                    string description = options[7];
                    string uploader = options[8];






                    string path = folderdir + "/JP" + "_" + type0;
                    // starting XML (Tables)
                    if (File.Exists(path + "/1.xml"))
                    {
                        using (StreamWriter sw = File.AppendText(path + "/1.xml"))
                        {
                            sw.WriteLine("<Attributes>");
                            sw.WriteLine("<Table key=\"item_" + num + "\"> ");
                            sw.WriteLine("<Pair key=\"icon\"><String>" + description + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"title\"><String>" + name + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"info\"><String>" + titleid);
                            sw.WriteLine("by" + uploader);
                            sw.WriteLine(type1);
                            sw.WriteLine(region + "</String></Pair>");
                            sw.WriteLine("</Table>");
                        }
                    }
                    else
                    {
                        // File.Create(path + "/1.xml");
                        string[] lines0 = { "<XMBML version = \"1.0\">", "<View id=\"" + region + "_" + type0 + "\">" };
                        foreach (string line in lines0)
                        {
                            File.WriteAllText(path + "/1.xml", line);
                        }
                        using (StreamWriter sw = File.AppendText(path + "/1.xml"))
                        {
                            sw.WriteLine("<Attributes>");
                            sw.WriteLine("<Table key=\"item_" + num + "\"> ");
                            sw.WriteLine("<Pair key=\"icon\"><String>" + description + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"title\"><String>" + name + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"info\"><String>" + titleid);
                            sw.WriteLine("by" + uploader);
                            sw.WriteLine(type1);
                            sw.WriteLine(region + "</String></Pair>");
                            sw.WriteLine("</Table>");
                        }

                    }
                    // 2nd XML (Items)
                    if (File.Exists(path + "/2.xml"))
                    {
                        using (StreamWriter sw = File.AppendText(path + "/2.xml"))
                        {
                            sw.WriteLine("<Items>");
                            sw.WriteLine("<Query ");
                            sw.WriteLine("class=\"type:x-xmb/folder-pixmap");
                            sw.WriteLine("key=\"item_" + num + "\"   attr =\"item_" + num + "\"  src = \"#item_" + num + "_link");
                            sw.WriteLine("/>");

                        }
                    }
                    else
                    {
                        // File.Create(path + "/2.xml");
                        string[] lines2 = { "</Attributes>" };
                        foreach (string line in lines2)
                        {
                            File.WriteAllText(path + "/2.xml", line);
                        }
                        using (StreamWriter sw = File.AppendText(path + "/2.xml"))
                        {
                            sw.WriteLine("<Items>");
                            sw.WriteLine("<Query ");
                            sw.WriteLine("class=\"type:x-xmb/folder-pixmap");
                            sw.WriteLine("key=\"item_" + num + "\"   attr =\"item_" + num + "\"  src = \"#item_" + num + "_link");
                            sw.WriteLine("/>");
                        }
                    }
                    // 3rd XML (content)
                    if (File.Exists(path + "/3.xml"))
                    {
                        using (StreamWriter sw = File.AppendText(path + "/3.xml"))
                        {
                            sw.WriteLine("<View id=\"item_" + num + "_link\"> ");
                            sw.WriteLine("<Attributes> ");
                            sw.WriteLine("<Table key=\"link_" + num + "\">");
                            sw.WriteLine("<Pair key =\"info\"><String>net_package_install</String></Pair> ");
                            sw.WriteLine("<Pair key=\"pkg_src\"><String>" + url + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"pkg_src_qa\"><String>" + url + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"content_name\"><String>tool_pkg_install_pc</String></Pair> ");
                            sw.WriteLine("<Pair key=\"content_id\"><String>" + contentid + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"prod_pict_path\"><String>" + description + "</String></Pair> ");
                            sw.WriteLine("</Table> ");
                            sw.WriteLine("</Attributes> ");
                            sw.WriteLine("<Items>  ");
                            sw.WriteLine("<Item class=\"type:x-xmb/xmlnpsignup\" key=\"link_" + num + "\" attr=\"link_" + num + "\"/> ");
                            sw.WriteLine("</Items> ");
                            sw.WriteLine("</View>");

                        }
                    }
                    else
                    {
                        // File.Create(path + "/3.xml");
                        string[] lines1 = { "</Items>", "</View>" };
                        foreach (string line in lines1)
                        {
                            File.WriteAllText(path + "/3.xml", line);
                        }
                        using (StreamWriter sw = File.AppendText(path + "/3.xml"))
                        {
                            sw.WriteLine("<View id=\"item_" + num + "_link\"> ");
                            sw.WriteLine("<Attributes> ");
                            sw.WriteLine("<Table key=\"link_" + num + "\">");
                            sw.WriteLine("<Pair key =\"info\"><String>net_package_install</String></Pair> ");
                            sw.WriteLine("<Pair key=\"pkg_src\"><String>" + url + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"pkg_src_qa\"><String>" + url + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"content_name\"><String>tool_pkg_install_pc</String></Pair> ");
                            sw.WriteLine("<Pair key=\"content_id\"><String>" + contentid + "</String></Pair> ");
                            sw.WriteLine("<Pair key=\"prod_pict_path\"><String>" + description + "</String></Pair> ");
                            sw.WriteLine("</Table> ");
                            sw.WriteLine("</Attributes> ");
                            sw.WriteLine("<Items>  ");
                            sw.WriteLine("<Item class=\"type:x-xmb/xmlnpsignup\" key=\"link_" + num + "\" attr=\"link_" + num + "\"/> ");
                            sw.WriteLine("</Items> ");
                            sw.WriteLine("</View>");
                        }

                    }

                    // File.Create(path + "/4.xml");

                    if (File.Exists(path + "/4.xml"))
                    {

                    }
                    else
                    {
                        string[] lines = { "" };
                        foreach (string line in lines)
                        {
                            File.WriteAllText(path + "/4.xml", line);
                        }
                        using (StreamWriter sw = File.AppendText(path + "/4.xml"))
                        {
                            sw.WriteLine("</XMBML>");
                            sw.WriteLine("<!-- Created using PhoenixARC's XML Generator -->");
                            sw.WriteLine("<!-- Sub to PhoenixARC on YT! -->");
                        }
                    }


                    Globals.counter = Globals.counter + 1;

                }
            }
            else
            {
                foreach (string item in listBox2.Items)
                {
                    string[] twelve = item.Split(';');
                    int number = Globals.counter;
                    string num = number.ToString();
                    string entryname = twelve[0];
                    string region = twelve[3];
                    string url = twelve[1];
                    string length = twelve[5];
                    string source = twelve[5];
                    string info = twelve[6];
                    string iconpath = twelve[7];
                    string uploader = twelve[4];
                    string podname = twelve[8];
                    switch (type)
                    {
                        case "Podcast":

                            string path = folderdir + "/US" + "_" + type;
                            if (File.Exists(path + "/1.xml"))
                            {
                                using (StreamWriter sw = File.AppendText(path + "/1.xml"))
                                {
                                    sw.WriteLine("<Table key=\"item_" + num + "\"> ");
                                    sw.WriteLine("<Pair key=\"icon\"><String> " + iconpath + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"title\"><String>#" + num + " " + entryname + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"info\"><String> " + length + " </String></Pair> ");
                                    sw.WriteLine("</Table>");
                                }
                            }
                            else
                            {
                                string[] lines0 = { "" };
                                foreach (string line in lines0)
                                {
                                    File.WriteAllText(path + "/1.xml", line);
                                }
                                using (StreamWriter sw = File.AppendText(path + "/1.xml"))
                                {
                                    sw.WriteLine("<XMBML version=\"1.0\"> ");
                                    sw.WriteLine("<View id=\"main\"> ");
                                    sw.WriteLine("<Attributes>");
                                    sw.WriteLine("<Table key=\"podcast_main\">");
                                    sw.WriteLine("<Pair key=\"icon\"><String> " + iconpath + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"title\"><String> " + podname + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"info\"><String></String></Pair> ");
                                    sw.WriteLine("</Table>");
                                    sw.WriteLine("</Attributes>");
                                    sw.WriteLine("<Items>");
                                    sw.WriteLine("<Query class=\"type:x-xmb/folder-pixmap\" key =\"podcast_main\" attr =\"podcast_main\" src =\"#podcast_items\" /> ");
                                    sw.WriteLine("</Items>");
                                    sw.WriteLine("</View>");
                                    sw.WriteLine("<View id=\"podcast_items\"> ");
                                    sw.WriteLine("<Attributes>");
                                    sw.WriteLine("<Table key=\"item_" + num + "\"> ");
                                    sw.WriteLine("<Pair key=\"icon\"><String> " + iconpath + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"title\"><String>#" + num + " " + entryname + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"info\"><String> " + length + " </String></Pair> ");
                                    sw.WriteLine("</Table>");
                                }

                            }
                            if (File.Exists(path + "/2.xml"))
                            {
                                using (StreamWriter sw = File.AppendText(path + "/2.xml"))
                                {
                                    sw.WriteLine("<Query class=\"type:x-xmb/folder-pixmap\" key=\"item_" + num + "\" attr=\"item_" + num + "\" src=\"#podcast00" + num + "_items\"/>");
                                }
                            }
                            else
                            {
                                string[] lines0 = { "" };
                                foreach (string line in lines0)
                                {
                                    File.WriteAllText(path + "/2.xml", line);
                                }
                                using (StreamWriter sw = File.AppendText(path + "/2.xml"))
                                {
                                    sw.WriteLine("</Attributes>");
                                    sw.WriteLine("<Items>");
                                    sw.WriteLine("<Query class=\"type:x-xmb/folder-pixmap\" key=\"item_" + num + "\" attr=\"item_" + num + "\" src=\"#podcast00" + num + "_items\"/>");
                                }
                            }
                            if (File.Exists(path + "/3.xml"))
                            {
                                using (StreamWriter sw = File.AppendText(path + "/3.xml"))
                                {
                                    sw.WriteLine("<View id=\"podcast00" + num + "_items\"> ");
                                    sw.WriteLine("<Attributes>");
                                    sw.WriteLine("<Table key=\"item_" + num + "_001\"> ");
                                    sw.WriteLine("<Pair key=\"icon\"><String> " + iconpath + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"title\"><String>   PLAY </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"info\"><String></String></Pair> ");
                                    sw.WriteLine("<Pair key=\"module_name\"><String> webbrowser_plugin </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"module_action\"><String> " + url + " </String></Pair> ");
                                    sw.WriteLine("</Table>");
                                    sw.WriteLine("<Table key=\"item_" + num + "_002\"> ");
                                    sw.WriteLine("<Pair key=\"icon\"><String> " + iconpath + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"title\"><String>   DOWNLOAD </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"info\"><String></String></Pair> ");
                                    sw.WriteLine("<Pair key=\"module_name\"><String> webbrowser_plugin </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"module_action\"><String> " + url + " </String></Pair> ");
                                    sw.WriteLine("</Table>");
                                    sw.WriteLine("<Table key=\"info_00" + num + "_main\"> ");
                                    sw.WriteLine("<Pair key=\"icon\"><String> " + iconpath + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"title\"><String>   INFO </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"info\"><String> " + info + " </String></Pair> ");
                                    sw.WriteLine("</Table>");
                                    sw.WriteLine("</Attributes>");
                                    sw.WriteLine("<Items>");
                                    sw.WriteLine("<Item class=\"type:x-xmb/module-action\" key=\"item_" + num + "_001\" attr=\"item_" + num + "_001\"/>");
                                    sw.WriteLine("<Item class=\"type:x-xmb/module-action\" key=\"item_" + num + "_002\" attr=\"item_" + num + "_002\"/>");
                                    sw.WriteLine("<Query class=\"type:x-xmb/folder-pixmap\" key=\"info_00" + num + "_main\" attr=\"info_00" + num + "_main\" src=\"#info_00" + num + "_item\"/>");
                                    sw.WriteLine("</Items>");
                                    sw.WriteLine("</View> ");
                                }
                            }
                            else
                            {
                                string[] lines0 = { "" };
                                foreach (string line in lines0)
                                {
                                    File.WriteAllText(path + "/3.xml", line);
                                }
                                using (StreamWriter sw = File.AppendText(path + "/3.xml"))
                                {
                                    sw.WriteLine("</Items>");
                                    sw.WriteLine("</View> ");
                                    sw.WriteLine("<View id=\"podcast00" + num + "_items\"> ");
                                    sw.WriteLine("<Attributes>");
                                    sw.WriteLine("<Table key=\"item_" + num + "_001\"> ");
                                    sw.WriteLine("<Pair key=\"icon\"><String> " + iconpath + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"title\"><String>   PLAY </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"info\"><String></String></Pair> ");
                                    sw.WriteLine("<Pair key=\"module_name\"><String> webbrowser_plugin </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"module_action\"><String> " + url + " </String></Pair> ");
                                    sw.WriteLine("</Table>");
                                    sw.WriteLine("<Table key=\"item_" + num + "_002\"> ");
                                    sw.WriteLine("<Pair key=\"icon\"><String> " + iconpath + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"title\"><String>   DOWNLOAD </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"info\"><String></String></Pair> ");
                                    sw.WriteLine("<Pair key=\"module_name\"><String> webbrowser_plugin </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"module_action\"><String> " + url + " </String></Pair> ");
                                    sw.WriteLine("</Table>");
                                    sw.WriteLine("<Table key=\"info_00" + num + "_main\"> ");
                                    sw.WriteLine("<Pair key=\"icon\"><String> " + iconpath + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"title\"><String>   INFO </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"info\"><String> " + info + " </String></Pair> ");
                                    sw.WriteLine("</Table>");
                                    sw.WriteLine("</Attributes>");
                                    sw.WriteLine("<Items>");
                                    sw.WriteLine("<Item class=\"type:x-xmb/module-action\" key=\"item_" + num + "_001\" attr=\"item_" + num + "_001\"/>");
                                    sw.WriteLine("<Item class=\"type:x-xmb/module-action\" key=\"item_" + num + "_002\" attr=\"item_" + num + "_002\"/>");
                                    sw.WriteLine("<Query class=\"type:x-xmb/folder-pixmap\" key=\"info_00" + num + "_main\" attr=\"info_00" + num + "_main\" src=\"#info_00" + num + "_item\"/>");
                                    sw.WriteLine("</Items>");
                                    sw.WriteLine("</View> ");
                                }
                            }
                            if (File.Exists(path + "/4.xml"))
                            {

                            }
                            else
                            {
                                string[] lines = { "" };
                                foreach (string line in lines)
                                {
                                    File.WriteAllText(path + "/4.xml", line);
                                }
                                using (StreamWriter sw = File.AppendText(path + "/4.xml"))
                                {
                                    sw.WriteLine("</XMBML>");
                                    sw.WriteLine("<!-- Created using PhoenixARC's XML Generator -->");
                                    sw.WriteLine("<!-- Sub to PhoenixARC on YT! -->");
                                }
                            }
                            Globals.counter = Globals.counter + 1;

                            break;

                        case "Video":

                            string pathB = folderdir + "/US" + "_" + type;
                            if (File.Exists(pathB + "/1.xml"))
                            {
                                using (StreamWriter sw = File.AppendText(pathB + "/1.xml"))
                                {
                                    sw.WriteLine("<Table key=\"item_" + num + "\"> ");
                                    sw.WriteLine("<Pair key=\"icon\"><String> " + iconpath + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"title\"><String>#" + num + " " + entryname + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"info\"><String> " + length + " </String></Pair> ");
                                    sw.WriteLine("</Table>");
                                }
                            }
                            else
                            {
                                string[] lines0 = { "" };
                                foreach (string line in lines0)
                                {
                                    File.WriteAllText(pathB + "/1.xml", line);
                                }
                                using (StreamWriter sw = File.AppendText(pathB + "/1.xml"))
                                {
                                    sw.WriteLine("<XMBML version=\"1.0\"> ");
                                    sw.WriteLine("<View id=\"main\"> ");
                                    sw.WriteLine("<Attributes>");
                                    sw.WriteLine("<Table key=\"playlist_main\">");
                                    sw.WriteLine("<Pair key=\"icon\"><String> " + iconpath + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"title\"><String> " + podname + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"info\"><String></String></Pair> ");
                                    sw.WriteLine("</Table>");
                                    sw.WriteLine("</Attributes>");
                                    sw.WriteLine("<Items>");
                                    sw.WriteLine("<Query class=\"type:x-xmb/folder-pixmap\" key =\"playlist_main\" attr =\"playlist_main\" src =\"#playlist_items\" /> ");
                                    sw.WriteLine("</Items>");
                                    sw.WriteLine("</View>");
                                    sw.WriteLine("<View id=\"playlist_items\"> ");
                                    sw.WriteLine("<Attributes>");
                                    sw.WriteLine("<Table key=\"item_" + num + "\"> ");
                                    sw.WriteLine("<Pair key=\"icon\"><String> " + iconpath + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"title\"><String>#" + num + " " + entryname + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"info\"><String> " + length + " </String></Pair> ");
                                    sw.WriteLine("</Table>");
                                }

                            }
                            if (File.Exists(pathB + "/2.xml"))
                            {
                                using (StreamWriter sw = File.AppendText(pathB + "/2.xml"))
                                {
                                    sw.WriteLine("<Query class=\"type:x-xmb/folder-pixmap\" key=\"item_" + num + "\" attr=\"item_" + num + "\" src=\"#playlist00" + num + "_items\"/>");
                                }
                            }
                            else
                            {
                                string[] lines0 = { "" };
                                foreach (string line in lines0)
                                {
                                    File.WriteAllText(pathB + "/2.xml", line);
                                }
                                using (StreamWriter sw = File.AppendText(pathB + "/2.xml"))
                                {
                                    sw.WriteLine("</Attributes>");
                                    sw.WriteLine("<Items>");
                                    sw.WriteLine("<Query class=\"type:x-xmb/folder-pixmap\" key=\"item_" + num + "\" attr=\"item_" + num + "\" src=\"#playlist00" + num + "_items\"/>");
                                }
                            }
                            if (File.Exists(pathB + "/3.xml"))
                            {
                                using (StreamWriter sw = File.AppendText(pathB + "/3.xml"))
                                {
                                    sw.WriteLine("<View id=\"playlist00" + num + "_items\"> ");
                                    sw.WriteLine("<Attributes>");
                                    sw.WriteLine("<Table key=\"item_" + num + "_001\"> ");
                                    sw.WriteLine("<Pair key=\"icon\"><String> " + iconpath + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"title\"><String>   PLAY </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"info\"><String></String></Pair> ");
                                    sw.WriteLine("<Pair key=\"module_name\"><String> webbrowser_plugin </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"module_action\"><String> " + url + " </String></Pair> ");
                                    sw.WriteLine("</Table>");
                                    sw.WriteLine("<Table key=\"item_" + num + "_002\"> ");
                                    sw.WriteLine("<Pair key=\"icon\"><String> " + iconpath + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"title\"><String>   DOWNLOAD </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"info\"><String></String></Pair> ");
                                    sw.WriteLine("<Pair key=\"module_name\"><String> webbrowser_plugin </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"module_action\"><String> " + url + " </String></Pair> ");
                                    sw.WriteLine("</Table>");
                                    sw.WriteLine("<Table key=\"info_00" + num + "_main\"> ");
                                    sw.WriteLine("<Pair key=\"icon\"><String> " + iconpath + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"title\"><String>   INFO </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"info\"><String> " + info + " </String></Pair> ");
                                    sw.WriteLine("</Table>");
                                    sw.WriteLine("</Attributes>");
                                    sw.WriteLine("<Items>");
                                    sw.WriteLine("<Item class=\"type:x-xmb/module-action\" key=\"item_" + num + "_001\" attr=\"item_" + num + "_001\"/>");
                                    sw.WriteLine("<Item class=\"type:x-xmb/module-action\" key=\"item_" + num + "_002\" attr=\"item_" + num + "_002\"/>");
                                    sw.WriteLine("<Query class=\"type:x-xmb/folder-pixmap\" key=\"info_00" + num + "_main\" attr=\"info_00" + num + "_main\" src=\"#info_00" + num + "_item\"/>");
                                    sw.WriteLine("</Items>");
                                    sw.WriteLine("</View> ");
                                }
                            }
                            else
                            {
                                string[] lines0 = { "" };
                                foreach (string line in lines0)
                                {
                                    File.WriteAllText(pathB + "/3.xml", line);
                                }
                                using (StreamWriter sw = File.AppendText(pathB + "/3.xml"))
                                {
                                    sw.WriteLine("</Items>");
                                    sw.WriteLine("</View> ");
                                    sw.WriteLine("<View id=\"playlist00" + num + "_items\"> ");
                                    sw.WriteLine("<Attributes>");
                                    sw.WriteLine("<Table key=\"item_" + num + "_001\"> ");
                                    sw.WriteLine("<Pair key=\"icon\"><String> " + iconpath + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"title\"><String>   PLAY </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"info\"><String></String></Pair> ");
                                    sw.WriteLine("<Pair key=\"module_name\"><String> webbrowser_plugin </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"module_action\"><String> " + url + " </String></Pair> ");
                                    sw.WriteLine("</Table>");
                                    sw.WriteLine("<Table key=\"item_" + num + "_002\"> ");
                                    sw.WriteLine("<Pair key=\"icon\"><String> " + iconpath + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"title\"><String>   DOWNLOAD </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"info\"><String></String></Pair> ");
                                    sw.WriteLine("<Pair key=\"module_name\"><String> webbrowser_plugin </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"module_action\"><String> " + url + " </String></Pair> ");
                                    sw.WriteLine("</Table>");
                                    sw.WriteLine("<Table key=\"info_00" + num + "_main\"> ");
                                    sw.WriteLine("<Pair key=\"icon\"><String> " + iconpath + " </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"title\"><String>   INFO </String></Pair> ");
                                    sw.WriteLine("<Pair key=\"info\"><String> " + info + " </String></Pair> ");
                                    sw.WriteLine("</Table>");
                                    sw.WriteLine("</Attributes>");
                                    sw.WriteLine("<Items>");
                                    sw.WriteLine("<Item class=\"type:x-xmb/module-action\" key=\"item_" + num + "_001\" attr=\"item_" + num + "_001\"/>");
                                    sw.WriteLine("<Item class=\"type:x-xmb/module-action\" key=\"item_" + num + "_002\" attr=\"item_" + num + "_002\"/>");
                                    sw.WriteLine("<Query class=\"type:x-xmb/folder-pixmap\" key=\"info_00" + num + "_main\" attr=\"info_00" + num + "_main\" src=\"#info_00" + num + "_item\"/>");
                                    sw.WriteLine("</Items>");
                                    sw.WriteLine("</View> ");
                                }
                            }
                            if (File.Exists(pathB + "/4.xml"))
                            {

                            }
                            else
                            {
                                string[] lines = { "" };
                                foreach (string line in lines)
                                {
                                    File.WriteAllText(pathB + "/4.xml", line);
                                }
                                using (StreamWriter sw = File.AppendText(pathB + "/4.xml"))
                                {
                                    sw.WriteLine("</XMBML>");
                                    sw.WriteLine("<!-- Created using PhoenixARC's XML Generator -->");
                                    sw.WriteLine("<!-- Sub to PhoenixARC on YT! -->");
                                }
                            }
                            Globals.counter = Globals.counter + 1;

                            break;

                        case "Link":

                            string pathC = folderdir + "/US" + "_" + type;
                            if (File.Exists(pathC + "/1.xml"))
                            {
                                using (StreamWriter sw = File.AppendText(pathC + "/1.xml"))
                                {
                                    sw.WriteLine("<Table key=\"link_" + num + "\">");
                                    sw.WriteLine("<Pair key=\"icon\"><String>" + iconpath + "</String></Pair>");
                                    sw.WriteLine("<Pair key=\"icon_notation\"><String>WNT_XmbItemBrowser</String></Pair>");
                                    sw.WriteLine("<Pair key=\"title\"><String>" + entryname + "</String></Pair>");
                                    sw.WriteLine("<Pair key=\"module_name\"><String>webrender_plugin</String></Pair>");
                                    sw.WriteLine("<Pair key=\"module_action\"><String>" + url + "</String></Pair>");
                                    sw.WriteLine("</Table>");
                                }
                            }
                            else
                            {
                                string[] lines0 = { "" };
                                foreach (string line in lines0)
                                {
                                    File.WriteAllText(pathC + "/1.xml", line);
                                }
                                using (StreamWriter sw = File.AppendText(pathC + "/1.xml"))
                                {
                                    sw.WriteLine("<XMBML version=\"1.0\">");
                                    sw.WriteLine("<View id=\"gen_links\">");
                                    sw.WriteLine("<Attributes>");
                                    sw.WriteLine("<Table key=\"link_" + num + "\">");
                                    sw.WriteLine("<Pair key=\"icon\"><String>" + iconpath + "</String></Pair>");
                                    sw.WriteLine("<Pair key=\"icon_notation\"><String>WNT_XmbItemBrowser</String></Pair>");
                                    sw.WriteLine("<Pair key=\"title\"><String>" + entryname + "</String></Pair>");
                                    sw.WriteLine("<Pair key=\"module_name\"><String>webrender_plugin</String></Pair>");
                                    sw.WriteLine("<Pair key=\"module_action\"><String>" + url + "</String></Pair>");
                                    sw.WriteLine("</Table>");
                                }

                            }
                            if (File.Exists(pathC + "/2.xml"))
                            {
                                using (StreamWriter sw = File.AppendText(pathC + "/2.xml"))
                                {
                                    sw.WriteLine("<Item class=\"type:x-xmb/module-action\" key=\"link_" + num + "\" attr=\"link_" + num + "\" />");
                                }
                            }
                            else
                            {
                                string[] lines0 = { "" };
                                foreach (string line in lines0)
                                {
                                    File.WriteAllText(pathC + "/2.xml", line);
                                }
                                using (StreamWriter sw = File.AppendText(pathC + "/2.xml"))
                                {
                                    sw.WriteLine("</Attributes>");
                                    sw.WriteLine("<Items>");
                                    sw.WriteLine("<Item class=\"type:x-xmb/module-action\" key=\"link_" + num + "\" attr=\"link_" + num + "\" />");
                                }
                            }
                            if (File.Exists(pathC + "/3.xml"))
                            {
                                using (StreamWriter sw = File.AppendText(pathC + "/3.xml"))
                                {
                                }
                            }
                            else
                            {
                                string[] lines0 = { "" };
                                foreach (string line in lines0)
                                {
                                    File.WriteAllText(pathC + "/3.xml", line);
                                }
                                using (StreamWriter sw = File.AppendText(pathC + "/3.xml"))
                                {
                                    sw.WriteLine("</Items>");
                                    sw.WriteLine("</View>");
                                }
                            }
                            if (File.Exists(pathC + "/4.xml"))
                            {

                            }
                            else
                            {
                                string[] lines = { "" };
                                foreach (string line in lines)
                                {
                                    File.WriteAllText(pathC + "/4.xml", line);
                                }
                                using (StreamWriter sw = File.AppendText(pathC + "/4.xml"))
                                {
                                    sw.WriteLine("</XMBML>");
                                    sw.WriteLine("<!-- Created using PhoenixARC's XML Generator -->");
                                    sw.WriteLine("<!-- Sub to PhoenixARC on YT! -->");
                                }
                            }
                            Globals.counter = Globals.counter + 1;
                            break;

                        case "XMB":
                            string pathD = folderdir + "/US" + "_" + type;
                            if (File.Exists(pathD + "/1.xml"))
                            {
                                using (StreamWriter sw = File.AppendText(pathD + "/1.xml"))
                                {
                                    sw.WriteLine("<Table key=\"xmb_item_" + num + "\">");
                                    sw.WriteLine("<Pair key=\"icon\"><String>" + iconpath + "</String></Pair>");
                                    sw.WriteLine("<Pair key=\"icon_notation\"><String>WNT_XmbItemAlbum</String></Pair>");
                                    sw.WriteLine("<Pair key=\"title\"><String>" + entryname + "</String></Pair>");
                                    sw.WriteLine("<Pair key=\"info\"><String>" + info + "</String></Pair>");
                                    sw.WriteLine("<Pair key=\"str_noitem\"><String>msg_error_no_content</String></Pair>");
                                    sw.WriteLine("<Pair key=\"ingame\"><String>enable</String></Pair>");
                                    sw.WriteLine("</Table>");
                                }
                            }
                            else
                            {
                                string[] lines0 = { "" };
                                foreach (string line in lines0)
                                {
                                    File.WriteAllText(pathD + "/1.xml", line);
                                }
                                using (StreamWriter sw = File.AppendText(pathD + "/1.xml"))
                                {
                                    sw.WriteLine("<XMBML version=\"1.0\">");
                                    sw.WriteLine("<View id=\"xmb_main\">");
                                    sw.WriteLine("<Attributes>");
                                    sw.WriteLine("<Table key=\"xmb_item_" + num + "\">");
                                    sw.WriteLine("<Pair key=\"icon\"><String>" + iconpath + "</String></Pair>");
                                    sw.WriteLine("<Pair key=\"icon_notation\"><String>WNT_XmbItemAlbum</String></Pair>");
                                    sw.WriteLine("<Pair key=\"title\"><String>" + entryname + "</String></Pair>");
                                    sw.WriteLine("<Pair key=\"info\"><String>" + info + "</String></Pair>");
                                    sw.WriteLine("<Pair key=\"str_noitem\"><String>msg_error_no_content</String></Pair>");
                                    sw.WriteLine("<Pair key=\"ingame\"><String>enable</String></Pair>");
                                    sw.WriteLine("</Table>");
                                }

                            }
                            if (File.Exists(pathD + "/2.xml"))
                            {
                                using (StreamWriter sw = File.AppendText(pathD + "/2.xml"))
                                {
                                    sw.WriteLine("<Query class=\"type:x-xmb/folder-pixmap\" key=\"xmb_item_" + num + "\" attr=\"xmb_item_" + num + "\" src=\"" + source + "\"/>");
                                }
                            }
                            else
                            {
                                string[] lines0 = { "" };
                                foreach (string line in lines0)
                                {
                                    File.WriteAllText(pathD + "/2.xml", line);
                                }
                                using (StreamWriter sw = File.AppendText(pathD + "/2.xml"))
                                {
                                    sw.WriteLine("</Attributes>");
                                    sw.WriteLine("<Items>");
                                    sw.WriteLine("<Query class=\"type:x-xmb/folder-pixmap\" key=\"xmb_item_" + num + "\" attr=\"xmb_item_" + num + "\" src=\"" + source + "\"/>");
                                }
                            }
                            if (File.Exists(pathD + "/3.xml"))
                            {
                                using (StreamWriter sw = File.AppendText(pathD + "/3.xml"))
                                {
                                }
                            }
                            else
                            {
                                string[] lines0 = { "" };
                                foreach (string line in lines0)
                                {
                                    File.WriteAllText(pathD + "/3.xml", line);
                                }
                                using (StreamWriter sw = File.AppendText(pathD + "/3.xml"))
                                {
                                    sw.WriteLine("</Items>");
                                    sw.WriteLine("</View>");
                                }
                            }
                            if (File.Exists(pathD + "/4.xml"))
                            {

                            }
                            else
                            {
                                string[] lines = { "" };
                                foreach (string line in lines)
                                {
                                    File.WriteAllText(pathD + "/4.xml", line);
                                }
                                using (StreamWriter sw = File.AppendText(pathD + "/4.xml"))
                                {
                                    sw.WriteLine("</XMBML>");
                                    sw.WriteLine("<!-- Created using PhoenixARC's XML Generator -->");
                                    sw.WriteLine("<!-- Sub to PhoenixARC on YT! -->");
                                }
                            }
                            Globals.counter = Globals.counter + 1;
                            break;
                        case "fcopy":
                            string copy1 = metroLabel52.Text;
                            string copy2 = metroLabel53.Text;
                            string pathE = folderdir + "/US" + "_" + type;
                            if (File.Exists(pathE + "/1.xml"))
                            {
                                using (StreamWriter sw = File.AppendText(pathE + "/1.xml"))
                                {
                                    sw.WriteLine("<Table key=\"item_" + num + "\">");
                                    sw.WriteLine("<Pair key=\"icon\"><String>" + iconpath + "</String></Pair>");
                                    sw.WriteLine("<Pair key=\"title\"><String>" + entryname + "</String></Pair>");
                                    sw.WriteLine("<Pair key=\"info\"><String>Press  to continue</String></Pair>");
                                    sw.WriteLine("<Pair key=\"module_name\"><String>videodownloader_plugin</String></Pair>");
                                    sw.WriteLine("<Pair key=\"module_action\"><String>fcopy#" + copy1 + "#" + copy2 + "</String></Pair>");
                                    sw.WriteLine("<Pair key=\"bar_action\"><String>none</String></Pair>");
                                    sw.WriteLine("<Pair key=\"lbl_half\"><String>1</String></Pair>");
                                    sw.WriteLine("</Table>");
                                }
                            }
                            else
                            {
                                string[] lines0 = { "" };
                                foreach (string line in lines0)
                                {
                                    File.WriteAllText(pathE + "/1.xml", line);
                                }
                                using (StreamWriter sw = File.AppendText(pathE + "/1.xml"))
                                {
                                    sw.WriteLine("<XMBML version=\"1.0\">");
                                    sw.WriteLine("<View id=\"fcopy_main\">");
                                    sw.WriteLine("<Attributes>");
                                    sw.WriteLine("<Table key=\"item_" + num + "\">");
                                    sw.WriteLine("<Pair key=\"icon\"><String>" + iconpath + "</String></Pair>");
                                    sw.WriteLine("<Pair key=\"title\"><String>" + entryname + "</String></Pair>");
                                    sw.WriteLine("<Pair key=\"info\"><String>Press  to continue</String></Pair>");
                                    sw.WriteLine("<Pair key=\"module_name\"><String>videodownloader_plugin</String></Pair>");
                                    sw.WriteLine("<Pair key=\"module_action\"><String>fcopy#" + copy1 + "#" + copy2 + "</String></Pair>");
                                    sw.WriteLine("<Pair key=\"bar_action\"><String>none</String></Pair>");
                                    sw.WriteLine("<Pair key=\"lbl_half\"><String>1</String></Pair>");
                                    sw.WriteLine("</Table>");
                                }

                            }
                            if (File.Exists(pathE + "/2.xml"))
                            {
                                using (StreamWriter sw = File.AppendText(pathE + "/2.xml"))
                                {
                                    sw.WriteLine("<Query class=\"type:x-xmb/module-action\" key=\"item_" + num + "\" attr=\"item_" + num + "\" />");
                                }
                            }
                            else
                            {
                                string[] lines0 = { "" };
                                foreach (string line in lines0)
                                {
                                    File.WriteAllText(pathE + "/2.xml", line);
                                }
                                using (StreamWriter sw = File.AppendText(pathE + "/2.xml"))
                                {
                                    sw.WriteLine("</Attributes>");
                                    sw.WriteLine("<Items>");
                                    sw.WriteLine("<Query class=\"type:x-xmb/module-action\" key=\"item_" + num + "\" attr=\"item_" + num + "\" />");
                                }
                            }
                            if (File.Exists(pathE + "/3.xml"))
                            {
                                using (StreamWriter sw = File.AppendText(pathE + "/3.xml"))
                                {
                                }
                            }
                            else
                            {
                                string[] lines0 = { "" };
                                foreach (string line in lines0)
                                {
                                    File.WriteAllText(pathE + "/3.xml", line);
                                }
                                using (StreamWriter sw = File.AppendText(pathE + "/3.xml"))
                                {
                                    sw.WriteLine("</Items>");
                                    sw.WriteLine("</View>");
                                }
                            }
                            if (File.Exists(pathE + "/4.xml"))
                            {

                            }
                            else
                            {
                                string[] lines = { "" };
                                foreach (string line in lines)
                                {
                                    File.WriteAllText(pathE + "/4.xml", line);
                                }
                                using (StreamWriter sw = File.AppendText(pathE + "/4.xml"))
                                {
                                    sw.WriteLine("</XMBML>");
                                    sw.WriteLine("<!-- Created using PhoenixARC's XML Generator -->");
                                    sw.WriteLine("<!-- Sub to PhoenixARC on YT! -->");
                                }
                            }
                            Globals.counter = Globals.counter + 1;
                            break;
                        default:
                            break;

                    }
                }

                string typeX = metroLabel19.Text;

                if (File.Exists(@folderdir + "/US" + "_" + typeX + "/1.xml"))
                {
                    string path1 = @folderdir + "/US" + "_" + typeX + "/1.xml";
                    string path2 = @folderdir + "/US" + "_" + typeX + "/2.xml";
                    string path3 = @folderdir + "/US" + "_" + typeX + "/3.xml";
                    string path4 = @folderdir + "/US" + "_" + typeX + "/4.xml";
                    string newFilePath = @folderdir + "/US" + "_" + typeX + "/US_" + typeX + ".xml";
                    using (FileStream fs = File.Create(@folderdir + "/US" + "_" + typeX + "/US_" + typeX + ".xml"))
                    {

                        fs.Close();
                    }

                    string allText = System.IO.File.ReadAllText(path1);
                    allText += "\r\n";
                    allText += System.IO.File.ReadAllText(path2);
                    allText += "\r\n";
                    allText += System.IO.File.ReadAllText(path3);
                    allText += "\r\n";
                    allText += System.IO.File.ReadAllText(path4);
                    File.WriteAllText(newFilePath, allText);

                }


                if (File.Exists(@folderdir + "/EU" + "_" + typeX + "/1.xml"))
                {
                    string path1B = @folderdir + "/EU" + "_" + typeX + "/1.xml";
                    string path2B = @folderdir + "/EU" + "_" + typeX + "/2.xml";
                    string path3B = @folderdir + "/EU" + "_" + typeX + "/3.xml";
                    string path4B = @folderdir + "/EU" + "_" + typeX + "/4.xml";
                    string newFilePathB = @folderdir + "/EU" + "_" + typeX + "/EU_" + typeX + ".xml";

                    string allTextB = System.IO.File.ReadAllText(path1B);
                    allTextB += "\r\n";
                    allTextB += System.IO.File.ReadAllText(path2B);
                    allTextB += "\r\n";
                    allTextB += System.IO.File.ReadAllText(path3B);
                    allTextB += "\r\n";
                    allTextB += System.IO.File.ReadAllText(path4B);
                    File.WriteAllText(newFilePathB, allTextB);
                }


                if (File.Exists(@folderdir + "/JP" + "_" + typeX + "/1.xml"))
                {
                    string path1C = @folderdir + "/JP" + "_" + typeX + "/1.xml";
                    string path2C = @folderdir + "/JP" + "_" + typeX + "/2.xml";
                    string path3C = @folderdir + "/JP" + "_" + typeX + "/3.xml";
                    string path4C = @folderdir + "/JP" + "_" + typeX + "/4.xml";
                    string newFilePathC = @folderdir + "/JP" + "_" + typeX + "/JP_" + typeX + ".xml";

                    string allTextC = System.IO.File.ReadAllText(path1C);
                    allTextC += "\r\n";
                    allTextC += System.IO.File.ReadAllText(path2C);
                    allTextC += "\r\n";
                    allTextC += System.IO.File.ReadAllText(path3C);
                    allTextC += "\r\n";
                    allTextC += System.IO.File.ReadAllText(path4C);
                    File.WriteAllText(newFilePathC, allTextC);
                }
            }


        }

        private void MetroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            metroPanel3.Visible = false;
            metroPanel2.Visible = false;
            metroPanel4.Visible = false;
            metroPanel5.Visible = false;
            metroPanel6.Visible = false;
            metroPanel1.Visible = true;
        }

        private void MetroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            metroPanel1.Visible = false;
            metroPanel2.Visible = false;
            metroPanel4.Visible = false;
            metroPanel5.Visible = false;
            metroPanel6.Visible = false;
            metroPanel3.Visible = true;
        }

        private void MetroRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            metroPanel1.Visible = false;
            metroPanel2.Visible = false;
            metroPanel3.Visible = false;
            metroPanel5.Visible = false;
            metroPanel6.Visible = false;
            metroPanel4.Visible = true;

        }

        private void MetroRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            metroPanel1.Visible = false;
            metroPanel2.Visible = false;
            metroPanel3.Visible = false;
            metroPanel4.Visible = false;
            metroPanel6.Visible = false;
            metroPanel5.Visible = true;

        }

        private void MetroRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            metroPanel1.Visible = false;
            metroPanel2.Visible = false;
            metroPanel3.Visible = false;
            metroPanel4.Visible = false;
            metroPanel5.Visible = false;
            metroPanel6.Visible = true;

        }

        private void MetroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked == true)
            {
                metroTextBox32.Enabled = true;
                metroPanel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            }
            else
            {
                metroTextBox32.Enabled = false;
                metroPanel7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            }
        }

        private void MetroButton11_Click(object sender, EventArgs e)
        {
            metroTextBox16.Enabled = false;
            List<string> test = new List<string>();
            string entryname = metroTextBox18.Text;
            string url = metroTextBox21.Text;
            string length = metroTextBox19.Text;
            string iconpath = metroTextBox17.Text;
            string uploader = metroTextBox20.Text;
            string type = "Podcast";
            string region = "US";
            string info = metroTextBox15.Text;
            string podname = metroTextBox16.Text;
            string add = entryname + ";" + url + ";" + type + ";" + region + ";" + uploader + ";" + length + ";" + info + ";" + iconpath + ";" + podname;
            foreach (string item in listBox1.Items)
            {
                test.Add(item);
            }
            test.Add(add);
            listBox1.Items.Clear();
            foreach (string item in test)
            {
                listBox1.Items.Add(item);
            }
        }

        private void MetroButton10_Click(object sender, EventArgs e)
        {

            List<string> test = new List<string>();
            foreach (string item in listBox1.Items)
            {
                test.Add(item);
            }

            string asdf = listBox1.SelectedItem.ToString();
            test.Remove(asdf);
            listBox1.Items.Clear();
            foreach (string item in test)
            {
                listBox1.Items.Add(item);
            }

        }

        private void MetroButton13_Click(object sender, EventArgs e)
        {

            List<string> test = new List<string>();
            string entryname = metroTextBox25.Text;
            string url = metroTextBox28.Text;
            string length = metroTextBox26.Text;
            string iconpath = metroTextBox24.Text;
            string uploader = metroTextBox27.Text;
            string type = "Video";
            string region = "US";
            string info = metroTextBox22.Text;
            string add = entryname + ";" + url + ";" + type + ";" + region + ";" + uploader + ";" + length + ";" + info + ";" + iconpath + ";" + uploader;
            foreach (string item in listBox1.Items)
            {
                test.Add(item);
            }
            test.Add(add);
            listBox1.Items.Clear();
            foreach (string item in test)
            {
                listBox1.Items.Add(item);
            }

        }

        private void MetroButton12_Click(object sender, EventArgs e)
        {

            List<string> test = new List<string>();
            foreach (string item in listBox1.Items)
            {
                test.Add(item);
            }

            string asdf = listBox1.SelectedItem.ToString();
            test.Remove(asdf);
            listBox1.Items.Clear();
            foreach (string item in test)
            {
                listBox1.Items.Add(item);
            }

        }

        private void MetroButton15_Click(object sender, EventArgs e)
        {

            List<string> test = new List<string>();
            string entryname = metroTextBox10.Text;
            string url = metroTextBox12.Text;
            string length = "";
            string iconpath = metroTextBox11.Text;
            string uploader = "";
            string type = "Link";
            string region = "US";
            string info = "";
            string add = entryname + ";" + url + ";" + type + ";" + region + ";" + uploader + ";" + length + ";" + info + ";" + iconpath + ";" + uploader;
            foreach (string item in listBox1.Items)
            {
                test.Add(item);
            }
            test.Add(add);
            listBox1.Items.Clear();
            foreach (string item in test)
            {
                listBox1.Items.Add(item);
            }

        }

        private void MetroButton14_Click(object sender, EventArgs e)
        {

            List<string> test = new List<string>();
            foreach (string item in listBox1.Items)
            {
                test.Add(item);
            }

            string asdf = listBox1.SelectedItem.ToString();
            test.Remove(asdf);
            listBox1.Items.Clear();
            foreach (string item in test)
            {
                listBox1.Items.Add(item);
            }

        }

        private void MetroButton17_Click(object sender, EventArgs e)
        {

            List<string> test = new List<string>();
            string entryname = metroTextBox30.Text;
            string linktoanother = metroLabel18.Text;
            string extlink = metroTextBox32.Text;
            string iconpath = metroTextBox31.Text;
            string uploader = "";
            string type = "XMB";
            string region = "US";
            string info = metroTextBox29.Text;
            string add = entryname + ";" + linktoanother + ";" + type + ";" + region + ";" + uploader + ";" + extlink + ";" + info + ";" + iconpath + ";" + uploader;
            foreach (string item in listBox1.Items)
            {
                test.Add(item);
            }
            test.Add(add);
            listBox1.Items.Clear();
            foreach (string item in test)
            {
                listBox1.Items.Add(item);
            }

        }

        private void MetroButton16_Click(object sender, EventArgs e)
        {

            List<string> test = new List<string>();
            foreach (string item in listBox1.Items)
            {
                test.Add(item);
            }

            string asdf = listBox1.SelectedItem.ToString();
            test.Remove(asdf);
            listBox1.Items.Clear();
            foreach (string item in test)
            {
                listBox1.Items.Add(item);
            }

        }

        private void MetroCheckBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked == true)
            {
                metroLabel18.Text = "Yes";
                metroTextBox32.Enabled = true;
                metroPanel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            }
            else
            {
                metroLabel18.Text = "No";
                metroTextBox32.Enabled = false;
                metroPanel7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            }

        }

        private void MetroRadioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton10.Checked == true)
            {
                metroComboBox3.Enabled = true;
                metroButton7.Enabled = false;
            }
        }

        private void MetroRadioButton9_CheckedChanged(object sender, EventArgs e)
        {

            if (metroRadioButton9.Checked == true)
            {
                metroComboBox3.Enabled = false;
                metroButton7.Enabled = true;
            }
        }

        private void MetroRadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton8.Checked == true)
            {
                metroComboBox3.Enabled = false;
                metroButton7.Enabled = true;
            }
        }

        private void MetroRadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton7.Checked == true)
            {
                metroComboBox3.Enabled = false;
                metroButton7.Enabled = true;
            }
        }

        private void MetroRadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton6.Checked == true)
            {
                metroComboBox3.Enabled = false;
                metroButton7.Enabled = true;
            }
        }

        private void MetroButton25_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.psx-place.com/members/phoenixarc.43472/");
        }

        private void MetroButton24_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCRX1QghQRJTAgXx11Hc_IVQ?view_as=subscriber");
        }

        private void MetroButton22_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.psx-place.com/members/devil303.22544/");
        }

        private void MetroButton23_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCQS02JAUiGySZK-rK0BW1Yg");
        }

        private void MetroButton9_Click(object sender, EventArgs e)
        {

            List<string> test = new List<string>();
            string entryname = metroTextBox8.Text;
            string copy1 = metroTextBox13.Text;
            string copy2 = metroTextBox14.Text;
            string iconpath = metroTextBox9.Text;
            string uploader = "";
            string type = "fcopy";
            string region = "US";
            string info = "";
            string add = entryname + ";" + copy1 + ";" + type + ";" + region + ";" + uploader + ";" + copy2 + ";" + info + ";" + iconpath + ";" + uploader;
            metroLabel52.Text = copy1;
            metroLabel53.Text = copy2;
            foreach (string item in listBox1.Items)
            {
                test.Add(item);
            }
            test.Add(add);
            listBox1.Items.Clear();
            foreach (string item in test)
            {
                listBox1.Items.Add(item);
            }
        }

        private void MetroButton8_Click(object sender, EventArgs e)
        {

            List<string> test = new List<string>();
            foreach (string item in listBox1.Items)
            {
                test.Add(item);
            }

            string asdf = listBox1.SelectedItem.ToString();
            test.Remove(asdf);
            listBox1.Items.Clear();
            foreach (string item in test)
            {
                listBox1.Items.Add(item);
            }
        }

        private void MetroRadioButton11_CheckedChanged(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            metroPanel1.Visible = false;
            metroPanel2.Visible = true;
            metroPanel3.Visible = false;
            metroPanel4.Visible = false;
            metroPanel5.Visible = false;
            metroPanel6.Visible = false;
        }

        private void MetroRadioButton12_CheckedChanged(object sender, EventArgs e)
        {
            if (metroRadioButton12.Checked == true)
            {
                metroComboBox3.Enabled = false;
                metroButton7.Enabled = true;
            }
        }

        private void MetroTabPage3_Click(object sender, EventArgs e)
        {

        }

        private void MetroButton18_Click(object sender, EventArgs e)
        {

            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = "MP3 Audio File |*.MP3";
            OpenFileDialog1.FilterIndex = 1;
            List<string> newlist = new List<string>();
            if (OpenFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string line = OpenFileDialog1.FileName;
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/tools/convert/mp3/temp.mp3");
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/tools/convert/mp3/output.m4a");
                File.Copy(line, AppDomain.CurrentDomain.BaseDirectory + "/tools/convert/mp3/temp.mp3");
                metroTextBox33.Text = line;
            }
        }

        private void MetroButton19_Click(object sender, EventArgs e)
        {
            try
            {
                string oldline = metroTextBox33.Text.Replace(".mp3", ".m4a");
                var process = Process.Start(AppDomain.CurrentDomain.BaseDirectory + "/tools/convert/mp3/Convert_mp3_to_PS3_m4a.bat");
                process.WaitForExit();
                string line = AppDomain.CurrentDomain.BaseDirectory + "tools/convert/mp3/output.m4a";
                File.Copy(line, oldline);
            }
            catch (Exception)
            {
                MessageBox.Show("Could not convert! \n Error code (80x1257)", "Error!");
            }


        }

        private void MetroButton20_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = "PhoeniXML Tempfile |*.PhoList";
            OpenFileDialog1.FilterIndex = 1;
            if (OpenFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                metroLabel14.Text = OpenFileDialog1.FileName;
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox4.Items.Clear();
                string line = System.IO.File.ReadAllText(OpenFileDialog1.FileName);
                string[] seperated = line.Split(
    new[] { "\r\n", "\r", "\n" },
    StringSplitOptions.None
);
                string dir = OpenFileDialog1.FileName;
                List<string> list0 = new List<string>();
                List<string> pass = new List<string>();
                list0.Clear();
                string twelve = seperated[0];
                string[] twelve2 = twelve.Split(';');
                    foreach (string item in seperated)
                    {
                        if (string.IsNullOrEmpty(item))
                        {

                        }
                        else
                        {
                            pass.Add(item);
                        }
                    }
                    foreach (string item in pass)
                    {
                            switch (twelve2[2])
                            {
                                case "Podcast":
                                    list0.Add(item);
                                    break;
                                case "Video":
                                    list0.Add(item);
                                    break;
                                case "Link":
                                    list0.Add(item);
                                    break;
                                case "XMB":
                                    list0.Add(item);
                                    break;
                                case "fcopy":
                                    list0.Add(item);
                                    break;

                                default:

                                    break;
                            }
                    }
                    foreach (string item in list0)
                    {
                        string[] options = item.Split(';');
                    if (listBox5.Items.IsBlank() == true)
                    {
                        switch (item.Split(';')[3])
                        {
                            case "EU":
                                listBox5.Items.Add(item);
                                break;
                            case "US":
                                listBox5.Items.Add(item);
                                break;
                            case "JP":
                                listBox5.Items.Add(item);
                                break;
                            case "HK":
                                listBox5.Items.Add(item);
                                break;
                            default:

                                break;
                        }
                    }
                    if (listBox5.Items.IsBlank() == false)
                    {
                        if (listBox6.Items.IsBlank() == true)
                        {
                            switch (item.Split(';')[3])
                            {
                                case "EU":
                                    listBox6.Items.Add(item);
                                    break;
                                case "US":
                                    listBox6.Items.Add(item);
                                    break;
                                case "JP":
                                    listBox6.Items.Add(item);
                                    break;
                                case "HK":
                                    listBox6.Items.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                    }

                    if (listBox6.Items.IsBlank() == false)
                    {
                        if (listBox7.Items.IsBlank() == true)
                        {
                            switch (item.Split(';')[3])
                            {
                                case "EU":
                                    listBox7.Items.Add(item);
                                    break;
                                case "US":
                                    listBox7.Items.Add(item);
                                    break;
                                case "JP":
                                    listBox7.Items.Add(item);
                                    break;
                                case "HK":
                                    listBox7.Items.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                    }

                    if (listBox7.Items.IsBlank() == false)
                    {
                        if (listBox8.Items.IsBlank() == true)
                        {
                            switch (item.Split(';')[3])
                            {
                                case "EU":
                                    listBox8.Items.Add(item);
                                    break;
                                case "US":
                                    listBox8.Items.Add(item);
                                    break;
                                case "JP":
                                    listBox8.Items.Add(item);
                                    break;
                                case "HK":
                                    listBox8.Items.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                    }

                    if (listBox8.Items.IsBlank() == false)
                    {
                        if (listBox9.Items.IsBlank() == true)
                        {
                            switch (item.Split(';')[3])
                            {
                                case "EU":
                                    listBox9.Items.Add(item);
                                    break;
                                case "US":
                                    listBox9.Items.Add(item);
                                    break;
                                case "JP":
                                    listBox9.Items.Add(item);
                                    break;
                                case "HK":
                                    listBox9.Items.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                    }

                }
                    foreach (string item in seperated)
                    {
                        if (string.IsNullOrEmpty(item))
                        {

                        }
                        else
                        {
                            pass.Add(item);
                        }

                    }
                    foreach (string item in pass)
                    {
                        string[] options = item.Split(';');
                        string opt1 = item.Split(';')[2];
                        if (opt1 == "Any")
                        {
                            switch (opt1)
                            {
                                default:
                                    list0.Add(item);
                                    break;
                            }
                        }
                        if (opt1 == "PS3")
                        {
                            switch (item.Split(';')[2])
                            {
                                case "PS3":
                                    list0.Add(item);
                                    break;
                                case "PSN":
                                    list0.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                        if (opt1 == "PS4")
                        {
                            switch (item.Split(';')[2])
                            {
                                case "PS4":
                                    list0.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                        if (opt1 == "PS2")
                        {
                            switch (item.Split(';')[2])
                            {
                                case "PS2":
                                    list0.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                        if (opt1 == "PSX (PS1)")
                        {
                            switch (item.Split(';')[2])
                            {
                                case "PS1":
                                    list0.Add(item);
                                    break;
                                case "PSX":
                                    list0.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                        if (opt1 == "C00")
                        {
                            switch (item.Split(';')[2])
                            {
                                case "C00":
                                    list0.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                        if (opt1 == "DLC")
                        {
                            switch (item.Split(';')[2])
                            {
                                case "DLC":
                                    list0.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                        if (opt1 == "Theme")
                        {
                            switch (item.Split(';')[2])
                            {
                                case "Theme":
                                    list0.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                        if (opt1 == "Homebrew")
                        {
                            switch (item.Split(';')[2])
                            {
                                case "Homebrew":
                                    list0.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                        if (opt1 == "Tool")
                        {
                            switch (item.Split(';')[2])
                            {
                                case "Tool":
                                    list0.Add(item);
                                    break;
                                default:

                                    break;
                            }
                        }
                    }
                
            }
        }

        private void MetroButton21_Click(object sender, EventArgs e)
        {
            foreach (string item in listBox2.Items)
            {

                string text = this.text27.Trim();
                if (text.Length == 0)
                {
                    return;
                }
                int num = text.IndexOf('/');
                if (-1 != num)
                {
                    text = text.Substring(num);
                }
                num = text.IndexOf('\\');
                if (-1 != num)
                {
                    text = text.Substring(num);
                }
                string text2;
                bool flag;
                if (text.Length == 0 || text.EndsWith(".rap", StringComparison.OrdinalIgnoreCase))
                {
                    text2 = AppDomain.CurrentDomain.BaseDirectory + "\\exdata";
                    flag = false;
                }
                else
                {
                    text2 = AppDomain.CurrentDomain.BaseDirectory + "\\fixes";
                    flag = true;
                }
                if (!Directory.Exists(text2))
                {
                    Directory.CreateDirectory(text2);
                }
                try
                {
                    string hex = this.text27;
                    File.WriteAllBytes(text2 + "\\" + text, Form1.StringToByteArray(hex));
                    bool flag2 = true;
                    if (flag)
                    {
                        if (flag2)
                        {
                            MessageBox.Show("FIX", "FIX has been saved to fixes!");
                        }
                        else
                        {
                            MessageBox.Show("FIX", "Couldn't save Fix!");
                        }
                    }
                    else if (flag2)
                    {
                        MessageBox.Show("RAP", "Rap has been saved to exdata!");
                    }
                    else
                    {
                        MessageBox.Show("rap", "Couldn't save Rap!");
                    }
                }
                catch
                {

                    MessageBox.Show("Warning", "No rap/fix available!");
                }
            }
            foreach (string item in listBox3.Items)
            {

                string text = this.text27.Trim();
                if (text.Length == 0)
                {
                    return;
                }
                int num = text.IndexOf('/');
                if (-1 != num)
                {
                    text = text.Substring(num);
                }
                num = text.IndexOf('\\');
                if (-1 != num)
                {
                    text = text.Substring(num);
                }
                string text2;
                bool flag;
                if (text.Length == 0 || text.EndsWith(".rap", StringComparison.OrdinalIgnoreCase))
                {
                    text2 = AppDomain.CurrentDomain.BaseDirectory + "\\exdata";
                    flag = false;
                }
                else
                {
                    text2 = AppDomain.CurrentDomain.BaseDirectory + "\\fixes";
                    flag = true;
                }
                if (!Directory.Exists(text2))
                {
                    Directory.CreateDirectory(text2);
                }
                try
                {
                    string hex = this.text27;
                    File.WriteAllBytes(text2 + "\\" + text, Form1.StringToByteArray(hex));
                    bool flag2 = true;
                    if (flag)
                    {
                        if (flag2)
                        {
                            MessageBox.Show("FIX", "FIX has been saved to fixes!");
                        }
                        else
                        {
                            MessageBox.Show("FIX", "Couldn't save Fix!");
                        }
                    }
                    else if (flag2)
                    {
                        MessageBox.Show("RAP", "Rap has been saved to exdata!");
                    }
                    else
                    {
                        MessageBox.Show("rap", "Couldn't save Rap!");
                    }
                }
                catch
                {

                    MessageBox.Show("Warning", "No rap/fix available!");
                }
            }
            foreach (string item in listBox4.Items)
            {

                string text = this.text27.Trim();
                if (text.Length == 0)
                {
                    return;
                }
                int num = text.IndexOf('/');
                if (-1 != num)
                {
                    text = text.Substring(num);
                }
                num = text.IndexOf('\\');
                if (-1 != num)
                {
                    text = text.Substring(num);
                }
                string text2;
                bool flag;
                if (text.Length == 0 || text.EndsWith(".rap", StringComparison.OrdinalIgnoreCase))
                {
                    text2 = AppDomain.CurrentDomain.BaseDirectory + "\\exdata";
                    flag = false;
                }
                else
                {
                    text2 = AppDomain.CurrentDomain.BaseDirectory + "\\fixes";
                    flag = true;
                }
                if (!Directory.Exists(text2))
                {
                    Directory.CreateDirectory(text2);
                }
                try
                {
                    string hex = this.text27;
                    File.WriteAllBytes(text2 + "\\" + text, Form1.StringToByteArray(hex));
                    bool flag2 = true;
                    if (flag)
                    {
                        if (flag2)
                        {
                            MessageBox.Show("FIX", "FIX has been saved to fixes!");
                        }
                        else
                        {
                            MessageBox.Show("FIX", "Couldn't save Fix!");
                        }
                    }
                    else if (flag2)
                    {
                        MessageBox.Show("RAP", "Rap has been saved to exdata!");
                    }
                    else
                    {
                        MessageBox.Show("rap", "Couldn't save Rap!");
                    }
                }
                catch
                {

                    MessageBox.Show("Warning", "No rap/fix available!");
                }
            }

        }

        private static byte[] StringToByteArray(string hex)
        {
            return (from x in Enumerable.Range(0, hex.Length)
                    where x % 2 == 0
                    select Convert.ToByte(hex.Substring(x, 2), 16)).ToArray<byte>();
        }

        private void create_rap(int idx)
        {
            try
            {
                string text = this.text27.Trim();
                if (text.Length != 0)
                {
                    int num = text.IndexOf('/');
                    if (-1 != num)
                    {
                        text = text.Substring(num);
                    }
                    num = text.IndexOf('\\');
                    if (-1 != num)
                    {
                        text = text.Substring(num);
                    }
                    string text2;
                    if (text.Length == 0 || text.EndsWith(".rap", StringComparison.OrdinalIgnoreCase))
                    {
                        text2 = AppDomain.CurrentDomain.BaseDirectory + "\\exdata";
                    }
                    else
                    {
                        text2 = AppDomain.CurrentDomain.BaseDirectory + "\\fixes";
                    }
                    if (!Directory.Exists(text2))
                    {
                        Directory.CreateDirectory(text2);
                    }
                    try
                    {
                        string hex = this.text27;
                        File.WriteAllBytes(text2 + "\\" + text, Form1.StringToByteArray(hex));
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }

        private void MetroButton41_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = "PS3 XML |*.xml";
            OpenFileDialog1.FilterIndex = 1;
            List<string> newlist = new List<string>();
            if (OpenFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string STR = System.IO.File.ReadAllText(OpenFileDialog1.FileName);

                string STRFirst = "<Table Key";

                string STRLast = "</Table>";

                string FinalString;



                try
                {
                    int Pos1 = STR.IndexOf(STRFirst) + STRFirst.Length;

                    int Pos2 = STR.IndexOf(STRLast);

                    FinalString = STR.Substring(Pos1, Pos2 - Pos1);

                    listBox10.Items.Add(FinalString);
                }
                catch (Exception)
                {

                }
            }
        }
            }
    }


