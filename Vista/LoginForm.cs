using DomestikReservas.Login;

private void btnIngresar_Click(object sender, EventArgs e)
{
    string usuario = txtUsuario.Text;
    string contraseña = txtContraseña.Text;

    var loginService = new LoginService();

    if (loginService.ValidarLogin(usuario, contraseña))
    {
        MainForm main = new MainForm();
        main.Show();
        this.Hide();  // Oculta el login
    }
    else
    {
        MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtContraseña.Clear();
        txtUsuario.Focus();
    }
}
