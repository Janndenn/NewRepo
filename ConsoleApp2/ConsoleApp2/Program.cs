using static System.Console;

IEnumerable<int> Square(int max)
{
    for (int i = 0; i < max; i++)
    {
        yield return i * i;
    }
}

var squares = Square(5);

foreach (var n in squares)
{
    WriteLine(n);
}
