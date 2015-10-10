using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace GujAThon
{
    public partial class Form1 : Form
    {

        private static Color[,] pixelColor = new Color[500, 500];
        private static string txtFileContent = "";
        private static byte[,] blueValue = new byte[500, 500];
        public Form1()
        {
            InitializeComponent();
            richTextBox1.AppendText("Program Initialization....\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Bitmap myBitmap = new System.Drawing.Bitmap(openFileDialog1.FileName);
                richTextBox1.AppendText(openFileDialog1.FileName + "File Selected....\n");
                var img = Image.FromFile(openFileDialog1.FileName);
                int width = img.Width;
                int height = img.Height;
                richTextBox1.AppendText("Conversion of .bmp to .txt is in Progress....\n");
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        pixelColor[i, j] = myBitmap.GetPixel(i, j);
                    }
                }
                richTextBox1.AppendText("Conversion Complete....\n");
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        blueValue[i, j] = pixelColor[i, j].B;
                        if (blueValue[i, j] == 255) blueValue[i, j] = 0;
                        else blueValue[i, j] = 1;
                        txtFileContent = txtFileContent + blueValue[i, j].ToString();
                    }
                }

                System.IO.StreamWriter file = new System.IO.StreamWriter("R:\\Testing Debug.txt");
                file.WriteLine(txtFileContent);
                richTextBox1.AppendText("");
                file.Close();
                richTextBox1.AppendText(".txt File Generated....\n");
                openFileDialog1.Dispose();
                richTextBox1.AppendText("Communication Commencing....\n");
                SerialPort port = new SerialPort("COM3", 9600); // Change according to Arduino Port
                port.Open();
                richTextBox1.AppendText("Communication Start....\n");
                char[] inbuf = new char[50];
                port.Write(blueValue[0, 0].ToString());
                for (int i = 0; i < width; i++)
                {
                    for (int j = 1; j < height; j++)
                    {
                        while (port.Read(inbuf, 0, 1) != 1) { richTextBox1.AppendText("Waiting For Response....\n"); };
                        port.Write(blueValue[i, j].ToString());
                    }
                    richTextBox1.AppendText(i + "Line Completed....\n");
                }
                port.Close();
                richTextBox1.AppendText("Close the Window OR Select File Again....\n");
            }


        }


    }
}

