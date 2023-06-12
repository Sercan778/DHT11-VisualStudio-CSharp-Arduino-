using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sıcaklık_tamamlandı__visual_
{
    public partial class Form1 : Form
    {
        string[] portlistesi;
        SerialPort port;
        private string data;
        private string data1;
        public Form1()
        {
            InitializeComponent();
            groupBox2.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            pictureBox4.Visible = false;
        }
        void portlistele()
        {
            comboBox1.Items.Clear();
            portlistesi = SerialPort.GetPortNames();
            foreach (string portadi in portlistesi)
            {
                comboBox1.Items.Add(portadi);
                if (portlistesi[0] != null)
                {
                    comboBox1.SelectedItem = portlistesi[0];
                }
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            portlistele();
            timer1.Enabled = true;
            textBox1.ReadOnly = true;
            textBox3.ReadOnly = true;
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(SerialDataReceived);
        }

        private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            data = serialPort1.ReadLine();
            data1 = serialPort1.ReadLine();
            this.Invoke(new EventHandler(displayData_event));
        }

        private void displayData_event(object sender, EventArgs e)
        {
            textBox1.Text = data;
            textBox3.Text = data1;
            progressBar1.Value=Convert.ToInt32(data);
            progressBar2.Value = Convert.ToInt32(data1);
            if(progressBar1.Value> 0&&progressBar1.Value<20)
            {
                progressBar1.ForeColor = Color.Blue;
            }
            if (progressBar1.Value > 19 && progressBar1.Value < 30)
            {
                progressBar1.ForeColor = Color.Yellow;
            }
            if (progressBar1.Value > 29 && progressBar1.Value <40)
            {
                progressBar1.ForeColor = Color.Red;
            }
            if (progressBar2.Value > 0 && progressBar2.Value < 40)
            {
                progressBar1.ForeColor = Color.Blue;
            }
            if (progressBar2.Value > 39 && progressBar2.Value < 70)
            {
                progressBar1.ForeColor = Color.Yellow;
            }
            if (progressBar2.Value > 69 && progressBar2.Value < 100)
            {
                progressBar1.ForeColor = Color.Red;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
                    serialPort1.PortName = comboBox1.GetItemText(comboBox1.SelectedItem);
                    serialPort1.BaudRate = 9600;
                    serialPort1.Open();
                    pictureBox1.Visible = false; pictureBox2.Visible = true; pictureBox3.Visible = false; pictureBox4.Visible = true;
                    groupBox2.Visible = true; groupBox2.Visible = true;
          
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true; pictureBox2.Visible = false; pictureBox3.Visible = true; pictureBox4.Visible = false;
            groupBox2.Visible = false;
            port.Close();
            textBox1.Text = "0";
            progressBar1.Value = 0;
            textBox2.Text = "0";
            progressBar2.Value = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string x = comboBox1.SelectedItem.ToString();
            serialPort1.PortName = x;
            serialPort1.BaudRate = 9600;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox2.Text = DateTime.Now.ToLongTimeString();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
