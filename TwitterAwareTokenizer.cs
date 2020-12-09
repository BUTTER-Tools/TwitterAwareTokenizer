using PluginContracts;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System;
using OutputHelperLib;

namespace TwitterAwareTokenizer
{
    public class TwitterAwareTokenizer : Plugin
    {

        public string[] InputType { get; } = { "String" };
        public string OutputType { get; } = "Tokens";

        public bool InheritHeader { get; } = false;
        public Dictionary<int, string> OutputHeaderData { get; set; } = new Dictionary<int, string>(){};

        #region Plugin Details and Info

        public string PluginName { get; } = "Twitter-Aware Tokenizer";
        public string PluginType { get; } = "Tokenizers/Segmenters";
        public string PluginVersion { get; } = "1.0.2";
        public string PluginAuthor { get; } = "Ryan L. Boyd (ryan@ryanboyd.io)";
        public string PluginDescription { get; } = "This plugin will tokenize your texts using a port of NLTK's Twitter-Aware tokenizer. Does a great job at recognizing / separating out words, emoji, punctuation, etc. into separate entities.";
        public bool TopLevel { get; } = false;
        public string PluginTutorial { get; } = "Coming Soon";



        public Icon GetPluginIcon
        {
            get
            {
                return Properties.Resources.icon;
            }
        }

        #endregion



        private bool reduce_elongation = true;
        private bool preserve_text_case = false;



        public void ChangeSettings()
        {


            using (var form = new SettingsForm_TwitterAwareTokenizer(reduce_elongation, preserve_text_case))
            {


                form.Icon = Properties.Resources.icon;

                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    preserve_text_case = form.preserve_text_case;
                    reduce_elongation = form.reduce_elongation;
                }
            }

        }

        //Makes sure that the regexes are initialized when created
        public void Initialize()
        {
            Initialize_Regex();
        }
        

        #region Tokenization Details
        private string URLS { get; set; } = @"(?:https?:(?:/{1,3}|[a-z0-9%])|[a-z0-9.\-]+[.](?:[a-z]{2,13})/)(?:[^\s()<>{}\[\]]+|\([^\s()]*?\([^\s()]+\)[^\s()]*?\)|\([^\s]+?\))+(?:\([^\s()]*?\([^\s()]+\)[^\s()]*?\)|\([^\s]+?\)|[^\s`!()\[\]{};:'"".,<>?«»“”‘’])|(?:[a-z0-9]+(?:[.\-][a-z0-9]+)*[.](?:[a-z]{2,13})\b/?(?!@))";
        private string EMOTICONS { get; set; } = @"(?:[<>]?[:;=8][\-o\*\']?[\)\]\(\[dDpP/\:\}\{@\|\\]|[\)\]\(\[dDpP/\:\}\{@\|\\][\-o\*\']?[:;=8][<>]?|<3)";
        private string PHONENUMBERS { get; set; } = @"(?:(?:\+?[01][*\-.\)]*)?(?:[\(]?\d{3}[*\-.\)]*)?\d{3}[*\-.\)]*\d{4})";
        private string HTMLTAGS { get; set; } = @"<[^>\s]+>";
        private string ASCII_ARROWS { get; set; } = @"[\-]+>|<[\-]+";
        private string TWITTER_USERNAMES { get; set; } = @"(?:@[\w_]+)";
        private string TWITTER_HASHTAG { get; set; } = @"(?:\#+[\w_]+[\w\'_\-]*[\w_]+)";
        private string EMAIL { get; set; } = @"[\w.+-]+@[\w-]+\.(?:[\w-]\.?)+[\w-]";
        private string REMAINING_WORD_TYPES { get; set; } = @"(?:[^\W\d_](?:[^\W\d_]|['\-_])+[^\W\d_])|(?:[+\-]?\d+[,/.:-]\d+[+\-]?)|(?:[\w_]+)|(?:\.(?:\s*\.){1,})|(?:\S)";


        private Regex WORD_RE;
        public Regex WORD_RE_ACCESS
        {
            get { return WORD_RE; }
            set { WORD_RE = value; }

        }

        private Regex HANG_RE { get; set; } = new Regex(@"([^a-zA-Z0-9])\1{3,}", RegexOptions.Compiled);
        private Regex EMOTICON_RE { get; set; }
        private Regex ENT_RE { get; set; } = new Regex(@"&(#?(x?))([^&;\s]+);");

        private Regex Reduce_Lengthening_Regex { get; set; } = new Regex(@"(.)\1{2,}", RegexOptions.Compiled);


        private void Initialize_Regex()
        {
            List<string> All_Regex_List = new List<string>();
            All_Regex_List.Add(URLS);
            All_Regex_List.Add(PHONENUMBERS);
            All_Regex_List.Add(EMOTICONS);
            All_Regex_List.Add(HTMLTAGS);
            All_Regex_List.Add(ASCII_ARROWS);
            All_Regex_List.Add(TWITTER_USERNAMES);
            All_Regex_List.Add(TWITTER_HASHTAG);
            All_Regex_List.Add(EMAIL);
            All_Regex_List.Add(REMAINING_WORD_TYPES);

            string[] AllRegexArray = All_Regex_List.ToArray();

            this.WORD_RE_ACCESS = new Regex(String.Join("|", AllRegexArray), RegexOptions.Compiled | RegexOptions.IgnoreCase);
            EMOTICON_RE = new Regex(EMOTICONS, RegexOptions.IgnoreCase);

        }

        private string reduce_lengthening(string text)
        {
            return Reduce_Lengthening_Regex.Replace(text, @"$1$1$1");
        }

        #endregion

        private string[] tokenize(string text, bool reduce_lengthening = true, bool preserve_case = false)
        {

            if (reduce_lengthening) text = this.reduce_lengthening(text);

            string safe_text = HANG_RE.Replace(text, @"$1$1$1");

            MatchCollection mc = WORD_RE.Matches(safe_text);

            string[] words = new string[mc.Count];

            for (int i = 0; i < words.Length; i++) words[i] = mc[i].Groups[0].Value;

            if (preserve_case == false)
            {
                for (uint i = 0; i < words.Length; i++)
                {
                    if (EMOTICON_RE.Matches(words[i]).Count == 0)
                    {
                        words[i] = words[i].ToLower();
                    }
                }
            }

            return words;
        }



        public Payload RunPlugin(Payload Input)
        {

            Payload pData = new Payload();
            pData.FileID = Input.FileID;
            pData.SegmentID = Input.SegmentID;

            for (int counter = 0; counter < Input.StringList.Count; counter++)
            {

                pData.StringArrayList.Add(tokenize(Input.StringList[counter], reduce_elongation, preserve_text_case));
                pData.SegmentNumber.Add(Input.SegmentNumber[counter]);

            }


            return (pData);
          

        }


        public bool InspectSettings()
        {
            return true;
        }



        public Payload FinishUp(Payload Input)
        {
            return (Input);
        }






        #region Import/Export Settings
        public void ImportSettings(Dictionary<string, string> SettingsDict)
        {
            reduce_elongation = Boolean.Parse(SettingsDict["reduce_elongation"]);
            preserve_text_case = Boolean.Parse(SettingsDict["preserve_text_case"]);
        }

        public Dictionary<string, string> ExportSettings(bool suppressWarnings)
        {
            Dictionary<string, string> SettingsDict = new Dictionary<string, string>();
            SettingsDict.Add("reduce_elongation", reduce_elongation.ToString());
            SettingsDict.Add("preserve_text_case", preserve_text_case.ToString());
            return (SettingsDict);
        }
        #endregion





    }
}
