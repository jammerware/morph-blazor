namespace MorphShared.Models
{
    public class ClipboardEventArgs
    {
        public string Content { get; private set; }

        internal ClipboardEventArgs(string content)
        {
            Content = content;
        }
    }
}
