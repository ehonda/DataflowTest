using Serilog;

namespace DataflowTest;

public static class Processor
{
    public static async Task Sequential(ILogger logger)
    {
        logger.Information("Using {Method}", nameof(Sequential));
        
        await foreach (var item in ItemSource.A(logger))
        {
            Console.WriteLine(item);
        }

        await foreach (var item in ItemSource.B(logger))
        {
            Console.WriteLine(item);
        }
    }

    public static async Task Zip(ILogger logger)
    {
        logger.Information("Using {Method}", nameof(Zip));
        await foreach (var pair in ItemSource.A(logger).Zip(ItemSource.B(logger)))
        {
            Console.WriteLine(pair);
        }
    }
    
    public static async Task ZipAwait(ILogger logger)
    {
        logger.Information("Using {Method}", nameof(ZipAwait));
        await foreach (var pair in ItemSource.A(logger).ZipAwait(ItemSource.B(logger), (a, b) => ValueTask.FromResult((a, b))))
        {
            logger.Information("{Pair}", pair);
        }
    }
}
