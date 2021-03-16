using System;
using System.Windows.Threading;

namespace Task_1
{
    public class Model
    {
        private DispatcherTimer _timer;
        private DateTime _start, _end;
        private TimeSpan _extra;
        
        private bool NoRunningTimer => _timer == null || (bool) !_timer?.IsEnabled;
        private TimeSpan CuttoffDuration => _timer.IsEnabled ? DateTime.Now - _start : _end - _start;
        public string TimerText => (CuttoffDuration + _extra).ToString("d\\.hh\\:mm\\:ss\\.fff");

        public delegate void Update();

        public event Update UpdateTimerText;
        private void OnTimerOnTick(object sender, EventArgs args) => UpdateTimerText?.Invoke();

        public void Start()
        {
            _start = DateTime.Now;
            if (NoRunningTimer)
            {
                _timer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0, 0, 35)};
                _timer.Tick += OnTimerOnTick;
            }
            else
                Reset();

            _timer.Start();
        }

        public void Stop()
        {
            if (NoRunningTimer) return;
            
            _end = DateTime.Now;
            _timer?.Stop();
            _extra += _end - _start;
            _start = _end;
            UpdateTimerText?.Invoke();
        }

        public void Reset()
        {
            if (_timer == null) return;
            
            _start = DateTime.Now;
            _end = _start;
            _extra = TimeSpan.Zero;
            UpdateTimerText?.Invoke();
        }
    }
}