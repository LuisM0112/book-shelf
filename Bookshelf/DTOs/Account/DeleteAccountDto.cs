using Bookshelf.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Bookshelf.Models.DTOs.Account;

public class DeleteAccountDto
{
  [Required(ErrorMessage = Messages.Validation.FieldRequired)]
  [Display(Name = "Nombre de usuario")]
  public string Username { get; set; } = string.Empty;
}
