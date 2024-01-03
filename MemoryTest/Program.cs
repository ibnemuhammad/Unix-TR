// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;
using System.Diagnostics;
using TR;

Console.WriteLine("Hello, World!");
// Create a Stopwatch instance
Stopwatch stopwatch = new Stopwatch();

// Start the stopwatch
stopwatch.Start();

new MemoryUsageTest().TestMemoryUsageFor3000Iterations();
// Stop the stopwatch
stopwatch.Stop();

// Get the elapsed time in milliseconds
long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

// Print the elapsed time
Console.WriteLine($"Time taken: {elapsedMilliseconds} milliseconds");


