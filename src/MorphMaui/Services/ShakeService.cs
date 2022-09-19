namespace MorphMaui.Services
{
    internal class ShakeService : IDisposable
    {
        internal EventHandler<ShakeEventArgs> ShakeDetected;

        private ShakeService() { }

        internal static ShakeService Start()
        {
            var service = new ShakeService();

            if (Accelerometer.Default.IsSupported)
            {
                Accelerometer.Default.ShakeDetected += service.OnShakeDetected;
                Accelerometer.Default.Start(SensorSpeed.UI);
            }

            return service;
        }

        private void OnShakeDetected(object sender, EventArgs e)
        {
            ShakeDetected?.Invoke(sender, new ShakeEventArgs(DateTime.UtcNow));
        }

        public void Dispose() => Accelerometer.ShakeDetected -= OnShakeDetected;
    }
}
