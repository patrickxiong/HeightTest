using System;

string str1 = null;
string str2 = "london";

str1?.Equals(str2, StringComparison.CurrentCultureIgnoreCase); // true