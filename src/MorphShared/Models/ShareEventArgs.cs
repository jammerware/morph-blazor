namespace MorphShared.Models
{
    public class ShareEventArgs
    {
        public string Content { get; private set; }

        public ShareEventArgs(string content)
        {
            this.Content = content;
        }
    }
}
