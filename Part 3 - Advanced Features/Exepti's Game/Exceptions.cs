namespace Exceptions;

public class AteCookieException : Exception
{
    public AteCookieException()
    { }
    public AteCookieException(string message) : base(message)
    { }
}