using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteLockDemo
{
    class Consumer
    {
        public Cell cell { get; set; }
        public int limit { get; set; }


        public Consumer(Cell c, int r)
        {
            cell = c;
            limit = r;
        }

        public void Consume()
        {
            for (int i = 0; i < limit; i++)
            {
                cell.Read();
            }
        }
    }
}
