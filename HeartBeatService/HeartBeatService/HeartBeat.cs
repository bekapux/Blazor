using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
namespace HeartBeatService
{
    public class HeartBeat
    {
        private readonly System.Timers.Timer _timer;
        public HeartBeat()
        {
            _timer = new System.Timers.Timer(1000) { AutoReset = true };
            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            var toast = new ToastNotification(new XmlDocument());
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
