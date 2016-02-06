using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosedEyedVisualsApp
{
    public class TemplateMatchingResults
    {
        public bool MatchFound { get; set; }
        public float SimilarityMax { get; set; }
        public int NumberOfMatches { get; set; }
    }
}
