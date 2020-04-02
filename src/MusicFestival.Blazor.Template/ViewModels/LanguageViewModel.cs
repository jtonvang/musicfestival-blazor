using System;

namespace MusicFestival.Blazor.Template.ViewModels
{
    public class LanguageViewModel
    {
        private string _link;
        public string Link
        {
            get
            {
                return ToRelative(_link);
            }
            set
            {
                _link = value;
            }
        }

        public string DisplayName { get; set; }
        public string Name { get; set; }

        private string ToRelative(string link)
        {
            var uri = new Uri(link);

            return uri.IsAbsoluteUri ? uri.PathAndQuery : uri.OriginalString;

        }
    }
}
