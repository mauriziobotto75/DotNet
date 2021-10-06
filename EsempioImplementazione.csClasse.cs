AB ab = new AB();
ab.IlMetodo();
ab.UnMetodo();
Console.ReadLine();

(ab as IA).UnMetodo();
Console.ReadLine();

(ab as IB).IlMetodo();
Console.ReadLine();
