namespace linqTest
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>() { "adam", "vignesh", "cm", "prabu", "navanee", "vibi" };

            var query = from names in list select names;
            var query1 = list.ToList();
            List<string> list2 = list.ToList();

            List<Student> students = new List<Student>() {
            new Student() {Id = 1,Name = "adam",Email = "adam@gmail.com" },
            new Student() { Id = 2, Name = "a2", Email = "a2@gmail.com" },
            new Student() { Id = 3, Name = "a3", Email = "a3@gmail.com" },
            new Student() { Id = 4, Name = "a4", Email = "a4@gmail.com" },
            };
            var StudentQuery = from student in students where (student.Id > 2) select student;
            foreach (Student item in StudentQuery)
            {
                Console.WriteLine(item.Name);
            }

            var studentQuery1 = students.Where(s =>
            {
                return s.Id > 2 && s.Name == "a3";
            }).ToList();

            /*foreach (var item in studentQuery1)
            {
                Console.WriteLine(item.Name);
            }*/

            //select many
            List<int> numlist1 = new List<int>() { 3, 3, 41, 1, 3, 3, 9, 5, 6, 7, 8, 9 };
            List<int> numlist2 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<List<int>> nestedList = new List<List<int>>() { numlist1, numlist2 };
            var res = nestedList.SelectMany(value => value.Distinct()).Distinct();
            //Take (takes the first x values)
           // numlist1.Take(3).ToList().ForEach(x=>Console.WriteLine(x));

            //skip (skips the first x values)
            //numlist1.Skip(3).ToList().ForEach(x=>Console.WriteLine(x));
            //end

            //skipWhile (skips the values until the condition)
            numlist1.SkipWhile(x=>x.Equals(3)).ToList().ForEach(x => Console.WriteLine(x));
            //end

            /*foreach (var item in res)
            {
                Console.WriteLine(item);
            }*/

            List<object> objectList = new List<object>() { 1, "one", 2, "two", 3, "three", 4.5f };

            var objectQuery = objectList.OfType<int>().ToList();
            var objectQuery1 = (from x in objectList where ((x is int) && (x is > 1)) select x).ToList(); ;
            var objectQuery2 = (from x in objectList where x is string orderby x select x).ToList();

            /*foreach (var item in objectQuery2)
            {
                Console.WriteLine("objectQuery1 " + item);
            }*/

            //reverse
            List<int> nums = new List<int>() { 23, 245, 74531, 435, 46, 8567, 45623, 5568, 5656, };
            nums.Reverse();
            /*foreach (int i in nums)
            {
                Console.WriteLine(i);
            }*/

            //All
            var q = nums.All((item) => item > 2);
            //Console.WriteLine(q);
            


        }
    }
}