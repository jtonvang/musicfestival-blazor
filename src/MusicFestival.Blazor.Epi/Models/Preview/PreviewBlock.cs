using EPiServer.Core;

namespace MusicFestival.Blazor.Epi.Models.Preview
{
    public class PreviewBlock : PageData
    {
        public IContent PreviewContent { get; }

        public PreviewBlock(PageData currentPage, IContent previewContent)
            : base(currentPage)
        {
            PreviewContent = previewContent;
        }
    }
}