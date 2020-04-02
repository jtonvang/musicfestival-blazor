using System.Collections.Generic;

namespace MusicFestival.Blazor.Template.ViewModels
{
    public class PageBaseViewModel : ContentBaseViewModel
    {
        public string Url { get; set; }
        public PageLinkViewModel ParentLink { get; set; }
        public IEnumerable<LanguageViewModel> ExistingLanguages {get;set;}

        public LanguageViewModel Language { get; set; }
    }
}
