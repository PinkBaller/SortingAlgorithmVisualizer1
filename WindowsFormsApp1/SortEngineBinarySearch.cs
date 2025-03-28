using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class SortEngineBinarySearch : ISortEngine
    {
        private Form1 myForm;
        private int[] myArray;
        private Graphics g;
        private int swapsCount = 0;
        private int comparisonsCount = 0;
        private int MaxVal;
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        private bool sorted = false;

        public SortEngineBinarySearch(Form1 form)
        {
            myForm = form;
        }
        public void DoWork(int[] myArray_In, Graphics g_In, int MaxValue_In)
        {
            myArray = myArray_In;
            MessageBox.Show("WIP, not finished yet", "Work In Progress", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}