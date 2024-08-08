namespace MagicMelee.Exceptions;

// Base exception for the application-specific errors
public class MagicMeleeException : Exception
{
    public MagicMeleeException() { }

    public MagicMeleeException(string message)
        : base(message) { }

    public MagicMeleeException(string message, Exception innerException)
        : base(message, innerException) { }
}

// Specific exception types for various error scenarios
public class UserNotFoundException : MagicMeleeException
{
    public UserNotFoundException() { }

    public UserNotFoundException(string message)
        : base(message) { }

    public UserNotFoundException(string message, Exception innerException)
        : base(message, innerException) { }
}

public class InvalidLoginException : MagicMeleeException
{
    public InvalidLoginException() { }

    public InvalidLoginException(string message)
        : base(message) { }

    public InvalidLoginException(string message, Exception innerException)
        : base(message, innerException) { }
}

public class CharacterNotFoundException : MagicMeleeException
{
    public CharacterNotFoundException() { }

    public CharacterNotFoundException(string message)
        : base(message) { }

    public CharacterNotFoundException(string message, Exception innerException)
        : base(message, innerException) { }
}
