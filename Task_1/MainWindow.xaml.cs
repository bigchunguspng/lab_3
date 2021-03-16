using System.Windows;

namespace Task_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly Model _model;
        
        public MainWindow()
        {
            InitializeComponent();
            _model = new Model();
            _model.UpdateTimerText += () => { TimerTextBlock.Text = _model.TimerText; };
        }

        private void Play_OnClick(object sender, RoutedEventArgs e) => _model.Start();

        private void Stop_OnClick(object sender, RoutedEventArgs e) => _model.Stop();

        private void Reset_OnClick(object sender, RoutedEventArgs e) => _model.Reset();
    }
}