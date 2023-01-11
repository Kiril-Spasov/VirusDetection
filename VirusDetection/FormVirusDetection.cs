using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirusDetection
{
    public partial class FormVirusDetection : Form
    {
        public FormVirusDetection()
        {
            InitializeComponent();
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            string line = "";

            string path = Application.StartupPath + @"\virus.txt";
            StreamReader streamReader = new StreamReader(path);

            bool finished = false;

            while (!finished)
            {
                line = streamReader.ReadLine();

                if (line == null)
                {
                    finished = true;
                }
                else
                {
                    if (CheckForVirus(line))
                    {
                        TxtResult.Text += line + " has occurance of the string - virus" + Environment.NewLine;
                    }
                }
            }
        }

        private bool CheckForVirus(string input)
        {
            string character;
            bool hasVirus = true;
            string word = "virus";
            int index = 0;
            int count = 0;

            string toLower = input.ToLower();

            while (count < word.Length)
            {
                index = toLower.IndexOf(word[count]);

                if (index == -1)
                {
                    hasVirus = false;
                    break;
                }
                else
                {
                    toLower = toLower.Substring(index + 1);
                    count++;
                }
            }
            return hasVirus;
        }
    }
}
