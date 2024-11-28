using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager
{
    public class LessonNote
    {
        public string LessonName { get; set; }
        public float Note { get; set; }

        public LessonNote(string lessonName, int note)
        {
            LessonName = lessonName;
            Note = note;
        }
    }
}
