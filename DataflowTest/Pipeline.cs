using System.Threading.Tasks.Dataflow;
using Serilog;

namespace DataflowTest;

public static class Pipeline
{
    private static readonly BufferBlock<WorkItem> BufferA = new();
    private static readonly BufferBlock<WorkItem> BufferB = new();
    private static readonly JoinBlock<WorkItem, WorkItem> JoinBlock = new();

    private static async Task FillBuffer(ITargetBlock<WorkItem> buffer, IAsyncEnumerable<WorkItem> items)
    {
        await foreach (var item in items)
        {
            buffer.Post(item);
        }
        buffer.Complete();
    }

    public static async Task Run(ILogger logger)
    {
        var linkOptions = new DataflowLinkOptions() { PropagateCompletion = true };
        
        // TODO: What about all these disposables?
        using var disposeA = BufferA.LinkTo(JoinBlock.Target1, linkOptions);
        using var disposeB = BufferB.LinkTo(JoinBlock.Target2, linkOptions);

        var actionBlock = new ActionBlock<Tuple<WorkItem, WorkItem>>(pair =>
        {
            logger.Information("{Pair}", pair);
        });

        using var disposeJoin = JoinBlock.LinkTo(actionBlock, linkOptions);

        // TODO: What happens if e.g. exceptions are thrown on fill?
        _ = Task.Run(() => FillBuffer(BufferA, ItemSource.A(logger)));
        _ = Task.Run(() => FillBuffer(BufferB, ItemSource.B(logger)));

        await actionBlock.Completion;
    }
}
