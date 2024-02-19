using System.Diagnostics;
using System.Security.AccessControl;

namespace RenderModes.Shared.Services;

public interface ICounterService
{
    event Action OnChange;

    int GetCount();
    void IncrementCount();
}

public class CounterService : ICounterService
{
    private int count;
    public event Action OnChange;

    public CounterService()
    {
        Debug.WriteLine("Counter service instantiated..,");
    }

    public void IncrementCount()
    {
        count++;
        NotifyStateChanged();
    }

    public int GetCount()
    {
        return count;
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
public class CounterService2 : ICounterService
{
    private int count;
    public event Action OnChange;

    public CounterService2()
    {
        Debug.WriteLine("Counter service 2 instantiated..,");
    }

    public void IncrementCount()
    {
        count++;
        count++;
        NotifyStateChanged();
    }

    public int GetCount()
    {
        return count;
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
