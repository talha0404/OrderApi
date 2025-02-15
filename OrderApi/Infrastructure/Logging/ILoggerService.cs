namespace OrderApi.Infrastructure.Logging;

public interface ILoggerService
{
    void LogInformation(string message);
    void LogWarning(string message);
    void LogError(string message, Exception ex);
    void LogDebug(string message); 
    void LogTrace(string message);
}