using HotelCalifornia.Models;
using HotelCalifornia.Services;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.codec.wmf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HotelCalifornia.ModeloFactura;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Font = iTextSharp.text.Font;
using System.Diagnostics;

namespace HotelCalifornia
{
    public partial class CrearPagoForm : Form
    {
        private int idReserva;

        public CrearPagoForm(int idRes)
        {
            InitializeComponent();
            idReserva = idRes;
            CargarDatosReserva();
        }

        private void CargarDatosReserva()
        {
            // Mostrar los datos básicos en los labels
            LFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            LReserva.Text = idReserva.ToString();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();
                string query = "SELECT total AS Total FROM Reserva WHERE id_reserva = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idReserva);

                object total = cmd.ExecuteScalar();
                if (total != DBNull.Value && total != null)
                    LMonto.Text = Convert.ToDecimal(total).ToString("0.00");
                else
                    LMonto.Text = "0.00";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal monto = Convert.ToDecimal(LMonto.Text);
                int idMetodoPago = ObtenerMetodoPagoSeleccionado();
                int referencia = 10000; // Valor fijo para referencia

                if (idMetodoPago == 0)
                {
                    MessageBox.Show("Seleccione un método de pago.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    conn.Open();
                    SqlTransaction tran = conn.BeginTransaction();

                    try
                    {
                        // Insertar el pago
                        string insertarPago = @"INSERT INTO Pago (fecha, monto, referencia, id_metodoPago, id_reserva)
                        OUTPUT INSERTED.id_pago
                        VALUES (GETDATE(), @monto, @referencia, @metodo, @idReserva)";

                        SqlCommand cmdPago = new SqlCommand(insertarPago, conn, tran);
                        cmdPago.Parameters.AddWithValue("@monto", monto);
                        cmdPago.Parameters.AddWithValue("@metodo", idMetodoPago);
                        cmdPago.Parameters.AddWithValue("@referencia", referencia);
                        cmdPago.Parameters.AddWithValue("@idReserva", idReserva); 
                        int idPago = (int)cmdPago.ExecuteScalar();

                        // Actualizar estado de la reserva a “Confirmada”
                        string updateReserva = "UPDATE Reserva SET id_estado = 1 WHERE id_reserva = @id";
                        SqlCommand cmdUpdate = new SqlCommand(updateReserva, conn, tran);
                        cmdUpdate.Parameters.AddWithValue("@id", idReserva);
                        cmdUpdate.ExecuteNonQuery();                        

                        tran.Commit();
                        MessageBox.Show("Pago registrado y reserva confirmada correctamente.");                       

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Error al registrar el pago: " + ex.Message);
                    }
                }
                String metodo = RBEfectivo.Checked ? "Efectivo" :
                RBCredito.Checked ? "Tarjeta de Crédito" :
                "Transferencia";

                var facturaCompleta = ObtenerFacturaCompleta(idReserva, monto, metodo);
                if (facturaCompleta != null)
                    GenerarFacturaPDF_iTextSharp(facturaCompleta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private int ObtenerMetodoPagoSeleccionado()
        {
            // Asigná el ID real según valores en la tabla MetodoPago
            if (RBEfectivo.Checked)
            {
                return 1;
            }
            else if (RBCredito.Checked)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        private FacturaCompleta ObtenerFacturaCompleta(int idReserva, decimal monto, string metodo)
        {
            var datos = new FacturaCompleta();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();

                // FACTURA PRINCIPAL
                string qFactura = @"
                            SELECT 
                                r.id_reserva + 100000 AS numero_pdf,              -- Usamos el ID de la reserva como 'Número de Factura'
                                r.fecha_creacion AS fecha_emision,                -- Usamos la fecha de creacion como 'Fecha de Emisión'
                                r.total AS Total,
                                c.nombre + ' ' + c.apellido AS Cliente,
                                c.dni,
                                c.email,
                                r.id_reserva
                            FROM Reserva r                                -- Tabla principal: Reserva
                            INNER JOIN Cliente c ON r.id_cliente = c.id_cliente
                            WHERE r.id_reserva = @idReserva";

                using (SqlCommand cmd = new SqlCommand(qFactura, conn))
                {
                    cmd.Parameters.AddWithValue("@idReserva", idReserva);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        datos.Factura = new FacturaData
                        {
                            Numero = rd["numero_pdf"].ToString(),
                            FechaEmision = Convert.ToDateTime(rd["fecha_emision"]),
                            Cliente = rd["Cliente"].ToString(),
                            DNI = rd["dni"].ToString(),
                            Email = rd["email"].ToString(),
                            MetodoPago = metodo,
                            Total = Convert.ToDecimal(rd["Total"])
                        };
                        datos.Factura.Numero = rd["numero_pdf"].ToString(); // Ajustar esta línea también
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
                            WHERE r.id_reserva = @idReserva";

                using (SqlCommand cmd = new SqlCommand(qHab, conn))
                {
                    cmd.Parameters.AddWithValue("@idReserva", idReserva);
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
                            FROM Reserva r                                 
                            INNER JOIN ReservaServicio rs ON r.id_reserva = rs.id_reserva
                            INNER JOIN Servicio s ON rs.id_servicio = s.id_servicio
                            WHERE r.id_reserva = @idReserva";

                // Modificar el parámetro en el C#
                using (SqlCommand cmd = new SqlCommand(qServ, conn))
                {
                    cmd.Parameters.AddWithValue("@idReserva", idReserva);
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
            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4, 40, 40, 40, 40);

            try
            {
                // 2. Definir la ruta de destino (ruta completa del archivo)
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

                // 5. Abrir el PDF automaticamente
                try
                {
                    // Usa el proceso de Windows para abrir el archivo con la aplicación predeterminada (lector de PDF)
                    System.Diagnostics.Process.Start(path);
                }
                catch (Exception ex)
                {
                    // Manejar un posible error si no puede iniciar el proceso (e.g., permisos denegados)
                    MessageBox.Show($"Advertencia: El PDF se generó, pero no se pudo abrir automáticamente. Error: {ex.Message}", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
