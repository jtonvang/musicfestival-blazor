using EPiServer.Core;

namespace MusicFestival.Blazor.Epi.Models.Preview
{
    public class BlockEditPageViewModel
    {
        public BlockEditPageViewModel(PageData page, IContent content)
        {
            PreviewBlock = new PreviewBlock(page, content);
        }

        public PreviewBlock PreviewBlock { get; }
    }
}