namespace DelegateHomework;

internal class FilesPassing
{
    private readonly string _path;
    public FilesPassing(string path)
    {
        _path = path;
    }

    public delegate void EventHandler(object sender, FileArgs args);
    public event EventHandler FileFound;

    public void RaiseEvent()
    {
        string[] files = null;

        try
        {
            files = Directory.GetFiles(_path);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
        }

        if (files?.Any() is false)
        {
            return;
        }

        foreach (var file in files)
        {
            var args = new FileArgs(file);

            Console.WriteLine($"Was found file '{args.FileName}'");
            FileFound?.Invoke(this, args);

            if (args.ToCancel)
            {
                break;
            }
        }

    }
}

internal class FileArgs : EventArgs
{
    public string FileName { get; set; }
    public bool ToCancel { get; set; }

    public FileArgs(string fileName) : base()
    {
        FileName = fileName;
    }
}
