using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using System.Web.Mvc;
using System.Linq;

namespace _3.BonusChallenge_1.Controllers
{
    public class HomeController : Controller
    {
        public readonly Resource Data = new Resource();

        public ActionResult Index()
        {
            var ResourceList = new ResourceList
            {
                SimpleList = Data.SimpleList.AsEnumerable(),
                SimpleListAnagramSorted = Output(Data.SimpleList.AsEnumerable()),
                HarderList = Data.HarderList.AsEnumerable(),
                HarderListAnagramSorted = Output(Data.HarderList.AsEnumerable())
            };

            return View(ResourceList);
        }


        public IEnumerable<IEnumerable<string>> Output(IEnumerable<string> input)
        {
            var output = new List<List<string>>();
            var inputList = input.Select(s => string.IsNullOrWhiteSpace(s) ? null : s.Trim()).OrderBy(s => s).ToList();

            do
            {
                if (inputList[0] != null)
                {
                    var currentWord = inputList[0].ToString();
                    IEnumerable<string> newList;
                    inputList.Remove(currentWord);
                    var tempList = inputList;
                    if (currentWord != "")
                    {
                        newList = new[] { currentWord };
                        for (var j = 0; j < tempList.Count(); j++)
                        {
                            var tempWord = tempList[j];
                            if (tempWord != null)
                            {
                                if (IsAnagram(currentWord, tempWord))
                                {
                                    newList = newList.Concat(new[] { tempWord });
                                    inputList.Remove(tempWord);
                                    tempList.Remove(tempWord);
                                }
                            }
                        }
                        output.Add(newList.Distinct().ToList());
                    }
                }
                else
                {
                    inputList.Remove(inputList[0]);
                }
            } while (inputList.Count() > 0);

            return output;
        }

        public bool IsAnagram(string stringOne, string stringTwo)
        {
            stringOne = RemoveWhiteSpace(stringOne);
            stringTwo = RemoveWhiteSpace(stringTwo);

            if (stringOne.Length != stringTwo.Length)
            {
                return false;
            }

            var stringOneChars = stringOne.ToLower().ToCharArray();
            var stringTwoChars = stringTwo.ToLower().ToCharArray();

            Array.Sort(stringOneChars);
            Array.Sort(stringTwoChars);

            for (var i = 0; i < stringOneChars.Length; i++)
            {
                if (stringOneChars[i].ToString() != stringTwoChars[i].ToString()) return false;
            }

            return true;
        }

        public string RemoveWhiteSpace(string input)
        {
            return new Regex(@"\s+").Replace(input, "");
        }
    }

    
}