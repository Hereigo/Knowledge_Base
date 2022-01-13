using System;

public class PrivateMethodByDelegate
{
    public delegate void MyPublicDelegate(string text);

    private void PrivateMethod(string text)
    {
        Console.WriteLine(text);
    }

    public void GetPrivateMethod(out MyPublicDelegate linkToPrivateMethod)
    {
        linkToPrivateMethod = PrivateMethod;
    }
    
    public void Test()
    {
        MyPublicDelegate linkToPrivateMethod;

        var pmbd = new PrivateMethodByDelegate();
        
        pmbd.GetPrivateMethod(out linkToPrivateMethod);

        linkToPrivateMethod("Hello");

        Console.WriteLine(" World!");
    }
}
