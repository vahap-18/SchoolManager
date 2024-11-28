using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager
{
    public class Student
    {
        public int Number;
        public string Name;
        public string Surname;
        public DateTime Birthday;
        public BRANCH Branch;
        public GENDER Gender;
        public Adress Adress;

        public List<string> Books = new List<string>();
        public List<LessonNote> Notes = new List<LessonNote>();

        public float Average
        {
            get
            {
                if (Notes.Any())
                {
                    return (float)Notes.Average(n => n.Note);
                }
                else
                {
                    return 0;
                }
            }
        }
    }
    public enum BRANCH
    {
        Empty, A, B, C
    }

    public enum GENDER
    {
        Empty, Kiz, Erkek
    }
}
