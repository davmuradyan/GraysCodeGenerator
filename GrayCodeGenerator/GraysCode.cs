using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrayCodeGenerator {
    internal static class GraysCode {
        private static int FindTheRange(int number) {
            int i = 0;
            int pow = 1;

            while (number > pow - 1) {
                i++;
                pow *= 2;
            }

            return i;
        }
        private static void ReflectAndPrefix(ref List<string> codes) {
            int length = codes.Count;

            for (int k = 0; k < length; k++) {
                codes.Add(codes[length - k - 1]);
            }

            for (int k = 0; k < length; k++) {
                codes[k] = "0" + codes[k];
            }
            for (int k = 0; k < length; k++) {
                codes[k + length] = "1" + codes[k + length];
            }
        }
        private static void PrintResults(List<string> codes, int number) {
            foreach (var code in codes) {
                Console.WriteLine(code);
            }

            Console.WriteLine("\nNumber " + number + " is " + codes[number] + " in Gray's code");
        }
        public static void GenerateGraysCode(int number) {
            List<string> codes = new List<string>();

            int i = FindTheRange(number);

            for (int j = 0; j < i; j++) {
                if (j == 0) {
                    codes.Add("0");
                    codes.Add("1");
                } else {
                    ReflectAndPrefix(ref codes);
                }
            }

            PrintResults(codes, number);
        }
    }
}
