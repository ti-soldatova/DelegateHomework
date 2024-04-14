// See https://aka.ms/new-console-template for more information
using DelegateHomework;

public class Program
{
    public static void Main(string[] args)
    {
        // search maximum
        List<string> strings = new() { "mur", "myau", "cat" };
        string stringMax = strings.GetMax<string>(ConvertToNumber);

        //search files

        //sender
        var filePassing = new FilesPassing("C:");
        
        // anonimous func
        int filesFound = 0; 
        FilesPassing.EventHandler onFileFound = (sender, eventArgs) =>
        { 
            filesFound++;
            Console.WriteLine(filesFound);
            eventArgs.ToCancel = true;
        };

        // add reciever
        filePassing.FileFound += onFileFound;

        // call event
        filePassing.RaiseEvent();
    }

    public static float ConvertToNumber<T>(T value) where T : class 
        =>  value.ToString().Length;
}
