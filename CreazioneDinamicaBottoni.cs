private void CreaBottone()
{
    Button btn = new Button();
    btn.BackColor = System.Drawing.Color.Azure;
    btn.Text = "Ciao Mondo";
    btn.Top = 50;
    btn.Left = 50;
    btn.Click += new System.EventHandler(this.btn_Click);                                   //Registro l'evento 
    Controls.Add (btn);
}

private void btn_Click(object sender, EventArgs e)
{
    ComboBox cmb = new ComboBox();
    cmb.BackColor = System.Drawing.Color.White;
    cmb.Top = 50;
    cmb.Left = 150;
    cmb.Items.Add("Alessandro");
    cmb.Items.Add("Andrea");
    cmb.Items.Add("Massimo");
    cmb.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);     //Registro l'evento
    Controls.Add (cmb);
}
private void cmb_SelectedIndexChanged(object sender, EventArgs e)
{
    MessageBox.Show(((ComboBox)sender).SelectedItem.ToString(),"Messaggio");
}
protected EventHandler OnClickHandler = new EventHandler(OnClick);

btnUno.Click += OnClickHandler;
btnDue.Click += OnClickHandler;
btnTre.Click += OnClickHandler;
public static void OnClick(object sender,EventArgs e)
{
    if (sender is Button)
    {
        {Button btnClick=(Button)sender;
        switch(btnClick.Name)
        {
            case "btnUno":
                //Codice da gestire per il bottone
                break;
            case "btnDue":
                //Codice da gestire per il bottone
                break;
            case "btnTre":
                //Codice da gestire per il bottone
                break;
        }
    }
}
