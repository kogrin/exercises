using System;

// List:
//  - new
//  - getAt
//  - AddLast
//  - PopLast

namespace MyList
{
    class Node
    {
        public int data { get; private set; }
        public Node? next { get; set; }

        public Node(int x)
        {
            this.data = x;
        }
    }

    class List
    {
        public Node? first { get; private set; }
        public Node? last { get; private set; }
        public int Length { get; private set; } = 0;

        public List(Node first)
        {
            this.first = first;
            this.last = first;
            this.Length++;
        }

        public List()
        {
            this.first = null;
            this.last = null;
        }

        public int GetAt(int index)
        {
            if (index >= this.Length)
            {
                throw new IndexOutOfRangeException(
                    $"Index: {index} is out if list bounds, length: {this.Length}"
                );
            }

            if (this.Length == 0 || this.first == null || this.last == null)
            {
                throw new IndexOutOfRangeException("list is empty");
            }

            var tmp = this.first;

            for (var i = 0; i < index; i++)
            {
                if (tmp != null)
                {
                    tmp = tmp.next;
                }
            }

            if (tmp == null)
            {
                throw new Exception("Internal error: list corrupted");
            }

            return tmp.data;
        }

        public void AddFirst(int x)
        {
            var newNode = new Node(x);
            if (this.Length == 0)
            {
                this.first = newNode;
                this.last = newNode;
            }
            else
            {
                newNode.next = this.first;
                this.first = newNode;
            }

            this.Length++;

        }

        public void AddLast(int x)
        {
            var newNode = new Node(x);
            if (this.Length == 0)
            {
                this.first = newNode;
                this.last = newNode;
            }
            else if (this.last != null)
            {
                this.last.next = newNode;
                this.last = newNode;
            }

            this.Length++;
        }

        public int Pop()
        {
            if (this.Length == 0 || this.first == null || this.last == null)
            {
                throw new IndexOutOfRangeException("list is empty");
            }

            var data = this.last.data;

            if (this.Length == 1)
            {
                this.first = null;
                this.last = null;
                return data;
            }

            var previous = this.first;
            var current = this.first;

            while (current.next != null)
            {
                previous = current;
                current = current.next;
            }

            this.last = previous;
            this.Length--;
            return data;
        }

        public void RemoveLast()
        {
            if (this.Length == 0 || this.first == null || this.last == null)
            {
                throw new IndexOutOfRangeException("list is empty");
            }

            var data = this.last.data;

            if (this.Length == 1)
            {
                this.first = null;
                this.last = null;
                return;
            }

            var previous = this.first;
            var current = this.first;

            while (current.next != null)
            {
                previous = current;
                current = current.next;
            }

            this.last = previous;
            this.Length--;
        }
    }

    internal class ListTests
    {
        static void Main(string[] args)
        {
            object myObj = 12;
            var strObj = myObj.ToString();
            Console.WriteLine(strObj);
            var testList = new List();
            testList.AddLast(1);
            testList.AddLast(2);
            testList.AddLast(3);
            Console.WriteLine($"List element at 0: {testList.GetAt(2)}; length: {testList.Length}\n");
            Console.WriteLine($"List pop: {testList.Pop()}");
            Console.WriteLine($"List pop: {testList.Pop()}");
            Console.WriteLine($"Length: {testList.Length}");
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