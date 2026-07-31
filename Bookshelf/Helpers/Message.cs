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
}
