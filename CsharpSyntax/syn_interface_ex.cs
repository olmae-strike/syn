using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CsharpSyntax
{
    class syn_interface_ex
    {
    }

    interface IFile
    {
        void Save(List<int> item);
    }

    class TextFile : IFile
    {
        public void Save(List<int> item)
        {
            string scoreText = "";

            for(int i=0; i<item.Count; i++)
            {
                scoreText += item[i].ToString();

                if (i < item.Count - 1)
                    scoreText += " ";
            }
            File.WriteAllText("score.txt", scoreText);
            Console.WriteLine("txt 파일로 저장");
        }
    }
    class CSVFile : IFile
    {
        public void Save(List<int> item)
        {
            string scoreText = "";
            
            for(int i=0;i<item.Count;i++)
            {
                scoreText += item[i].ToString();

                if (i < item.Count - 1)
                    scoreText += ",";
            }
            File.WriteAllText("score.csv", scoreText);
            Console.WriteLine("csv 파일로 저장");
        }
    }
    class Score
    {
        private List<int> scores;
        private IFile file;
        public Score()
        {
            scores = new List<int>();
        }
        public void SetFileType(IFile file)
        {
            this.file = file;
        }
        public void AddScore(int score)
        {
            scores.Add(score);
        }
        public void SaveScore()
        {
            //if (file != null)
            //    file.Save(scores);
            file?.Save(scores);
        }
    }
    class Program
    { 
        static void Main(string[] args)
        {
            Score score = new Score();
            score.AddScore(100);
            score.AddScore(90);
            score.AddScore(80);
            score.AddScore(75);
            score.AddScore(745);
            score.AddScore(7425);
            score.AddScore(751);

            TextFile textFile = new TextFile();
            CSVFile csvFile = new CSVFile();

            score.SetFileType(textFile);
            score.SaveScore();
            score.SetFileType(csvFile);
            score.SaveScore();
        }
    }

}
