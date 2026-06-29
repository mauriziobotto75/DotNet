using System.Windows.Controls;

public partial class ClienteView : UserControl
{
    public ClienteView()
    {
        InitializeComponent();
        DataContext = new ClienteViewModel();
    }
}
