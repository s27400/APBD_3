namespace ConsoleApp1.Model.Exception;

public class OverfillException : System.Exception
{
    public OverfillException()
    {
        
    }

    public OverfillException(string info)
        :base(info)
    {
        
    }
    
}