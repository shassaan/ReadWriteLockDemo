using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteLockDemo
{
    class Producer
    {
        public Cell cell { get; set; }
        public int limit { get; set; }
        

        public Producer(Cell c , int r)
        {
            cell = c;
            limit = r;
        }

        public void Produce()
        {
            for (int i = limit; i >=1; i--)
            {
                cell.Write(i);
            }
        }
    }
}
