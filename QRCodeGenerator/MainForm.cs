using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
namespace QRCodeGeneratorApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inputTextBox.Text))
            {
                pictureBox1.Image = null;
                return;
            }
            var QRImage = QRGenerator.GenerateQRCode(inputTextBox.Text);
            pictureBox1.Image = QRImage;
        }

        private void SaveQRButton_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image == null) MessageBox.Show("Отсутствует QR код для сохранения","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG file (*.png)|*.png";
            saveFileDialog.RestoreDirectory = true;
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}
