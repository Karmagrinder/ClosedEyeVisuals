using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Imaging;
using System.Drawing;
using System.Drawing.Imaging;

namespace ClosedEyedVisualsApp
{
    public class TemplateDetection
    {
        private static float threshold; // 0.925f 
        private static Bitmap sourceImage;
        private static Bitmap templateImage;
        private static TemplateMatch[] matchings;
        private static float similarityMax;
        private static Rectangle regionOfInterest;
        private static int pyramidLevels;

        public TemplateDetection(InputDataHandler inputData) {

            if (float.IsNaN(inputData.Threshold))
            {
                throw new ClosedEyedVisuals_Exception(" Threshold value is not a number.");
            }

            else if (inputData.SourceImage == null)
            {
                throw new ClosedEyedVisuals_Exception("Source image is null");
            }
            else if (inputData.TemplateImage == null)
            {
                throw new ClosedEyedVisuals_Exception("Template Image is null");
            }

            sourceImage = inputData.SourceImage;
            templateImage = inputData.TemplateImage;
            regionOfInterest = new Rectangle(inputData.RoiPointX, inputData.RoiPointY, inputData.RoiWidth, inputData.RoiHeight );
            pyramidLevels = inputData.PyramidLevels;
            threshold = inputData.Threshold;



        }


         public TemplateMatchingResults FindTemplateInROI()
        {
            TemplateMatchingResults results = new TemplateMatchingResults();
            similarityMax = 0f;
            ExhaustiveTemplateMatching exhaustiveTemplateMatching = new ExhaustiveTemplateMatching(threshold);
            matchings = exhaustiveTemplateMatching.ProcessImage(sourceImage, templateImage, regionOfInterest);
            BitmapData data = sourceImage.LockBits(
                            new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
                            ImageLockMode.ReadWrite, sourceImage.PixelFormat);
            foreach (TemplateMatch m in matchings)
            {
                Drawing.Rectangle(data, m.Rectangle, Color.Red); // Adding rectangles in the areas of possible matches
                // do something else with matching
                if (m.Similarity > similarityMax)
                {
                    similarityMax = m.Similarity;
                }
                results.NumberOfMatches++;
            }
            sourceImage.UnlockBits(data);
            sourceImage.Save("SourceImage_Processed.bmp", ImageFormat.Bmp); //Saving the image.
         
            if (similarityMax >= threshold)
            {
                results.MatchFound = true;
            }
            else {
                results.MatchFound = false;
            }

            results.SimilarityMax = similarityMax;
            return results;
        }


        public TemplateMatchingResults FindTemplateInImageExhaustively()
        {
            TemplateMatchingResults results = new TemplateMatchingResults();
            int i = 0;
            int divisor;
            similarityMax = 0f;
            ExhaustiveTemplateMatching exhaustiveTemplateMatching = new ExhaustiveTemplateMatching(threshold);
            results.MatchFound = false;
            while ((results.MatchFound == false) && (i < pyramidLevels))
            {
                divisor = pyramidLevels - i;
                if (divisor != 0){
                    Rectangle sourceImageRegion = new Rectangle(0, 0, sourceImage.Width / divisor, sourceImage.Height / divisor);
                    matchings = exhaustiveTemplateMatching.ProcessImage(sourceImage, templateImage, sourceImageRegion);

                    foreach (TemplateMatch m in matchings){
                        if (m.Similarity > threshold){
                            results.MatchFound = true;
                            results.NumberOfMatches++;
                            if (m.Similarity > similarityMax){
                                similarityMax = m.Similarity;
                            }
                        }
                        else {
                            results.MatchFound = false;
                        }
                    }
                }
                i++;
            }
            results.SimilarityMax = similarityMax;
            return results;

        }

    }
}
