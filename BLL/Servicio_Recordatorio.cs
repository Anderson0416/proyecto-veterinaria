using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Servicio_Recordatorio
    {
        public void EnviarRecordatorios()
        {
            Servicio_Cita servicio_Cita = new Servicio_Cita();  

            // Obtener las citas programadas para el día siguiente
            List<Citas> citasFecha = servicio_Cita.Citas_Fecha(); 

            // Configuración del cliente SMTP (este es un ejemplo usando Gmail)
            SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("agendapeludavet@gmail.com", "lznu cxsm fpba cojo"), // Cambia por tus credenciales
                EnableSsl = true
            };

            // Enviar un correo por cada cita
            foreach (var cita in citasFecha)
            {
                try
                {
                    // Crear el mensaje de correo
                    MailMessage mensaje = new MailMessage
                    {
                        From = new MailAddress("agendapeludavet@gmail.com"), // El correo desde el que se enviará
                        Subject = "Recordatorio de Cita Médica",
                        Body = $"Estimado/a {cita.propietario.nombre} {cita.propietario.apellido},\n\n" +
                               $"Le recordamos que tiene una cita programada para el día {cita.fecha_cita.ToShortDateString()} a las {cita.fecha_cita.ToShortTimeString()}.\n" +
                               $"Estado de la cita: {cita.estado}\n" +
                               $"Total a pagar: {cita.total_pagar:C}\n\n" +
                               $"Notas: {cita.nota}\n\n" +
                               "Gracias por confiar en nosotros."
                    };

                    // Agregar el destinatario
                    mensaje.To.Add(cita.propietario.correo);

                    // Enviar el mensaje
                    clienteSmtp.Send(mensaje);

                    Console.WriteLine($"Correo enviado a: {cita.propietario.correo}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al enviar correo a {cita.propietario.correo}: {ex.Message}");
                }
            }
        }
    }
}
