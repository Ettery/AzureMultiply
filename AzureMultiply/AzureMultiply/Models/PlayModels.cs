using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace AzureMultiply.Models
{

    public class SelectPlayModel
    {
        public SelectPlayModel() { }

        public SelectPlayModel(string definition) 
        {
            string[] defs = definition.Split('|');
            PlayMode = defs[0];
            Min = Int32.Parse(defs[1]);
            Max = Int32.Parse(defs[2]);
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Bonds/Times/Divide")]
        public string PlayMode { get; set; }

        [Required]
        [Display(Name = "Lower Set")]
        public int Min { get; set; }

        [Required]
        [Display(Name = "Upper Set")]
        public int Max { get; set; }

    }

    public class FullPlayModel
    {
        private SelectPlayModel _selectPlayModel;
        private List<PlayValue> _playValues = new List<PlayValue>();

        public FullPlayModel(SelectPlayModel selectModel)
        {
            _selectPlayModel = selectModel;

            Initialise();
        }

        public SelectPlayModel SelectPlayModel
        {
            get { return _selectPlayModel; }
        }

        public List<PlayValue> PlayValues
        {
            get { return _playValues; }
        }

        private void Initialise()
        {
            _playValues = GeneratePlayValues(SelectPlayModel);
        }

        private List<PlayValue> GeneratePlayValues(SelectPlayModel selectModel)
        {
            List<PlayValue> playValues = new List<PlayValue>();

            for (int n = 0; n <= 200; n++)
            {
                int result = 0;
                int first = GetRandomIntegerBetween((n*3), 1, selectModel.Min);
                int second = GetRandomIntegerBetween((n*7), 1, selectModel.Max);

                switch (SelectPlayModel.PlayMode)
                {
                    case "Bonds":
                        {
                            result = first + second;
                            int alt = n%2;
                            if (alt == 0)
                                playValues.Add(new PlayValue(result, first, second, "&#45;"));
                            else
                                playValues.Add(new PlayValue(first, second, result, "&#43;"));
                            break;
                        }
                    case "Multiply":
                        {
                            result = first*second;
                            playValues.Add(new PlayValue(first, second, result, "&times;"));
                            break;
                        }
                    case "Divide":
                        {
                            result = first*second;
                            playValues.Add(new PlayValue(result, first, second, "&divide;"));
                            break;
                        }
                }

            }
            return playValues;
        }

        private int GetRandomIntegerBetween(int seed, int startVal, int endVal)
        {
            Random rnd = new Random(seed);
            return rnd.Next(startVal, ((startVal>endVal)?startVal:endVal));
        }

    }

    public class PlayValue 
    {
        public PlayValue(int first, int second, int result, string operatorString)
        {
            First = first;
            Second = second;
            Result = result;
            OperatorString = operatorString;
        }

        public int First;
        public int? Second;
        public int? Result;
        public string OperatorString;
    }
}
