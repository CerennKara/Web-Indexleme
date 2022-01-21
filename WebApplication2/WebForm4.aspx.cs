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
    public class Sites
    {
        public float rate;
        public String name;
        public int deep;
        public int word1;
        public int word2;
        public int word3;
        public int word4;
        public int word5;
    }
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public int[] findTimes(string k, List<string> arrw1)
        {
            int[] arr = new int[6];
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
                Str2 = Str2.Replace(",", "").Replace(":", "").Replace(".", "").Replace(";", "").Replace("[", "").Replace("]", "").Replace("!", "").Replace("(", "").Replace(")", "").Replace("\"", " ").Replace("/", "");
                Str2 = Regex.Replace(Str2, @"\t|\n|\r", " ");
                Str2 = Regex.Replace(Str2, "[0-9]{2,}", "*");
                Str2 = Regex.Replace(Str2, @"\p{P}", " ");
                words2 = Str2.Split(' ');
                int j = 0;
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
                    arr[j] = sayac;
                    j++;
                }
            }
            return arr;
        }
        public float findRate(string k, List<string> arrw1, int[] arrayt)
        {
            try
            {
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
                    Str2 = Str2.Replace(",", "").Replace(":", "").Replace(".", "").Replace(";", "").Replace("[", "").Replace("]", "").Replace("!", "").Replace("(", "").Replace(")", "").Replace("\"", " ").Replace("/", "");
                    Str2 = Regex.Replace(Str2, @"\t|\n|\r", " ");
                    Str2 = Regex.Replace(Str2, "[0-9]{2,}", "*");
                    Str2 = Regex.Replace(Str2, @"\p{P}", " ");
                    words2 = Str2.Split(' ');
                    int f = 0;
                    int sayx = 1;
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
                            f += 20 * sayac / arrayt[sayx];
                        } sayx++;
                    }
                    return f;
                }

            }
            catch (Exception)
            {
                //lbl4.Text += "Hata";
            }
            return -1;

        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            string urla = url41.Text;
            Uri url1 = new Uri(urla);
            WebClient client = new WebClient();
            string html = client.DownloadString(url1);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            HtmlNodeCollection titles = doc.DocumentNode.SelectNodes("//body");
            string Str = " ";
            lbl4.Text = " ";
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
            List<string> arrw1 = new List<string>();
            for (int i = 1; i < 7; i++)
            {
                arrw1.Add(arrayw[i]);
            }
            string urlS = url42.Text;
            urlS = Regex.Replace(urlS, @"\t|\n|\r", " ");
            string[] links;
            links = urlS.Split(' ');
            List<string> links1 = new List<string>();
            List<Sites> links2 = new List<Sites>();
            List<Sites> links3 = new List<Sites>();
            int say = 0;
            foreach (string k in links)
            {
                say = 0;
                if (k.Contains("http"))
                {
                    Sites s = new Sites();
                    s.name = k;
                    s.deep = 1;
                    s.rate = findRate(k, arrw1, arrayt);
                    int[] arrs = findTimes(k, arrw1);
                    for (int q = 0; q < 5; q++)
                    {
                        if (q == 0)
                        {
                            s.word1 = arrs[q];
                        }
                        if (q == 1)
                        {
                            s.word2 = arrs[q];
                        }
                        if (q == 2)
                        {
                            s.word3 = arrs[q];
                        }
                        if (q == 3)
                        {
                            s.word4 = arrs[q];
                        }
                        if (q == 4)
                        {
                            s.word5 = arrs[q];
                        }
                    }
                    links3.Add(s);
                    links2.Add(s);
                    Uri url = new Uri(k);
                    HtmlWeb hw = new HtmlWeb();
                    var doc1 = new HtmlWeb().Load(url);
                    var linkTags = doc1.DocumentNode.Descendants("link");
                    var linkedPages = doc1.DocumentNode.Descendants("a")
                                                      .Select(a => a.GetAttributeValue("href", null))
                                                      .Where(u => !String.IsNullOrEmpty(u));
                    foreach (var link in linkedPages)
                    {
                        //lbl4.Text += link;
                        /*  string d="http://";
                          if (!link.Contains("http") & !link.Contains("www"))
                          {
                              string m = k.Replace("http://", "").Replace("https://", "");

                              for(int x = 0; x < m.Length; x++)
                              {

                                  if (m[x].Equals('/'))
                                  {
                                      index = x;
                                      break;
                                  }
                              }
                              m = m.Substring(0, index);
                               d += m;
                              d += link;
                              if (findRate(d, arrw1) != -1)
                              {
                                  Sites y = new Sites();
                                  y.name = d;
                                  y.deep = 2;
                                  y.rate = findRate(d, arrw1);
                                  links2.Add(y);
                                  links1.Add(d);
                              }
                          }
                          else if (link.Contains("www") & !link.Contains("http"))
                          {
                              string m = link.Replace("//", "");
                              d += m;
                              if (findRate(d, arrw1) != -1)
                              {
                                  Sites y = new Sites();
                                  y.name = d;
                                  y.deep = 2;
                                  y.rate = findRate(d, arrw1);
                                  links2.Add(y);
                                  links1.Add(d);
                              }
                          }*/
                        if (link.Contains("www") & link.Contains("http") & say != 5)
                        {
                            if (findRate(link, arrw1, arrayt) != -1)
                            {
                                Sites y = new Sites();
                                y.name = link;
                                y.deep = 2;
                                y.rate = findRate(link, arrw1, arrayt);
                                int[] arrs1 = findTimes(k, arrw1);
                                for (int q = 0; q < 5; q++)
                                {
                                    if (q == 0)
                                    {
                                        y.word1 = arrs1[q];
                                    }
                                    if (q == 1)
                                    {
                                        y.word2 = arrs1[q];
                                    }
                                    if (q == 2)
                                    {
                                        y.word3 = arrs1[q];
                                    }
                                    if (q == 3)
                                    {
                                        y.word4 = arrs1[q];
                                    }
                                    if (q == 4)
                                    {
                                        y.word5 = arrs1[q];
                                    }
                                }
                                links2.Add(y);
                                links1.Add(link);
                                say++;
                            }
                        }
                    }
                }
            }
            foreach (string k in links1)
            {
                Sites y1 = new Sites();
                y1.name = k;
                y1.deep = 2;
                links3.Add(y1);
                say = 0;
                Sites s = new Sites();
                Uri url = new Uri(k);
                HtmlWeb hw = new HtmlWeb();
                var doc1 = new HtmlWeb().Load(url);
                var linkTags = doc1.DocumentNode.Descendants("link");
                var linkedPages = doc1.DocumentNode.Descendants("a")
                                                  .Select(a => a.GetAttributeValue("href", null))
                                                  .Where(u => !String.IsNullOrEmpty(u));
                foreach (var link in linkedPages)
                {
                    // string d = "http://";
                    /*if (!link.Contains("http") & !link.Contains("www"))
                    {
                        string m = k.Replace("http://", "").Replace("https://", "");


                        for (int x = 0; x < m.Length; x++)
                        {

                            if (m[x].Equals('/'))
                            {
                                index = x;
                                break;
                            }
                        }
                        m = m.Substring(0, index);
                        d += m;
                        d += link;
                        if (findRate(d, arrw1) != -1)
                        {
                            Sites y = new Sites();
                            y.name = d;
                            y.deep = 3;
                            y.rate = findRate(d, arrw1);
                            links2.Add(y);
                        }
                    }
                    else if (link.Contains("www") & !link.Contains("http"))
                    {
                        string m = link.Replace("//", "");
                        d += m;
                        if (findRate(d, arrw1) != -1)
                        {
                            Sites y = new Sites();
                            y.name = d;
                            y.deep = 3;
                            y.rate = findRate(d, arrw1);
                            links2.Add(y);
                        }
                    }*/
                    if (link.Contains("www") & link.Contains("http") & say != 5)
                    {
                        if (findRate(link, arrw1, arrayt) != -1)
                        {
                            Sites y = new Sites();
                            y.name = link;
                            y.deep = 3;
                            y.rate = findRate(link, arrw1, arrayt);
                            int[] arrs1 = findTimes(k, arrw1);
                            for (int q = 0; q < 5; q++)
                            {
                                if (q == 0)
                                {
                                    y.word1 = arrs1[q];
                                }
                                if (q == 1)
                                {
                                    y.word2 = arrs1[q];
                                }
                                if (q == 2)
                                {
                                    y.word3 = arrs1[q];
                                }
                                if (q == 3)
                                {
                                    y.word4 = arrs1[q];
                                }
                                if (q == 4)
                                {
                                    y.word5 = arrs1[q];
                                }
                            }
                            links2.Add(y);
                            links3.Add(y);
                            say++;
                        }
                    }
                }
            }
            links2 = links2.OrderBy(x => x.rate).Reverse().ToList();
            foreach (Sites t in links2)
            {
                lbl4.Text += t.name + " -> " + t.deep + " -> " + t.rate + "<br/>";
                for (int i = 1; i < 6; i++)
                {
                    if (i == 0)
                    {
                        lbl4.Text += arrw1[0] + "->" + t.word1 + "kere,";
                    }
                    if (i == 1)
                    {
                        lbl4.Text += arrw1[1] + "-> " + t.word2 + "kere, ";
                    }
                    if (i == 2)
                    {
                        lbl4.Text += arrw1[2] + "-> " + t.word3 + "kere, ";
                    }
                    if (i == 3)
                    {
                        lbl4.Text += arrw1[3] + "-> " + t.word4 + "kere, ";
                    }
                    if (i == 4)
                    {
                        lbl4.Text += arrw1[4] + "-> " + t.word5 + "kere<br/>";
                    }
                }
            }
            lbl4.Text += "<br/><br/><br/><br/>";
            foreach (Sites t in links3)
            {
                if (t.deep == 1)
                {
                    lbl4.Text += t.name + "<br/>";
                }
                if (t.deep == 2)
                {
                    lbl4.Text += "---------->" + t.name + "<br/>";
                }
                if (t.deep == 3)
                {
                    lbl4.Text += "--------------------------------->" + t.name + "<br/>";
                }
            }
        }
    }
}