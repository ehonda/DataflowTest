using Serilog;

namespace DataflowTest;

public static class ItemSource
{
    private static readonly TimeSpan Delay = TimeSpan.FromSeconds(1);
    private const int NumberOfItems = 3;
    
    public static async IAsyncEnumerable<WorkItem> A(ILogger logger)
    {
        for (var i = 0; i < NumberOfItems; i++)
        {
            var identifier = $"{nameof(A)}-{i}";
            logger.Information("Generating {Identifier}", identifier);
            
            await Task.Delay(Delay);
            yield return new(identifier);
        }
    }
    
    public static async IAsyncEnumerable<WorkItem> B(ILogger logger)
    {
        for (var i = 0; i < NumberOfItems; i++)
        {
            var identifier = $"{nameof(B)}-{i}";
            logger.Information("Generating {Identifier}", identifier);
            
            await Task.Delay(Delay);
            yield return new(identifier);
        }
    }
}
