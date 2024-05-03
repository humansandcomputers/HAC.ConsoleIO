using System.Globalization;

namespace HAC.ConsoleIO
{
    public static class IO
    {
        public static string ReadLine() => Console.ReadLine() ?? throw new InvalidOperationException("There is no input.");

        public static T ReadLine<T>() where T : IParsable<T> => DefaultParse<T>(ReadLine());

        public static string[] ReadArray() => ReadLine().Split(' ').ToArray();

        public static T[] ReadArray<T>() where T : IParsable<T> => ReadArray().Select(DefaultParse<T>).ToArray();

        public static (T1 Item1, T2 Item2) ReadLine<T1, T2>()
                                                      where T1 : IParsable<T1>
                                                      where T2 : IParsable<T2>
        {
            var inputs = ReadArray();
            return (DefaultParse<T1>(inputs[0]), DefaultParse<T2>(inputs[1]));
        }
        public static (T1 Item1, T2 Item2, T3 Item3) ReadLine<T1, T2, T3>()
                                                      where T1 : IParsable<T1>
                                                      where T2 : IParsable<T2>
                                                      where T3 : IParsable<T3>
        {
            var inputs = ReadArray();
            return (DefaultParse<T1>(inputs[0]), DefaultParse<T2>(inputs[1]), DefaultParse<T3>(inputs[2]));
        }

        static T DefaultParse<T>(string s) where T : IParsable<T> => T.Parse(s, CultureInfo.InvariantCulture);
    }
}
