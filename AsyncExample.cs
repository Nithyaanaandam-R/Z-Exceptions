public class AsyncExample
{
    public static Task AsyncFun()
    {
        return Task.Run(() =>
        {
            try
            {
                Task.Delay(2000);
                throw new Exception("User-defined exception");      //suppose the exception occured outside the try block, then the task wont be returned
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        );
    }

    public async void Call()
    {
        try
        {
            await AsyncFun();
        }
        catch(Exception ex)     //since the above task was cancelled a task cancelled exception is recieved in this try block
        {
            Console.WriteLine(ex.Message);
        }
    }
}