public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // scegli cosa vedere:
        // Login o POS diretto
        DataContext = new POSViewModel();
    }
}
