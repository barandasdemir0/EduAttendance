public class Result
{
    //public string Message { get; set; } = default!;
    private List<string> _messages = new();

    public IReadOnlyCollection<string> Messages => _messages.ToArray();

    public static Result Succeed(string message)
    {
        var res = new Result();
        res.Add(message);
        return res;
    }
    public static Result Fail(string message)
    {
        var res = new Result();
        res.Add(message);
        return res;
    }
    public static Result Fail(List<string> message)
    {
        var res = new Result();
        res.Add(message);
        return res;
    }

    public void Add(string message)
    {
        _messages.Add(message);
    }

    public void Add(List<string> message)
    {
        _messages.AddRange(message);
    }





}