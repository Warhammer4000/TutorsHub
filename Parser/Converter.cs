using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.QuestionModels;
using ServiceStack;
using ServiceStack.Text;

namespace Parser
{
    public static class Converter
    {
       
        public static List<Question> FromCsv(string data) => CsvSerializer.DeserializeFromString<List<Question>>(data);
        public static string ToCsv(List<Question> questions) => CsvSerializer.SerializeToString(questions);
    }
}
