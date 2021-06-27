using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Nail.Core;
using Nail.Core.Net;

namespace Zen.Update
{
    public partial class Form2 : Form
    {
        public const string WorkPath = "updates";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            var file = Fetch.Get(textBox1.Text);
            if (file == null)
            {
                Log.Write("Fetch failed.");
                return;
            }
            var info = new FileInfo(Path.Combine(WorkPath, "Download.file"));
            Directory.CreateDirectory(info.DirectoryName);
            File.WriteAllBytes(info.FullName, file);
            */
            string url = textBox1.Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string html = reader.ReadToEnd();
                    Regex regex = new Regex(GetDirectoryListingRegexForUrl(url));
                    MatchCollection matches = regex.Matches(html);
                    if (matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            if (match.Success)
                            {
                                Console.WriteLine(match.Groups["name"]);
                            }
                        }
                    }
                }
            }

        }
        public  string GetDirectoryListingRegexForUrl(string url)
        {
            return "<a href=\".*\">(?<name>.*)</a>";

            //if (url.Equals("http://www.ibiblio.org/pub/"))
            //{
            //    return "<a href=\".*\">(?<name>.*)</a>";
            //}
            //throw new NotSupportedException();
        }
    }
}
