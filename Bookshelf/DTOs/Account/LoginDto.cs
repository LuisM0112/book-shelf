using Bookshelf.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Bookshelf.Models.DTOs.Account;

public class LoginDto
{
  [Required(ErrorMessage = Messages.Validation.FieldRequired)]
  [Display(Name = "Nombre de usuario o correo electrónico")]
  public string Identifier { get; set; } = string.Empty;


  [Required(ErrorMessage = Messages.Validation.FieldRequired)]
  [DataType(DataType.Password)]
  [Display(Name = "Contraseña")]
  public string Password { get; set; } = string.Empty;


  [Display(Name = "Recordarme")]
  public bool RememberMe { get; set; }
}
