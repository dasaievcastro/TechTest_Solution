using System;
namespace TechTest_Domain.Classes.ReadData
{
    public class ReadData
    {
        public int _hoursWorked { get; set; }
        public double _hourRate { get; set; }
        public int _location { get; set; }
        public ReadData()
        {
            //read data
            Console.WriteLine("Please enter the hours worked: ");
            _hoursWorked = ReadData.ReadStringToInt(Console.ReadLine());
            Console.WriteLine("Please enter the hourly rate:");
            _hourRate = ReadData.ReadStringToDouble(Console.ReadLine());
            Console.WriteLine("Please enter the employee’s location:");
            Console.WriteLine("0 - Ireland");
            Console.WriteLine("1 - Italy");
            Console.WriteLine("2 - Germany");
            _location = ReadData.ReadStringToInt(Console.ReadLine());
        }

        public static double ReadStringToDouble(string data)
        {
            double conv = 0;
            return (double.TryParse(data, out conv)) ? conv : -1;
        }

        public static int ReadStringToInt(string data)
        {
            int conv = 0;
            return (Int32.TryParse(data, out conv)) ? conv : -1;
        }
}
}
