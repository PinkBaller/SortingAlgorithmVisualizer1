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
    internal class SortEngineQuick : ISortEngine
    {
        private Form1 myForm;
        private int[] myArray;
        private Graphics g;
        private int swapsCount = 0;
        private int comparisonsCount = 0;
        private int MaxVal;
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

        public SortEngineQuick(Form1 form)
        {
            myForm = form;
        }

        public void DoWork(int[] myArray_In, Graphics g_In, int MaxValue_In)
        {
            myArray = myArray_In;
            g = g_In;
            MaxVal = MaxValue_In;

            Task task1 = new Task(() => {
                Stack<(int, int)> stack = new Stack<(int, int)>();
                stack.Push((0, myArray.Length - 1));

                while (stack.Count > 0)
                {
                    var (low, high) = stack.Pop();
                    if (low < high)
                    {
                        if (myForm.GetStopper())
                        {
                            myForm.SetStopper(false);
                            return;
                        }

                        int pivot = myArray[high];
                        int i = low - 1;

                        for (int j = low; j < high; j++)
                        {
                            if (myForm.WhetherPaused())
                            {
                                while (myForm.WhetherPaused())
                                    Thread.Sleep(1);
                            }

                            comparisonsCount++;
                            myForm.updateComparisons(comparisonsCount);

                            if (myArray[j] < pivot)
                            {
                                comparisonsCount++;
                                myForm.updateComparisons(comparisonsCount);
                                i++;
                                Swap(i, j);
                            }
                        }

                        comparisonsCount++;
                        myForm.updateComparisons(comparisonsCount);
                        Swap(i + 1, high);

                        int pivotIndex = i + 1;
                        stack.Push((low, pivotIndex - 1));
                        stack.Push((pivotIndex + 1, high));
                    }
                }
                MessageBox.Show("Sorted! Press Stop to access other buttons", "Sorted!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            });
            task1.Start();
        }


        private void Swap(int i, int v)
        {
            int temp = myArray[i];
            myArray[i] = myArray[v];
            myArray[v] = temp;

            g.FillRectangle(BlackBrush, i, 0, 1, MaxVal);
            g.FillRectangle(BlackBrush, v, 0, 1, MaxVal);
            g.FillRectangle(WhiteBrush, i, MaxVal - myArray[i], 1, MaxVal);
            g.FillRectangle(WhiteBrush, v, MaxVal - myArray[v], 1, MaxVal);

            if (myForm.GetSound())
            {
                int frequency = MapValue(myArray[i], myArray.Min(), myArray.Max(), 200, 2000);
                Console.Beep(frequency, 100);
            }
            swapsCount++;
            myForm.updateSwaps(swapsCount);
        }

        int MapValue(int value, int inMin, int inMax, int outMin, int outMax)
        {
            if (inMax == inMin) return outMin;
            return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }


    }

}
