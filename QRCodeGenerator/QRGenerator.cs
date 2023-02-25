using System.Windows.Forms;
using ZXing.Windows.Compatibility;


namespace QRCodeGeneratorApp
{
    public static class QRGenerator
    {
        /// <summary>
        /// Метод генерирующий QR код и возвращающий Image с этим кодом
        /// </summary>
        /// <param name="textToEncode">Текст который нужно закодировать</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap GenerateQRCode(string textToEncode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textToEncode)) return null;

                var barcodeWriter = new BarcodeWriter()
                {
                    Format = ZXing.BarcodeFormat.QR_CODE,
                    Options = new ZXing.Common.EncodingOptions
                    {
                        Width = 220,
                        Height = 220,
                    }
                };
                barcodeWriter.Options.Hints.Add(ZXing.EncodeHintType.CHARACTER_SET, "UTF-8");
                var result = barcodeWriter.Write(textToEncode);
                return result;
            }
            catch (ZXing.WriterException) 
            {
                MessageBox.Show("Слишком большой объем данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
