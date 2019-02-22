using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ewrapSoftware
{
    public partial class FrameworkForm : Form
    {

        #region Initilazation


        int[] globalScore;                                      // global scoring
        string saveAddress;                                     // addess of static result file
        string[] hamFiles;                                      // list of ham files
        string[] spamFiles;                                     // list of spam files
        List<string> phrases;                                   // list of phrase words
        Dictionary<string, int> phrasePower;                    // dictionary of phrase words
        AlgorithmBox selectedAlgorithm;                         // Selected Algorithm to Test


        public FrameworkForm()
        {
            InitializeComponent();

            // Writing the Radio Options
            algorithmRadio0.Text = AlgorithmBox.LCS.ToString();
            algorithmRadio1.Text = AlgorithmBox.Levenshtein.ToString();
            algorithmRadio2.Text = AlgorithmBox.Jaro.ToString();
            algorithmRadio3.Text = AlgorithmBox.JaroWinker.ToString();
            algorithmRadio4.Text = AlgorithmBox.BiGram.ToString();
            algorithmRadio5.Text = AlgorithmBox.TFIDF.ToString();

            // global variable initilization

            phrasePower = new Dictionary<string, int>();
            selectedAlgorithm = AlgorithmBox.LCS;
            saveAddress = "";


        }

      
        #endregion

        #region Run
        private int Loop (string[] files, decimal limit, Algorithm myAlgorithm )
        {
            int score = 0;
            Thread myRunner;
            int length = (int)limit;
            // global data box for score
            globalScore = new int[length];

            // the selected Threshold
            float threshold = ((float)thresholdValue.Value) / 100F;
          

            int phraseLimit = (int)phraseNumber.Value;
            for (int i = 0; i < length; i++)
            {
                // each thread runs a file
                myRunner = new Thread(() => Run(i, files[i], phraseLimit, threshold, myAlgorithm));
                // the thread is only for the pgrogress bar 
                myRunner.Start();
                myRunner.Join();
                progressBar.Value++;

                score += globalScore[i];
            }

            return score;
        }
        /// <summary>
        /// THIS SMAP LOOP FOR TFIDF Algorithm
        /// </summary>
        /// <param name="files"> all the email files</param>
        /// <param name="limit"> how many emails </param>
        /// <param name="SPAM"> are they spam or not</param>
        /// <param name="obj"> the TFIDF object </param>
        private void Loop (string[] files, decimal limit, bool SPAM , TFIDF obj )
        {
            try
            {
                for (int i = 0; i < (int)limit; i++)
                {

                    StreamReader myFile = new StreamReader(files[i]);
                    string allFile = myFile.ReadToEnd();
                    string[] words = allFile.Split(' ');
                    obj.addDocument(words, SPAM);       // add the document and its words

                }
            }
            catch
            {

            }
            
        }
        /// <summary>
        /// this run is for all 5 algorithms
        /// </summary>
        /// <param name="id"> the id of thread </param>
        /// <param name="fileName"> the filename </param>
        /// <param name="phraseLimit"> the limit of phrases </param>
        /// <param name="threshold"> </param>
        /// <param name="myAlgorithm"> the algorithm definder </param>
        void Run (int id , string fileName,int phraseLimit, float threshold, Algorithm myAlgorithm)
        {
            try
            {

                int score = 0;
               
                StreamReader myFile = new StreamReader(fileName);
                string allFile = myFile.ReadToEnd();
                string[] topInput = allFile.Split(' ');

                foreach (var item in phrasePower)
                {
                    
                    string leftInput = item.Key;
                    score = 0;
                    for (int j = 0; j < topInput.Length; j++)
                    {
                        // the initilization of the algorithm
                        myAlgorithm.initlize(topInput[j], leftInput);
                        // score for each run
                        score += myAlgorithm.run(threshold);
                         
                    }
                    if (score > 0)
                    {
                        globalScore[id] = 1;
                        phrasePower[item.Key] += score;
                    }

                }

                

            }

            catch
            {

            }
            

        }
        /// <summary>
        /// this calcuate the shown statics for each algorithm
        /// </summary>
        /// <param name="hams">list of ham files </param>
        /// <param name="spams">list of spam files </param>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        staticSet calculateStatics(string[] hams, string[] spams, AlgorithmBox algorithm)
        {
            staticSet myStatics = new staticSet(0);

            int hamScores = 0;
            int spamScores = 0;

            myStatics.totalham = (float)hamNumber.Value;
            myStatics.totalspam = (float)spamNumber.Value;
            progressBar.Value = 0;
            progressBar.Maximum = (int)(myStatics.totalham + myStatics.totalspam);

            DateTime tic = DateTime.Now;
            Algorithm myAlgo = null;
            switch (algorithm)
            {
                case AlgorithmBox.LCS:
                    myAlgo = new LCSWord();
                    break;


                case AlgorithmBox.Levenshtein:
                    myAlgo = new Levenshtien();
                    break;

                case AlgorithmBox.Jaro:
                    myAlgo = new Jaro();
                    break;

                case AlgorithmBox.JaroWinker:
                    myAlgo = new JaroWinker();
                    break;

                case AlgorithmBox.BiGram:
                    myAlgo = new BGram();
                    break;
                default:
                    break;
            }
            // we need a conditon here
            if (selectedAlgorithm == AlgorithmBox.TFIDF)
            {
                TFIDF myTFI = new TFIDF();
                myTFI.Terms = phrasePower;
                Loop(hams, hamNumber.Value, false , myTFI);
                Loop(spams, spamNumber.Value, true , myTFI);

                // the TFIDF runner
                myTFI.run();
                float threshold = ((float)thresholdValue.Value) / 100F;
                myTFI.claculate(ref hamScores, ref spamScores, threshold);


            }
            else
            {
                // other runners
                hamScores = Loop(hams, hamNumber.Value, myAlgo);
                spamScores = Loop(spams, spamNumber.Value, myAlgo);
            }



            DateTime toc = DateTime.Now;
            TimeSpan timeSpent = toc - tic;

            // calculate the spent time , a simple timing mechanism
            myStatics.time = (float)timeSpent.TotalSeconds;

            if (myStatics.totalspam > 0)
            {
                // false negatives
                myStatics.fnegatives = (myStatics.totalspam - spamScores) / myStatics.totalspam;

                // spam recall
                myStatics.spamrecall = spamScores / myStatics.totalspam;

                // spam precision
                myStatics.spamper = spamScores / (spamScores + (myStatics.totalham - hamScores));
            }

            if (myStatics.totalham > 0)
            {
                // false positives
                myStatics.fpositives = (myStatics.totalham - hamScores) / myStatics.totalham;
            }

            if (myStatics.totalham > 0 || myStatics.totalspam > 0)
                // accuracy
                myStatics.accuracy = 1 - (((myStatics.totalspam - spamScores) + (myStatics.totalham - hamScores)) / (myStatics.totalham + myStatics.totalspam));

            // Spam recall





            return myStatics;
        }
        #endregion

        #region Methods
        private void fillBox()
        {
            // this method fills the listbox with the words
            // in dictionary 

            wordList.Items.Clear();
            foreach (var item in phrasePower)
            {
                wordList.Items.Add(item);
            }

        }

        private void copyPhrases(int limit)
        {
            // this function will create a new copy of all the phrases
            // from a simple list to a key-value structure
            phrasePower.Clear();

            for (int i = 0; i < limit; i++)
            {
                if (phrasePower.ContainsKey(phrases[i])==false)
                    phrasePower.Add(phrases[i], 0);
            }

            wordList.Enabled = true;
            deleteBTM.Enabled = true;
            fillBox();
        }

    

        private void setPhrases(decimal limit)
        {
            // this functioncreates a load of phrases
            // and copy them to the text

            phraseLabel.Text = string.Format("There are {0} phrases loaded, how many would you like to use?", phrases.Count);
            phraseNumber.Minimum = 1;
            phraseNumber.Maximum = phrases.Count;
            phraseNumber.Value = limit;
            phraseNumber.Enabled = true;
        }

        private void saveLogFile(staticSet newResults)
        {
            // this function writes the new static results to a file

            if (saveAddress == "") 
                saveAddress = browseFile();

            loadText.Text = saveAddress;
            

            bool append = false;

            // headers
            string[] newLine = {"ID", "Date", "Time", "Data Set", "Phrase File" ,
                                "Total Spams", "Total Hams","Total Used Phrases",
                                "Algorithm", "Threshold","Time Spend (seconds) ",
                                "Accuracy", "False Positives", "False Negatives",
                                "Spam Recall", "Spam Precision"}; 

           
            append = File.Exists(saveAddress);
        

                
            // write the statics into a line in the list
          

            // write all lines
            try
            {
                StreamWriter writer = new StreamWriter(saveAddress, append);
                if (!append)
                {
                    WriteFile(ref writer, newLine);
                }

                newLine = writeStatics(newResults);
                WriteFile(ref writer, newLine);
                writer.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WriteFile(ref StreamWriter file, string[] data)
        {
            // write the data to the file

            int i = 0;
            for (i = 0; i < data.Length - 1; i++)
            {
                file.Write("{0}, ", data[i]);
            }
            file.Write(data[i]);
            file.WriteLine();
        }

        private  string[] writeStatics (staticSet newResults)
        {
            // create an array of strings out of static data

            
            string [] output = new string[16];

            output[0] = "0";                                    // ID
            output[1] = DateTime.Now.Date.ToString();           // Today's Date
            output[2] = DateTime.Now.TimeOfDay.ToString();      // now s time
            output[3] = datasetFolder.Text;                     // address of dataset
            output[4] = phraseFile.Text;                        // address of phrase files
            output[5] = newResults.totalspam.ToString();        // total spams used
            output[6] = newResults.totalham.ToString();         // total hams used
            output[7] = phraseNumber.Value.ToString();          // total phrases used
            output[8] = selectedAlgorithm.ToString();           // algorithm used
            output[9] = (thresholdValue.Value/100).ToString();  // value of thrshold
            output[10] = newResults.time.ToString();            // time spent
            output[11] = newResults.accuracy.ToString();        // accuracy
            output[12] = newResults.fpositives.ToString();      // false positives
            output[13] = newResults.fnegatives.ToString();      // false negatives
            output[14] = newResults.spamrecall.ToString();      // spam recall
            output[15] = newResults.spamper.ToString();         // spam precision
               


            return output;
        }

        private string browseFile()
        {
            // simple file browser


            try
            {
                using (var saveDiag = new SaveFileDialog())
                {
                    saveDiag.Filter = "CSV FILES|*.csv";
                    if (saveDiag.ShowDialog() == DialogResult.OK)
                    {
                        return saveDiag.FileName;
                    }
                }
                return Application.ExecutablePath + "\\default.csv";
            }
            catch
            {
                return Application.ExecutablePath + "\\default.csv";
            }

        }
        #endregion

        #region Events
        private void algorithmChange(object sender, EventArgs e)
        {
            RadioButton myRadio = (RadioButton)sender;

            // get the last char of the name as radioButton0,1,... 
            // and then convert it to integer, and save it as algorithm
            int algoritghmIndex = myRadio.Name[myRadio.Name.Length - 1] - '0';

            selectedAlgorithm = (AlgorithmBox)  algoritghmIndex;

        }

        private void openDataset_Click(object sender, EventArgs e)
        {
            // this method loads the files
            try
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        spamFiles = Directory.GetFiles(fbd.SelectedPath + "\\spam\\");

                        hamFiles = Directory.GetFiles(fbd.SelectedPath + "\\ham\\");

                        spamLabel.Text = string.Format("There are {0} spam emails loaded, how many would you like to use?", spamFiles.Length);
                        hamLabel.Text = string.Format("There are {0} ham emails loaded, how many would you like to use?", hamFiles.Length);

                        spamNumber.Minimum = 1;
                        spamNumber.Maximum = spamFiles.Length;
                        spamNumber.Value = 50;
                        spamNumber.Enabled = true;


                        hamNumber.Minimum = 1;
                        hamNumber.Maximum = hamFiles.Length;
                        hamNumber.Value = 50;
                        hamNumber.Enabled = true;

                        datasetFolder.Text = fbd.SelectedPath;
                        //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void openPhrases_Click(object sender, EventArgs e)
        {
            // simple file loader and save them to the phrase loader
            try
            {
                using (var fbd = new OpenFileDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                    {

                        StreamReader myFile = new StreamReader(fbd.FileName);
                        phrases = new List<string>();

                        myFile.ReadLine();
                        while (!myFile.EndOfStream)
                        {
                            phrases.Add(myFile.ReadLine());
                        }

                        phraseFile.Text = fbd.FileName;
                        setPhrases(50);
                        copyPhrases(50);

                        //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void runBtm_Click(object sender, EventArgs e)
        {
            // this creates a static structure
            staticSet resultStatic = new staticSet();

            resultStatic = calculateStatics(hamFiles, spamFiles, selectedAlgorithm);

            // write down the result box
            timeBox.Text = string.Format("Time: {0}", resultStatic.time);
            accurecyBox.Text = string.Format("Accuracy: {0}", resultStatic.accuracy);
            falseNbox.Text = string.Format("False Negatives: {0}", resultStatic.fnegatives);
            falsePBox.Text = string.Format("False Positives: {0}", resultStatic.fpositives);
            spamPrecision.Text = string.Format("Spam Percesion: {0}", resultStatic.spamper);
            spamRecallBox.Text = string.Format("Spam Recall: {0}", resultStatic.spamrecall);

            if (saveFile.Checked)
                saveLogFile(resultStatic);


            fillBox();
        }
        private void phraseNumber_ValueChanged(object sender, EventArgs e)
        {
            // copies the requested number of phrases in dictionary

            copyPhrases((int)phraseNumber.Value);
        }
        private void deleteBTM_Click(object sender, EventArgs e)
        {
            // delete any phrase 

            decimal limit = phraseNumber.Value;
            foreach (KeyValuePair<string, int> item in wordList.SelectedItems)
            {
                try
                {
                    phrases.Remove(item.Key);
                    limit--;

                }
                catch
                {

                }

            }

            setPhrases(limit);
            copyPhrases((int)limit);
        }
        private void fillBtm_Click(object sender, EventArgs e)
        {
            // this method will copy n number of phrases into the listbox
            // the n = phraseNumber.Value
            copyPhrases((int)phraseNumber.Value);
        }
        private void threshold_CheckedChanged(object sender, EventArgs e)
        {
            // change the threshold 
            thresholdValue.Enabled = threshold.Checked;

        }
       

        private void saveFile_CheckedChanged(object sender, EventArgs e)
        {
            // if the save into file is activated
            browseBTM.Enabled = saveFile.Checked;

        }

        private void browseBTM_Click(object sender, EventArgs e)
        {
            // browse the file
            loadText.Text = saveAddress = browseFile();
        }
        #endregion

    }
}
