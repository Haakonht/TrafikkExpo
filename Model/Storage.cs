using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TrafikkExpo.Model
{
    public static class Storage
    {
        public static double SlideTimer { set; get; }
        public static double FadeTimer { set; get; }

        public static String Monday { set; get; }
        public static String Tuesday { set; get; }
        public static String Wednesday { set; get; }
        public static String Thursday { set; get; }
        public static String Friday { set; get; }

        public static List<Course> Courses { set; get; }

        static Storage()
        {
            FadeTimer = 3;
            SlideTimer = 20;
            Monday = "08:00 - 16:00";
            Tuesday = "08:00 - 16:00";
            Wednesday = "08:00 - 16:00";
            Thursday = "08:00 - 16:00";
            Friday = "08:00 - 16:00";
            Deserialize();
        }

        public static void AddCourse(String name, DateTime from, DateTime to, String price)
        {
            Courses.Add(new Course(name, from, to, price));
            Courses.Sort((x, y) => DateTime.Compare(x.from, y.from));
        }
        public static void DeleteCourse(Course course)
        {
            Courses.Remove(course);
        }

        public static void Serialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("courses.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, Courses);
            stream.Close();
        }

        public static void Deserialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("courses.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            Courses = (List<Course>)formatter.Deserialize(stream);
            stream.Close();
        }

    }

    [Serializable]
    public class Course
    {
        public String courseName { get; }
        public String price { get; }
        public DateTime from { get; }
        public DateTime to { get; }
        public Course() { }
        public Course(String courseName, DateTime from, DateTime to, String price)
        {
            this.courseName = courseName; this.from = from; this.to = to; this.price = price;
        }
    }
}
