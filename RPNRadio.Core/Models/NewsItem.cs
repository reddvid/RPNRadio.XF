using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;

namespace RPNRadio.Core.Models
{
    public class NewsItem : INotifyPropertyChanged
    {
        public string Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public bool IsVisible => ImageUrls.Count() > 0 ? true : false;

        private List<string> _imageUrls;
        public List<string> ImageUrls
        {
            get { return _imageUrls; }
            set
            {
                _imageUrls = value;
                NotifyPropertyChanged();
            }
        }

        public string FormattedContent => GetAndParseImportantContent(Content);

        private string GetAndParseImportantContent(string content)
        {
            string parsed = content;

            int _start, _end;
            string start = "/>";
            string end = "The post";
            if (content.Contains(start) && content.Contains(end))
            {
                _start = content.IndexOf(start, 0) + start.Length;
                _end = content.IndexOf(end, _start);
                parsed = content.Substring(_start, _end - _start);
            }

            var document = new HtmlDocument();
            document.LoadHtml(parsed);

            //Fetching list of p tags    
            var texts = document.DocumentNode.Descendants("p");
            var paragraphs = new List<string>();
            foreach (var node in texts)
            {
                if (!string.IsNullOrWhiteSpace(node.InnerText))
                {
                    paragraphs.Add(node.InnerText);
                }
            }

            string news = string.Empty;

            foreach (var p in paragraphs)
            {
                news += p;
                news += "\n\n";
            }

            // Get image urls
            var imgUrls = document.DocumentNode.Descendants("img")
                                .Select(e => e.GetAttributeValue("src", null))
                                .Where(s => !String.IsNullOrWhiteSpace(s));

            ImageUrls = new List<string>();
            ImageUrls = imgUrls.ToList();
            if (ImageUrls.Count() > 0)
            {
                ImageUrls.RemoveAt(0);
            }

            return HttpUtility.HtmlDecode(news);
        }

        public string Link { get; set; }
        public string Author { get; set; }
        public string Date { get; set; }
        public string ImagePath { get; set; }
        public string ThumbPath { get; set; }

        public string SubTitle => $"{Author.Replace(" News", string.Empty)}  |  {FormattedDate}";
        public string FormattedDate => DateTime.Parse(Date).ToString("ddd, dd MMM yyyy", CultureInfo.InvariantCulture);

        private string GetImagePath(string text)
        {
            string path = string.Empty;

            int _start, _end;
            string start = "src=\"";
            string end = "\" class=\"";
            if (text.Contains(start) && text.Contains(end))
            {
                _start = text.IndexOf(start, 0) + start.Length;
                _end = text.IndexOf(end, _start);
                path = text.Substring(_start, _end - _start);
            }

            return path;
        }

        public override string ToString()
        {
            return Title;
        }

        #region NOTIFYPROPERTY
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
