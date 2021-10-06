interface IA
{
    void UnMetodo();
}

public class A : IA
{
    public void UnMetodo()
    {
        Console.WriteLine("IA.UnMetodo");
    }
}

interface IB
{
    void IlMetodo();
}

public class B : IB
{
    public void IlMetodo()
    {
        Console.WriteLine("IB.IlMetodo");
    }
}

public class AB : IA, IB
{
    private A a = new A();
    private B b = new B();

    public void UnMetodo()
    {
        a.UnMetodo();
    }

    public void IlMetodo()
    {
        b.IlMetodo();
    }
}
