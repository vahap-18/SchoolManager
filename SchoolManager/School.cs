using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager
{
    public class School
    {
        static public List<Student> students = new List<Student>();
        Student student = new Student();
        static int not;

        public void StudentAdd(int number, string name, string surname, DateTime birthday, BRANCH branch, GENDER gender)
        {
            Student o = new Student();
            o.Number = number;
            o.Name = name;
            o.Surname = surname;
            o.Birthday = birthday;
            o.Branch = branch;
            o.Gender = gender;

            students.Add(o);
        }
        public void ListStudentByBranch()
        {
            Console.WriteLine();
            Console.WriteLine(" 2- Şubeye Göre Öğrenci Listele ");
            Console.WriteLine();

            Console.Write("Listelemek istediğiniz  şubeyi girin (A/B/C): ");
            string branchs = Console.ReadLine().ToUpper();
            BRANCH branch;
            if (!Enum.TryParse(branchs, out branch) || branch == BRANCH.Empty)
            {
                Console.WriteLine("Hatalı giriş yaptınız.");
                return;
            }
            Console.WriteLine("Şube" + branch + "Öğrencileri:");
            Console.WriteLine("Şube".PadRight(10) + "No".PadRight(8) + "Adı".PadRight(10) + "Soyadı".PadRight(10) + "Not Ort".PadRight(10) + "Okuduğu Kitap Say.");
            Console.WriteLine(new string('-', 60));
            var ogrenciler = School.students.Where(o => o.Branch == branch);
            foreach (var ogr in ogrenciler)
            {
                Console.WriteLine(ogr.Branch.ToString().PadRight(10) + ogr.Number.ToString().PadRight(8) + ogr.Name.PadRight(10) + ogr.Surname.PadRight(10) + ogr.Average.ToString().PadRight(10) + ogr.Books.Count);
            }

        }
        public void ListStudentByGender()
        {
            Console.WriteLine();
            Console.WriteLine("3 - Cinsiyetine göre öğrencileri listele");
            Console.WriteLine();
            Console.WriteLine("Listelemek istediğiniz  cinsiyeti girin (Kız için K /Erkek için E): ");
            string inputGender = Console.ReadLine().ToUpper();
            GENDER gender;

            if (inputGender == "K")
            {
                gender = GENDER.Kiz;
            }
            else if (inputGender == "E")
            {
                gender = GENDER.Erkek;
            }
            else
            {
                Console.WriteLine("Geçersiz bir cinsiyet girdiniz!");
                return;
            }

            Console.WriteLine("Cinsiyet: " + gender);

            Console.WriteLine("Şube".PadRight(10) + "No".PadRight(8) + "Adı".PadRight(10) + "Soyadı".PadRight(15) + "Not Ort".PadRight(20) + "Okuduğu Kitap Say.");
            Console.WriteLine(new string('-', 60));

            var chooseStudent = students.Where(o => o.Gender == gender).OrderBy(o => o.Number).ToList();
            foreach (var ogr in chooseStudent)
            {
                Console.WriteLine(ogr.Branch.ToString().PadRight(10) + ogr.Number.ToString().PadRight(8) + ogr.Name.PadRight(15) + ogr.Surname.PadRight(10) + ogr.Average.ToString().PadRight(10) + ogr.Books.Count);
            }

        }
        public void ListStudentBornAfterDate()
        {
            Console.WriteLine();
            Console.WriteLine("4 - Şu tarihten sonra doğan öğrencileri listele");
            Console.WriteLine();
            Console.WriteLine("Hangi tarihten sonraki öğrencileri listelemek  istersiniz (gg.aa.yyyy):");

            string inputDate = Console.ReadLine();
            DateTime date;

            if (!DateTime.TryParse(inputDate, out date))
            {
                Console.WriteLine("Hatalı tarih girdiniz.");
            }

            Console.WriteLine(date.ToShortDateString() + "tarihinden sonra doğan öğrenciler:");
            Console.WriteLine("Şube".PadRight(10) + "Numara".PadRight(10) + "Ad".PadRight(10) + "Soyad".PadRight(10) + "Ortalama" + "Okuduğu Kitap Sayısı");
            Console.WriteLine(new string('-', 60));

            var ogrenciler = School.students.Where(o => o.Birthday > date);
            foreach (var ogr in ogrenciler)
            {
                Console.WriteLine(ogr.Branch.ToString().PadRight(10) + ogr.Number.ToString().PadRight(8) + ogr.Name.PadRight(15) + ogr.Surname.PadRight(10) + ogr.Average.ToString().PadRight(10) + ogr.Books.Count);
            }
        }
        public void ListStudentByCity()
        {
            Console.WriteLine();
            Console.WriteLine("5- İllere göre öğrencileri Listele");
            Console.WriteLine();
            Console.WriteLine("Şube".PadRight(8) + "No".PadRight(8) + "Adı".PadRight(8) + "Soyadı".PadRight(8) + "Şehir".PadRight(8) + "Semt");
            Console.WriteLine(new string('-', 60));

            var students = School.students.Where(o => o.Adress != null).OrderBy(o => o.Adress.City);
            foreach (var std in students)
            {
                Console.WriteLine(std.Branch.ToString().PadRight(8) + std.Number.ToString().PadRight(8) + std.Name + std.Surname.PadRight(10) + std.Adress.City.PadRight(10) + std.Adress.Distritch);

            }
        }
        public void ListStudentNotes()
        {
            Console.WriteLine();
            Console.WriteLine("6 - Öğrencinin tüm notlarını listele");
            Console.WriteLine();
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("Henüz sisteme kayıtlı öğrenci bulunmamaktadır.");
                return;
            }

            Console.WriteLine(new string('-', 60));

            foreach (var std in students)
            {
                Console.WriteLine("Öğrenci No: " + std.Number + ", Ad: " + std.Name + ", Soyad: " + std.Surname);

                if (student.Notes.Count > 0)
                {
                    Console.WriteLine("Notlar:");
                    foreach (var not in student.Notes)
                    {

                        Console.WriteLine("- Ders: " + not.LessonName + ", Not: " + not.Note);
                    }
                }
                else
                {
                    Console.WriteLine("Bu öğrencinin henüz notu bulunmamaktadır.");
                }

                Console.WriteLine(new string('-', 60));
            }
        }
        public void ListStudentBook()
        {
            Console.WriteLine("7 - Öğrencinin okuduğu kitapları listele");
            Console.WriteLine();
            Console.Write("Ögrenci numarası giriniz: ");
            if (int.TryParse(Console.ReadLine(), out int no))
            {
                var studentBook = School.students.FirstOrDefault(o => o.Number == no);
                if (studentBook != null)
                {
                    Console.WriteLine("Öğrencinin Adı Soyadı: " + studentBook.Name + studentBook.Surname);
                    Console.WriteLine("Öğrencinin Şubesi: " + studentBook.Branch);
                    Console.WriteLine("Okuduğu Kitaplar:");
                    Console.WriteLine(new string('-', 20));

                    foreach (var book in student.Books)
                    {
                        Console.WriteLine(book);
                    }
                    if (!student.Books.Any())
                    {
                        Console.WriteLine("Bu öğrencinin henüz kitap kaydı bulunmamaktadır.");
                    }

                }
                else
                {
                    Console.WriteLine("Geçerli bir numara giriniz");
                }
            }
        }
        public void StudentListSuccessfullTopFive()
        {
            Console.WriteLine("8- En Yüksek Notlu 5 Öğrenciyi Listele");
            Console.WriteLine();
            Console.WriteLine("No".PadRight(10) + "Ad".PadRight(15) + "Soyad".PadRight(15) + "Ortalama".PadRight(10));
            Console.WriteLine(new string('-', 60));
            var ogrenciler = School.students.OrderByDescending(o => o.Average).Take(5).ToList();
            foreach (var ogr in ogrenciler)
            {
                Console.WriteLine(ogr.Number.ToString().PadRight(8) + ogr.Name.PadRight(15) +
                    ogr.Surname.PadRight(10) + ogr.Average.ToString().PadRight(10));

            }

        }
        public void StudentListUnsuccessfullTopThree()
        {
            Console.WriteLine("9 - Okuldaki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine();

            Console.WriteLine("Şube".PadRight(10) + "No".PadRight(10) + "Ad".PadRight(15) + "Soyad".PadRight(15) + "Ortalama");
            Console.WriteLine(new string('-', 60));
            var ogrenciler = School.students.OrderBy(o => o.Average).Take(3).ToList();
            foreach (var ogr in ogrenciler)
            {
                Console.WriteLine(ogr.Branch.ToString().PadRight(10) + ogr.Number.ToString().PadRight(8) + ogr.Name.PadRight(15) + ogr.Surname.PadRight(10) + ogr.Average.ToString().PadRight(10));
            }
        }
        public void StudentListSuccessfullTopFiveByBranch()
        {
            Console.WriteLine();
            Console.WriteLine("10 - Şubedeki en yüksek  notlu 5 öğrenciyi listele");
            Console.WriteLine();

            Console.Write("Listelemek istediğiniz şubeyi girin (A-B-C):");
            string inputBranch = Console.ReadLine().ToUpper();

            if (Enum.TryParse(inputBranch, out BRANCH branch))
            {
                var studensWon = School.students.Where(o => o.Branch == branch).OrderByDescending(o => o.Average).Take(5).ToList();

                Console.WriteLine("Şube".PadRight(10) + "No".PadRight(10) + "Ad".PadRight(15) + "Soyad".PadRight(15) + "Ortalama".PadRight(10));
                Console.WriteLine(new string('-', 60));

                foreach (var std in studensWon)
                {
                    Console.WriteLine(std.Branch.ToString().PadRight(10) + std.Number.ToString().PadRight(10) + std.Name.PadRight(15) + std.Surname.PadRight(15) + std.Average.ToString().PadRight(10));
                }
            }

            else
            {
                Console.WriteLine("Hatalı şube girdiniz.");
            }
        }
        public void StudentListUnsuccessfullTopThreeByBranch()
        {
            Console.WriteLine("11 - Şubedeki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine();

            Console.Write("Listelemek istediğiniz şubeyi girin (A-B-C):");
            string inputBranch = Console.ReadLine().ToUpper();

            if (Enum.TryParse(inputBranch, out BRANCH branch))
            {
                var studentFail = School.students.Where(o => o.Branch == branch).OrderBy(o => o.Average).Take(3).ToList();

                Console.WriteLine("Şube".PadRight(10) + "No".PadRight(10) + "Ad".PadRight(15) + "Soyad".PadRight(15) + "Ortalama".PadRight(10));
                Console.WriteLine(new string('-', 60));

                foreach (var std in studentFail)
                {
                    Console.WriteLine(std.Branch.ToString().PadRight(10) + std.Number.ToString().PadRight(10) + std.Name.PadRight(15) + std.Surname.PadRight(15) + std.Average.ToString().PadRight(10));
                }
            }

            else
            {
                Console.WriteLine("Hatalı şube girdiniz.");
            }

        }
        public void StudentNoteAverage()
        {
            int no;

            Console.WriteLine("12 - Öğrencinin not ortalamasını gör");
            Console.WriteLine();
            Console.WriteLine("Öğrencinin Numarası:");

            if (!int.TryParse(Console.ReadLine(), out no))
            {
                Console.WriteLine("Geçersiz Numara");
                return;
            }
            var std = School.students.FirstOrDefault(o => o.Number == no);
            if (std == null)
            {
                Console.WriteLine("Bu numarada öğrenci yok.");
                return;
            }
            Console.WriteLine("\nÖğrencinin Adı Soyadı:" + std.Name + std.Surname);
            Console.WriteLine("Öğrencinin Şubesi:" + std.Branch);
            Console.WriteLine("Öğrencinin not ortalaması" + std.Average);

        }
        public void BranchNoteAverage()
        {
            Console.WriteLine("13 - Şubenin not ortalamasını gör");
            Console.WriteLine();
            Console.Write("Bir Şube Seçin (A-B-C) : ");

            string inputBranch = Console.ReadLine();
        }
        public void StudentsAdd()
        {
            Student o = new Student();

            Console.WriteLine();
            Console.WriteLine("15- Öğrenci ekle");
            Console.WriteLine();
            Console.WriteLine(students.Count + 1 + " . öğrencin");

            bool presentNo;
            do
            {
                presentNo = false;
                Console.Write("Numarası: ");


                if (!int.TryParse(Console.ReadLine(), out o.Number))
                {
                    Console.WriteLine("Geçersiz numara. Lütfen geçerli bir numara giriniz.");
                    return;
                }


                foreach (var ogr in students)
                {
                    if (ogr.Number == o.Number)
                    {
                        presentNo = true;
                        Console.WriteLine("Bu numara zaten mevcut! Lütfen farklı bir numara giriniz.");
                        break;
                    }
                }
            } while (presentNo);


            Console.Write("Adı: ");
            o.Name = Console.ReadLine();

            Console.Write("Soyadı: ");
            o.Surname = Console.ReadLine();


            DateTime addBirthday;
            Console.Write("Doğum tarihi (gg.aa.yyyy): ");
            while (!DateTime.TryParse(Console.ReadLine(), out addBirthday))
            {
                Console.WriteLine("Geçersiz tarih. Lütfen belirtilen formatta tarih giriniz (gg.aa.yyyy): ");
            }
            o.Birthday = addBirthday;


            Console.Write("Öğrencinin cinsiyeti (K/E): ");
            string inputGender = Console.ReadLine().ToUpper();

            GENDER addGender;

            if (inputGender == "K")
                addGender = GENDER.Kiz;
            else if (inputGender == "E")
                addGender = GENDER.Erkek;
            else
            {
                Console.WriteLine("Hatalı giriş yaptınız.");
                return;
            }


            Console.Write("Öğrencinin şubesi (A/B/C): ");
            string inputBranch = Console.ReadLine().ToUpper();

            if (!Enum.TryParse(inputBranch, out BRANCH branch) || branch == BRANCH.Empty)
            {
                Console.WriteLine("Hatalı şube girdiniz. Öğrenci eklenemedi.");
                return;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Ögrenci başarıyla eklendi. Ana menüye yönlendiriliyorsunuz...");
            }


            students.Add(new Student
            {
                Number = o.Number,
                Name = o.Name,
                Surname = o.Surname,
                Birthday = o.Birthday,
                Branch = branch,
                Gender = addGender
            });
        }
        public void StudentEdit()
        {
            int no;

            Console.WriteLine();
            Console.WriteLine("16- Öğrenci Güncelle");
            Console.WriteLine();
            Console.WriteLine("Öğrencinin numarası:");

            if (!int.TryParse(Console.ReadLine(), out no))
            {
                Console.Write("Geçersiz numara.");
                return;
            }

            var std = students.FirstOrDefault(o => o.Number == no);
            if (std == null)
            {
                Console.WriteLine("Bu numarada öğrenci var"); return;
            }

            Console.Write("Öğrencinin Adı:");
            string name = Console.ReadLine();

            Console.Write("Öğrencinin Soyadı:");
            string surname = Console.ReadLine();

            Console.Write("Öğrencinin Doğum tarihi (gg.aa.yyyy):");
            DateTime birhtday;

            if (!DateTime.TryParse(Console.ReadLine(), out birhtday)) ;
            {
                Console.WriteLine("Geçersiz Tarih"); return;
            }

            GENDER gender;
            while (true)
            {
                Console.Write("Ögrencinin cinsiyeti (K/E):");
                string inputGender = Console.ReadLine().ToUpper();
                if (inputGender == "K")
                {
                    student.Gender = GENDER.Kiz;
                }

                if (inputGender == "E")
                {
                    student.Gender = GENDER.Erkek;
                }
            }


        }
        public void StudentDelete()
        {
            Console.WriteLine();
            Console.WriteLine("17- Öğrenci sil");
            Console.WriteLine();
            Console.Write("silmek istediğiniz öğrencinin numarasını giriniz:");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                var ogrenci = students.FirstOrDefault(o => o.Number == number);
                if (ogrenci != null)
                {
                    students.Remove(ogrenci);
                    Console.WriteLine("Öğrenci" + ogrenci.Name + ogrenci.Surname + " başarıyla silindi.");
                }
                else
                {
                    Console.WriteLine("Bu numaraya sahip bir öğrenci bulunamadı.");
                }
            }
            else
            {
                Console.WriteLine("Geçerli bir öğrenci numarası giiniz.");
            }


        }
        public void InputNoteofStudent()
        {
            Console.WriteLine();
            Console.WriteLine("20- Öğrencinin notunu gir");
            Console.WriteLine();

            Console.Write("Öğrencinin numarası: ");
            if (!int.TryParse(Console.ReadLine(), out int no))
            {
                Console.WriteLine("Geçersiz numara.");
                return;
            }

            var std = students.FirstOrDefault(o => o.Number == no);
            if (std == null)
            {
                Console.WriteLine("Geçerli bir öğrenci numarası giriniz.");
                return;
            }

            Console.WriteLine("Öğrencinin Adı Soyadı:" + std.Name + std.Surname);
            Console.WriteLine("Öğrencinin Şubesi:" + std.Branch);

            Console.Write("Not eklemek istediğiniz ders: ");
            string lessonName = Console.ReadLine();

            Console.Write("Eklemek istediğiniz not adeti (1-3): ");
            if (!int.TryParse(Console.ReadLine(), out int count) || count < 1 || count > 3)
            {
                Console.WriteLine("En az 1 en fazla 3 adet not girebilirsiniz!");
                return;
            }


            for (int i = 1; i <= count; i++)
            {
                while (true)
                {
                    Console.Write(i + ". Notu girin (0-100): ");
                    if (!int.TryParse(Console.ReadLine(), out int note) || note < 0 || note > 100)
                    {
                        Console.WriteLine("Geçersiz Not. Lütfen 0 ile 100 arasında bir değer giriniz.");
                        continue;
                    }

                    std.Notes.Add(new LessonNote(lessonName, note));
                    break;
                }
            }

            Console.WriteLine("Notlar başarıyla sisteme girildi.");
        }
        public void StudentAddBook()
        {
            Console.WriteLine();
            Console.WriteLine("19 - öğrencinin okuduğu kitapları gir:");
            Console.WriteLine();
            Console.Write("Öğrenci Numarası : ");
            int no = int.Parse(Console.ReadLine());

            var student = School.students.FirstOrDefault(o => o.Number == no);
            if (student == null)
            {
                Console.WriteLine("Öğrenci bulunamadı.");
                return;
            }
            Console.Write("Kitap Adı: ");
            string bookName = Console.ReadLine();

            student.Books.Add(bookName);
            Console.WriteLine(bookName + " kitabı eklendi.");

        }
    }
}
