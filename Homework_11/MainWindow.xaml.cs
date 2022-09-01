

using System.Windows.Controls;

namespace Homework_11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository repository = new Repository(100);

        public MainWindow()
        {
            InitializeComponent();

            ListOfClient.ItemsSource = repository.clients;
            
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            repository.clients.Remove((Client)ListOfClient.SelectedItem);
        }

        private void Button_Change_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            PasswordWindow passwordWindow = new PasswordWindow();
           

            if (passwordWindow.ShowDialog() == true)
            {
                
                    MessageBox.Show("Авторизация пройдена");
               
            }
            else
            {
                MessageBox.Show("Авторизация не пройдена");
            }
        }
    }
    
}
