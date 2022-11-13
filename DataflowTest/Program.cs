using DataflowTest;
using Serilog;

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

// await Processor.Sequential(logger);
// await Processor.Zip(logger);
// await Processor.ZipAwait(logger);
// await Processor.Concat(logger);
await Processor.SequentialParallel(logger);
