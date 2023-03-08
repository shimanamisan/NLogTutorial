using NLog;
using System;
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

        private async void LogOutput(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                StartLoopInfoLog();
            });
        }

        private void LogExceptionOutput(object sender, RoutedEventArgs e)
        {
            try
            {
                var num = 0;
                // 0による除算で例外を発生させる
                var sum = 1 / num;
            }
            catch (Exception ex)
            {
                // 以下はerrorフォルダに出力される
                _logger.Warn("Warnを一回出力します: {0}", ex.Message);
                _logger.Error("Errorを一回出力します: {0}", ex.Message);
                _logger.Fatal("Fatalを一回出力します: {0}", ex.Message);

                MessageBox.Show("エラーが発生しました。");
            }
        }

        private void LogRotationStop(object sender, RoutedEventArgs e)
        {
            _isLogStop = false;

            MessageBox.Show("ループ処理を停止しました。");
        }

        private async void StartLoopInfoLog()
        {
            _isLogStop = true;

            while (_isLogStop)
            {
                // 以下はinfoフォルダに出力される
                _logger.Debug("Debugを一回出力します");
                _logger.Info("Infoを一回出力します");

                // 以下はerrorフォルダに出力される
                _logger.Warn("Warnを一回出力します");
                _logger.Error("Errorを一回出力します");
                _logger.Fatal("Fatalを一回出力します");

                await Task.Delay(0);
            }
        }
    }
}
