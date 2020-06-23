using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace base64decoder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        byte[] _res = null;

        private void button1_Click(object sender, EventArgs e)
        {
            _res = FromBase64(textBox1.Text);

            if (_res == null)
                return;

            var d = new SaveFileDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(d.FileName, _res);
            }
        }

        private byte[] FromBase64(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                MessageBox.Show("BASE64 string not set");
                return null;
            }

            byte[] res = null;
            try
            {
                res = Convert.FromBase64String(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading BASE64: " + ex.Message);
            }

            return res;
        }
    }
}
