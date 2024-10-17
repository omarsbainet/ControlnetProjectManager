using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Controlnet_Project_Manager.Data
{
        public static class SendMail { 

            public static async Task SendMailVoid(string subject, string emailTo, string body)
            {
                try
                {
                    var smtpClient = new SmtpClient("smtp-relay.sendinblue.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential("toni@controlnet.es", "A2m7dQTDHIbz1f5p"),
                        EnableSsl = true

                    };

                    var message = new MailMessage
                    {
                        From = new MailAddress("info@controlnet.es"),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true,
                    };
                    try
                    {
                        message.To.Add(emailTo);
                        await smtpClient.SendMailAsync(message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to send email: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    // Manejar excepciones aquí
                    Console.WriteLine($"Ocurrió un error al enviar el correo: {ex.Message}");
                    throw; // Puedes considerar lanzar la excepción nuevamente para manejarla en capas superiores si es necesario
                }
            }
        }
  }