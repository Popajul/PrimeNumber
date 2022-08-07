// See https://aka.ms/new-console-template for more information


using PrimeNumber;
using static PerfObserver.ProcessManager;
using System.Linq;
using PerfObserver;


Type targetType = typeof(PrimeUtils);
var process = CreateProcess(targetType, "IsPrime", new[] { typeof(int),typeof(IEnumerable<int>).MakeByRefType() },null, new object[] {12345678,null} );
PerfLogger.LogProcessSample(process, 10);
CreateSample(process, 20);
SaveSampleDataToFile(process);

process = CreateProcess(targetType, "PrimeDecompositionList", new[] { typeof(int) }, null, new object[] { 2*3*5 });
CreateSample(process, 20);
SaveSampleDataToFile(process);

process = CreateProcess(targetType, "PrimeDecompositionList", new[] { typeof(int) }, null, new object[] { 2*3*5*7 });
CreateSample(process, 20);
SaveSampleDataToFile(process);

process = CreateProcess(targetType, "PrimeDecompositionList", new[] { typeof(int) }, null, new object[] { 2 * 3 * 5 * 7 * 11 });
CreateSample(process, 20);
SaveSampleDataToFile(process);

process = CreateProcess(targetType, "PrimeDecompositionList", new[] { typeof(int) }, null, new object[] { (int)(Math.Pow(2,5) * Math.Pow(3, 5) * 7 * 11) });
CreateSample(process, 20);
SaveSampleDataToFile(process);

CreateLineCharts(process);


