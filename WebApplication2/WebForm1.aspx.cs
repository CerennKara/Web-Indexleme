using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Net;
using HtmlAgilityPack;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string urla = url1.Text;
            Uri url = new Uri(urla);
            WebClient client = new WebClient();
            string html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            HtmlNodeCollection titles = doc.DocumentNode.SelectNodes("//body");
            string Str = " ";
            foreach (var title in titles)
            {
                string link = title.InnerText;
                Str += link;
            }


            string[] words;
            List<string> l = new List<string>();
            Str = Str.ToLower();
            Str = Str.Replace("ı", "").Replace("#", "").Replace("â", "").Replace("€", "").Replace("™", "").Replace("^", "");
            Str = Regex.Replace(Str, @"\t|\n|\r", " ");
            Str = Regex.Replace(Str, "[0-9]{2,}", "*");
            Str = Regex.Replace(Str, @"\p{P}", " ");
            words = Str.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (l.Contains(words[i]) == false)
                {
                    l.Add(words[i]);
                }
            }
            foreach (string k in l)
            {
                int sayac = 0;
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] == k)
                    {
                        sayac++;
                    }
                }
                lbl.Text += k;
                lbl.Text += " ->";
                lbl.Text += sayac;
                lbl.Text += "<br/>";
            }
        }
    }
}