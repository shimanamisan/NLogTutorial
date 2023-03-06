using NLog;
using System.Threading.Tasks;
using System.Windows;

namespace NLogTutorial
{

    public partial class MainWindow : Window
    {
        static Logger _logger = LogManager.GetCurrentClassLogger();

        private bool _isLogStop = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Log_Output(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                StartLoopInfoLog();
            });
        }

        private void Log_Exception(object sender, RoutedEventArgs e)
        {
            _isLogStop = true;

            StartLoopErrorLog();
        }

        private void Log_Rotation(object sender, RoutedEventArgs e)
        {
            _isLogStop = false;

            MessageBox.Show("ループ処理を停止しました。");
        }

        private async void StartLoopInfoLog()
        {
            _isLogStop = true;

            while (_isLogStop)
            {
                _logger.Info("Infoを一回出力します");
                _logger.Warn("Warnを一回出力します");
                _logger.Error("Errorを一回出力します");
                _logger.Fatal("Fatalを一回出力します");

                await Task.Delay(0);
            }
        }

        private async void StartLoopErrorLog()
        {
            _isLogStop = true;

            while (_isLogStop)
            {
                _logger.Info("Infoを一回出力します");
                _logger.Warn("Warnを一回出力します");
                _logger.Error("Errorを一回出力します");
                _logger.Fatal("Fatalを一回出力します");

                await Task.Delay(0);
            }
        }
    }
}
