using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Yield_Measure
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    internal static class Program
    {
        private static void Main()
        {
            // To Use Benchmark should run in Release mode!
            // Benchmark will run while 2-3 minutes.
            var result = BenchmarkRunner.Run<YieldBenchmarks>();
        }
    }

    [MemoryDiagnoser]
    public class YieldBenchmarks
    {
        [Benchmark]
        public void CreateStudents()
        {
            var students = GetStudents(1000000);

            foreach (var student in students)
            {
                if (student.Id < 1000)
                    Console.WriteLine($"Id: {student.Id}, Name: {student.Name}");
                else
                    break;
            }
        }

        static IEnumerable<Student> GetStudents(int count)
        {
            var students = new List<Student>();

            for (int i = 0; i < count; i++)
            {
                students.Add(new Student() { Id = i, Name = $"Student Number {i}" });
            }
            return students;
        }

        [Benchmark]
        public void CreateStudentsYield()
        {
            var students = GetStudentsYield(1000000);

            foreach (var student in students)
            {
                if (student.Id < 1000)
                    Console.WriteLine($"Id: {student.Id}, Name: {student.Name}");
                else
                    break;
            }
        }

        static IEnumerable<Student> GetStudentsYield(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new Student() { Id = i, Name = $"Student Number {i}" };
            }
        }
    }
}
// Output:  * Summary *
// 
// BenchmarkDotNet = v0.13.1, OS = Windows 10.0.19043.1202(21H1 / May2021Update)
// Intel Core i7-4702MQ CPU 2.20GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
// .NET SDK=6.0.100-preview.7.21379.14
//   [Host]     : .NET 5.0.8(5.0.821.31504), X64 RyuJIT
//   DefaultJob : .NET 5.0.8(5.0.821.31504), X64 RyuJIT
// 
// |              Method |     Mean |    Error  |   StdDev  |      Gen 0  |     Gen 1  |     Gen 2  |  Allocated  |
// |-------------------- |---------:| ---------:| ---------:| -----------:| ----------:| ----------:| -----------:|
// | CreateStudents      | 735.7 ms | 14.46 ms  | 24.16 ms  | 20000.0000  | 8000.0000  | 2000.0000  | 133,681 KB  |
// | CreateStudentsYield | 356.4 ms | 7.12 ms   | 17.06 ms  | -           | -          | -          |      226 KB |
//