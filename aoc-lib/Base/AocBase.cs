using aoc_lib.Models;

namespace aoc_lib.Base;

public abstract class AocBase<T>(int year, int day, string sessionKey) : IAocBase
{
    protected InputData<T>? Input;
    
    private readonly AocLib _lib = new(sessionKey);

    public async Task LoadInput()
    {
        Input = await _lib.DownloadInputData<T>(year, day);
    }

    public abstract object SolveTask1();

    public abstract object SolveTask2();
}