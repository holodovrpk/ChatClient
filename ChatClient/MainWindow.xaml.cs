using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            // Логика подключения к серверу
            string name = NameTextBox.Text;
            string server = ServerTextBox.Text;
            string port = PortTextBox.Text;

            // Пример добавления системного сообщения
            //AddSystemMessage($"Подключено к серверу {server}:{port}");
        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {
            // Логика отключения
            //AddSystemMessage("Отключено от сервера.");
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}