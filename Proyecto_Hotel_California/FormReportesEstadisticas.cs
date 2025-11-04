using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HotelCalifornia
{
 public partial class FormReportesEstadisticas : Form
 {
 private Chart chartEstadisticas;

 public FormReportesEstadisticas()
 {
 InitializeComponent();
 InicializarFormulario();
 }

 private void InicializarFormulario()
 {
 try
 {
 // Configurar fechas por defecto
 dtpFechaDesdeReservas.Value = DateTime.Now.AddMonths(-1);
 dtpFechaHastaReservas.Value = DateTime.Now;
 dtpFechaDesdeePagos.Value = DateTime.Now.AddMonths(-1);
 dtpFechaHastaPagos.Value = DateTime.Now;

 // Cargar combo de estados
 DataTable dtEstados = DatabaseHelper.GetEstadosReserva();
 dtEstados.Rows.InsertAt(dtEstados.NewRow(),0);
 dtEstados.Rows[0]["id_estado"] = DBNull.Value;
 dtEstados.Rows[0]["nombre"] = "Todos";

 cmbEstadoReserva.DataSource = dtEstados;
 cmbEstadoReserva.DisplayMember = "nombre";
 cmbEstadoReserva.ValueMember = "id_estado";
 cmbEstadoReserva.SelectedIndex =0;

 // Cargar combo de métodos de pago
 DataTable dtMetodos = DatabaseHelper.GetMetodosPago();
 cmbMetodoPago.DataSource = dtMetodos;
 cmbMetodoPago.DisplayMember = "metodo";
 cmbMetodoPago.ValueMember = "metodo";
 cmbMetodoPago.SelectedIndex =0;

 // Configurar año para estadísticas
 numAño.Value = DateTime.Now.Year;
 numAño.Minimum =2020;
 numAño.Maximum =2099;

 // Seleccionar primera pestaña
 tabControl.SelectedIndex =0;

 // Deshabilitar fechas inicialmente
 dtpFechaDesdeReservas.Enabled = false;
 dtpFechaHastaReservas.Enabled = false;
 dtpFechaDesdeePagos.Enabled = false;
 dtpFechaHastaPagos.Enabled = false;
 }
 catch (Exception ex)
 {
 MessageBox.Show($"Error al inicializar formulario: {ex.Message}",
 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
 }
 }

 // Helper para leer valor de DataRow probando varios nombres de columna
 private string GetRowString(DataRow row, params string[] posiblesNombres)
 {
 // Primero intentar con los nombres proporcionados
 foreach (var nombre in posiblesNombres)
 {
 if (string.IsNullOrEmpty(nombre)) continue;
 if (row.Table.Columns.Contains(nombre) && row[nombre] != DBNull.Value)
 return row[nombre].ToString();
 }

 // Si no encontramos, buscar por coincidencia parcial ignorando acentos y caracteres especiales
 string[] palabrasClave = { "metodo", "método", "m?todo", "method" };
 foreach (DataColumn col in row.Table.Columns)
 {
 string colNameLower = col.ColumnName.ToLower().Replace("é", "e").Replace("?", "e");
 foreach (string palabra in palabrasClave)
 {
 if (colNameLower.Contains(palabra.ToLower()))
 {
 if (row[col.ColumnName] != DBNull.Value)
 return row[col.ColumnName].ToString();
 }
 }
 }

 return string.Empty;
 }

 // ============================================
 // PESTAÑA: REPORTES DE RESERVAS
 // ============================================

 private void chkFiltrarFechasReservas_CheckedChanged(object sender, EventArgs e)
 {
 dtpFechaDesdeReservas.Enabled = chkFiltrarFechasReservas.Checked;
 dtpFechaHastaReservas.Enabled = chkFiltrarFechasReservas.Checked;
 }

 private void btnBuscarReservas_Click(object sender, EventArgs e)
 {
 try
 {
 // Validar fechas si el filtro está activo
 if (chkFiltrarFechasReservas.Checked)
 {
 if (dtpFechaDesdeReservas.Value > dtpFechaHastaReservas.Value)
 {
 MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.",
 "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
 return;
 }
 }

 Cursor = Cursors.WaitCursor;
 btnBuscarReservas.Enabled = false;

 // Preparar filtros
 DateTime? fechaDesde = chkFiltrarFechasReservas.Checked ?
 (DateTime?)dtpFechaDesdeReservas.Value : null;
 DateTime? fechaHasta = chkFiltrarFechasReservas.Checked ?
 (DateTime?)dtpFechaHastaReservas.Value : null;
 int? idEstado = cmbEstadoReserva.SelectedValue != DBNull.Value ?
 (int?)cmbEstadoReserva.SelectedValue : null;
 string busqueda = string.IsNullOrWhiteSpace(txtBusquedaReservas.Text) ?
 null : txtBusquedaReservas.Text.Trim();

 // Obtener datos
 DataTable datos = DatabaseHelper.GetReporteReservas(
 fechaDesde, fechaHasta, idEstado, busqueda);

 // Mostrar en DataGridView
 dgvReporteReservas.DataSource = datos;

 // Configurar formato de columnas
 if (dgvReporteReservas.Columns.Count >0)
 {
 dgvReporteReservas.Columns["ID"].Width =60;
 dgvReporteReservas.Columns["Cliente"].Width =150;
 dgvReporteReservas.Columns["DNI"].Width =100;
 dgvReporteReservas.Columns["Fecha Inicio"].DefaultCellStyle.Format = "dd/MM/yyyy";
 dgvReporteReservas.Columns["Fecha Fin"].DefaultCellStyle.Format = "dd/MM/yyyy";
 dgvReporteReservas.Columns["Total"].DefaultCellStyle.Format = "C2";
 dgvReporteReservas.Columns["Total"].DefaultCellStyle.Alignment =
 DataGridViewContentAlignment.MiddleRight;
 }

 // Calcular totales
 decimal totalIngresos =0;
 foreach (DataRow row in datos.Rows)
 {
 if (row["Total"] != DBNull.Value)
 totalIngresos += Convert.ToDecimal(row["Total"]);
 }

 lblTotalRegistrosReservas.Text = $"Total de registros: {datos.Rows.Count}";
 lblTotalIngresosReservas.Text = $"Total ingresos: {totalIngresos:C2}";
 }
 catch (Exception ex)
 {
 MessageBox.Show($"Error al buscar reservas: {ex.Message}",
 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
 }
 finally
 {
 Cursor = Cursors.Default;
 btnBuscarReservas.Enabled = true;
 }
 }

 private void btnLimpiarFiltrosReservas_Click(object sender, EventArgs e)
 {
 txtBusquedaReservas.Clear();
 cmbEstadoReserva.SelectedIndex =0;
 chkFiltrarFechasReservas.Checked = false;
 dtpFechaDesdeReservas.Value = DateTime.Now.AddMonths(-1);
 dtpFechaHastaReservas.Value = DateTime.Now;
 dgvReporteReservas.DataSource = null;
 lblTotalRegistrosReservas.Text = "Total de registros:0";
 lblTotalIngresosReservas.Text = "Total ingresos: $0.00";
 }

 private void btnExportarReservas_Click(object sender, EventArgs e)
 {
 if (dgvReporteReservas.DataSource == null || dgvReporteReservas.Rows.Count ==0)
 {
 MessageBox.Show("No hay datos para exportar. Primero realice una búsqueda.",
 "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
 return;
 }

 DataTable datos = (DataTable)dgvReporteReservas.DataSource;
 ExportacionHelper.ExportarConDialogo(datos, "Reporte_Reservas");
 }

 // ============================================
 // PESTAÑA: REPORTES DE PAGOS
 // ============================================

 private void chkFiltrarFechasPagos_CheckedChanged(object sender, EventArgs e)
 {
 dtpFechaDesdeePagos.Enabled = chkFiltrarFechasPagos.Checked;
 dtpFechaHastaPagos.Enabled = chkFiltrarFechasPagos.Checked;
 }

 private void btnBuscarPagos_Click(object sender, EventArgs e)
 {
 try
 {
 if (chkFiltrarFechasPagos.Checked)
 {
 if (dtpFechaDesdeePagos.Value > dtpFechaHastaPagos.Value)
 {
 MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.",
 "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
 return;
 }
 }

 Cursor = Cursors.WaitCursor;
 btnBuscarPagos.Enabled = false;

 DateTime? fechaDesde = chkFiltrarFechasPagos.Checked ?
 (DateTime?)dtpFechaDesdeePagos.Value : null;
 DateTime? fechaHasta = chkFiltrarFechasPagos.Checked ?
 (DateTime?)dtpFechaHastaPagos.Value : null;

 // Obtener el método de pago correctamente
 string metodoPago = null;
 if (cmbMetodoPago.SelectedValue != null)
 {
 string metodo = cmbMetodoPago.SelectedValue.ToString();
 if (metodo != "Todos")
 {
 metodoPago = metodo;
 }
 }

 string busqueda = string.IsNullOrWhiteSpace(txtBusquedaPagos.Text) ?
 null : txtBusquedaPagos.Text.Trim();

 DataTable datos = DatabaseHelper.GetReportePagos(
 fechaDesde, fechaHasta, metodoPago, busqueda);

        // DIAGNÓSTICO: Mostrar los nombres de columnas que vienen de la BD
        System.Diagnostics.Debug.WriteLine($"=== DIAGNÓSTICO PAGOS - COLUMNAS ===");
        foreach (DataColumn col in datos.Columns)
        {
       System.Diagnostics.Debug.WriteLine($"Columna: '{col.ColumnName}' (bytes: {string.Join(",", System.Text.Encoding.Default.GetBytes(col.ColumnName))})");
        }
        System.Diagnostics.Debug.WriteLine("====================================");

  dgvReportePagos.DataSource = datos;

  if (dgvReportePagos.Columns.Count >0)
  {
   dgvReportePagos.Columns["ID Pago"].Width =70;
   dgvReportePagos.Columns["Reserva"].Width =70;
   dgvReportePagos.Columns["Cliente"].Width =150;
   dgvReportePagos.Columns["Monto"].DefaultCellStyle.Format = "C2";
   dgvReportePagos.Columns["Monto"].DefaultCellStyle.Alignment =
    DataGridViewContentAlignment.MiddleRight;
   dgvReportePagos.Columns["Fecha Pago"].DefaultCellStyle.Format = "dd/MM/yyyy";
  }

  // Calcular totales por método
  decimal totalEfectivo =0;
  decimal totalTarjeta =0;
  decimal totalTransferencia =0;

  foreach (DataRow row in datos.Rows)
  {
   if (row["Monto"] != DBNull.Value)
{
    decimal monto = Convert.ToDecimal(row["Monto"]);
    // CORREGIDO: Usar directamente el nuevo nombre de columna sin caracteres especiales
    string metodo = row["MetodoPago"].ToString();
       
    // DIAGNÓSTICO: Ver qué valor se está obteniendo
   System.Diagnostics.Debug.WriteLine($"Método encontrado: '{metodo}'");

    if (metodo.Contains("Efectivo"))
    {
     totalEfectivo += monto;
    }
    else if (metodo.Contains("Tarjeta"))
    {
     totalTarjeta += monto;
    }
    else if (metodo.Contains("Transferencia"))
    {
     totalTransferencia += monto;
    }
   }
  }

  decimal totalGeneral = totalEfectivo + totalTarjeta + totalTransferencia;

  lblTotalRegistrosPagos.Text = $"Total: {datos.Rows.Count} pagos";
  lblTotalesPagos.Text = $"Efectivo: {totalEfectivo:C2} | " +
   $"Tarjeta: {totalTarjeta:C2} | " +
   $"Transfer.: {totalTransferencia:C2} | " +
   $"TOTAL: {totalGeneral:C2}";
 }
 catch (Exception ex)
 {
  MessageBox.Show($"Error al buscar pagos: {ex.Message}",
   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
 }
 finally
 {
  Cursor = Cursors.Default;
  btnBuscarPagos.Enabled = true;
 }
 }

 private void btnLimpiarFiltrosPagos_Click(object sender, EventArgs e)
 {
 txtBusquedaPagos.Clear();
 cmbMetodoPago.SelectedIndex =0;
 chkFiltrarFechasPagos.Checked = false;
 dtpFechaDesdeePagos.Value = DateTime.Now.AddMonths(-1);
 dtpFechaHastaPagos.Value = DateTime.Now;
 dgvReportePagos.DataSource = null;
 lblTotalRegistrosPagos.Text = "Total:0 pagos";
 lblTotalesPagos.Text = "Efectivo: $0.00 | Tarjeta: $0.00 | Transfer.: $0.00 | TOTAL: $0.00";
 }

 private void btnExportarPagos_Click(object sender, EventArgs e)
 {
 if (dgvReportePagos.DataSource == null || dgvReportePagos.Rows.Count ==0)
 {
 MessageBox.Show("No hay datos para exportar. Primero realice una búsqueda.",
 "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
 return;
 }

 DataTable datos = (DataTable)dgvReportePagos.DataSource;
 ExportacionHelper.ExportarConDialogo(datos, "Reporte_Pagos");
 }

 // ============================================
 // PESTAÑA: ESTADÍSTICAS
 // ============================================

 private void btnGenerarEstadisticas_Click(object sender, EventArgs e)
 {
 try
 {
 Cursor = Cursors.WaitCursor;
 panelGrafico.Controls.Clear();

 if (rbOcupacion.Checked)
 {
 GenerarGraficoOcupacion();
 }
 else if (rbIngresos.Checked)
 {
 GenerarGraficoIngresos();
 }
 else if (rbPagosPorMetodo.Checked)
 {
 GenerarGraficoPagosPorMetodo();
 }
 else if (rbHabitacionesPopulares.Checked)
 {
 GenerarGraficoHabitacionesPopulares();
 }
 }
 catch (Exception ex)
 {
 MessageBox.Show($"Error al generar estadísticas: {ex.Message}",
 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
 }
 finally
 {
 Cursor = Cursors.Default;
 }
 }

 private void GenerarGraficoOcupacion()
 {
 DataTable datos = DatabaseHelper.GetEstadisticasOcupacion();

 if (datos.Rows.Count ==0)
 {
 MessageBox.Show("No hay datos para mostrar.", "Sin Datos",
 MessageBoxButtons.OK, MessageBoxIcon.Information);
 return;
 }

 chartEstadisticas = new Chart();
 chartEstadisticas.Size = new Size(panelGrafico.Width -20, panelGrafico.Height -20);
 chartEstadisticas.Location = new Point(10,10);
 chartEstadisticas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
 AnchorStyles.Left | AnchorStyles.Right;

 ChartArea area = new ChartArea();
 area.BackColor = Color.White;
 chartEstadisticas.ChartAreas.Add(area);

 Series series = new Series();
 series.ChartType = SeriesChartType.Pie;
 series.IsValueShownAsLabel = true;
 series.Font = new Font("Arial",11, FontStyle.Bold);

 Color[] colores = { Color.FromArgb(76,175,80), Color.FromArgb(255,193,7),
 Color.FromArgb(33,150,243) };
 int colorIndex =0;

 // Calcular el total primero
 double totalCantidad = Convert.ToDouble(datos.Compute("SUM(Cantidad)", ""));

 foreach (DataRow row in datos.Rows)
 {
 string estado = row["Estado"].ToString();
 int cantidad = Convert.ToInt32(row["Cantidad"]);
 DataPoint point = new DataPoint();
 point.SetValueXY(estado, cantidad);
 
 // MEJORA UI/UX: Mostrar solo el porcentaje dentro de la porción
 decimal porcentaje = cantidad * 100.0m / (decimal)totalCantidad;
 point.Label = $"{porcentaje:0.0}%";
 
 // Personalizar el texto de la leyenda con estado y cantidad
 point.LegendText = $"{estado}: {cantidad} reservas";
 
 point.Color = colores[colorIndex % colores.Length];
 series.Points.Add(point);
 colorIndex++;
 }

 chartEstadisticas.Series.Add(series);

 Title title = new Title("Reservas por Estado");
 title.Font = new Font("Arial",16, FontStyle.Bold);
 title.ForeColor = Color.FromArgb(33,33,33);
 chartEstadisticas.Titles.Add(title);

 // MEJORA UI/UX: La leyenda muestra el detalle completo
 Legend legend = new Legend();
 legend.Docking = Docking.Right;
 legend.Font = new Font("Arial",10);
 legend.Title = "Detalle";
 legend.TitleFont = new Font("Arial", 10, FontStyle.Bold);
 chartEstadisticas.Legends.Add(legend);

 panelGrafico.Controls.Add(chartEstadisticas);
 }

 private void GenerarGraficoIngresos()
 {
 int año = (int)numAño.Value;
 DataTable datos = DatabaseHelper.GetEstadisticasIngresosMensuales(año);

 if (datos.Rows.Count ==0)
 {
 MessageBox.Show($"No hay datos para el año {año}.", "Sin Datos",
 MessageBoxButtons.OK, MessageBoxIcon.Information);
 return;
 }

 chartEstadisticas = new Chart();
 chartEstadisticas.Size = new Size(panelGrafico.Width -20, panelGrafico.Height -20);
 chartEstadisticas.Location = new Point(10,10);
 chartEstadisticas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
 AnchorStyles.Left | AnchorStyles.Right;

 ChartArea area = new ChartArea();
 area.BackColor = Color.White;
 
 // MEJORA UI/UX: Eliminar líneas de cuadrícula (grid lines)
 area.AxisX.MajorGrid.Enabled = false;
 area.AxisY.MajorGrid.Enabled = false;
 area.AxisX.MinorGrid.Enabled = false;
 area.AxisY.MinorGrid.Enabled = false;
 
 // MEJORA UI/UX: Eliminar el eje Y (redundante con etiquetas en barras)
 area.AxisY.LineWidth = 0;
 area.AxisY.MajorTickMark.Enabled = false;
 area.AxisY.LabelStyle.Enabled = false;
 
 area.AxisX.Title = "Mes";
 area.AxisX.TitleFont = new Font("Arial",11, FontStyle.Bold);
 chartEstadisticas.ChartAreas.Add(area);

 Series series = new Series();
 series.ChartType = SeriesChartType.Column;
 series.Color = Color.FromArgb(33,150,243);
 
 // MEJORA UI/UX: Mostrar solo el valor sobre la barra
 series.IsValueShownAsLabel = true;
 series.LabelFormat = "${0:N0}";
 series.Font = new Font("Arial",10, FontStyle.Bold);

 foreach (DataRow row in datos.Rows)
 {
 string mes = row["NombreMes"].ToString();
 decimal ingreso = Convert.ToDecimal(row["IngresoTotal"]);
 series.Points.AddXY(mes, ingreso);
 }

 chartEstadisticas.Series.Add(series);

 Title title = new Title($"Ingresos Mensuales - Año {año}");
 title.Font = new Font("Arial",16, FontStyle.Bold);
 title.ForeColor = Color.FromArgb(33,33,33);
 chartEstadisticas.Titles.Add(title);

 panelGrafico.Controls.Add(chartEstadisticas);
 }

 private void GenerarGraficoPagosPorMetodo()
 {
 DataTable datos = DatabaseHelper.GetEstadisticasPagosPorMetodo();

 if (datos.Rows.Count ==0)
 {
 MessageBox.Show("No hay datos de pagos para mostrar.", "Sin Datos",
 MessageBoxButtons.OK, MessageBoxIcon.Information);
 return;
 }

 chartEstadisticas = new Chart();
 chartEstadisticas.Size = new Size(panelGrafico.Width -20, panelGrafico.Height -20);
 chartEstadisticas.Location = new Point(10,10);
 chartEstadisticas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
 AnchorStyles.Left | AnchorStyles.Right;

 ChartArea area = new ChartArea();
 area.BackColor = Color.White;
 chartEstadisticas.ChartAreas.Add(area);

 Series series = new Series();
 series.ChartType = SeriesChartType.Pie;
 series.IsValueShownAsLabel = true;
 series.Font = new Font("Arial",11, FontStyle.Bold);

 Color[] colores = { Color.FromArgb(76,175,80), Color.FromArgb(33,150,243),
 Color.FromArgb(255,152,0) };
 int colorIndex =0;

 decimal totalGeneral =0;
 foreach (DataRow row in datos.Rows)
 {
 totalGeneral += Convert.ToDecimal(row["Total"]);
 }

 foreach (DataRow row in datos.Rows)
 {
  string metodo = row["MetodoPago"].ToString();
  decimal total = Convert.ToDecimal(row["Total"]);
  int cantidad = Convert.ToInt32(row["Cantidad"]);

  DataPoint point = new DataPoint();
  point.SetValueXY(metodo, total);
  
  // MEJORA UI/UX: Mostrar solo el porcentaje dentro de cada porción
  decimal porcentaje = total * 100 / totalGeneral;
  point.Label = $"{porcentaje:0.0}%";
  
  point.Color = colores[colorIndex % colores.Length];
  series.Points.Add(point);
  colorIndex++;
 }

 chartEstadisticas.Series.Add(series);

 Title title = new Title("Pagos por Método");
 title.Font = new Font("Arial",16, FontStyle.Bold);
 title.ForeColor = Color.FromArgb(33,33,33);
 chartEstadisticas.Titles.Add(title);

 // MEJORA UI/UX: La leyenda muestra el detalle completo (método + monto)
 Legend legend = new Legend();
 legend.Docking = Docking.Right;
 legend.Font = new Font("Arial",10);
 
 // Personalizar leyenda para mostrar método y monto
 legend.Title = "Detalle";
 legend.TitleFont = new Font("Arial", 10, FontStyle.Bold);
 
 chartEstadisticas.Legends.Add(legend);
 
 // Agregar información de detalle en la leyenda
 for (int i = 0; i < series.Points.Count; i++)
 {
     DataPoint point = series.Points[i];
     string metodo = datos.Rows[i]["MetodoPago"].ToString();
     decimal total = Convert.ToDecimal(datos.Rows[i]["Total"]);
     
     // Personalizar el texto de la leyenda con método y monto
     point.LegendText = $"{metodo}: ${total:N0}";
 }

 panelGrafico.Controls.Add(chartEstadisticas);
 }

 private void GenerarGraficoHabitacionesPopulares()
 {
 DataTable datos = DatabaseHelper.GetHabitacionesPopulares();

 // DIAGNÓSTICO: Mostrar información detallada de lo que retorna la consulta
 System.Diagnostics.Debug.WriteLine($"=== DIAGNÓSTICO HABITACIONES POPULARES ===");
 System.Diagnostics.Debug.WriteLine($"Filas retornadas: {datos.Rows.Count}");
 System.Diagnostics.Debug.WriteLine($"Columnas: {datos.Columns.Count}");

 if (datos.Columns.Count >0)
 {
 foreach (DataColumn col in datos.Columns)
 {
 System.Diagnostics.Debug.WriteLine($" - Columna: {col.ColumnName} ({col.DataType})");
 }
 }

 if (datos.Rows.Count >0)
 {
 System.Diagnostics.Debug.WriteLine("Datos encontrados:");
 foreach (DataRow row in datos.Rows)
 {
 System.Diagnostics.Debug.WriteLine($" Tipo: {row["Tipo"]}, Reservas: {row["Reservas"]}, Ingresos: {row["Ingresos"]}");
 }
 }
 System.Diagnostics.Debug.WriteLine("==========================================");

 if (datos.Rows.Count ==0)
 {
 MessageBox.Show("No hay tipos de habitaciones configurados en el sistema.\n\n" +
 "Verifique que la tabla TipoHabitacion contenga registros.",
 "Sin Datos",
 MessageBoxButtons.OK, MessageBoxIcon.Warning);
 return;
 }

 chartEstadisticas = new Chart();
 chartEstadisticas.Size = new Size(panelGrafico.Width -20, panelGrafico.Height -20);
 chartEstadisticas.Location = new Point(10,10);
 chartEstadisticas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
 AnchorStyles.Left | AnchorStyles.Right;

 ChartArea area = new ChartArea();
 area.BackColor = Color.White;
 
 // MEJORA UI/UX: Eliminar líneas de cuadrícula
 area.AxisX.MajorGrid.Enabled = false;
 area.AxisY.MajorGrid.Enabled = false;
 area.AxisX.MinorGrid.Enabled = false;
 area.AxisY.MinorGrid.Enabled = false;
 
 area.AxisX.Title = "Tipo de Habitación";
 area.AxisX.TitleFont = new Font("Arial",11, FontStyle.Bold);
 
 chartEstadisticas.ChartAreas.Add(area);

 Series series = new Series();
 series.ChartType = SeriesChartType.Bar;
 series.Color = Color.FromArgb(156,39,176);
 series.IsValueShownAsLabel = true;
 series.Font = new Font("Arial",10, FontStyle.Bold);

 foreach (DataRow row in datos.Rows)
 {
 string tipo = row["Tipo"].ToString();
 int reservas = Convert.ToInt32(row["Reservas"]);
 series.Points.AddXY(tipo, reservas);
 }

 chartEstadisticas.Series.Add(series);

 Title title = new Title("Top 10 Habitaciones Más Reservadas");
 title.Font = new Font("Arial",16, FontStyle.Bold);
 title.ForeColor = Color.FromArgb(33,33,33);
 chartEstadisticas.Titles.Add(title);

 panelGrafico.Controls.Add(chartEstadisticas);
 }

 private void btnExportarGrafico_Click(object sender, EventArgs e)
 {
 if (chartEstadisticas == null)
 {
 MessageBox.Show("Primero genere un gráfico.", "Sin Gráfico",
 MessageBoxButtons.OK, MessageBoxIcon.Warning);
 return;
 }

 SaveFileDialog dialog = new SaveFileDialog();
 dialog.Filter = "Imagen PNG|*.png|Imagen JPEG|*.jpg";
 dialog.FileName = $"Grafico_{DateTime.Now:yyyyMMdd_HHmmss}";
 dialog.Title = "Exportar Gráfico";

 if (dialog.ShowDialog() == DialogResult.OK)
 {
 try
 {
 ChartImageFormat formato = dialog.FilterIndex ==1 ?
 ChartImageFormat.Png : ChartImageFormat.Jpeg;
 chartEstadisticas.SaveImage(dialog.FileName, formato);

 MessageBox.Show("Gráfico exportado exitosamente.", "Éxito",
 MessageBoxButtons.OK, MessageBoxIcon.Information);
 }
 catch (Exception ex)
 {
 MessageBox.Show($"Error al exportar gráfico: {ex.Message}", "Error",
 MessageBoxButtons.OK, MessageBoxIcon.Error);
 }
 }
 }

 private void btnTopClientes_Click(object sender, EventArgs e)
 {
 try
 {
 DataTable datos = DatabaseHelper.GetTopClientes(10);

 if (datos.Rows.Count ==0)
 {
 MessageBox.Show("No hay datos de clientes para mostrar.", "Sin Datos",
 MessageBoxButtons.OK, MessageBoxIcon.Information);
 return;
 }

 Form formTop = new Form();
 formTop.Text = "Top10 Clientes Frecuentes";
 formTop.Size = new Size(700,500);
 formTop.StartPosition = FormStartPosition.CenterParent;
 formTop.MinimizeBox = false;
 formTop.MaximizeBox = false;

 DataGridView dgv = new DataGridView();
 dgv.Dock = DockStyle.Fill;
 dgv.DataSource = datos;
 dgv.ReadOnly = true;
 dgv.AllowUserToAddRows = false;
 dgv.AllowUserToDeleteRows = false;
 dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
 dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

 if (dgv.Columns.Count >0)
 {
 dgv.Columns["Total Gastado"].DefaultCellStyle.Format = "C2";
 dgv.Columns["Total Gastado"].DefaultCellStyle.Alignment =
 DataGridViewContentAlignment.MiddleRight;
 }

 formTop.Controls.Add(dgv);
 formTop.ShowDialog();
 }
 catch (Exception ex)
 {
 MessageBox.Show($"Error al obtener top clientes: {ex.Message}",
 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
 }
 }
 }
}
