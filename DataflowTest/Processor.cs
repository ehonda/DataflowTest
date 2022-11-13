using System.Runtime.CompilerServices;
using Serilog;

namespace DataflowTest;

public static class Processor
{
    public static async Task Sequential(ILogger logger)
    {
        logger.Information("Using {Method}", nameof(Sequential));
        
        await foreach (var item in ItemSource.A(logger))
        {
            logger.Information("{Item}", item);
        }

        await foreach (var item in ItemSource.B(logger))
        {
            logger.Information("{Item}", item);
        }
    }

    public static async Task SequentialFrom(IAsyncEnumerable<WorkItem> items, ILogger logger,
        [CallerArgumentExpression(nameof(items))] string? itemsExpression = null)
    {
        logger.Information("Using {Method} with items {Items}", nameof(SequentialFrom), itemsExpression);
        
        await foreach (var item in items)
        {
            logger.Information("{Item}", item);
        }
    }

    public static async Task SequentialParallel(ILogger logger)
    {
        logger.Information("Using {Method}", nameof(SequentialParallel));

        var taskA = Task.Run(() => SequentialFrom(ItemSource.A(logger), logger));
        var taskB = Task.Run(() => SequentialFrom(ItemSource.B(logger), logger));

        await Task.WhenAll(taskA, taskB);
    }

    public static async Task Zip(ILogger logger)
    {
        logger.Information("Using {Method}", nameof(Zip));
        await foreach (var pair in ItemSource.A(logger).Zip(ItemSource.B(logger)))
        {
            logger.Information("{Pair}", pair);
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
    
    public static async Task Concat(ILogger logger)
    {
        logger.Information("Using {Method}", nameof(Concat));
        await foreach (var item in ItemSource.A(logger).Concat(ItemSource.B(logger)))
        {
            logger.Information("{Item}", item);
        }
    }
}
