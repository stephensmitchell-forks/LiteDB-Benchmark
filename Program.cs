﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDB_Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var rounds = 10;

            var tests = new List<Test>
            {
                new MongoDBTest(),
                new LiteDBTest(),
                new LiteDBNoJournalTest()
            };

            for (var round = 1; round <= rounds; round++)
            {
                foreach (var test in tests)
                {
                    test.Run(round, 
                        insert: 15000, 
                        fetch: 10000, 
                        update: 1000, 
                        delete: 2000, 
                        fileSizeMB: 50);
                }
            }

            Console.WriteLine("Final Results");
            Console.WriteLine("=============");
            Console.WriteLine();

            foreach (var test in tests)
            {
                test.ShowResults();
            }


            Console.ReadKey();
        }
    }
}
