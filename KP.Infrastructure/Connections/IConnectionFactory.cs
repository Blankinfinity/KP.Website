using System.Data;

namespace KP.Infrastructure.Connections
{
    public interface IConnectionFactory
    {
        IDbConnection Get();
    }
}
