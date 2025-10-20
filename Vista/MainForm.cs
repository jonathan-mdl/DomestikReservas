using DomestikReservas.Datos;
using DomestikReservas.Negocio;

private List<Vuelo> listaVuelos = new List<Vuelo>();
private VueloService vueloService = new VueloService();

private PasajeroController pasajeroController = new PasajeroController();

private void btnAgregarPasajero_Click(object sender, EventArgs e)
{
    Pasajero p = new Pasajero(
        txtRut.Text,
        txtNombre.Text,
        txtApellido.Text,
        cmbTipo.SelectedItem?.ToString() ?? "Normal",
        0
    );

    if (pasajeroController.AgregarPasajero(p))
    {
        MessageBox.Show("Pasajero agregado correctamente");
        dgvPasajeros.DataSource = pasajeroController.ObtenerTodosPasajeros();
    }
    else
    {
        MessageBox.Show("Error al agregar pasajero");
    }

    txtRut.Clear();
    txtNombre.Clear();
    txtApellido.Clear();
    cmbTipo.SelectedIndex = -1;
}

private VueloController vueloController = new VueloController();

private void btnAgregarVuelo_Click(object sender, EventArgs e)
{
    string numVlo = txtNumVuelo.Text;
    DateTime fecha = dtpFechaVuelo.Value;
    TimeSpan hora;

    if (!TimeSpan.TryParse(txtHoraVuelo.Text, out hora))
    {
        MessageBox.Show("Hora inválida.");
        return;
    }

    string destino = txtDestino.Text;

    Vuelo v = new Vuelo(numVlo, fecha, hora, destino);

    if (vueloController.AgregarVuelo(v))
    {
        MessageBox.Show("Vuelo agregado correctamente");
        dgvVuelos.DataSource = vueloController.ObtenerTodosVuelos();
    }
    else
    {
        MessageBox.Show("Error al agregar vuelo");
    }

    txtNumVuelo.Clear();
    txtDestino.Clear();
    txtHoraVuelo.Clear();
    dtpFechaVuelo.Value = DateTime.Today;
}


private ReservaController reservaController = new ReservaController();

private void btnCrearReserva_Click(object sender, EventArgs e)
{
    string codigo = txtCodigoReserva.Text;
    string tipo = cmbTipoReserva.SelectedItem?.ToString() ?? "Económica";
    string rut = txtRutReserva.Text;
    string numVlo = txtNumVloReserva.Text;

    double valor = new ReservaService().CalcularCosto(tipo);
    string tipoPasajero = "Frecuente"; // Simulado por ahora
    int puntaje = new ReservaService().CalcularPuntaje(tipo, tipoPasajero);

    Reserva r = new Reserva(codigo, tipo, valor, rut, numVlo);

    if (reservaController.AgregarReserva(r))
    {
        MessageBox.Show("Reserva agregada correctamente");
        dgvReservas.DataSource = reservaController.ObtenerReservasConDetalle();
    }
    else
    {
        MessageBox.Show("Error al agregar reserva");
    }

    txtCodigoReserva.Clear();
    txtRutReserva.Clear();
    txtNumVloReserva.Clear();
    cmbTipoReserva.SelectedIndex = -1;
}

private void btnModificarFecha_Click(object sender, EventArgs e)
{
    if (dgvReservas.SelectedRows.Count == 0)
    {
        MessageBox.Show("Selecciona una reserva");
        return;
    }

    string numVlo = dgvReservas.SelectedRows[0].Cells["numVlo"].Value.ToString();
    DateTime nuevaFecha = dtpNuevaFecha.Value;

    if (vueloController.ModificarFechaVuelo(numVlo, nuevaFecha))
    {
        MessageBox.Show("Fecha de vuelo modificada con éxito");
        dgvReservas.DataSource = reservaController.ObtenerReservasConDetalle();
    }
    else
    {
        MessageBox.Show("Error al modificar la fecha");
    }
}

