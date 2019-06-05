using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
namespace MonitoringTool
{
    public partial class Form2 : Form
    {
        //Listataan järjestyksessä Object, Counter sekä Instance. Jos Counteria tai Instancea ei ole, jätetään tyhjäksi. 
        PerformanceCounter perfCPUcounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        PerformanceCounter perfCPUPower = new PerformanceCounter("Processor Information", "Processor Frequency", "_Total");
        PerformanceCounter perfMEMcounter = new PerformanceCounter("Memory", "Available MBytes");
        PerformanceCounter perfsystemCounter = new PerformanceCounter("System", "System Up Time");
        PerformanceCounter perfNetworkIn = new PerformanceCounter("Network Interface", "Bytes Received/sec", "Realtek PCIe GBE Family Controller");
        PerformanceCounter perfNetworkSent = new PerformanceCounter("Network Interface", "Bytes Sent/sec", "Realtek PCIe GBE Family Controller");
        PerformanceCounter perfDiskReadD = new PerformanceCounter("LogicalDisk", "Avg. Disk Bytes/Read", "_Total");
        PerformanceCounter perfDiskWriteD = new PerformanceCounter("LogicalDisk", "Avg. Disk Bytes/Write", "_Total");



        public Form2()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "CPU Load:" + "   " + (int)perfCPUcounter.NextValue() + "   " + "% ";
            label2.Text = "Free Memory:" + "  " + (int)perfMEMcounter.NextValue() + "  " + "MB";
            label3.Text = "System Uptime:" + "  " + (int)perfsystemCounter.NextValue() / 60 /60 + "  " + "Hours";
            label4.Text = "OUT: " + "  " + (int)perfNetworkSent.NextValue() + "  " + "Bytes/s";
            label5.Text = "IN: " + "  " + (int)perfNetworkIn.NextValue() + "  " + "Bytes/s";
            label9.Text = "AVG Read " + "  " + (int)perfDiskReadD.NextValue() + "  " + "Bytes/s";
            label8.Text = "AVG Write " + "  " + (int)perfDiskReadD.NextValue() + "  " + "Bytes/s";
            label10.Text = "CPU MHz: " + "  " + (int)perfCPUPower.NextValue();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string message;
            var dir = @"D:\Tiedostot\PcDiagnostics";
            message =   label1.Text + "\r\n" + label10.Text + "\r\n" + label2.Text + "\r\n" + label4.Text 
                        + "\r\n" + label5.Text + "\r\n" + label9.Text + "\r\n" + label8.Text + "\r\n" +
                         label3.Text + "\r\n";
            MessageBox.Show(message + "Information has been saved", "Data save");

            if (!Directory.Exists(dir))  // Jos ei kansiota olemassa, luo uuden
                System.IO.Directory.CreateDirectory(dir);

            File.AppendAllText(System.IO.Path.Combine(dir, textBox1.Text.ToString()), label1.Text + "\r\n" + label10.Text + "\r\n" +  label2.Text + "\r\n" + "\r\n" +
                                                                                      label4.Text + "\r\n" + label5.Text + "\r\n" + "\r\n" + label9.Text + "\r\n" + 
                                                                                      label8.Text + "\r\n" + "\r\n" + label3.Text + "\r\n" + "\r\n" +
                                                                                      "DATE: " + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm") + "\r\n" +
                                                                                      "- - - - - - - - - -" + "\r\n");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Change save file just writing your own file name." + "\r\n" + 
                            "Common is standard savefile name" + "\r\n" +
                             "You can use different names for your save file"
                             + "\r\n" + "Software will autosave stats every 15minutes", "?");     
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {

            //Saves automaticly every 1hrs
   
            var dir = @"D:\Tiedostot\PcDiagnostics";
            if (!Directory.Exists(dir))  // Jos ei kansiota olemassa, luo uuden
                System.IO.Directory.CreateDirectory(dir);

            File.AppendAllText(System.IO.Path.Combine(dir, textBox1.Text.ToString()), "AUTOSAVE" + "\r\n" +
                                                                                      label1.Text + "\r\n" + label10.Text + "\r\n" + label2.Text + "\r\n" + "\r\n" +
                                                                                      label4.Text + "\r\n" + label5.Text + "\r\n" + "\r\n" + label9.Text + "\r\n" +
                                                                                      label8.Text + "\r\n" + "\r\n" + label3.Text + "\r\n" + "\r\n" +
                                                                                      "DATE: " + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm") + "\r\n" +
                                                                                      "- - - - - - - - - -" + "\r\n");
        }
    }
}
