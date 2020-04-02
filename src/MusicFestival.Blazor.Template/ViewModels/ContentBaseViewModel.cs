using MusicFestival.Blazor.Template.Helpers;
using System;

namespace MusicFestival.Blazor.Template.ViewModels
{
    public class ContentBaseViewModel
    {
        public string[] ContentType { get; set; }
        public string Name { get; set; }

        public Type GetContentType()
        {
            return ContentTypeHelper.ResolveContentType(ContentType);
        }

    }
}
