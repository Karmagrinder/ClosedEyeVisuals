using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tessnet2;
using System.Drawing;
using System.Drawing.Imaging;



namespace ClosedEyedVisualsApp
{
    public class ClosedEyeVisualsOCR
    {

        public List<Word> GetTextFromImage( Bitmap image)
        {
            List<Word> result;
            try
            {
                var ocr = new Tesseract();
                //ocr.SetVariable("tessedit_char_whitelist", "0123456789");
                ocr.SetVariable("tessedit_char_whitelist", "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"); 
                ocr.Init("tessdata", "eng", false);
                result = ocr.DoOCR(image, Rectangle.Empty);
            }
            catch (Exception e)
            {
                throw new ClosedEyedVisuals_Exception("OCR error:" + e.ToString());
            }

            return result;
        } 

    }
}
