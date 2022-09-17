namespace OopExamples
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }
        public Point(int x, int y) => (X, Y) = (x, y);
    }

    public class Pair<TypeFirst, TypeSecond>
    {
        public TypeFirst First { get; }
        public TypeSecond Second { get; }
        public Pair(TypeFirst first, TypeSecond second) =>
            (First, Second) = (first, second);
    }

}
