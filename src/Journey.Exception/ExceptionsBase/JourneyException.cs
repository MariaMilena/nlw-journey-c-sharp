namespace Journey.Exception.ExceptionsBase;

public class JourneyException : SystemException
{
    public JourneyException(string message) : base(message) // base(message) : repassa a mensagem recebida para o construtor do SystemException
    {
    }
}
