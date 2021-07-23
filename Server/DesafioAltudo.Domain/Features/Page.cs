using DesafioAltudo.Domain.Exceptions;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioAltudo.Domain.Features
{
    public class Page
    {
        public string Url { get; set; }
        public IEnumerable<string> LinksImages { get; set; }
        public string WordsList { get; set; }
        public List<Word> MostUsedWords { get; set; }

        public Page()
        {
            Url = "";
            LinksImages = new List<string>();
            WordsList = "";
        }
        public struct Word
        {
            public string word;
            public int Occurrences;
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Url))
            {
                throw new PageUrlUninformedException();
            }
        }

        /** <summary>
        * Function used to load page from url using HtmlAgilityPack
        * </summary>
        * <param name="linkUrl">Link</param>
        */
        public HtmlDocument LoadUrl(string linkUrl)
        {
            try
            {
                HtmlWeb web = new HtmlWeb()
                {
                    AutoDetectEncoding = true,
                };
                if (linkUrl.StartsWith("www."))
                {
                    linkUrl = "http://" + linkUrl;
                }

                HtmlDocument document = web.Load(linkUrl);
                Url = linkUrl;


                return document;
            }
            catch (PageLoadErrorException)
            {
                throw;
            }
        }

        /** <summary>
         * Function used to get all images on page using LINQ, getting src attribute from img tag
         * </summary>
         * <param name="document">HtmlDocument</param>*/
        public void GetImages(HtmlDocument document)
        {
            LinksImages =  document.DocumentNode.Descendants("img")
                                            .Select(e => e.GetAttributeValue("src", null))
                                            .Where(s => !String.IsNullOrEmpty(s)).Where(link => link.Contains("http")).Where(link => !link.Contains("data:"));
                
        }

        /** 
         * <summary>
         * Function used to get all words on the page separated by delimiters
         * Foreach selects all body nodes and excludes the style and script from the tags
         * Then take the words and add them to the word list
         * </summary>
         * <param name="document">HtmlDocument</param>
         */
        public string GetAllWords(HtmlDocument document)
        {
            if (document == null)
            {
                throw new PageLoadErrorException();
            }

            var root = document.DocumentNode;

            char[] delimiter = new char[] { ' ', '\n', '\t' };
            string wordsTemp = "";
            IEnumerable<string> words;

            foreach (string text in document.DocumentNode
                .SelectNodes("//body//*[not(parent::style) and not(self::style) and not(parent::script) and not(self::script)]/text()")
                .Select(node => node.InnerText))
            {
                words = text.Split(delimiter, StringSplitOptions.RemoveEmptyEntries)
                    .Where(s => Char.IsLetter(s[0]));
                int wordCount = words.Count();
                if (wordCount > 0)
                {
                    wordsTemp += " " + text;
                }
            }
            WordsList = wordsTemp;

            return wordsTemp;
        }

        /** 
        * <summary>
        * Function used to get the ten most used words on the page
          * it takes the words and splits the words, creating a HashSet to have a single word in the list
          * Foreach takes words from HashSet and searches the word list, returning matchQuery and counting occurrences
          * struct Word receives wordhash and occurrences
          * Then takes the words and sorts by occurrence count 
        * </summary>
        *<param name="WordsList">List of Words</param>
        *<returns>Ten Most Used Words</returns>
        */
        public List<Word> GetTenMostUsedWords(string WordsList)
        {
            if (string.IsNullOrEmpty(WordsList))
            {
                throw new PageWordsListUninformedException();
            }
            List<Word> MostUsedWords = new List<Word>();
            string words = WordsList;

            words = words.ToLower();
            string[] source = words.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var WordsHashSet = new HashSet<string>(source);
            int wordCount;

            foreach (var wordHash in WordsHashSet)
            {
                wordCount = 0;
                IEnumerable<string> matchQuery = from word in source
                                                 where word == wordHash
                                                 select word;

                wordCount = matchQuery.Count();
                Word structWord;
                if (wordHash.Length > 2)
                {
                    structWord.word = wordHash;
                    structWord.Occurrences = wordCount;
                    MostUsedWords.Add(structWord);
                }
            }
            MostUsedWords.Sort((s1, s2) => s2.Occurrences.CompareTo(s1.Occurrences));
            int totalWords = MostUsedWords.Count;
            if (totalWords > 10)
            {
                MostUsedWords.RemoveRange(10, totalWords - 10);
            }
            return MostUsedWords;
        }

    }
}
