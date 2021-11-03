using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmark
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class Benchmark
    {
        private readonly Random _random = new Random();
        
        [Params(10, int.MaxValue)]
        public int MAX_RND;
        
        [Benchmark(Baseline = true)]
        public int GetRandom_System_Random()
        {
            return _random.Next(MAX_RND);
        }
        
        [Benchmark]
        public int GetRandom_System_NewRandomInstanceEachTime()
        {
            return new Random().Next(MAX_RND);
        }
        
        [Benchmark]
        public int GetRandom_SystemSecurityCryptography_RandomNumberGenerator()
        {
            return RandomNumberGenerator.GetInt32(MAX_RND);
        }
    }
}
