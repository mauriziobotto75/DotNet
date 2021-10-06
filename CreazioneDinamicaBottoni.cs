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
