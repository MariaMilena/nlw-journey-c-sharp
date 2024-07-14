using System.Net;

namespace Journey.Exception.ExceptionsBase;

public abstract class JourneyException : SystemException
{
    public JourneyException(string message) : base(message) // base(message) : repassa a mensagem recebida para o construtor do SystemException
    {

    }

    public abstract HttpStatusCode GetStatusCode();

    public abstract IList<string> GetErrorMessages();
}
