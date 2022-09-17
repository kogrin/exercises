// List:
//  - new
//  - getAt
//  - AddLast
//  - PopLast

namespace Tests
{
    static internal class ListTests
    {
        static void StringTest()
        {
            Console.WriteLine($"\nRunning: {System.Reflection.MethodBase.GetCurrentMethod().Name}");
            var xs = new MyList.List<string>();
            xs.AddLast("Generics");
            xs.AddLast("Are");
            xs.AddLast("Cool");

            Console.WriteLine($"Last element: {xs.Pop()}");
            Console.WriteLine($"Last - 1 element: {xs.Pop()}");
            Console.WriteLine($"Real length: {xs.Count}, expected length: 1");
        }

        static void IntTest()
        {
            Console.WriteLine($"\nRunning: {System.Reflection.MethodBase.GetCurrentMethod().Name}");
            var testList = new MyList.List<int>();
            testList.AddLast(1);
            testList.AddLast(2);
            testList.AddLast(3);
            Console.WriteLine($"List element at 2: {testList.GetAt(2)}; length: {testList.Count}");
            Console.WriteLine($"List pop: {testList.Pop()}");
            Console.WriteLine($"List pop: {testList.Pop()}");
            Console.WriteLine($"Length: {testList.Count}");
        }

        static void Main(string[] args)
        {
            StringTest();
            IntTest();
        }
    }
}
