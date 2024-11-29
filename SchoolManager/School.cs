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
        public void ListStudentAll()
        {
            Console.WriteLine();
            Console.WriteLine(" 1- Tüm öğrencileri listele ");
            Console.WriteLine();

            if (students == null || students.Count == 0)
            {
                Console.WriteLine("Henüz sisteme kayıtlı öğrenci bulunmamaktadır.");
                return;
            }

            Console.WriteLine("Şube".PadRight(10) + "No".PadRight(10) + "Ad".PadRight(10) + "Soyad".PadRight(12) + "Ortalama".PadRight(15) + "Oku. Kitap Say.");
            Console.WriteLine(new string('-', 80));

            foreach (var student in students.OrderBy(o => o.Branch).ThenBy(o => o.Number))
            {
                Console.WriteLine(Convert.ToString(student.Branch).PadRight(10) + Convert.ToString(student.Number).PadRight(10)
                    + Convert.ToString(student.Name).PadRight(10) + Convert.ToString(student.Surname).PadRight(12)
                    + Convert.ToString(student.Average).PadRight(18) + Convert.ToString(student.Books.Count));
            }

        }
        public void LastBookReadOfStudent()
        {
            Console.WriteLine("14 - Öğrencinin okuduğu son kitabı gör\n");
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
                Console.WriteLine(studentBranch.Name + " " + studentBranch.Surname + " 'in okuduğu herhangi bir kitap bulunmamaktadır.");
                return;
            }
            Console.WriteLine(studentBranch.Name + " " + studentBranch.Surname + " 'in okuduğu son kitap: " + studentBranch.Books.Last());
        }
        public void ListStudentByBranch()
        {
            Console.WriteLine();
            Console.WriteLine(" 2- Şubeye Göre Öğrenci Listele ");
            Console.WriteLine();

            Console.Write("Listelemek istediğiniz  şubeyi girin (A-B-C): ");
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
            Console.Write("Listelemek istediğiniz  cinsiyeti girin (K/E): ");
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
                Console.WriteLine("Geçersiz bir değer girdiniz!");
                return;
            }

            Console.WriteLine("Cinsiyet: " + gender);

            Console.WriteLine("Şube".PadRight(10) + "No".PadRight(12) + "Adı".PadRight(12) + "Soyadı".PadRight(15) + "Not Ort".PadRight(12) + "Oku. Kitap Say.");
            Console.WriteLine(new string('-', 80));

            var chooseStudent = students.Where(o => o.Gender == gender).OrderBy(o => o.Number).ToList();
            foreach (var ogr in chooseStudent)
            {
                Console.WriteLine(ogr.Branch.ToString().PadRight(10) + ogr.Number.ToString().PadRight(10) + ogr.Name.PadRight(15) + ogr.Surname.PadRight(15) + ogr.Average.ToString().PadRight(12) + ogr.Books.Count);
            }

        }
        public void ListStudentBornAfterDate()
        {
            Console.WriteLine();
            Console.WriteLine("4 - Şu tarihten sonra doğan öğrencileri listele");
            Console.WriteLine();
            Console.Write("Hangi tarihten sonraki öğrencileri listelemek  istersiniz (gg.aa.yyyy):");

            string inputDate = Console.ReadLine();
            DateTime date;

            if (!DateTime.TryParse(inputDate, out date))
            {
                Console.WriteLine("Hatalı tarih girdiniz.");
            }
            Console.WriteLine();
            Console.WriteLine(date.ToShortDateString() + "tarihinden sonra doğan öğrenciler:");
            Console.WriteLine("Şube".PadRight(10) + "Numara".PadRight(10) + "Ad".PadRight(10) + "Soyad".PadRight(10) + "Doğum Tarihi".PadRight(15) + "Ortalama".PadRight(10) + "Oku. Kitap Say.");
            Console.WriteLine(new string('-', 80));

            var ogrenciler = School.students.Where(o => o.Birthday > date);
            foreach (var ogr in ogrenciler)
            {
                Console.WriteLine(ogr.Branch.ToString().PadRight(10) + ogr.Number.ToString().PadRight(10) + ogr.Name.PadRight(10) + ogr.Surname.PadRight(10) + ogr.Birthday.ToShortDateString().ToString().PadRight(15) + ogr.Average.ToString().PadRight(10) + ogr.Books.Count);
            }
        }
        public void ListStudentByCity()
        {
            Console.WriteLine();
            Console.WriteLine("5- İllere göre öğrencileri Listele");
            Console.WriteLine();
            Console.WriteLine("Şube".PadRight(10) + "No".PadRight(10) + "Adı".PadRight(12) + "Soyadı".PadRight(12) + "il".PadRight(12) + "İlçe");
            Console.WriteLine(new string('-', 65));

            var students = School.students.Where(o => o.Adress != null).OrderBy(o => o.Adress.City);
            foreach (var std in students)
            {
                Console.WriteLine(std.Branch.ToString().PadRight(10) + std.Number.ToString().PadRight(10) + std.Name.PadRight(12) + std.Surname.PadRight(12) + std.Adress.City.PadRight(12) + std.Adress.Distritch);
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

            foreach (var std in students)
            {
                Console.WriteLine("Öğrenci No: " + std.Number + " | Ad-Soyad : " + std.Name + " " + std.Surname);

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
                    Console.WriteLine("Bu öğrencinin henüz notu bulunmamaktadır.\n");
                }
            }
        }
        public void ListStudentBook()
        {
            Console.WriteLine("\n7 - Öğrencinin okuduğu kitapları listele");
            Console.WriteLine();
            Console.Write("Numara : ");

            if (int.TryParse(Console.ReadLine(), out int no))
            {
                var studentBook = School.students.FirstOrDefault(o => o.Number == no);

                if (studentBook != null)
                {
                    Console.WriteLine("Ad-Soyadı : " + studentBook.Name + " " + studentBook.Surname);
                    Console.WriteLine("Şube : " + studentBook.Branch);

                    // Kitap listesini kontrol et
                    if (studentBook.Books != null && studentBook.Books.Any())
                    {
                        Console.WriteLine("Okuduğu Kitaplar:");
                        Console.WriteLine(new string('-', 18));

                        foreach (var book in studentBook.Books)
                        {
                            Console.WriteLine(" + " + book);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bu öğrencinin henüz kitap kaydı bulunmamaktadır.");
                    }
                }
                else
                {
                    Console.WriteLine("Bu numaraya sahip bir öğrenci bulunamadı. Lütfen geçerli bir numara giriniz.");
                }
            }
            else
            {
                Console.WriteLine("Geçerli bir öğrenci numarası giriniz.");
            }
        }
        public void StudentListSuccessfullTopFive()
        {
            Console.WriteLine("8- En Yüksek Notlu 5 Öğrenciyi Listele\n");
            Console.WriteLine("No".PadRight(10) + "Şube".PadRight(10) + "Ad".PadRight(12) + "Soyad".PadRight(12) + "Ortalama");
            Console.WriteLine(new string('-', 60));
            var studentTopFive = School.students.OrderByDescending(o => o.Average).Take(5).ToList();
            foreach (var std in studentTopFive)
            {
                Console.WriteLine(std.Number.ToString().PadRight(10) + std.Branch.ToString().PadRight(10) + std.Name.PadRight(12) +
                    std.Surname.PadRight(10) + std.Average.ToString());
            }

        }
        public void StudentListUnsuccessfullTopThree()
        {
            Console.WriteLine("9 - Okuldaki en düşük notlu 3 öğrenciyi listele\n");

            Console.WriteLine("Şube".PadRight(10) + "No".PadRight(10) + "Şube".PadRight(10) + "Ad".PadRight(12) + "Soyad".PadRight(12) + "Ortalama");
            Console.WriteLine(new string('-', 60));
            var studentDescThree = School.students.OrderBy(o => o.Average).Take(3).ToList();
            foreach (var std in studentDescThree)
            {
                Console.WriteLine(std.Branch.ToString().PadRight(10) + std.Number.ToString().PadRight(10) + std.Branch.ToString().PadRight(10) + std.Name.PadRight(12) + std.Surname.PadRight(12) + std.Average.ToString().PadRight(10));
            }
        }
        public void StudentListSuccessfullTopFiveByBranch()
        {
            Console.WriteLine();
            Console.WriteLine("10 - Şubedeki en yüksek  notlu 5 öğrenciyi listele\n");

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
            Console.WriteLine("11 - Şubedeki en düşük notlu 3 öğrenciyi listele\n");

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

            Console.WriteLine("\n12 - Öğrencinin not ortalamasını gör\n");
            Console.Write("Numara : ");

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
            Console.WriteLine("\nAd-Soyad : " + std.Name + " " + std.Surname);
            Console.WriteLine("Şube : " + std.Branch);
            Console.WriteLine("Not Ortalaması : " + std.Average);

        }
        public void BranchNoteAverage()
        {
            Console.WriteLine("\n13 - Şubenin not ortalaması\n");

            Console.Write("Bir Şube Seçin (A-B-C) : ");
            string inputBranch = Console.ReadLine().ToUpper();
            if (Enum.TryParse(inputBranch, out BRANCH branch))
            {
                var studentByBranch = School.students.Where(o => o.Branch == branch).ToList();
                if (studentByBranch.Any())
                {
                    Console.WriteLine("\nŞube".PadRight(10) + "No".PadRight(10) + "Ad".PadRight(15) + "Soyad".PadRight(15) + "Not Ortalaması".PadRight(15));
                    Console.WriteLine(new string('-', 65));

                    foreach (var student in studentByBranch)
                    {
                        Console.WriteLine(
                            student.Branch.ToString().PadRight(10) + student.Number.ToString().PadRight(10) + student.Name.PadRight(15) + student.Surname.PadRight(15) + student.Average.ToString()
                        );
                    }
                }
            }

        }
        public void StudentsAdd()
        {
            Student o = new Student();

            Console.WriteLine();
            Console.WriteLine("15- Öğrenci Ekle");
            Console.WriteLine();
            Console.WriteLine(students.Count + 1 + " . öğrencin bilgilerini giriniz");

            bool presentNo;
            do
            {
                presentNo = false;
                Console.Write("Numara : ");


                if (!int.TryParse(Console.ReadLine(), out o.Number))
                {
                    Console.WriteLine("Hatalı numara formatı. Lütfen geçerli bir numara giriniz.");
                    return;
                }


                foreach (var ogr in students)
                {
                    if (ogr.Number == o.Number)
                    {
                        presentNo = true;
                        Console.WriteLine("Bu numarada öğrenci zaten mevcut! Lütfen farklı bir numara giriniz.");
                        break;
                    }
                }
            } while (presentNo);


            Console.Write("Ad : ");
            o.Name = Console.ReadLine();

            Console.Write("Soyad : ");
            o.Surname = Console.ReadLine();


            DateTime addBirthday;
            Console.Write("Doğum tarihi (gg.aa.yyyy) : ");
            while (!DateTime.TryParse(Console.ReadLine(), out addBirthday))
            {
                Console.WriteLine("Geçersiz tarih. Lütfen belirtilen formatta tarih giriniz (gg.aa.yyyy): ");
            }
            o.Birthday = addBirthday;


            Console.Write("Cinsiyet (K/E) : ");
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


            Console.Write("Şube (A/B/C) : ");
            string inputBranch = Console.ReadLine().ToUpper();

            if (!Enum.TryParse(inputBranch, out BRANCH branch) || branch == BRANCH.Empty)
            {
                Console.WriteLine("Hatalı şube girdiniz.");
                return;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Ögrenci başarıyla eklendi.\n");
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
            Console.Write("Numara: ");

            if (!int.TryParse(Console.ReadLine(), out no))
            {
                Console.WriteLine("Geçersiz numara.");
                return;
            }

            var std = students.FirstOrDefault(o => o.Number == no);
            if (std == null)
            {
                Console.WriteLine("Bu numarada öğrenci mevcut değil. Başka bir numara giriniz.");
                return;
            }

            Console.Write("Ad: ");
            string name = Console.ReadLine();

            Console.Write("Soyad: ");
            string surname = Console.ReadLine();

            DateTime birthday;
            while (true)
            {
                Console.Write("Doğum tarihi (gg.aa.yyyy) : ");
                if (DateTime.TryParse(Console.ReadLine(), out birthday))
                {
                    break;
                }
                Console.WriteLine("Geçersiz tarih. Lütfen tekrar deneyin.");
            }

            GENDER gender;
            while (true)
            {
                Console.Write("Öğrencinin cinsiyeti (K/E): ");
                string inputGender = Console.ReadLine().ToUpper();
                if (inputGender == "K")
                {
                    gender = GENDER.Kiz;
                    break;
                }
                else if (inputGender == "E")
                {
                    gender = GENDER.Erkek;
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz cinsiyet. Lütfen K veya E şeklinde giriniz.");
                }
            }

            std.Name = name;
            std.Surname = surname;
            std.Birthday = birthday;
            std.Gender = gender;

            Console.WriteLine("Öğrenci bilgileri başarıyla güncellendi.");
        }
        public void StudentDelete()
        {
            Console.WriteLine();
            Console.WriteLine("17- Öğrenci Sil");
            Console.WriteLine();

            while (true)
            {
                Console.Write("Öğrenci Numarası: ");
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    var ogrenci = students.FirstOrDefault(o => o.Number == number);
                    if (ogrenci != null)
                    {
                        Console.Write(ogrenci.Name + " " + ogrenci.Surname + " silinecektir! Emin misin (E/H): ");
                        string inputDelete = Console.ReadLine().ToUpper();
                        if (inputDelete == "E")
                        {
                            students.Remove(ogrenci);
                            Console.WriteLine(ogrenci.Name + " " + ogrenci.Surname + " başarıyla silindi.");
                        }
                        else
                        {
                            Console.WriteLine("Öğrenci silme işlemi iptal edildi.");
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Bu numaraya sahip bir öğrenci bulunamadı. Lütfen tekrar deneyin.");
                    }
                }
                else
                {
                    Console.WriteLine("Geçerli bir öğrenci numarası giriniz.");
                }
            }
        }

        public void InputNoteofStudent()
        {
            Console.WriteLine("\n20- Öğrencinin notunu gir");
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

            Console.WriteLine("Ad-Soyad :" + std.Name + std.Surname);
            Console.WriteLine("Şube :" + std.Branch);

            Console.Write("Not eklemek istediğiniz ders: ");
            string lessonName = Console.ReadLine();

            Console.Write("Eklemek istediğiniz not adeti (1-3) : ");
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
            Console.Write("Kitap Adı : ");
            string bookName = Console.ReadLine();

            student.Books.Add(bookName);
            Console.WriteLine(bookName + " kitabı eklendi.");

        }
        public void AddInpuAdress()
        {
            Console.WriteLine("\n18 - Öğrenci adres ekleme\n");

            while (true)
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
                break;
            }
        }
        public void AddFakeData()
        {
            //StudentAdd metodu School class'ında olduğu için school nesnesi üzerinden metodu çağırıldı
            //Toplam 5 adet sahte öğrenci verisi eklendi.
            StudentAdd(1, "Ahmet", "Kaya", new DateTime(2002, 1, 15), BRANCH.A, GENDER.Erkek);
            StudentAdd(2, "Zeynep", "Doğan", new DateTime(2001, 4, 10), BRANCH.B, GENDER.Kiz);
            StudentAdd(3, "Mehmet", "Yıldız", new DateTime(2003, 6, 18), BRANCH.C, GENDER.Erkek);
            StudentAdd(4, "Ayşe", "Aydın", new DateTime(2000, 9, 20), BRANCH.A, GENDER.Kiz);
            StudentAdd(5, "Emre", "Öz", new DateTime(2002, 2, 25), BRANCH.B, GENDER.Erkek);

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
        public void FakeAddNote(int number, string lessonName, int note)
        {
            Student o = students.Where(a => a.Number == number).FirstOrDefault();
            if (o != null)
            {
                o.Notes.Add(new LessonNote(lessonName, note));
            }
        }
        public void FakeAddBook(int number, string kitapAdi)
        {

            Student o = students.Where(a => a.Number == number).FirstOrDefault();
            if (o != null)
            {
                o.Books.Add(kitapAdi);
            }
        }
        public void FakeAddAdress(int number, string city, string district)
        {
            Student o = students.Where(a => a.Number == number).FirstOrDefault();
            if (o != null)
            {
                o.Adress = new Adress { City = city, Distritch = district };
            }
        }

    }
}
