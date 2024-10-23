using System.Windows;

namespace MessagesSent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int day = 1;
        private int totalMessages = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            int messages;
            if (int.TryParse(MessagesInput.Text, out messages) && messages >= 0 && messages <= 10000)
            {
                totalMessages += messages;
                MessagesDisplay.Text += $"Day {day}: {messages} messages\n";
                day++;

                if (day > 7)
                {
                    double average = totalMessages / 7.0;
                    AverageLabel.Content = $"Average: {average:F1} messages";
                    MessagesInput.IsEnabled = false;
                    EnterButton.IsEnabled = false;
                }
                else
                {
                    DayLabel.Content = $"Day {day}";
                    MessagesInput.Clear();
                    MessagesInput.Focus();
                }
            }
            else
            {
                MessageBox.Show("Enter a number between 0 and 10000");
                MessagesInput.Focus();
            }
        } 

    } 
}
