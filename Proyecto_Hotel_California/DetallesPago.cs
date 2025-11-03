using HotelCalifornia.Models;
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
using System.Threading.Tasks;
using System.Windows.Forms;
using static HotelCalifornia.ModeloFactura;
using Font = iTextSharp.text.Font;
using System.Diagnostics;

namespace HotelCalifornia
{
    public partial class DetallesPago : Form
    {
        private int pagoId;
        private int idReservaFactura;
        public DetallesPago(int id_pago)
        {
            InitializeComponent();
            pagoId = id_pago;
            idReservaFactura = 0;
        }

        private void DetallesPago_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                string query = @"SELECT
                        p.id_pago,
                        p.monto,
                        p.fecha,
                        p.referencia + p.id_pago AS Referencia,
                        r.id_reserva,
                        r.id_reserva + 100000 AS Factura,
                        r.fecha_inicio,
                        r.fecha_fin,
                        r.total AS Total,
                        c.nombre + ' ' + c.apellido AS Cliente,
                        c.dni,
                        c.email,
                        mp.descripcion AS metodoPago
                    FROM Pago p
                    INNER JOIN Reserva r ON p.id_reserva = r.id_reserva
                    INNER JOIN Cliente c ON r.id_cliente = c.id_cliente
                    INNER JOIN ReservaHabitacion rh ON r.id_reserva = rh.id_reserva
                    INNER JOIN Habitacion h ON rh.numero_hab = h.numero_hab
                    INNER JOIN MetodoPago mp ON p.id_metodoPago = mp.id_metodoPago
                    WHERE p.id_pago = @idPago;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idPago", pagoId);

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Mostrar Numero de la habitacion en el título o label
                        LNroRef.Text = reader["Referencia"].ToString();
                        LFP.Text = Convert.ToDateTime(reader["fecha"]).ToString("dd/MM/yyyy");
                        LClie.Text = reader["Cliente"].ToString();
                        LD.Text = reader["dni"].ToString();
                        LMail.Text = reader["email"].ToString();
                        LNumRes.Text = reader["id_reserva"].ToString();
                        LInicioR.Text = Convert.ToDateTime(reader["fecha_inicio"]).ToString("dd/MM/yyyy");
                        LFinR.Text = Convert.ToDateTime(reader["fecha_fin"]).ToString("dd/MM/yyyy");
                        LMP.Text = reader["metodoPago"].ToString();
                        LFactu.Text = reader["Factura"].ToString();

                        // Cargar las habitaciones asociadas
                        int idReserva = Convert.ToInt32(reader["id_reserva"]);
                        reader.Close(); // Cerrar antes de usar la misma conexión

                        idReservaFactura = idReserva; // Guardar el id_reserva para usarlo en la generación de la factura

