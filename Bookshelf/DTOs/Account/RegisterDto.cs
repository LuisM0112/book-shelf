using System.ComponentModel.DataAnnotations;
using Bookshelf.Helpers;

namespace Bookshelf.Models.DTOs.Account;

public class RegisterDto
{
  [Required(ErrorMessage = Messages.Validation.FieldRequired)]
  [StringLength(50)]
  [Display(Name = "Nombre de usuario")]
  public string Username { get; set; } = string.Empty;

  [Required(ErrorMessage = Messages.Validation.FieldRequired)]
  [EmailAddress(ErrorMessage = Messages.Validation.InvalidEmail)]
  [Display(Name = "Correo electrónico")]
  public string Email { get; set; } = string.Empty;

  [Required(ErrorMessage = Messages.Validation.FieldRequired)]
  [DataType(DataType.Password)]
  [StringLength(100, MinimumLength = 6, ErrorMessage = Messages.Validation.PasswordLength)]
  [Display(Name = "Contraseña")]
  public string Password { get; set; } = string.Empty;

  [Required(ErrorMessage = Messages.Validation.FieldRequired)]
  [DataType(DataType.Password)]
  [Compare(nameof(Password), ErrorMessage = Messages.Validation.PasswordsDoNotMatch)]
  [Display(Name = "Confirmar contraseña")]
  public string ConfirmPassword { get; set; } = string.Empty;
}
