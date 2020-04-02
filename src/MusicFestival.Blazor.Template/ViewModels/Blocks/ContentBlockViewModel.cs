using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicFestival.Blazor.Template.ViewModels.Blocks
{
    public class ContentBlockViewModel : BlockBaseViewModel
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string ImageAlignment { get; set; }
        public string Content { get; set; }
    }
}
