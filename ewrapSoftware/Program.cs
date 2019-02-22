using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ewrapSoftware
{
    // the algorithm Box 
    enum AlgorithmBox { LCS, Levenshtein, Jaro, JaroWinker, BiGram, TFIDF};


    /// <summary>
    /// This structure is used for static 
    /// </summary>
    struct staticSet
    {

        public float time;                  // TIME of Process
        public float spamper;               // Spam Percision
        public float spamrecall;            // Spam Recall
        public float fpositives;            // False Positives
        public float fnegatives;            // False Negatives
        public float totalham;              // Total Hams
        public float totalspam;             // Total Spams
        public float accuracy;              // calculated accuracy
        public staticSet(float value)
        {
            spamrecall = time = spamper = fpositives = fnegatives = totalham = totalspam = accuracy = value;
        }
    }


    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
 
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          Application.Run(new FrameworkForm());

        }
    }
}
