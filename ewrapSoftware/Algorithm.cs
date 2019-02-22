using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ewrapSoftware
{

    /// <summary>
    /// abstract class for all algorithms except TFIDF
    /// </summary>
    abstract class Algorithm
    {
        // each class has an initlization of two strings
        public abstract void initlize(string leftInput, string topInput);
        // each class has a run service regarding to threshold
        // return 1 if the email is spam
        // return 0 if the email is ham
        public abstract int run(float threshold);
    }

    /// <summary>
    /// Longest Common Subsequence Problem
    /// </summary>
    class LCSWord : Algorithm
    {
        string topInput;
        string leftInput;

        /* the value in matrix is 8 bits long 
         * we capture the 2 most significant bits as indicator
         * 00 NOT VALUED
         * 01 COPYIED FROM WEST
         * 10 COPYIED FROM NORTH
         * 11 COPYIED FROM NORTH WEST
         * the remaining is the score value of 6 bits, 0 to 63
         * Therfore the limit for this method is
         * a string of 64 charecters or a sentence of 64 words
         */
        byte[,] matrix;
        int height;
        int width;
        string output;

        public LCSWord()
        {

        }
        public override void initlize(string top, string left)
        {
            // initilzing data
            height = left.Length + 1;
            width = top.Length + 1;
            // creating the matrix

            matrix = new byte[height, width];
            topInput = " " + top;
            leftInput = " " + left;
            fillTable();
        }
        public LCSWord(string top, string left)
        {
            // initilzing data
            height = left.Length + 1;
            width = top.Length + 1;
            // creating the matrix

            matrix = new byte[height, width];
            topInput = " " + top;
            leftInput = " " + left;
            fillTable();
        }

        public override int run(float threshold)
        {
            int h = height - 1;
            int w = width - 1;


            if (leftInput == topInput)
                return 1;


            int outputSize = findMax();
            /* calculate the distance of the diagonal
             * diagonal = squar root of h^2 + w^2
             * the score is calculated as the percentage of the similarity 
            */
            double diagonal = (height + width) / 2;
            double score = 1 - (((diagonal - outputSize) / diagonal) * 1);
            if (score < threshold)
                return 0;

            return 1;
        }

        /// <summary>
        /// FINDING MAX
        /// </summary>
        /// <returns></returns>
        public int findMax()
        {
            int max = matrix[0, 0];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (max < (matrix[i, j] & 0X3F))
                        max = matrix[i, j] & 0X3F;
                }

            }
            return max;
        }
        private void fillTable()
        {
            int h = height;
            int w = width;

            for (int i = 1; i < h; i++)
            {
                for (int j = 1; j < w; j++)
                {
                    //
                    if (leftInput[i] == topInput[j])
                    {
                        matrix[i, j] = (byte)(matrix[i - 1, j - 1] + 0X01);        // saving the score in the matrix
                        matrix[i, j] |= 0XC0;                                      // or with 1100 0000 indicating northWest
                    }
                    else
                    {
                        if ((matrix[i - 1, j] & 0X3F) >= (matrix[i, j - 1] & 0X3F))   //  ignoring 2 MSB and with 00 11 1111
                        {
                            matrix[i, j] = (byte)(matrix[i - 1, j] & 0X3F);
                            matrix[i, j] |= 0X80;                                      // or with 1000 0000 inidication North
                        }
                        else
                        {
                            matrix[i, j] = (byte)(matrix[i, j - 1] & 0X3F);
                            matrix[i, j] |= 0X40;                                      // or with 0100 0000 inidication West
                        }
                    }
                }
            }


        }
        private void findResult(int i, int j)
        {
            if ((i > 0) && (j > 0))
            {
                if (matrix[i, j] >> 6 == 0X03)                 // north west
                {
                    findResult(i - 1, j - 1);
                    output += leftInput[i];


                }
                else
                {
                    if (matrix[i, j] >> 6 == 0X02)         // north
                        findResult(i - 1, j);
                    else
                        findResult(i, j - 1);
                }
            }


        }



    }
    /// <summary>
    /// This class finds the distance between two strings
    /// and then from the threshold indicates that if the 
    /// email is ham or spam 
    /// </summary>

    class Levenshtien : Algorithm
    {
        string topInput;
        string leftInput;

        
        byte[,] matrix;
        int height;
        int width;

        public Levenshtien()
        {

        }
        public override void initlize(string top, string left)
        {
            // initilzing data
            height = left.Length + 1;
            width = top.Length + 1;
            // creating the matrix

            matrix = new byte[height, width];

            topInput = " " + top;
            leftInput = " " + left;


            fillTable();
        }
        public Levenshtien(string top, string left)
        {
            // initilzing data
            height = left.Length + 1;
            width = top.Length + 1;
            // creating the matrix

            matrix = new byte[height, width];

            topInput = " " + top;
            leftInput = " " + left;


            fillTable();
        }

        public override int run(float threshold)
        {
            // if the score is smaller than  threshold return 0
            int output = (int)matrix[height - 1, width - 1];
            /* calculate the distance of the diagonal
             * diagonal = squar root of h^2 + w^2
             * the score is calculated as the percentage of the similarity 
            */
            double diagonal = Math.Sqrt((height * height) + (width * width));
            double score = 1 - ((output / diagonal) * 1);
            if (score < threshold)
                return 0;

            return 1;
        }
        private void fillTable()
        {
            int h = height;
            int w = width;

            for (int i = 0; i < h; i++)
            {
                matrix[i, 0] = (byte)i;
            }
            for (int j = 0; j < w; j++)
            {
                matrix[0, j] = (byte)j;
            }
            byte substitutionCost = 0;

            for (int j = 1; j < w; j++)
            {
                for (int i = 1; i < h; i++)
                {
                    if (leftInput[i] == topInput[j])
                        substitutionCost = 0;
                    else
                        substitutionCost = 1;
                    // finds the minimum value in given 3 values
                    matrix[i, j] = (byte)Minimum(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1, matrix[i - 1, j - 1] + substitutionCost);
                }
            }


        }
        /// <summary>
        /// find the minimum value
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private int Minimum(int a, int b, int c)
        {
            if (a < b && a < c)
                return a;
            else
                if (b < c)
                    return b;
                else
                    return c;

        }
    }

    /// <summary>
    /// this class indicaties the similarites between two strings
    /// 
    /// </summary>
    class Jaro : Algorithm
    {
        string topInput;
        string leftInput;

        public override void initlize(string top, string left)
        {
            // initilzing data
            topInput = top;
            leftInput = left;
            // creating the matrix

        }

        public override int run(float threshold)
        {
            // if the score is smaller than  threshold return 0
            if (topInput.Length == 0 || leftInput.Length == 0)
                return 0;

            if (topInput == leftInput)
                return 1;

            int[] matchedChars = findMatches(topInput, leftInput);
            float matches = matchedChars[0];
            if (matches == 0)
            {
                return 0;
            }
            // the calculator of distance
            double originalScore = ((matches / topInput.Length + matches / leftInput.Length + (matches - matchedChars[1]) / matches)) / 3;


            double score = originalScore;



            if (score < threshold)
                return 0;

            return 1;
        }


        /// <summary>
        /// a function to find the matches  of two given strings s1 and s2
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        protected int[] findMatches(string s1, string s2)
        {
            string max, min;
            if (s1.Length > s2.Length)
            {
                max = s1;
                min = s2;
            }
            else
            {
                max = s2;
                min = s1;
            }
            int range = Math.Max(max.Length / 2 - 1, 0);
            int[] match_indexes = new int[min.Length];

            for (int i = 0; i < match_indexes.Length; i++)
            {
                match_indexes[i] = -1;
            }


            bool[] match_flags = new bool[max.Length];
            int matches = 0;
            for (int mi = 0; mi < min.Length; mi++)
            {
                char c1 = min[mi];
                for (int xi = Math.Max(mi - range, 0),
                        xn = Math.Min(mi + range + 1, max.Length);
                        xi < xn;
                        xi++)
                {
                    if (!match_flags[xi] && c1 == max[xi])
                    {
                        match_indexes[mi] = xi;
                        match_flags[xi] = true;
                        matches++;
                        break;
                    }
                }
            }
            char[] ms1 = new char[matches];
            char[] ms2 = new char[matches];
            for (int i = 0, si = 0; i < min.Length; i++)
            {
                if (match_indexes[i] != -1)
                {
                    ms1[si] = min[i];
                    si++;
                }
            }
            for (int i = 0, si = 0; i < max.Length; i++)
            {
                if (match_flags[i])
                {
                    ms2[si] = max[i];
                    si++;
                }
            }
            int transpositions = 0;
            for (int mi = 0; mi < ms1.Length; mi++)
            {
                if (ms1[mi] != ms2[mi])
                {
                    transpositions++;
                }
            }
            int prefix = 0;
            for (int mi = 0; mi < min.Length; mi++)
            {
                if (s1[mi] == s2[mi])
                {
                    prefix++;
                }
                else
                {
                    break;
                }
            }
            // return the required data in shape of an array
            return new int[] { matches, transpositions / 2, prefix, max.Length };
        }
    }
    /// <summary>
    /// same as Jaro, but with slight advancement
    /// </summary>

    class JaroWinker : Jaro
    {
        string topInput;
        string leftInput;

        public override void initlize(string top, string left)
        {
            // initilzing data
            topInput = top;
            leftInput = left;
            // creating the matrix

        }

        public override int run(float threshold)
        {
            // if the score is smaller than  threshold return 0
            if (topInput.Length == 0 || leftInput.Length == 0)
                return 0;

            if (topInput == leftInput)
                return 1;

            int[] matchedChars = findMatches(topInput, leftInput);
            float matches = matchedChars[0];
            if (matches == 0)
            {
                return 0;
            }
            double originalScore = ((matches / topInput.Length + matches / leftInput.Length + (matches - matchedChars[1]) / matches)) / 3;


            double score = originalScore;


            // jaro winker distance (the differnece between both jaro's) 
            if (originalScore > threshold)
            {
                score = originalScore + Math.Min(0.1, 1.0 / matchedChars[3]) * matchedChars[2] * (1 - originalScore);
            }

            if (score < threshold)
                return 0;

            return 1;
        }
    }
    /// <summary>
    ///  read the algorithm link
    /// </summary>
    class BGram : Algorithm
    {
        string topInput;
        string leftInput;
        private int n;
        public override void initlize(string top, string left)
        {
            // initilzing data
            topInput = top;
            leftInput = left;
            // creating the matrix

        }

        public BGram(int theN = 2)
        {
            n = theN;
        }

        public override int run(float threshold)
        {
            // if the score is smaller than  threshold return 0
            if (topInput.Length == 0 || leftInput.Length == 0)
                return 0;

            if (topInput == leftInput)
                return 1;

            double score = 1 - distance(topInput, leftInput); ;
            if (score < threshold)
                return 0;

            return 1;
        }

        public double distance(string s0, string s1)
        {


            char special = '\n';
            int sl = s0.Length;
            int tl = s1.Length;


            int cost = 0;
            if (sl < n || tl < n)
            {
                for (int i = 0, ni = Math.Min(sl, tl); i < ni; i++)
                {
                    if (s0[i] == s1[i])
                    {
                        cost++;
                    }
                }
                return (float)cost / Math.Max(sl, tl);
            }

            char[] sa = new char[sl + n - 1];
            float[] p; //'previous' cost array, horizontally
            float[] d; // cost array, horizontally
            float[] d2; //placeholder to assist in swapping p and d

            //construct sa with prefix
            for (int i = 0; i < sa.Length; i++)
            {
                if (i < n - 1)
                {
                    sa[i] = special; //add prefix
                }
                else
                {
                    sa[i] = s0[i - n + 1];
                }
            }
            p = new float[sl + 1];
            d = new float[sl + 1];

            // indexes into strings s and t
            int xi; // iterates through source
            int xj; // iterates through target

            char[] t_j = new char[n]; // jth n-gram of t

            for (xi = 0; xi <= sl; xi++)
            {
                p[xi] = xi;
            }

            for (xj = 1; xj <= tl; xj++)
            {
                //construct t_j n-gram
                if (xj < n)
                {
                    for (int ti = 0; ti < n - xj; ti++)
                    {
                        t_j[ti] = special; //add prefix
                    }
                    for (int ti = n - xj; ti < n; ti++)
                    {
                        t_j[ti] = s1[ti - (n - xj)];
                    }
                }
                else
                {
                    t_j = new char[xj - (xj - n)];
                    for (int k = 0; k < t_j.Length; k++)
                    {
                        t_j[k] = s1[(xj - n) + k];
                    }
                }
                d[0] = xj;
                for (xi = 1; xi <= sl; xi++)
                {
                    cost = 0;
                    int tn = n;
                    //compare sa to t_j
                    for (int ni = 0; ni < n; ni++)
                    {
                        if (sa[xi - 1 + ni] != t_j[ni])
                        {
                            cost++;
                        }
                        else if (sa[xi - 1 + ni] == special)
                        {
                            //discount matches on prefix
                            tn--;
                        }
                    }
                    float ec = (float)cost / tn;
                    // minimum of cell to the left+1, to the top+1,
                    // diagonally left and up +cost
                    d[xi] = Math.Min(
                            Math.Min(d[xi - 1] + 1, p[xi] + 1), p[xi - 1] + ec);
                }
                // copy current distance counts to 'previous row' distance counts
                d2 = p;
                p = d;
                d = d2;

            }
            return p[sl] / Math.Max(tl, sl);
        }
    }

    /// <summary>
    ///  different that other string comparsion
    /// it weights each string and then related to its connection it defines
    /// the power of word
    /// </summary>
    class TFIDF
    {
        List<Document> Documents;       // list of all doucments 
        Dictionary<string, int> terms;  // dictionary of term->index

        public TFIDF()
        {

            Documents = new List<Document>();
            terms = new Dictionary<string, int>();
            
        }

        public Dictionary<string, int> Terms
        {
            set
            {
                // propety design
                int index = 0;
                terms = new Dictionary<string, int>();
                foreach (var item in value)
                {
                    terms.Add(item.Key.ToLower(), index++);
                }

            }
            get
            {
                return terms;
            }
        }

        public void addDocument(string [] words , bool SPAM)
        {
            // add each document for each row

            if (words.Length > 0)
            {
                Document newDocument = new Document(terms.Count, words.Length, SPAM);
                newDocument.fillTable(terms, words);
                Documents.Add(newDocument);
            }
        }


        public void print ()
        {
            foreach (var item in Documents)
            {
                Console.WriteLine("{0}->{1}", item.isSpam, item.Score());
            }
        }

       

        public void run ()
        {
            // the run function which checks the weights 

            double documentCounter = Documents.Count;
            foreach (var item in terms)
            {
                double IDF = 0;

                int index = item.Value;
                double sum = 0;
                foreach (var document in Documents)
                {
                    sum += document.Score(index);
                }

                if (sum > 0)
                {
                    IDF = Math.Log10(documentCounter / sum);
                    // see https://en.wikipedia.org/wiki/Tf%E2%80%93idf

                }

                foreach (var document in Documents)
                {
                    // calculate the score again
                    document.Score(index, IDF);
                }
            }
        }



        internal void claculate(ref int hamScores, ref int spamScores, float threshold)
        {
            foreach (var item in Documents)
            {
                 double sum = item.Score() * 10000;          // gap
                                                            // if we change 1000, it changes accuracy
                if (sum>threshold)
                {
                    if (item.isSpam)
                    {
                        spamScores++;
                    }
                    else
                    {
                        hamScores++;
                    }
                }

            }
        }
    }

    // this class is only used in TFIDF
    class Document
    {
        bool spam;                      // indicate if the doucment is spam or not
        int wordcount;                  // how many words are in the document
        double[] scores;                // each term's score agianst the document
        public Document (int size, int words, bool SPAM )
        {
            
            scores = new double[size];  // initilizing the scoring array
            wordcount = words;          // initilizing the word counter
            spam = SPAM;                // initilizing the flag
            for (int i = 0; i < size; i++)
            {
                scores[i] = 0;          // not sure if this is neccessary
            }
        }

        public void fillTable (Dictionary<string,int> terms, string [] words)
        {
                        // this function , counts each terms frequency in the doucment
            foreach (string word in words)
            {
                if (terms.ContainsKey(word.ToLower()))
                {
                    int index = terms[word.ToLower()];
                    scores[index] += 1;
                }
            }
        }

        public double Score (int index)
        {
            return scores[index];

        }
        public void Score (int index, double IDF)
        {
            // calculating the new score
            double oldScore = scores[index];
            double TF = oldScore / wordcount;
            double TFIDF = TF * IDF;
            scores[index] = TFIDF;
        }

        public double Score ()
        {
            double sum = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                sum += scores[i];
            }
            return sum;
        }

        public bool isSpam
        {
            get { return spam; }
        }
    }
}