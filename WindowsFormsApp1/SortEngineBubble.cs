using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class SortEngineBubble : ISortEngine
    {
        private Form1 myForm;
        private bool _sorted = false;
        private int[] myArray;
        private Graphics g;
        private int swapsCount = 0;
        private int comparisonsCount = 0;
        private int MaxVal;
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

        public SortEngineBubble(Form1 form) 
        {   
            myForm = form;
        }

        public void DoWork(int[] myArray_In, Graphics g_In, int MaxValue_In)
        {
            myArray = myArray_In;
            g = g_In;
            MaxVal = MaxValue_In;


            Task task1 = new Task(() =>
            {
                
                while (!_sorted)
                {
                    if (myForm.GetStopper())
                    {
                        myForm.SetStopper(false);
                        break;
                    }
                    for (int i = 0; i < myArray.Count() - 1; i++)
                    {
                    if (myForm.WhetherPaused())
                        {
                            while (myForm.WhetherPaused())
                            {
                                if (!myForm.WhetherPaused())
                                    break;
                                Thread.Sleep(1); 
                            }
                        }
                        comparisonsCount++;
                        if (myArray[i] > myArray[i + 1])
                        {
                            Swap(i, i + 1);
                        }
                        myForm.updateComparisons(comparisonsCount);

                    }
                    _sorted = IsSorted();

                }
                MessageBox.Show("Sorted! Press Stop to access other buttons", "Sorted!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            });
            task1.Start();
            
        }

        private void Swap(int i, int v)
        {

            int temp = myArray[i];
            myArray[i] = myArray[i + 1];
            myArray[i + 1] = temp;

            g.FillRectangle(BlackBrush, i, 0, 1, MaxVal);
            g.FillRectangle(BlackBrush, v, 0, 1, MaxVal);

            g.FillRectangle(WhiteBrush, i, MaxVal - myArray[i], 1, MaxVal);
            g.FillRectangle(WhiteBrush, v, MaxVal - myArray[v], 1, MaxVal);
            if (myForm.GetSound())
            {
                int frequency = MapValue(myArray[i], myArray.Min(), myArray.Max(), 200, 2000);

                Console.Beep(frequency, 25);
                
            }
            swapsCount++;
            myForm.updateSwaps(swapsCount);
        }

        private bool IsSorted()
        {
            for (int i = 0; i< myArray.Count()-1; i++)
            {
                if (myArray[i] > myArray[i + 1]) return false;
            }

            return true;
        }

        int MapValue(int value, int inMin, int inMax, int outMin, int outMax)
        {
            if (inMax == inMin) return outMin;
            return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }

    }

 
}
