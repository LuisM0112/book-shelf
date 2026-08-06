namespace Bookshelf.Helpers;

public static class Messages
{
  public static class Validation
  {
    public const string FieldRequired = "Este campo es obligatorio.";
    public const string InvalidEmail = "El correo electrónico no es válido.";
    public const string PasswordLength = "La contraseña debe tener al menos 6 caracteres.";
    public const string PasswordsDoNotMatch = "Las contraseñas no coinciden.";
  }

  public static class User
  {
    public const string InvalidCredentials = "El nombre de usuario, correo electrónico o contraseña son incorrectos.";
  }

  public static class Account
  {
    public const string UsernameMismatch = "El nombre de usuario no coincide.";
    public const string DeleteFailed = "No se ha podido eliminar la cuenta.";
  }

  public static class Book
  {
    public const string TitleRequired = "El título es obligatorio.";
    public const string AuthorRequired = "El autor es obligatorio.";
    public const string DateRequired = "La fecha de publicación es obligatoria.";
    public const string IsbnRequired = "El ISBN es obligatorio.";
    public const string IsbnAlreadyExists = "Ya existe un libro con ese ISBN.";
  }

  public static class Proposal
  {
    public const string DuplicateProposal = "El libro ya existe en el catálogo o ya hay una propuesta pendiente para él.";
    public const string AcceptError = "No se ha podido aceptar la propuesta.";
    public const string AcceptSuccess = "La propuesta se ha aceptado correctamente.";
    public const string RejectError = "No se ha podido rechazar la propuesta.";
    public const string RejectSuccess = "La propuesta se ha rechazado correctamente.";
  }
}
