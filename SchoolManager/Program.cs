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
            AddFakeData();
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
            Console.WriteLine("çıkış yapmak için : exit\n");
        }
        static void Uygulama()
        {
            Menu();
            while (true)
            {
                Console.Write("\nYapmak istediğiniz işlemi seçiniz: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                switch (input)
                {
                    case "1":
                        ListStudentAll();
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
                        LastBookReadOfStudent();
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
                        AddInpuAdress();
                        break;
                    case "19":
                        school.StudentAddBook();
                        break;
                    case "20":
                        school.InputNoteofStudent();
                        break;
                    default:
                        Console.WriteLine("Geçersiz bir seçim yaptınız.");
                        return;
                }
            }
        }


        static void ListStudentAll()
        {
            Console.WriteLine();
            Console.WriteLine(" 1- Tüm öğrencileri listele ");
            Console.WriteLine();

            Console.WriteLine("Şube".PadRight(10) + "No".PadRight(10) + "Ad".PadRight(10) + "Soyad".PadRight(12) + "Ortalama".PadRight(15) + "Okuduğu Kitap Sayısı");
            Console.WriteLine(new string('-', 80));

            foreach (var student in students.OrderBy(o => o.Branch).ThenBy(o => o.Number))
            {
                Console.WriteLine(Convert.ToString(student.Branch).PadRight(10) + Convert.ToString(student.Number).PadRight(10)
                    + Convert.ToString(student.Name).PadRight(10) + Convert.ToString(student.Surname).PadRight(12)
                    + Convert.ToString(student.Average).PadRight(12) + Convert.ToString(student.Books.Count));
            }

        }
        static void LastBookReadOfStudent()
        {
            Console.WriteLine("14 - Öğrencinin okuduğu son kitabı gör");
            Console.WriteLine();
            Console.Write("Öğrenci Numarası : ");
            int no = int.Parse(Console.ReadLine());
            var studentBranch = School.students.FirstOrDefault(o => o.Number == no);

            if (studentBranch == null)
            {
                Console.WriteLine("Bu numaraya sahip bir öğrenci bulunamadı.");
                return;
            }

            if (studentBranch.Books == null || !studentBranch.Books.Any())
            {
                Console.WriteLine(studentBranch.Name + " adlı öğrencinin okuduğu herhangi bir kitap bulunmamaktadır.");
                return;
            }
            Console.WriteLine(studentBranch.Name + "adlı öğrencinin okuduğu son kitap: " + studentBranch.Books.Last());
        }
        static void AddInpuAdress()
        {
            Console.Write("Öğrenci Numarası : ");
            int number = int.Parse(Console.ReadLine());

            var student = School.students.FirstOrDefault(o => o.Number == number);
            if (student == null)
            {
                Console.WriteLine("Öğrenci bulunamadı.");
                return;
            }
            Console.Write("İl: ");
            string City = Console.ReadLine();

            Console.Write("İlçe: ");
            string district = Console.ReadLine();

            student.Adress = new Adress();
            Console.WriteLine("Adres başarıyla eklendi.");
        }
        static void AddFakeData()
        {
            //StudentAdd metodu School class'ında olduğu için school nesnesi üzerinden metodu çağırıldı
            //Toplam 5 adet sahte öğrenci verisi eklendi.
            school.StudentAdd(1, "Ahmet", "Kaya", new DateTime(2002, 1, 15), BRANCH.A, GENDER.Erkek);
            school.StudentAdd(2, "Zeynep", "Doğan", new DateTime(2001, 4, 10), BRANCH.B, GENDER.Kiz);
            school.StudentAdd(3, "Mehmet", "Yıldız", new DateTime(2003, 6, 8), BRANCH.C, GENDER.Erkek);
            school.StudentAdd(4, "Ayşe", "Aydın", new DateTime(2000, 9, 20), BRANCH.A, GENDER.Kiz);
            school.StudentAdd(5, "Emre", "Öz", new DateTime(2002, 2, 25), BRANCH.B, GENDER.Erkek);

            //Her öğrenciye Türkçe, Matematik, Fen ve Sosyal ders notları eklendi
            FakeAddNote(1, "Türkçe", 58);
            FakeAddNote(1, "Matematik", 72);
            FakeAddNote(1, "Fen", 60);
            FakeAddNote(1, "Sosyal", 65);

            FakeAddNote(2, "Türkçe", 85);
            FakeAddNote(2, "Matematik", 90);
            FakeAddNote(2, "Fen", 88);
            FakeAddNote(2, "Sosyal", 92);

            FakeAddNote(3, "Türkçe", 45);
            FakeAddNote(3, "Matematik", 50);
            FakeAddNote(3, "Fen", 48);
            FakeAddNote(3, "Sosyal", 52);

            FakeAddNote(4, "Türkçe", 95);
            FakeAddNote(4, "Matematik", 88);
            FakeAddNote(4, "Fen", 92);
            FakeAddNote(4, "Sosyal", 90);

            FakeAddNote(5, "Türkçe", 70);
            FakeAddNote(5, "Matematik", 68);
            FakeAddNote(5, "Fen", 72);
            FakeAddNote(5, "Sosyal", 75);

            //Her öğrenciye 1 adet kitap eklendi
            FakeAddBook(1, "Simyacı");
            FakeAddBook(2, "Kürk Mantolu Madonna");
            FakeAddBook(3, "Bir İdam Mahkumunun Son Günü");
            FakeAddBook(4, "Küçük Prens");
            FakeAddBook(5, "Beyaz Gemi");

            //Her öğrenciye ait il-ilçe adresi tanımlandı
            FakeAddAdress(1, "İstanbul", "Beşiktaş");
            FakeAddAdress(2, "Ankara", "Çankaya");
            FakeAddAdress(3, "İzmir", "Bornova");
            FakeAddAdress(4, "Bursa", "Nilüfer");
            FakeAddAdress(5, "Antalya", "Konyaaltı");
        }
        static void FakeAddNote(int number, string lessonName, int note)
        {
            Student o = students.Where(a => a.Number == number).FirstOrDefault();
            if (o != null)
            {
                o.Notes.Add(new LessonNote(lessonName, note));
            }
        }
        static void FakeAddBook(int number, string kitapAdi)
        {

            Student o = students.Where(a => a.Number == number).FirstOrDefault();
            if (o != null)
            {
                o.Books.Add(kitapAdi);
            }
        }
        static void FakeAddAdress(int number, string city, string district)
        {
            Student o = students.Where(a => a.Number == number).FirstOrDefault();
            if (o != null)
            {
                o.Adress = new Adress { City = city, Distritch = district };
            }
        }

    }
}
