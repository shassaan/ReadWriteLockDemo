using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReadWriteLockDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Cell cell = new Cell();
            var pd = new Producer(cell, 10);
            var cr = new Consumer(cell,10);
            var t1 = new Thread(pd.Produce);
            var t2 = new Thread(cr.Consume);
            t2.Start();
            t1.Start();
            start:
            if (!t1.IsAlive && !t2.IsAlive) {
                Console.WriteLine($"Write Chances Missed : {cell.writeMissed}");
                Console.WriteLine($"Read Chances Missed : {cell.readMissed}");
                goto finish;
            }
            goto start;
            finish:
            Console.ReadKey();
        }
    }
}
