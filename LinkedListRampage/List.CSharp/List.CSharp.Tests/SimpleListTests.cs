using System;
using Xunit;

namespace List.CSharp.Tests;

public class SimpleListTests
{
    [Fact]
    public void TestOutRangeException()
    {
        var list = new MyList.List<int>();                  // новый список int (пустой)
        var err =
            Record.Exception(                               // метод умеющий ловить Exception, принимает лямбда-функцию
                () => { list.GetAt(0); }                    // безымянная функция - наз. "лямбда" (параметры тут..) = { тело функции тут...}
            );
        Assert.IsType<ArgumentOutOfRangeException>(err);    // библиотечная проверка что исключение именно такое как ожидается
    }
}