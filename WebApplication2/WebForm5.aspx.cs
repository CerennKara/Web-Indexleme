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
    public class Sites1
    {
        public float rate;
        public String name;
        public int deep;
    }
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public float findRate(string k, List<string> arrw1)
        {
            try
            {
                float f;
                Uri url2 = new Uri(k);
                WebClient client2 = new WebClient();
                string html2 = client2.DownloadString(url2);
                HtmlAgilityPack.HtmlDocument doc2 = new HtmlAgilityPack.HtmlDocument();
                doc2.LoadHtml(html2);
                HtmlNodeCollection titles2 = doc2.DocumentNode.SelectNodes("//body");
                if (titles2 != null)
                {
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
                    int a = 1;
                    foreach (string s in arrw1)
                    {
                        int sayac = 0;
                        for (int i = 0; i < words2.Length; i++)
                        {
                            if (words2[i] == s)
                            {
                                sayac++;
                            }
                        }
                        if (sayac != 0)
                        {
                            a *= sayac;
                        }
                    }
                    f = ((float)a / (float)words2.Length);
                    return f;
                }

            }
            catch (Exception)
            {
                //lbl4.Text += "Hata";
            }
            return -1;

        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            string urlS = url5.Text;
            urlS = Regex.Replace(urlS, @"\t|\n|\r", " ");
            string[] links;
            string[] links21;
            links = urlS.Split(' ');
            links21 = urlS.Split(' ');
            int say = 0;
            lbl5.Text = " ";
            List<string> list1 = new List<string>();
            List<string> links2 = new List<string>();
            foreach (string k in links)
            {
                if (k.Contains("http"))
                {
                    say++;
                    //lbl5.Text += say + ". Link: <br/>";
                    Uri url = new Uri(k);
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
                    Str = Str.Replace("#", "").Replace("â", "").Replace("€", "").Replace("™", "").Replace("^", "");
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
                    foreach (string s in l)
                    {
                        if (!stopWords.Contains(s))
                        {
                            filter.Add(s);
                        }
                        else
                        {

                        }
                    }
                    List<string> arrw = new List<string>();
                    List<int> arrt = new List<int>();
                    foreach (string s in filter)
                    {
                        int sayac = 0;
                        for (int i = 0; i < words.Length; i++)
                        {
                            if (words[i] == s)
                            {
                                sayac++;
                            }
                        }
                        arrw.Add(s);
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
                    List<string> keys = new List<string>();
                    for (int i = 1; i < 7; i++)
                    {
                        keys.Add(arrayw[i]);
                        //list1.Add(arrayw[i]);
                    }
                    foreach (string s in keys)
                    {

                        string syn = "http://www.synonymy.com/synonym.php?word=" + s;

                        if (syn != "http://www.synonymy.com/synonym.php?word=")
                        {
                            Uri url1 = new Uri(syn);
                            WebClient client1 = new WebClient();
                            string html1 = client1.DownloadString(url1);
                            HtmlAgilityPack.HtmlDocument doc1 = new HtmlAgilityPack.HtmlDocument();
                            doc1.LoadHtml(html1);
                            HtmlNodeCollection titles1 = doc1.DocumentNode.SelectNodes("/html/body/div[2]/div[4]/div[2]");
                            string Str1 = " ";
                            foreach (var title in titles1)
                            {
                                string link = title.InnerText;
                                Str1 += link;
                            }
                            if (Str1.Contains("name") | Str1.Contains("adjective") | Str1.Contains("verb") | Str1.Contains("adverb"))
                            {
                                Str1 = Str1.Replace("name", "").Replace("adjective", "").Replace("verb", "").Replace("adverb", "");
                                lbl5.Text += s + " -> " + Str1 + " <br/><br/>";
                                string[] words3 = Str1.Split(',');
                                for (int x = 0; x < words3.Length; x++)
                                {
                                    list1.Add(words3[x]);
                                }
                            }
                        }
                    }
                    lbl5.Text += "<br/>";
                }
            }
            int say1 = 0;
            foreach (string k in links21)
            {
                say1 = 0;
                if (k.Contains("http"))
                {
                    Uri url = new Uri(k);
                    HtmlWeb hw = new HtmlWeb();
                    var doc1 = new HtmlWeb().Load(url);
                    var linkTags = doc1.DocumentNode.Descendants("link");
                    var linkedPages = doc1.DocumentNode.Descendants("a")
                                                      .Select(a => a.GetAttributeValue("href", null))
                                                      .Where(u => !String.IsNullOrEmpty(u));
                    foreach (var link in linkedPages)
                    {
                        if (link.Contains("www") & link.Contains("http") & say1 != 5)
                        {
                            //links2.Add(link);
                            lbl5.Text += link + "'teki alakalı kelimeler:<br/>";
                            Uri url2 = new Uri(k);
                            WebClient client2 = new WebClient();
                            string html2 = client2.DownloadString(url2);
                            HtmlAgilityPack.HtmlDocument doc2 = new HtmlAgilityPack.HtmlDocument();
                            doc2.LoadHtml(html2);
                            HtmlNodeCollection titles2 = doc2.DocumentNode.SelectNodes("//body");
                            string Str = " ";
                            foreach (var title in titles2)
                            {
                                string link2 = title.InnerText;
                                Str += link2;
                            }

                            string[] words;
                            List<string> l = new List<string>();
                            Str = Str.ToLower();
                            Str = Str.Replace("#", "").Replace("â", "").Replace("€", "").Replace("™", "").Replace("^", "");
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
                            say1++;
                            foreach (string q in l)
                            {
                                if (list1.Contains(q))
                                {
                                    lbl5.Text += q + " ";
                                }
                            }
                            lbl5.Text += "<br/>";
                        }
                    }
                }
            }
        }
    }
}