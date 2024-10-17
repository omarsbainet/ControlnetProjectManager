using System.Net;
using System.Net.Mail;

namespace Controlnet_Project_Manager.Areas.Identity.Data
{
	public static class EmailSend
	{

		/* Funcion 'Enviar correo' recibe dos parametros
		 * - email --> Email al que se enviará el correo
		 * - enlace --> Url que se generará con el token del usuario
		 * */
		public static async Task EnviarCorreo(string email, string enlace)
		{
			//Definimos el servidor SMTP, con sus credenciales
			var smtpClient = new SmtpClient("smtp-relay.sendinblue.com")
			{
				Port = 587,
				Credentials = new NetworkCredential("toni@controlnet.es", "A2m7dQTDHIbz1f5p"),
				EnableSsl = true
			};

			//Creamos el mensaje
			var message = new MailMessage
			{
				From = new MailAddress("info@controlnet.es"),
				Subject = "Recuperacion de contraseña",
				Body = "Restablezca la contraseña, pincha en este " + enlace,
				IsBodyHtml = true,
			};
			try
			{
				message.To.Add(email);
				await smtpClient.SendMailAsync(message);
			}
			catch (Exception e)
			{
				Console.WriteLine("Error al enviar el correo");
			}


		}

	}
}
