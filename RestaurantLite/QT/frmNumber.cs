using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantLite.QT
{
    public partial class frmNumber : Form
    {
        public frmNumber()
        {
            InitializeComponent();
            _Value = "1";
        }
        string _Value = "0";
        Timer tm;
        public string Value { get { return _Value; } set { _Value = value;} }

        private void button1_Click(object sender, EventArgs e)
        {
            tm.Enabled = false;
            Button btn = (Button)sender;
            textBox1.Text += btn.Text;
            tm.Enabled = true;
        }

        void tm_Tick(object sender, EventArgs e)
        {
            _Value = textBox1.Text;
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tm.Enabled = false;
            if (textBox1.Text != "")
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);    
            }
            else
            {
                _Value = "0";
                this.Close();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tm.Enabled = false;
            if (textBox1.Text =="")
            {
                _Value = "1";
            }
            else
            {
                _Value = textBox1.Text;
            }
            
            this.Close();
        }
        int _TimerInterval = 0;
        public int TimerInterval { get { return _TimerInterval; } set { _TimerInterval = value; } }
        private void frmNumber_Load(object sender, EventArgs e)
        {
            tm = new Timer();
            if (_TimerInterval != 0)
            {
               
                tm.Tick += tm_Tick;
                tm.Interval = _TimerInterval;
                tm.Enabled = false;
            }
        }

        private void FocusButton(int num)
        {
            // Find button by number text
            foreach (Control ctrl in tableLayoutPanel1.Controls)
            {
                if (ctrl is Button btn && btn.Text == num.ToString())
                {
                    btn.Focus(); // set focus
                    break;
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Handle top row digits (Keys.D1 - Keys.D9)
            if (keyData >= Keys.D1 && keyData <= Keys.D9)
            {
                int num = keyData - Keys.D0; // convert Keys.D1 -> 1, Keys.D2 -> 2, etc.
                FocusButton(num);
                return true;
            }
            // Handle numpad digits (Keys.NumPad1 - Keys.NumPad9)
            else if (keyData >= Keys.NumPad1 && keyData <= Keys.NumPad9)
            {
                int num = keyData - Keys.NumPad0; // convert Keys.NumPad1 -> 1, etc.
                FocusButton(num);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
