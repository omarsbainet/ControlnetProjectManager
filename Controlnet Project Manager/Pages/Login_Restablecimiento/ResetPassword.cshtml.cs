
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Controlnet_Project_Manager.Data;
using Controlnet_Project_Manager.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;

namespace Controlnet_Project_Manager.Pages.Login_Restablecimiento
{
	public class ResetPasswordModel : PageModel
	{
		[BindProperty]
		public InputModel Input { get; set; }

		private readonly ApplicationDbContext _context;
		private readonly UserManager<CPMUser> _userManager;
		private readonly SignInManager<CPMUser> _signInManager;
	


		public ResetPasswordModel(UserManager<CPMUser> manager, ApplicationDbContext context, SignInManager<CPMUser> signInManager)
		{
			_userManager = manager;
			_context = context;
			_signInManager = signInManager;
		}


		[ValidateAntiForgeryToken]
		public async Task<IActionResult> OnPostAsync()
		{
			//Se obtiene los valores de los campos ( Email, contraseña y de la contraseña repetida) del formulario
			var email = HttpContext.Request.Form["Email"];
			var password = HttpContext.Request.Form["Password"];
			var repeatPassword = HttpContext.Request.Form["RepeatPassword"];

			//Enlazamos con los campos
			Input.Email = email.FirstOrDefault();
			Input.Password = password.FirstOrDefault();
			Input.RepeatPassword = repeatPassword.FirstOrDefault();

			try
			{
				//Se comprueba si el modelo es valido
				if (ModelState.IsValid)
				{
					//Se comprueba si el email en el formulario no es nulo, es decir, si se ha proporcionado un correo electronico
					if (Input.Email != null)
					{
						//Se obtiene el usuario que coincida con el correo introducido
						var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Input.Email);

						//Se comprueba si el usuario no es nulo
						if (user != null)
						{
							//Se pasa a string el token de usuario
							UserCode.CodeTokenUser = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(UserCode.CodeTokenUser));

							//Se restablece el usuario y contraseña, para eso, pasamos a la funcion "resetpaswordAsync" el usuario, el token y la nueva contraseña
							var result = await _userManager.ResetPasswordAsync(user, UserCode.CodeTokenUser, Input.Password);

							//Si se ha completo con exito el restablecimiento..->
							if (result.Succeeded)
							{
								//Se restablece el token
								UserCode.CodeTokenUser = "";

								//Se obtiene de nuevo el usuario, esta vez con su nueva contraseña
								user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Input.Email);
								//Se inicia sesion con el usuario
								await _signInManager.SignInAsync(user, false);
								return LocalRedirect("/");
							}
							else
							{
								//El restablecimiento de contraseña no se ha podido completar
								ModelState.AddModelError(string.Empty, "Operacion No fue existosa");
								return Page();
							}
						}
						else
						{
							//El usuario no existe
							ModelState.AddModelError(string.Empty, "El usuario no existe");
							return Page();
						}
					}
					else
					{
						//En este caso, no se ha insertado ningun email
						ModelState.AddModelError(string.Empty, "No se ha insertado ningun email");
						return Page();
					}
				}
				else
				{
					//El model no es valido
					ModelState.AddModelError(string.Empty, "Error, Modelo no valido");
					return Page();
				}
			}
			catch (Exception ex)
			{
				ex.ToString();
				return Page();
			}

		}

		public class InputModel
		{
			//Campo de Email
			[Required]
			[EmailAddress]
			public string Email { get; set; }

			//Campo de password
			//Especificamos que su tipo de datoa es password
			[Required]
			[DataType(DataType.Password)]
			public string Password { get; set; }

			//Especificamos que su tipo de dato es password y que debe ser comparado con el campo password,para que la contraseña sea la misma.
			[Required]
			[DataType(DataType.Password)]
			[Compare("Password", ErrorMessage = "La contraseña debe de ser la misma")]
			public string RepeatPassword { get; set; }

		}

	}
}

