using MorphShared.Services;

namespace MorphMaui.Services
{
    internal class ShareService : IShareService
    {
        public async Task ShareContent(string content)
        {
            await Share.Default.RequestAsync(new ShareTextRequest
            {
                Text = content,
                Title = "Share text"
            });

        }
    }
}
