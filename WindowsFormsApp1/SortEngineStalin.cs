using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class SortEngineStalin : ISortEngine
    {
        private Form1 myForm;
        private int[] myArray;
        private Graphics g;
        private int comparisonsCount = 0;
        private int MaxVal;

        Brush WhiteBrush = new SolidBrush(Color.White);
        Brush BlackBrush = new SolidBrush(Color.Black);

        public SortEngineStalin(Form1 form)
        {
            myForm = form;
        }

        public void DoWork(int[] myArray_In, Graphics g_In, int MaxValue_In)
        {
            myArray = myArray_In;
            g = g_In;
            MaxVal = MaxValue_In;

            Task.Run(() =>
            {
                List<int> sortedList = new List<int>();
                int maxSoFar = int.MinValue;

                for (int i = 0; i < myArray.Length; i++)
                {
                    if (myForm.GetStopper())
                    {
                        myForm.SetStopper(false);
                        return;
                    }

                    if (myForm.WhetherPaused())
                    {
                        while (myForm.WhetherPaused())
                            Thread.Sleep(1);
                    }

                    comparisonsCount++;
                    myForm.updateComparisons(comparisonsCount);

                    if (myArray[i] >= maxSoFar)
                    {
                        maxSoFar = myArray[i];
                        sortedList.Add(myArray[i]);
                    }
                    else
                    {
                        // The "Stalinist purge" -> This number is removed
                        RemoveBar(i);
                    }
                }

                // Copy sortedList back to myArray
                for (int i = 0; i < sortedList.Count; i++)
                {
                    myArray[i] = sortedList[i];
                    DrawBar(i);
                }

                MessageBox.Show("Sorted! Press Stop to access other buttons.", "Sorted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private void RemoveBar(int index)
        {
            g.FillRectangle(BlackBrush, index, 0, 1, MaxVal); // "Erase" the bar
        }

        private void DrawBar(int index)
        {
            g.FillRectangle(WhiteBrush, index, MaxVal - myArray[index], 1, MaxVal);
        }
    }
}
