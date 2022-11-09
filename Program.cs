using System.ComponentModel.Design;

internal class Program
{
    private static void Main(string[] args)
    {
        int Number1, Number2, Result;
        
        Menu:
        try
        {
            Console.WriteLine("Enter First Number:");
            Number1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Second Number:");
            Number2 = int.Parse(Console.ReadLine());
            Result = Number1 / Number2;
            Console.WriteLine($"Result ={Result}");

            SomeMethod();
        }
        catch(FormatException ex)       //catches exception thrown from try method as well
        {
            Console.WriteLine("Please enter valid numerals only...");
            Console.WriteLine($"Message:{ex.Message}");
            Console.WriteLine($"Source:{ex.Source}");
            Console.WriteLine($"HelpLink:{ex.HelpLink}");
            Console.WriteLine($"StackTrace:{ex.StackTrace}");
        }
        catch(DivideByZeroException ex)
        {
            Console.WriteLine("Second number - Denominator cannot be zero...");
            Console.WriteLine($"Message:{ex.Message}");
            Console.WriteLine($"Source:{ex.Source}");
            Console.WriteLine($"HelpLink:{ex.HelpLink}");
            Console.WriteLine($"StackTrace:{ex.StackTrace}");
        }
        finally
        {
            Console.WriteLine("FinallyBlock");
        }
        Console.ReadKey();
        Console.Clear();
        //await in try-catch-finally

        Await_catch();
        Console.ReadKey();

        // managing exceptions in async functions
        Console.Clear();
        AsyncExample example = new AsyncExample();
        example.Call();
        Console.ReadLine();
    }

    static void SomeMethod()
    {
        try
        {
            Console.WriteLine("Inside SomeMethod");
            int num1 = 10, num2 = 0;
            int result = num1 / num2; //Exception will be thrown here
            Console.WriteLine($"Result: {result}");
        }
        finally
        {
            Console.WriteLine("SomeMethod finally Block");      //will still execute
        }
    }

    static async Task ExceptionLog()        //logs any exception into a file
    {
        await Task.Delay(5000);
    } 

    static async Task ProcessStates(Task t)
    {
        //stores the state of a process/task when it ends
        await Task.Delay(5000);
        
        //the code here is just an example, where you consider it takes 5000ms for the function to end
        ////and so it's async - to facilitate the main thread to run faster 
    }

    static async Task Await_catch()
    {
        try
        {
            int a = 5, b = 0;
            Console.WriteLine(a / b);

        }
        catch (Exception ex)
        {
            await ExceptionLog();
            Console.WriteLine("Logged excpetion details onto:- {FILE NAME}");
        }
        finally
        {
            await ProcessStates(Task.Delay(200));
            Console.WriteLine("Finally executed");
        }

    }

}
