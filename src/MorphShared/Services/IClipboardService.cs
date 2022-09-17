namespace MorphShared.Services
{
    public interface IClipboardService
    {
        public Task Copy(string content);
    }
}
