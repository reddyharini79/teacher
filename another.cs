using AssessmentProjectStoringAndUpdatingTeacherRecords;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProjectStoringAndUpdatingTeacherRecords
{

    class Program
    {
        public static string fileLocation = @"C:\\Users\Raj\Desktop\coder1.txt";

        public static void WriteData()
        {
            FileStream fs = new FileStream(fileLocation, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Teachers Records");
            sw.WriteLine("ID \t\t Name \t\t Class \t\t Section");

            sw.Close();
            fs.Close();
        }


        public static void AppendData()
        {
            FileStream fs = new FileStream(fileLocation, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            try
            {
                Console.Write("Please add teacher's ID:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please add teacher's Name:");
                string name = Console.ReadLine();
                Console.Write("Please add teacher's Class Number:");
                int classNum = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please add teacher's Section:");
                string section = Console.ReadLine();

                Teacher t1 = new Teacher(id, name, classNum, section);
                sw.WriteLine("{0} \t\t {1} \t\t {2} \t\t {3}", t1.Id, t1.Name, t1.ClassNum, t1.Section);
                Console.WriteLine("new Teacher data added successfully !\n");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex1)
            {
                Console.WriteLine(ex1.Message);
            }
            finally
            {
                sw.Close();
                fs.Close();
            }

        }



        public static void ReadData()
        {
            FileStream fs = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            while (str != null)
            {
                Console.WriteLine(str);
                str = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
        }


        public static void UpdateData(int id)
        {
            FileStream fs3 = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
            StreamReader sr3 = new StreamReader(fs3);

            try
            {
                Console.Write("Please add teacher's Name:");
                string name = Console.ReadLine();
                Console.Write("Please add teacher's Class Number:");
                int classNum = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please add teacher's Section:");
                string section = Console.ReadLine();

                Teacher t1 = new Teacher(id, name, classNum, section);
                string updatedData = $"{t1.Id} \t\t {t1.Name} \t\t {t1.ClassNum} \t\t {t1.Section}";

                string[] lines;
                using (fs3)
                {
                    using (sr3)
                    {
                        lines = File.ReadAllLines(fileLocation);

                        for (int i = 2; i < lines.Length; i++)
                        {
                            string[] split = lines[i].Split(',');
                            foreach (var item in split)

                            {
                                if (Char.GetNumericValue(item[0]) == id)
                                {
                                    lines[i] = updatedData;
                                }
                            }
                        }

                        foreach (var item in lines)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }

                using (FileStream fs = new FileStream(fileLocation, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (var item in lines)
                        {
                            sw.WriteLine(item);
                        }
                    }
                }

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex1)
            {
                Console.WriteLine(ex1.Message);
            }

        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(" --Teacher  System-- ");
                Console.WriteLine(" 1  enter new data  ");
                Console.WriteLine(" 2  update existing data  ");
                Console.WriteLine(" 3  display teacher records");
                Console.WriteLine(" 4  exit \n");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        WriteData();
                        AppendData();
                        break;
                    case 2:
                        ReadData();
                        Console.Write("Please enter teacher's ID to update:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        UpdateData(id);
                        break;
                    case 3:
                        ReadData();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Wrong input.");
                        break;
                }
                if (choice == 4) { break; }

            }

        }

    }
}