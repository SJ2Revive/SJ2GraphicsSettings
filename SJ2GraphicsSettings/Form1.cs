using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SJ2GraphicsSettings
{
    public partial class Form1 : Form
    {
        string filePath = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Utils.SaveConfig("C:\\Program Files (x86)\\Symulator Jazdy 2\\Config\\SettingsVideo.txt", textBox2.Text, textBox1.Text, checkBox1.Checked, checkBox2.Checked, textBox3.Text, textBox4.Text, textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Directory.Exists("C:\\Program Files (x86)\\Symulator Jazdy 2"))
            {
                if (Directory.Exists("C:\\Program Files (x86)\\Symulator Jazdy 2\\Config"))
                {
                    filePath = "C:\\Program Files (x86)\\Symulator Jazdy 2\\Config\\SettingsVideo.txt";
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains("RESOLUTION"))
                            {
                                textBox1.Text = line.Split(' ')[1];
                                textBox2.Text = line.Split(' ')[2];
                            }
                            if (line.Contains("COLORDEPTH"))
                            {
                                textBox3.Text = line.Split(' ')[1];
                            }
                            if (line.Contains("FULLSCREEN"))
                            {
                                checkBox1.Checked = Utils.SJ2FormatToBool(line.Split(' ')[1]);
                            }
                            if (line.Contains("VSYNC"))
                            {
                                checkBox2.Checked = Utils.SJ2FormatToBool(line.Split(' ')[1]);
                            }
                            if (line.Contains("MATERIAL_QUALITY"))
                            {
                                textBox4.Text = line.Split(' ')[1];
                            }
                            if (line.Contains("SHADOWS"))
                            {
                                textBox5.Text = line.Split(' ')[1];
                            }
                        }
                    }
                        
                }
                else
                {

                }
            } else
            {
                MessageBox.Show("Po nacisnieciu ok wyskoczy okno o wybranie pliku, wybierz plik nazwany SettingsVideo.txt zlokalizowany w folderze Config ktory jest w folderze sj2\n np. C:/Program Files (x86)/Symulator Jazdy 2/Configs/SettingsVideo.txt ", "Nie udało się automatycznie znaleść SJ2");
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if(line.Contains("RESOLUTION"))
                            {
                                textBox1.Text = line.Split(' ')[1];
                                textBox2.Text = line.Split(' ')[2];
                            }
                            if(line.Contains("COLORDEPTH"))
                            {
                                textBox3.Text = line.Split(' ')[1];
                            }
                            if(line.Contains("FULLSCREEN"))
                            {
                                checkBox1.Checked = Utils.SJ2FormatToBool(line.Split(' ')[1]);
                            }
                            if (line.Contains("VSYNC"))
                            {
                                checkBox2.Checked = Utils.SJ2FormatToBool(line.Split(' ')[1]);
                            } 
                            if(line.Contains("MATERIAL_QUALITY"))
                            {
                                textBox4.Text = line.Split(' ')[1];
                            }
                            if (line.Contains("SHADOWS"))
                            {
                                textBox5.Text = line.Split(' ')[1]; 
                            }
                        }
                        
                    }

                    
                }

            }
        }
    }
}
