using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [MemoryDiagnoser]
    [RankColumn]
    public class Benchmark
    {
        [Benchmark(Baseline = true)]
        public int GetRandom_SystemRandom()
        {
            return new Random().Next();
        }
        
        [Benchmark]
        public int GetRandom_SystemSecurityCryptography()
        {
            return RandomNumberGenerator.GetInt32(int.MaxValue);
        }
    }
}
