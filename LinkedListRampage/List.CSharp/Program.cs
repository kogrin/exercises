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
            Console.WriteLine($"Real length: {xs.Length}, expected length: 1");
        }

        static void IntTest()
        {
            Console.WriteLine($"\nRunning: {System.Reflection.MethodBase.GetCurrentMethod().Name}");
            var testList = new MyList.List<int>();
            testList.AddLast(1);
            testList.AddLast(2);
            testList.AddLast(3);

            Console.WriteLine($"List element at 2: {testList.GetAt(2)}; length: {testList.Length}");
            Console.WriteLine($"List pop: {testList.Pop()}");
            Console.WriteLine($"List pop: {testList.Pop()}");
            Console.WriteLine($"Length: {testList.Length}");
        }

        static void Main(string[] args)
        {
            StringTest();
            IntTest();
        }
    }
}

// TIL:
//  -> Compile time - во время компиляции = значит до запуска программы
//  -> Run time - во время работы программы - после запуска

//  -> Runtime (слитно) - среда выполнения кода =
//      - Виртуальная Машина (в случае C# -- .NET CLR / Java -- JVM )
//          или ОС (в случае C/C++)
//      + все библиотеки, которые нужны для выполнения программы

//  -> Свойства через C# {get; set; } -- свойства с автоматическими методами = авто-свойства (auto-property)
//  -> Исключения (*) - это способ вызвать распространение "контролируемой ошибки", в случае когда логика в конкретном месте не может справится с ошибкой.
//      |-> если для созданного исключения не существует обработчиков, выполнение программы прекращается с сообщением об ошибке.
//  -> VM - виртуальная машина - "операционная система" внутри ОС

//  -> Интерполяция строк - https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/tokens/interpolated

// _____ 15.09.20 _______

// -> internal <class> - доступ к классу внутри сборки = грубо говоря внутри проекта .csproj
// -> рефлексия .NET - возможность получать доступ (и модифицировать) в run time к данным о данных выполняющегося сейчас кода (внутри сборки)
// -> интерфейс - контракт, указывающий, какие методы (включая сигнатуру - название метода, тип аргументов и тип возвращаемого значения), класс, или структура должны реализовывать, чтобы выполнять этот крнтракт
//  -> интерфейс в C# является типом, а соответственно типы, выполняющие его - его подтипами