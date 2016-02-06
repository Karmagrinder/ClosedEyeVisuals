using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Imaging;
using System.Drawing;
//using System.Drawing.Imaging;

namespace ClosedEyedVisualsApp
{
    public class InputDataHandler
    {
        public float Threshold { get; set; }
        public Bitmap SourceImage { get; set; }
        public Bitmap TemplateImage { get; set; }
        public int RoiPointX { get; set; }
        public int RoiPointY { get; set; }
        public int RoiWidth { get; set; }
        public int RoiHeight { get; set; }
        public int PyramidLevels { get; set; }
        
    }
}
