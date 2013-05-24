using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using Shouldly;
using System.Linq;

namespace GenerateCsv
{
    public enum ProgrammingLanguage
    {
        CSharp,
        FSharp,
        Haskell,
        Ruby,
        JavaScript
    }

    public class SurveyResponse
    {
        public string Site;
        public Dictionary<ProgrammingLanguage, int> Results;
    }


    public class CsvGenerator
    {
        public string SurveyToCsv(IEnumerable<SurveyResponse> responses)
        {
            var languages = Enum.GetValues(typeof(ProgrammingLanguage)).Cast<int>().OrderBy(x => x).Select(x => (ProgrammingLanguage)x).ToArray();

            var text = responses.Select(response =>
                                        response.Site
                                        + ","
                                        + String.Join(",", languages.Select(l => response.Results.ContainsKey(l) ? response.Results[l] : 0)) + "\r\n")
                                .Aggregate("", (s, s1) => s + s1)
                                .Trim();

            var result = "site," 
                         + String.Join(",", languages.Select(x => x.ToString().ToLowerInvariant())) 
                         + "\r\n"
                         + text;

            return result.Trim();
        }
    }


    public class Tests
    {
        [Test]
        public void TESTNAME()
        {
            var responses = new[]
                                {
                                    new SurveyResponse{ Site = "site1", Results = new Dictionary<ProgrammingLanguage, int> { { ProgrammingLanguage.CSharp, 3 }, { ProgrammingLanguage.FSharp, 1 }, { ProgrammingLanguage.Haskell, 0 } } },
                                    new SurveyResponse{ Site = "site2", Results = new Dictionary<ProgrammingLanguage, int> { { ProgrammingLanguage.CSharp, 3 }, { ProgrammingLanguage.Ruby, 5 } } },
                                    new SurveyResponse{ Site = "site3", Results = new Dictionary<ProgrammingLanguage, int> { { ProgrammingLanguage.Ruby, 7 }, { ProgrammingLanguage.JavaScript, 4 } } },
                                };

            var generator = new CsvGenerator();

            var result = generator.SurveyToCsv(responses);

            result.ShouldBe(@"site,csharp,fsharp,haskell,ruby,javascript
site1,3,1,0,0,0
site2,3,0,0,5,0
site3,0,0,0,7,4");
        }
    }
}
