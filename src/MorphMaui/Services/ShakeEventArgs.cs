namespace MorphMaui.Services
{
    internal class ShakeEventArgs
    {
        internal DateTime EventTime { get; private set; }

        internal ShakeEventArgs(DateTime eventTime)
        {
            EventTime = eventTime;
        }
    }
}
