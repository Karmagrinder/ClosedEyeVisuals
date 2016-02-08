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
            List<Word> tempResult;
            List<Word> result = new List<Word>();
            try
            {
                var ocr = new Tesseract();
                //ocr.SetVariable("tessedit_char_whitelist", "0123456789");
                ocr.SetVariable("tessedit_char_whitelist", "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789:<>"); 
                ocr.Init("tessdata", "eng", false);
                tempResult = ocr.DoOCR(image, Rectangle.Empty);
                
                // Weed out the bad match results.
                foreach (Word word in tempResult)
                {
                    if (word.Confidence < 160) {
                        result.Add(word);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ClosedEyedVisuals_Exception("OCR error:" + e.ToString());
            }


            return result;
        }


        //private Bitmap ProcessImage(Bitmap image) 
        //{
        //    Bitmap processedImage;
                
        //    image.



        //    return processedImage;
        //}

    }
}
