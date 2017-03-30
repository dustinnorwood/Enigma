using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enigma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string key = keyBox.Text.PadRight(16, ' ');
            int numBlocks = plaintextBox.Text.Length / 16 + 1;
            ciphertextBox.Text = Rijndael.Encrypt(plaintextBox.Text.PadRight(16 * numBlocks, '\0'), key);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string key = keyBox.Text.PadRight(16, ' ');
            int numBlocks = ciphertextBox.Text.Length / 16 + 1;
            plaintextBox.Text = Rijndael.Decrypt(ciphertextBox.Text.PadRight(16 * numBlocks, '\0'), key);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sha512 sha = new Sha512(keyBox.Text);
            hashBox.Text = sha.HashString;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap b = new Bitmap(ofd.FileName);
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                Matrix m = new Matrix(b);
                pictureBox1.Image = m.ToBitmap();
                Bitmap bh = new Bitmap("C:\\Users\\Dustin\\Pictures\\es.jpg");
                Bitmap b2 = Steganography.EmbedToDCT(b, bh);
                if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
                pictureBox2.Image = b2;
                b2.Save("C:\\Users\\Dustin\\Desktop\\es.jpg");

            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap b = new Bitmap(ofd.FileName);
                if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
                Matrix m = new Matrix(b);
                Bitmap b2 = DCT.BlockedReverse(m).ToBitmap();
                b2.Save("C:\\Users\\Dustin\\Desktop\\hansidct.png");
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                pictureBox1.Image = b2;
            }
        }

        private void fileButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap b = new Bitmap(ofd.FileName);
                if (pictureBox3.Image != null) pictureBox3.Image.Dispose();
                pictureBox3.Image = b;
            }
        }

        private void embedButton3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 16)
                Steganography.EmbedToLSB((Bitmap)pictureBox3.Image, textBox3.Text, comboBox1.SelectedIndex);
            else
            {
                Steganography.EmbedToLSB((Bitmap)pictureBox3.Image, textBox3.Text, comboBox1.SelectedIndex, int.Parse(xBox.Text), int.Parse(yBox.Text));
            }
            pictureBox3.Invalidate();
            pictureBox3.Update();
        }

        private void retrieveButton3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 16)
            {
                string s = Steganography.ExtractFromLSB((Bitmap)pictureBox3.Image, comboBox1.SelectedIndex);
                textBox3.Text = s;
            }
            else
            {
                string s = Steganography.ExtractFromLSB((Bitmap)pictureBox3.Image, comboBox1.SelectedIndex, int.Parse(xBox.Text), int.Parse(yBox.Text));
                textBox3.Text = s;
            }
            pictureBox3.Invalidate();
            pictureBox3.Update();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 15)
            {
                label1.Visible = true;
                label2.Visible = true;
                xBox.Visible = true;
                yBox.Visible = true;
            }
            else
            {
                label1.Visible = false;
                label2.Visible = false;
                xBox.Visible = false;
                yBox.Visible = false;
            }
        }
    }
}
