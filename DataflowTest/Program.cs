using DataflowTest;
using Serilog;

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

// await Processor.Sequential();
// await Processor.Zip();
await Processor.ZipAwait(logger);
