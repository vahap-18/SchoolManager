using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager
{
    public class Program
    {
        static School school = new School();
        static List<Student> students = new List<Student>();

        Student student = new Student();

        static void Main(string[] args)
        {
            school.AddFakeData();
            Uygulama();
        }

        static void Menu()
        {
            Console.WriteLine("------  Okul Yönetim Uygulamasi  -----\n");
            Console.WriteLine("1 - Bütün öğrencileri listele");
            Console.WriteLine("2 - Şubeye göre öğrencileri listele");
            Console.WriteLine("3 - Cinsiyetine göre öğrencileri listele");
            Console.WriteLine("4 - Şu tarihten sonra doğan öğrencileri listele");
            Console.WriteLine("5 - İllere göre sıralayarak öğrencileri listele");
            Console.WriteLine("6 - Öğrencinin tüm notlarını listele");
            Console.WriteLine("7 - Öğrencinin okuduğu kitapları listele");
            Console.WriteLine("8 - Okuldaki en yüksek notlu 5 öğrenciyi listele");
            Console.WriteLine("9 - Okuldaki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine("10 - Şubedeki en yüksek notlu 5 öğrenciyi listele");
            Console.WriteLine("11 - Şubedeki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine("12 - Öğrencinin not ortalamasını gör");
            Console.WriteLine("13 - Şubenin not ortalamasını gör");
            Console.WriteLine("14 - Öğrencinin okuduğu son kitabı gör");
            Console.WriteLine("15 - Öğrenci ekle");
            Console.WriteLine("16 - Öğrenci güncelle");
            Console.WriteLine("17 - Öğrenci sil");
            Console.WriteLine("18 - Öğrencinin adresini gir");
            Console.WriteLine("19 - Öğrencinin okuduğu kitabı gir");
            Console.WriteLine("20 - Öğrencinin notunu gir\n");
        }
        static void Uygulama()
        {
            Menu();
            while (true)
            {
                Console.WriteLine("\nÇıkış için : çıkış/exit  -  Listeye dönmek için : liste yazın");
                Console.Write("Yapmak istediğiniz işlemi seçiniz: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "çıkış" || input.ToLower() == "exit")
                    break;
                if (input.ToLower() == "liste")
                    Uygulama();

                switch (input)
                {
                    case "1":
                        school.ListStudentAll();
                        break;
                    case "2":
                        school.ListStudentByBranch();
                        break;
                    case "3":
                        school.ListStudentByGender();
                        break;
                    case "4":
                        school.ListStudentBornAfterDate();
                        break;
                    case "5":
                        school.ListStudentByCity();
                        break;
                    case "6":
                        school.ListStudentNotes();
                        break;
                    case "7":
                        school.ListStudentBook();
                        break;
                    case "8":
                        school.StudentListSuccessfullTopFive();
                        break;
                    case "9":
                        school.StudentListUnsuccessfullTopThree();
                        break;
                    case "10":
                        school.StudentListSuccessfullTopFiveByBranch();
                        break;
                    case "11":
                        school.StudentListUnsuccessfullTopThreeByBranch();
                        break;
                    case "12":
                        school.StudentNoteAverage();
                        break;
                    case "13":
                        school.BranchNoteAverage();
                        break;
                    case "14":
                        school.LastBookReadOfStudent();
                        break;
                    case "15":
                        school.StudentsAdd();
                        break;
                    case "16":
                        school.StudentEdit();
                        break;
                    case "17":
                        school.StudentDelete();
                        break;
                    case "18":
                        school.AddInpuAdress();
                        break;
                    case "19":
                        school.StudentAddBook();
                        break;
                    case "20":
                        school.InputNoteofStudent();
                        break;
                    default:
                        Console.WriteLine("Geçersiz bir seçim yaptınız.");
                        break;
                }
            }
        }

    }
}
