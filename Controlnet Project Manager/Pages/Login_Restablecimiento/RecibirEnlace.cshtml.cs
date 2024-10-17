using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Controlnet_Project_Manager.Areas.Identity.Data;
using System.Text.Encodings.Web;
using Controlnet_Project_Manager.Data;

namespace Controlnet_Project_Manager.Pages.Login_Restablecimiento
{
    public class RecibirEnlaceModel : PageModel
    {
        [BindProperty]
        public InputModel input { get; set; }
        public readonly ApplicationDbContext dbcontext;
        private readonly UserManager<CPMUser> manager;


        //Constructor
        public RecibirEnlaceModel(ApplicationDbContext context, UserManager<CPMUser> _manager)
        {
            dbcontext = context;
            manager = _manager;
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            //La variable Login estara relacionada con el campo "Email" del formulario
            var login = HttpContext.Request.Form["Email"];

            input.email = login.FirstOrDefault();

            //Se comprueba si el modelo es valido
            if (ModelState.IsValid)
            {
                //Se mira si el email introducido es nulo
                if (!string.IsNullOrEmpty(input.email))
                {
                    //Se obtiene el usuario que tenga el email introducido en el formulario
                    var usuario = dbcontext.Users.FirstOrDefault(x => x.Email == input.email);
                    //Booleano que almacena si el usuario es nulo
                    var comprobacion_user = usuario != null;

                    //Si el usuario no es nulo, se ejecuta el codigo
                    if (comprobacion_user)
                    {
                        //Se genera el token de restablecimiento de usuario
						var code = await manager.GeneratePasswordResetTokenAsync(usuario);
						code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        //Se guarda el token en atributo de clase estatica pues será necesario mas tarde para restablecer la contraseña
                        UserCode.CodeTokenUser = code;

                        //Generamos la url con el codigo del usuario.
						var callbackUrl = Url.Page(
							"/Login_Restablecimiento/ResetPassword",
							pageHandler: null,
							values: new { pages = "Pages", code },
							protocol: Request.Scheme);

                        //Se manda el correo al email introducido en el formulario, ademas, se le pasará la url generada.
						    await EmailSend.EnviarCorreo(input.email, "<a href='" + HtmlEncoder.Default.Encode(callbackUrl) + "'> Enlace de recuperacion </a>");
                        //Se redirigé a la pagina /obtained, la cual es una pagina que indica que el usuario ha recibido el correo.
                        return LocalRedirect("/obtained");
                    }
                    else
                    {
                        //Si el usuario no existe, se redigirá a la misma pagina
                        ModelState.AddModelError(string.Empty, "Usuario no existente");
                        Console.WriteLine("No existe");
                        return Page();
                    }
                }
                else
                {
                    //Se redigirá a la misma pagina ya que no se ha introducido el email
                    ModelState.AddModelError(string.Empty, "Correo no valido");
                    return Page();
                }
            }
            //En este caso, el modelo no es valido
            else
            {
                ModelState.AddModelError(string.Empty, "Correo vacio");
                return Page();
            }

        }
        //Clase input model, indica que el campo 'email' es un correo electronico.
        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string email { get; set; }

        }
    }
}
