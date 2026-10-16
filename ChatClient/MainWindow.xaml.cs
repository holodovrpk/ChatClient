using System.IO;
using System.Net.Sockets;
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

        TcpClient client;
        NetworkStream stream;

        StreamReader reader;
        StreamWriter writer;

        public MainWindow()
        {
            InitializeComponent();
        }

        

        async private void Connect_Click(object sender, RoutedEventArgs e)
        {
            // Логика подключения к серверу
            string name = NameTextBox.Text;
            string server = ServerTextBox.Text;
            int port = Convert.ToInt32(PortTextBox.Text);


            // Создаём TCP-клиента — это объект, который подключается к серверу по IP и порту.
            client = new TcpClient();

            // Асинхронно подключаемся к серверу (без блокировки основного потока).
            // В данном примере подключаемся к localhost (127.0.0.1) и порту 5000.
            await client.ConnectAsync(server, port);

            ChatListBox.Items.Add("✅ Подключено к серверу");

            // Получаем поток данных, через который клиент будет общаться с сервером.
            stream = client.GetStream();

            // Оборачиваем поток в StreamReader и StreamWriter для удобной работы со строками.
            reader = new StreamReader(stream, Encoding.UTF8);
            writer = new StreamWriter(stream, Encoding.UTF8)
            {
                // AutoFlush = true — каждое сообщение будет сразу отправлено, без буферизации.
                AutoFlush = true
            };



            // Пример добавления системного сообщения
            //AddSystemMessage($"Подключено к серверу {server}:{port}");
        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {
            // Логика отключения
            //AddSystemMessage("Отключено от сервера.");
        }

        async private void Send_Click(object sender, RoutedEventArgs e)
        {
            string msg = MessageTextBox.Text;
            await writer.WriteLineAsync(msg);
        }
    }
}