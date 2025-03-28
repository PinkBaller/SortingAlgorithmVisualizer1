using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int[] myArray;
        Graphics g;

        bool _stopper = false;
        bool _sound = true;
        bool _paused = false;
        public Form1()
        {
            InitializeComponent();
            StopButton.Enabled = false;
        }

        

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            StopButton.Enabled = true;
            g = panel1.CreateGraphics();
            int NumEntries = panel1.Width;
            int MaxVal = panel1.Height;

            myArray = new int[NumEntries];

            g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), 0, 0, NumEntries, MaxVal);

            Random rand = new Random();

            for (int i = 0; i < NumEntries; i++)
                myArray[i] = rand.Next(0, MaxVal);

            for (int i = 0; i < NumEntries; i++)
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), i, MaxVal - myArray[i], 1, MaxVal);

            label1.Text = ("0");
            label5.Text = ("0");

            _stopper = false;
            label1.Text = ("0");
            label5.Text = ("0");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (_stopper)
            {
                _stopper = true;
            }
            switch (comboBox2.Text) 
            {
                case "":
                    MessageBox.Show("Please select a viable sorting algorithm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBox2.Enabled = true;
                    StartButton.Enabled = true;
                    GenerateButton.Enabled = true;
                    break;
                case "Bubble sort":
                    if(myArray == null)
                    {
                        MessageBox.Show("Please press Generate first to generate or regenerate values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    comboBox2.Enabled = false;
                    StartButton.Enabled = false;
                    GenerateButton.Enabled = false;
                    ISortEngine seBubble = new SortEngineBubble(this);
                    seBubble.DoWork(myArray, g, panel1.Height);
                    StopButton.Enabled = true;
                    break;
                case "Odd Even Sort":
                    if (myArray == null)
                    {
                        MessageBox.Show("Please press Generate first to generate or regenerate values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    comboBox2.Enabled = false;
                    StartButton.Enabled = false;
                    GenerateButton.Enabled = false;
                    ISortEngine seOddEven = new SortEngineOddEven(this);
                    seOddEven.DoWork(myArray, g, panel1.Height);
                    StopButton.Enabled = true;
                    break;
                case "Insertion sort":
                    if (myArray == null)
                    {
                        MessageBox.Show("Please press Generate first to generate or regenerate values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    comboBox2.Enabled = false;
                    StartButton.Enabled = false;
                    GenerateButton.Enabled = false;
                    ISortEngine seInsertion = new SortEngineInsertion(this);
                    seInsertion.DoWork(myArray, g, panel1.Height);
                    StopButton.Enabled = true;
                    break;
                case "Quick sort":
                    if (myArray == null)
                    {
                        MessageBox.Show("Please press Generate first to generate or regenerate values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    comboBox2.Enabled = false;
                    StartButton.Enabled = false;
                    GenerateButton.Enabled = false;
                    ISortEngine seQuick = new SortEngineQuick(this);
                    seQuick.DoWork(myArray, g, panel1.Height);
                    StopButton.Enabled = true;
                    break;
                case "Cocktail sort":
                    if (myArray == null)
                    {
                        MessageBox.Show("Please press Generate first to generate or regenerate values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    comboBox2.Enabled = false;
                    StartButton.Enabled = false;
                    GenerateButton.Enabled = false;
                    ISortEngine seCocktail = new SortEngineCocktail(this);
                    seCocktail.DoWork(myArray, g, panel1.Height);
                    StopButton.Enabled = true;
                    break;
                case "Stalin Sort":
                    if (myArray == null)
                    {
                        MessageBox.Show("Please press Generate first to generate or regenerate values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    comboBox2.Enabled = false;
                    StartButton.Enabled = false;
                    GenerateButton.Enabled = false;
                    ISortEngine seStalin = new SortEngineStalin(this);
                    seStalin.DoWork(myArray, g, panel1.Height);
                    StopButton.Enabled = true;
                    break;
                case "Binary Search":
                    if (myArray == null)
                    {
                        MessageBox.Show("Please press Generate first to generate or regenerate values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    comboBox2.Enabled = false;
                    StartButton.Enabled = false;
                    GenerateButton.Enabled = false;
                    ISortEngine seBinary = new SortEngineBinarySearch(this);
                    seBinary.DoWork(myArray, g, panel1.Height);
                    StopButton.Enabled = true;
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void updateComparisons(int new_text)
        {
            if (label5.InvokeRequired)
            {
                label5.Invoke(new Action(() => label5.Text = new_text.ToString()));
            }
            else
            {
                label5.Text = new_text.ToString();
            }
        }

        public void updateSwaps(int new_text)
        {
            if (label1.InvokeRequired)
            {
                label1.Invoke(new Action(() => label1.Text = new_text.ToString()));
            }
            else
            {
                label1.Text = new_text.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            label1.Text = ("0");
            label5.Text = ("0");

            comboBox2.Enabled = true;
            StartButton.Enabled = true;
            GenerateButton.Enabled = true;

            StopButton.Enabled = false;

            _stopper = true;
        }

        public bool GetStopper()
        {
            return _stopper;
        }

        public void SetStopper(bool value) 
        {
            _stopper = value;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void SoundButton_CheckChanged(object sender, EventArgs e)
        {
            if (_sound)
                _sound = false;
            else
                _sound = true;
        }

        public bool GetSound() 
        {
            return _sound;
        }

        private void PauseResumeButton_Click(object sender, EventArgs e)
        {
            if (!_paused)
            {
                _paused = true;
            }
            else
            {
                _paused = false; 
            }
        }


        public bool WhetherPaused()
        {
            return _paused;
        }
    }
}
