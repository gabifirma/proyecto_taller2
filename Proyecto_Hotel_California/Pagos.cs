using HotelCalifornia.Models;
using HotelCalifornia.Services;
using HotelCalifornia.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static HotelCalifornia.ModeloFactura;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Font = iTextSharp.text.Font;

namespace HotelCalifornia
{
    public partial class Pagos : BaseResponsiveForm
    {
        public Pagos()
        {
            InitializeComponent();
            CargarPagos();
        }

        private void CargarPagos()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                string query = @"SELECT 
                    p.id_pago,
                    p.fecha,
                    p.monto,
                    p.referencia + p.id_pago AS Referencia,
                    mp.descripcion AS metodoPago
                    FROM Pago p
                    INNER JOIN MetodoPago mp ON p.id_metodoPago = mp.id_metodoPago
                    ORDER BY p.id_pago ASC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GrillaPagos.AutoGenerateColumns = false;
                GrillaPagos.DataSource = dt;
            }

            if (!GrillaPagos.Columns.Contains("Factura"))
            {
                DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
                btnCol.Name = "Factura";
                btnCol.HeaderText = "Factura";
                btnCol.Text = "Ver / Imprimir";
                btnCol.UseColumnTextForButtonValue = true;
                btnCol.FillWeight = 45;
                GrillaPagos.Columns.Add(btnCol);
            }
        }

        private void Pagos_Load(object sender, EventArgs e)
        {
            CargarPagos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();

                // Construimos la consulta base
                string query = @"SELECT 
                    p.id_pago,
                    p.fecha,
                    p.monto,
                    p.referencia + p.id_pago AS Referencia,
                    mp.descripcion AS metodoPago
                    FROM Pago p
                    INNER JOIN MetodoPago mp ON p.id_metodoPago = mp.id_metodoPago
                    WHERE 1=1";

                // Creamos el comando
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                // Filtro por fechas
                if (DTDesde.Value <= DTHasta.Value) // rango de fechas
                {
                    query += " AND p.fecha BETWEEN @desde AND @hasta";
                    cmd.Parameters.AddWithValue("@desde", DTDesde.Value.Date);
                    cmd.Parameters.AddWithValue("@hasta", DTHasta.Value.Date.AddDays(1).AddSeconds(-1)); // incluye el día completo
                }
                else
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.", "Error de fechas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Filtro por referencia
                if (!string.IsNullOrEmpty(TReferencia.Text))
                {
                    query += " AND p.referencia LIKE @referencia";
                    cmd.Parameters.AddWithValue("@referencia", "%" + TReferencia.Text.Trim() + "%");
                }

                // Filtro por método de pago
                if (RBEfectivo.Checked)
                {
                    query += " AND p.id_metodoPago = 1";
                } 
                else if (RBTrans.Checked)
                {
                    query += " AND p.id_metodoPago = 2";
                }
                else if (RBCredito.Checked)
                {
                    query += " AND p.id_metodoPago = 3";
                }

                // Aplicamos la consulta final
                query += " ORDER BY p.fecha DESC";
                cmd.CommandText = query;

                // Llenamos el DataTable y lo mostramos
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);



                GrillaPagos.DataSource = dt;
            }
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            TReferencia.Clear();
            DTDesde.Value = DateTime.Now;
            DTHasta.Value = DateTime.Now;
            CargarPagos();
        }

        private void GrillaPagos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Funcionalidad para doble clic en la grilla
            if (e.RowIndex >= 0) // para evitar encabezados
            {
                // Obtener el valor de la columna ID de la fila seleccionada
                int idPago = Convert.ToInt32(GrillaPagos.Rows[e.RowIndex].Cells["id_pago"].Value);

                // Abrir el formulario de edición y pasarle el Id
                DetallesPago frm = new DetallesPago(idPago);
                frm.ShowDialog();

                // refrescar el DataGridView después de editar
                CargarPagos();
            }
        }

        private FacturaCompleta ObtenerFacturaCompleta(int idFactura)
        {
            var datos = new FacturaCompleta();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();

                // FACTURA PRINCIPAL
                string qFactura = @"
                        SELECT 
                            f.numero,
                            f.fecha_emision,
                            c.nombre + ' ' + c.apellido AS Cliente,
                            c.dni,
                            c.email,
                            mp.descripcion AS metodoPago,
                            f.total,
                            r.id_reserva
                        FROM Factura f
                        INNER JOIN Reserva r ON f.id_reserva = r.id_reserva
                        INNER JOIN Cliente c ON r.id_cliente = c.id_cliente
                        INNER JOIN Pago p ON f.id_pago = p.id_pago
                        INNER JOIN MetodoPago mp ON p.id_metodoPago = mp.id_metodoPago
                        WHERE f.id_factura = @idFactura";

                using (SqlCommand cmd = new SqlCommand(qFactura, conn))
                {
                    cmd.Parameters.AddWithValue("@idFactura", idFactura);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        datos.Factura = new FacturaData
                        {
                            Numero = rd["numero"].ToString(),
                            FechaEmision = Convert.ToDateTime(rd["fecha_emision"]),
                            Cliente = rd["Cliente"].ToString(),
                            DNI = rd["dni"].ToString(),
                            Email = rd["email"].ToString(),
                            MetodoPago = rd["metodoPago"].ToString(),
                            Total = Convert.ToDecimal(rd["total"])
                        };
                        datos.Factura.Numero = rd["numero"].ToString();
                    }
                    rd.Close();
                }

                if (datos.Factura == null) return null;

                // DETALLES DE HABITACIONES
                string qHab = @"
                        SELECT 
                            h.numero_hab AS Habitacion,
                            th.nombre AS TipoHabitacion,
                            DATEDIFF(day, r.fecha_inicio, r.fecha_fin) AS Noches,
                            th.base_precio AS PrecioPorNoche,
                            DATEDIFF(day, r.fecha_inicio, r.fecha_fin) * th.base_precio AS Subtotal
                        FROM Reserva r
                        INNER JOIN ReservaHabitacion rh ON r.id_reserva = rh.id_reserva
                        INNER JOIN Habitacion h ON rh.numero_hab = h.numero_hab
                        INNER JOIN TipoHabitacion th ON h.id_tipo = th.id_tipo
                        INNER JOIN Factura f ON f.id_reserva = r.id_reserva
                        WHERE f.id_factura = @idFactura";

                using (SqlCommand cmd = new SqlCommand(qHab, conn))
                {
                    cmd.Parameters.AddWithValue("@idFactura", idFactura);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        datos.Habitaciones.Add(new DetalleReserva
                        {
                            Habitacion = rd["Habitacion"].ToString(),
                            TipoHabitacion = rd["TipoHabitacion"].ToString(),
                            Noches = Convert.ToInt32(rd["Noches"]),
                            PrecioPorNoche = Convert.ToDecimal(rd["PrecioPorNoche"]),
                            Subtotal = Convert.ToDecimal(rd["Subtotal"])
                        });
                    }
                    rd.Close();
                }

                // DETALLES DE SERVICIOS (si aplica)
                string qServ = @"
                        SELECT 
                            s.nombre AS Servicio,
                            s.precio_base AS Precio
                        FROM Servicio s
                        INNER JOIN ReservaServicio rs ON s.id_servicio = rs.id_servicio
                        INNER JOIN Reserva r ON rs.id_reserva = r.id_reserva
                        INNER JOIN Factura f ON f.id_reserva = r.id_reserva
                        WHERE f.id_factura = @idFactura";

                using (SqlCommand cmd = new SqlCommand(qServ, conn))
                {
                    cmd.Parameters.AddWithValue("@idFactura", idFactura);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        datos.Servicios.Add(new DetalleServicio
                        {
                            Servicio = rd["Servicio"].ToString(),
                            Precio = Convert.ToDecimal(rd["Precio"])
                        });
                    }
                }
            }

            return datos;
        }

        private void GenerarFacturaPDF_iTextSharp(FacturaCompleta datos)
        {
            var f = datos.Factura;

            // 1. Crear el objeto Document (tamaño A4, márgenes)
            // Document(float marginLeft, float marginRight, float marginTop, float marginBottom)
            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4, 40, 40, 40, 40);

            try
            {
                // 2. Definir la ruta de destino (igual que tu código original)
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Factura_{f.Numero}.pdf");

                // 3. Crear el escritor PDF
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
                doc.Open(); // Abrir el documento para empezar a escribir

                // 4. Crear el objeto BaseFont para Helvetica
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                // 5. Definir las fuentes usando el BaseFont (el primer argumento del constructor Font)
                iTextSharp.text.Font fontTitulo = new iTextSharp.text.Font(bf, 20f, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontEncabezado = new iTextSharp.text.Font(bf, 13f, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(bf, 11f, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font fontBold = new iTextSharp.text.Font(bf, 11f, iTextSharp.text.Font.BOLD);

                // --- ENCABEZADO ---
                doc.Add(new Paragraph("HOTEL CALIFORNIA", fontTitulo) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph($"Factura Nº {f.Numero}", fontEncabezado) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph($"Fecha de emisión: {f.FechaEmision:dd/MM/yyyy}", fontNormal) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph("\n")); // Salto de línea

                // --- DATOS DEL CLIENTE ---
                doc.Add(new Paragraph("Datos del Cliente:", fontBold));
                doc.Add(new Paragraph($"Nombre: {f.Cliente}", fontNormal));
                doc.Add(new Paragraph($"DNI: {f.DNI}", fontNormal));
                doc.Add(new Paragraph($"Email: {f.Email}", fontNormal));
                doc.Add(new Paragraph($"Método de Pago: {f.MetodoPago}", fontNormal));
                doc.Add(new Paragraph("\n"));

                // --- TABLA DE HABITACIONES ---
                if (datos.Habitaciones.Any())
                {
                    doc.Add(new Paragraph("Habitaciones:", fontBold));

                    // Crear tabla con 5 columnas
                    PdfPTable tableHab = new PdfPTable(5);
                    tableHab.WidthPercentage = 100; // Ancho total
                                                    // Anchos relativos de las columnas (ajusta según necesites)
                    float[] widthsHab = new float[] { 80f, 160f, 60f, 80f, 80f };
                    tableHab.SetWidths(widthsHab);

                    // Agregar encabezados de tabla
                    AddCellToTable(tableHab, "Habitación", fontBold, true);
                    AddCellToTable(tableHab, "Tipo", fontBold, true);
                    AddCellToTable(tableHab, "Noches", fontBold, true);
                    AddCellToTable(tableHab, "Precio/Noche", fontBold, true);
                    AddCellToTable(tableHab, "Subtotal", fontBold, true);

                    // Agregar filas de datos
                    foreach (var h in datos.Habitaciones)
                    {
                        AddCellToTable(tableHab, h.Habitacion, fontNormal);
                        AddCellToTable(tableHab, h.TipoHabitacion, fontNormal);
                        AddCellToTable(tableHab, h.Noches.ToString(), fontNormal, false, Element.ALIGN_RIGHT);
                        AddCellToTable(tableHab, $"${h.PrecioPorNoche:N2}", fontNormal, false, Element.ALIGN_RIGHT);
                        AddCellToTable(tableHab, $"${h.Subtotal:N2}", fontNormal, false, Element.ALIGN_RIGHT);
                    }

                    doc.Add(tableHab);
                    doc.Add(new Paragraph("\n"));
                }

                // --- TABLA DE SERVICIOS ---
                if (datos.Servicios.Any())
                {
                    doc.Add(new Paragraph("Servicios:", fontBold));

                    // Crear tabla con 2 columnas
                    PdfPTable tableServ = new PdfPTable(2);
                    tableServ.WidthPercentage = 100;
                    float[] widthsServ = new float[] { 300f, 100f };
                    tableServ.SetWidths(widthsServ);

                    // Agregar encabezados de tabla
                    AddCellToTable(tableServ, "Servicio", fontBold, true);
                    AddCellToTable(tableServ, "Precio", fontBold, true);

                    // Agregar filas de datos
                    foreach (var s in datos.Servicios)
                    {
                        AddCellToTable(tableServ, s.Servicio, fontNormal);
                        AddCellToTable(tableServ, $"${s.Precio:N2}", fontNormal, false, Element.ALIGN_RIGHT);
                    }

                    doc.Add(tableServ);
                    doc.Add(new Paragraph("\n"));
                }

                // --- TOTAL ---
                Paragraph pTotal = new Paragraph($"TOTAL: ${f.Total:N2}", fontEncabezado) { Alignment = Element.ALIGN_RIGHT };
                doc.Add(pTotal);
                doc.Add(new Paragraph("\n"));


                // --- PIE DE PÁGINA (en iTextSharp se maneja diferente al Document.Add) ---
                // Puedes agregar un evento de página para el pie, pero por simplicidad lo agregamos al final del contenido.
                doc.Add(new Paragraph("Gracias por elegir Hotel California", fontNormal) { Alignment = Element.ALIGN_CENTER });


                // 4. Cerrar el documento
                doc.Close();

                MessageBox.Show($"Factura generada en el escritorio:\n{path}", "PDF generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (doc.IsOpen())
                {
                    doc.Close();
                }
            }
        }

        // Método auxiliar para agregar celdas a la tabla de forma consistente
        private void AddCellToTable(PdfPTable table, string text, Font font, bool isHeader = false, int alignment = Element.ALIGN_LEFT)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.Padding = 5;
            cell.BorderWidth = 0.5f;
            cell.BorderColor = BaseColor.LIGHT_GRAY;
            cell.HorizontalAlignment = alignment;

            if (isHeader)
            {
                // Color de fondo para encabezados si lo deseas
                // cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            }

            table.AddCell(cell);
        }

        private void GrillaPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evitamos errores si se hace clic fuera de los botones
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Verificamos si la columna clickeada es la de acción
            if (GrillaPagos.Columns[e.ColumnIndex].Name == "Factura")
            {
                int idPago = Convert.ToInt32(GrillaPagos.Rows[e.RowIndex].Cells["id_pago"].Value);

                // Buscamos el id_factura asociado a este pago
                int idFactura = ObtenerIdFacturaPorPago(idPago);

                if (idFactura == 0)
                {
                    MessageBox.Show("No se encontró ninguna factura asociada a este pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var facturaCompleta = ObtenerFacturaCompleta(idFactura);

                DialogResult result = MessageBox.Show(
                    $"¿Desea imprimir la factura?",
                    "Confirmar acción",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    if (facturaCompleta != null)
                    {
                        // GenerarFacturaPDF(facturaCompleta);
                        GenerarFacturaPDF_iTextSharp(facturaCompleta);
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron datos para la factura seleccionada.");
                    }                        
                }
            }
        }

        private int ObtenerIdFacturaPorPago(int idPago)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();
                string query = "SELECT id_factura FROM Factura WHERE id_pago = @idPago";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idPago", idPago);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        return Convert.ToInt32(result);
                }
            }
            return 0;
        }
    }
}
