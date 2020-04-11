using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReadWriteLockDemo
{
    class Cell
    {
        public int data { get; set; }
        public int readMissed { get; set; }
        public int writeMissed { get; set; }
        public bool readTurn = false;
        public void Write(int d)
        {
            Monitor.Enter(this);
            if (readTurn)
            {
                writeMissed++;
                Monitor.Wait(this);
            }

            Console.WriteLine("Attempting To Write");
            data = d;
            Thread.Sleep(1500);
            Console.WriteLine("Done Writing");
            Console.WriteLine(data);
            readTurn = true;
            Monitor.Pulse(this);
            Monitor.Exit(this);
        }

        public void Read()
        {
            Monitor.Enter(this);
            if (!readTurn)
            {
                readMissed++;
                Monitor.Wait(this);
            }
            Console.WriteLine("Attempting to Read");
            Console.WriteLine(data);
            Thread.Sleep(300);
            Console.WriteLine("Done Reading");
            readTurn = false;
            Monitor.Pulse(this);
            Monitor.Exit(this);

         }
        }
    }

