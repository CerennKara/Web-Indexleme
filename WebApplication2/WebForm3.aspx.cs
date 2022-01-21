using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using HtmlAgilityPack;
using System.IO;
using System.Text.RegularExpressions;

namespace WebApplication2
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string urla = url31.Text;
            Uri url1 = new Uri(urla);
            WebClient client = new WebClient();
            string html = client.DownloadString(url1);
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
                if (!l.Contains(words[i]))
                {
                    l.Add(words[i]);
                }
            }
            HashSet<string> stopWords = new HashSet<string>(File.ReadLines("C:\\stop_words.txt"), StringComparer.OrdinalIgnoreCase);
            List<string> filter = new List<string>();
            lbl3.Text = "1. Url Anahtar Kelimeleri:<br />";
            foreach (string k in l)
            {
                if (!stopWords.Contains(k))
                {
                    filter.Add(k);
                }
                else
                {

                }
            }
            List<string> arrw = new List<string>();
            List<int> arrt = new List<int>();
            foreach (string k in filter)
            {
                int sayac = 0;
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] == k)
                    {
                        sayac++;
                    }
                }
                arrw.Add(k);
                arrt.Add(sayac);
            }
            string[] arrayw = arrw.ToArray();
            int[] arrayt = arrt.ToArray();
            int temp;
            string strtemp;
            for (int i = 0; i < arrayt.Length; i++)
            {
                for (int j = 0; j < arrayt.Length - 1; j++)
                {
                    if (arrayt[j] < arrayt[j + 1])
                    {
                        temp = arrayt[j];
                        arrayt[j] = arrayt[j + 1];
                        arrayt[j + 1] = temp;
                        strtemp = arrayw[j];
                        arrayw[j] = arrayw[j + 1];
                        arrayw[j + 1] = strtemp;
                    }
                }
            }
            for (int i = 1; i < 6; i++)
            {
                lbl3.Text += arrayw[i] + "-->" + arrayt[i] + "  ";
            }
            List<string> arrw1 = new List<string>();
            for (int i = 1; i < 7; i++)
            {
                arrw1.Add(arrayw[i]);
            }

            //2. url çekme:
            string urlb = url32.Text;
            if (urlb != "")
            {
                lbl3.Text += "<br /><br />";
                lbl3.Text += "1. Urldeki anahtar kelimelerin 2. Urlde gecme sayilari:<br />";
                Uri url2 = new Uri(urlb);
                WebClient client2 = new WebClient();
                string html2 = client2.DownloadString(url2);
                HtmlAgilityPack.HtmlDocument doc2 = new HtmlAgilityPack.HtmlDocument();
                doc2.LoadHtml(html2);
                HtmlNodeCollection titles2 = doc2.DocumentNode.SelectNodes("//body");
                string Str2 = " ";
                foreach (var title in titles2)
                {
                    string link = title.InnerText;
                    Str2 += link;
                }


                string[] words2;
                Str2 = Str2.ToLower();
                Str2 = Str2.Replace("ı", "").Replace("#", "").Replace("â", "").Replace("€", "").Replace("™", "").Replace("^", "");
                Str2 = Regex.Replace(Str2, @"\t|\n|\r", " ");
                Str2 = Regex.Replace(Str2, "[0-9]{2,}", "*");
                Str2 = Regex.Replace(Str2, @"\p{P}", " ");
                words2 = Str2.Split(' ');
                int f = 1;
                for (int j = 0; j < 5; j++)
                {
                    int sayac = 0;
                    for (int i = 0; i < words2.Length; i++)
                    {
                        if (Equals(words2[i], arrw1[j]))
                        {
                            sayac++;
                        }
                    }
                    lbl3.Text += arrw1[j];
                    lbl3.Text += " ->";
                    lbl3.Text += sayac;
                    lbl3.Text += "\t";
                    if (sayac != 0)
                    {
                        f *= sayac;
                    }
                }
                
                lbl3.Text += "<br /><br />";
                lbl3.Text += "  Oran: " + ((float)f / (float)words2.Length);
            }
        }
    }
}