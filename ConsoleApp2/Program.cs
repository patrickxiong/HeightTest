// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string str1 = null;
string str2 = "london";
var b = str1?.Equals(str2, StringComparison.CurrentCultureIgnoreCase);

Console.WriteLine(b); // true

b=str2?.Equals(str1, StringComparison.CurrentCultureIgnoreCase);

Console.WriteLine(b);