using System;
using System.Collections.Generic;

namespace KaratePacan
{
    public static class Utils
    {
        public static int ScanIntValue()
        {
            int result;
            var success = false;

            do
            {
                string input = Console.ReadLine();

                success = int.TryParse(input, out result);
            } while (!success);

            return result;
        }

        public static string ScanStringValue()
        
        {
            string result = null;
            var success = false;

            do
            {
                string input = Console.ReadLine();

                success = !string.IsNullOrWhiteSpace(input);
                result = input;
            } while (!success);
            
            return result;
        }

        public static string FormatCollection(IEnumerable<string> collection)
        {
            return string.Join(",", collection);
        }
    }
}