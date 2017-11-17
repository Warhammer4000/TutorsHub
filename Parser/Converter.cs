using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.QuestionModels;

namespace Parser
{
    public static class Converter
    {
        //Task of this method is to take a filepath as input
        //Then Read that file and parse it to a list of questions
        public static List<Question> FromCsv(string filepath)
        {

            return new List<Question>();
        }


        //Task of this method is to take a List of question as input
        //Then convert it to CSV for user to download
        public static string ToCsv(List<Question> questions)
        {
            

            return   "";
        }


    }
}
