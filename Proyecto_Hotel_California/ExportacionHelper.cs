using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace HotelCalifornia
{
    /// <summary>
    /// Helper para exportar datos a diferentes formatos sin librerías externas
    /// </summary>
    public static class ExportacionHelper
    {
        /// <summary>
        /// Exporta un DataTable a CSV (compatible con Excel)
        /// </summary>
        public static bool ExportarACSV(DataTable datos, string rutaArchivo)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                
                // Encabezados
                string[] columnNames = new string[datos.Columns.Count];
                for (int i = 0; i < datos.Columns.Count; i++)
                {
                    columnNames[i] = datos.Columns[i].ColumnName;
                }
                sb.AppendLine(string.Join(",", columnNames));
                
                // Datos
                foreach (DataRow row in datos.Rows)
                {
                    string[] fields = new string[datos.Columns.Count];
                    for (int i = 0; i < datos.Columns.Count; i++)
                    {
                        string value = row[i].ToString().Replace(",", ";");
                        value = value.Replace("\"", "\"\"");
                        if (value.Contains(";") || value.Contains("\"") || value.Contains("\n"))
                        {
                            value = "\"" + value + "\"";
                        }
                        fields[i] = value;
                    }
                    sb.AppendLine(string.Join(",", fields));
                }

                // Escribir con BOM UTF-8 para que Excel lo detecte correctamente
                File.WriteAllText(rutaArchivo, sb.ToString(), new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar a CSV: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Exporta un DataTable a HTML (se puede abrir con Excel)
        /// </summary>
        public static bool ExportarAHTML(DataTable datos, string rutaArchivo, string titulo = "Reporte")
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<!DOCTYPE html>");
                sb.AppendLine("<html><head>");
                sb.AppendLine("<meta charset='utf-8'>");
                sb.AppendLine($"<title>{titulo}</title>");
                sb.AppendLine("<style>");
                sb.AppendLine("body { font-family: Arial, sans-serif; margin:20px; }");
                sb.AppendLine("table { border-collapse: collapse; width:100%; margin-top:20px; }");
                sb.AppendLine("th, td { border:1px solid #ddd; padding:8px; text-align: left; }");
                sb.AppendLine("th { background-color: #4CAF50; color: white; font-weight: bold; }");
                sb.AppendLine("tr:nth-child(even) { background-color: #f2f2f2; }");
                sb.AppendLine("tr:hover { background-color: #ddd; }");
                sb.AppendLine("h1 { color: #333; }");
                sb.AppendLine(".info { color: #666; font-size:14px; margin:10px0; }");
                sb.AppendLine("</style>");
                sb.AppendLine("</head><body>");
                
                sb.AppendLine($"<h1>{titulo}</h1>");
                sb.AppendLine($"<p class='info'>Generado el: {DateTime.Now:dd/MM/yyyy HH:mm}</p>");
                sb.AppendLine($"<p class='info'>Total de registros: {datos.Rows.Count}</p>");
                
                sb.AppendLine("<table>");
                
                // Encabezados
                sb.AppendLine("<thead><tr>");
                foreach (DataColumn column in datos.Columns)
                {
                    sb.AppendLine($"<th>{column.ColumnName}</th>");
                }
                sb.AppendLine("</tr></thead>");
                
                // Datos
                sb.AppendLine("<tbody>");
                foreach (DataRow row in datos.Rows)
                {
                    sb.AppendLine("<tr>");
                    foreach (DataColumn column in datos.Columns)
                    {
                        string value = row[column].ToString();
                        if (column.DataType == typeof(decimal) || column.DataType == typeof(double))
                        {
                            if (decimal.TryParse(value, out decimal numero))
                            {
                                value = numero.ToString("N2");
                            }
                        }
                        else if (column.DataType == typeof(DateTime))
                        {
                            if (DateTime.TryParse(value, out DateTime fecha))
                            {
                                value = fecha.ToString("dd/MM/yyyy");
                            }
                        }
                        sb.AppendLine($"<td>{value}</td>");
                    }
                    sb.AppendLine("</tr>");
                }
                sb.AppendLine("</tbody>");
                
                sb.AppendLine("</table>");
                sb.AppendLine("</body></html>");

                // Escribir con BOM UTF-8
                File.WriteAllText(rutaArchivo, sb.ToString(), new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar a HTML: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Muestra un diálogo para guardar archivo y exporta según el formato seleccionado
        /// </summary>
        public static void ExportarConDialogo(DataTable datos, string tituloReporte = "Reporte")
        {
            if (datos == null || datos.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Sin Datos", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Archivo CSV (Excel)|*.csv|Archivo HTML|*.html";
            dialog.FileName = $"{tituloReporte}_{DateTime.Now:yyyyMMdd_HHmmss}";
            dialog.Title = "Exportar Reporte";
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                bool exito = false;
                
                if (dialog.FilterIndex == 1) // CSV
                {
                    exito = ExportarACSV(datos, dialog.FileName);
                }
                else if (dialog.FilterIndex == 2) // HTML
                {
                    exito = ExportarAHTML(datos, dialog.FileName, tituloReporte);
                }
                
                if (exito)
                {
                    DialogResult result = MessageBox.Show(
                        "Archivo exportado exitosamente.\n¿Desea abrirlo ahora?", 
                        "Exportación Exitosa", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Information);
                    
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(dialog.FileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"No se pudo abrir el archivo: {ex.Message}", "Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
