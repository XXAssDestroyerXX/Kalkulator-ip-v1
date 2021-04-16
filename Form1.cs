using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        static Regex rgx = new Regex(@"(^|\.)0+(?!\.|$)", RegexOptions.Compiled);
        public Form1()
        {
            InitializeComponent();
        }
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        }
        private void label4_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String ipString = maskedTextBox1.Text;
            ipString = rgx.Replace(ipString, ".");
            IPAddress ipAddress = IPAddress.Parse(ipString);
            IPAddress maskAddress = IPAddress.Parse(maskedTextBox2.Text);
            byte[] ip = ipAddress.GetAddressBytes();
            byte[] mask = maskAddress.GetAddressBytes();
            IPNetwork network = IPNetwork.Parse(ipAddress.ToString(), maskAddress.ToString());
            maskedTextBox3.Text = network.Network.ToString();
            maskedTextBox4.Text = network.Broadcast.ToString();
            maskedTextBox6.Text = network.FirstUsable.ToString();
            maskedTextBox5.Text = network.LastUsable.ToString();
        }
        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        { }
        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        { }
        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        { }
        private void maskedTextBox6_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        { }
        private void maskedTextBox5_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        { }
    }
}
