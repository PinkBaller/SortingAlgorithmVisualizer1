using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal interface ISortEngine
    {
        void DoWork(int[] myArray, Graphics g, int MaxValue);
    }
}