                        CargarHabitacionesReserva(conn, idReserva);
                        CargarServiciosReserva(conn, idReserva);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la habitación con ese Número.");
                        this.Close();
                    }
                }
            }
        }

        // Método para cargar las habitaciones en GrillaHabitaciones
        private void CargarHabitacionesReserva(SqlConnection conn, int reserva_id)
        {
            string query = @"SELECT 
                        h.numero_hab AS Num_hab,
                        h.piso AS Piso,
                        th.nombre AS Tipo,
                        rh.cantidad_noches AS Noches,
                        rh.precio_noche AS Precio,
                        rh.subtotal AS Subtotal
                    FROM ReservaHabitacion rh
                    INNER JOIN Habitacion h ON rh.numero_hab = h.numero_hab
                    INNER JOIN TipoHabitacion th ON h.id_tipo = th.id_tipo
                    WHERE rh.id_reserva = @idReserva;";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@idReserva", reserva_id);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GrillaHabitaciones.DataSource = dt;
                }
            }
        }

        // Método para cargar los servicios asociados a la reserva
        private void CargarServiciosReserva(SqlConnection conn, int reserva_id)
        {
            string query = @"
                SELECT 
                    s.nombre AS Servicio,
                    rs.cantidad AS Cantidad,
                    rs.precio_unitario AS PrecioServ
                FROM ReservaServicio rs
                INNER JOIN Servicio s ON rs.id_servicio = s.id_servicio
                WHERE rs.id_reserva = @idReserva;";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@idReserva", reserva_id);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GrillaServicios.DataSource = dt;
                }
            }
        }

        private void BImprimir_Click(object sender, EventArgs e)
        {
            var facturaCompleta = ObtenerFacturaCompleta(idReservaFactura);
            if (facturaCompleta != null)
                GenerarFacturaPDF_iTextSharp(facturaCompleta);
        }

        private FacturaCompleta ObtenerFacturaCompleta(int idReserFac)
        {
            var datos = new FacturaCompleta();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();

                // FACTURA PRINCIPAL - CORREGIDA PARA INCLUIR MetodoPago
                string qFactura = @"
                    SELECT
                        r.id_reserva + 100000 AS numero_pdf,
                        r.fecha_creacion AS fecha_emision,
                        r.total AS Total,
                        c.nombre + ' ' + c.apellido AS Cliente,
                        c.dni,
                        c.email,
                        mp.descripcion AS MetodoPago, -- ¡Campo de la tabla MetodoPago!
                        r.id_reserva
                    FROM Reserva r
                    INNER JOIN Cliente c ON r.id_cliente = c.id_cliente
                    INNER JOIN Pago p ON r.id_reserva = p.id_reserva          -- Unir a Pago
                    INNER JOIN MetodoPago mp ON p.id_metodoPago = mp.id_metodoPago -- Unir a MetodoPago
                    WHERE r.id_reserva = @idReserva";

                using (SqlCommand cmd = new SqlCommand(qFactura, conn))
                {
                    cmd.Parameters.AddWithValue("@idReserva", idReserFac);
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
                            MetodoPago = rd["MetodoPago"].ToString(), // Ahora este campo existe
                            Total = Convert.ToDecimal(rd["Total"])
                        };
                        datos.Factura.Numero = rd["numero_pdf"].ToString();
                    }
                    rd.Close();
                }

                if (datos.Factura == null) return null;

                // DETALLES DE HABITACIONES - CORREGIDO PARA USAR LOS VALORES DE ReservaHabitacion
                string qHab = @"
                    SELECT
                        h.numero_hab AS Habitacion,
                        th.nombre AS TipoHabitacion,
                        rh.cantidad_noches AS Noches,     -- Usar campo de ReservaHabitacion
                        rh.precio_noche AS PrecioPorNoche, -- Usar campo de ReservaHabitacion
                        rh.subtotal AS Subtotal           -- Usar campo de ReservaHabitacion
                    FROM Reserva r
                    INNER JOIN ReservaHabitacion rh ON r.id_reserva = rh.id_reserva
                    INNER JOIN Habitacion h ON rh.numero_hab = h.numero_hab
                    INNER JOIN TipoHabitacion th ON h.id_tipo = th.id_tipo
                    WHERE r.id_reserva = @idReserva";

                using (SqlCommand cmd = new SqlCommand(qHab, conn))
                {
                    cmd.Parameters.AddWithValue("@idReserva", idReserFac);
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

                // DETALLES DE SERVICIOS (si aplica) - LA CONSULTA ESTÁ CORRECTA
                string qServ = @"
                    SELECT
                        s.nombre AS Servicio,
                        rs.cantidad AS Cantidad,            -- Añadido cantidad para mejor detalle si lo necesitas
                        rs.precio_unitario AS PrecioUnitario,-- Usado precio unitario de la reserva de servicio
                        rs.subtotal AS Precio               -- Usamos el subtotal como el precio del item en la factura
                    FROM Reserva r
                    INNER JOIN ReservaServicio rs ON r.id_reserva = rs.id_reserva
                    INNER JOIN Servicio s ON rs.id_servicio = s.id_servicio
                    WHERE r.id_reserva = @idReserva";
        
                using (SqlCommand cmd = new SqlCommand(qServ, conn))
                {
                    cmd.Parameters.AddWithValue("@idReserva", idReserFac);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        // Si usas el subtotal de ReservaServicio como el "Precio" total del item
                        // ajusta la propiedad del modelo DetalleServicio para que sea más clara (TotalServicio)
                        // Por ahora, usamos 'Precio' y asumimos que es el total de ese servicio.
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

                // 5. Abrir el PDF generado automáticamente
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
    }
}
