using MorphShared.Services;

namespace MorphWasm.Services
{
    public class ShareService : IShareService
    {
        private IClipboardService Clipboard { get; set; }

        public ShareService(IClipboardService clipboard)
        {
            this.Clipboard = clipboard;
        }

        public async Task ShareContent(string content)
        {
            await this.Clipboard.Copy(content);
        }
    }
}