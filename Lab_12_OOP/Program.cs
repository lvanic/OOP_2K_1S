using System;

namespace Lab_12_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"/Users/polza/source/repos/Lab_12_OOP/";
            Console.WriteLine(XXXDiskInfo.GetDiskInfo());
            XXXLog.Write(XXXDiskInfo.GetDiskInfo());

            Console.WriteLine(XXXFileInfo.GetFileInfo());
            XXXLog.Write(XXXFileInfo.GetFileInfo());
            XXXLog.Write("$Session - " + DateTime.Now.Date.ToString() + "$");

            XXXFileManager.MoveFiles(path);
            XXXFileManager.MoveDirectoriesByExtension(path, ".js");
            XXXFileManager.ToZip(path);

            Console.WriteLine("======================================");
            Console.WriteLine("============= FROM FILE ==============");
            Console.WriteLine($"============= COUNT: {XXXLog.GetRecordCount()}================");
            Console.WriteLine("======================================\n");
            Console.WriteLine(XXXLog.GetInfoByDay(DateTime.Now.Date));

            XXXFileManager.FromZip();

            XXXLog.Close();
        }
    }
}
