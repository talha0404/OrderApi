namespace OrderApi.Infrastructure.Logging;

public class LoggerService: ILoggerService
{
    private readonly ILogger<LoggerService> _logger; // Inject ILogger

    public LoggerService(ILogger<LoggerService> logger)
    {
        _logger = logger;
    }
    
    public void LogInformation(string message)
    {
        _logger.LogInformation(message);
    }

    public void LogWarning(string message)
    {
        _logger.LogWarning(message);
    }

    public void LogError(string message, Exception ex)
    {
        _logger.LogError(ex, message);
    }

    public void LogDebug(string message)
    {
        _logger.LogDebug(message); 
    }

    public void LogTrace(string message)
    {
        _logger.LogTrace(message); 
    }
}