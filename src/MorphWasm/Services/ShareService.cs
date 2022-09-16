using MorphShared.Services;
using TextCopy;

namespace MorphWasm.Services
{
    public class ShareService : IShareService
    {
        public async Task ShareContent(string content)
        {
            await ClipboardService.SetTextAsync(content);
        }
    }
}