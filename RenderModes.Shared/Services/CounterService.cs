using System.Diagnostics;

namespace RenderModes.Shared.Services;

public interface ICounterService
{
    event Action OnChange;

    int GetCount();
    void IncrementCount();
    List<string> GetMessages();
}

public class CounterService : ICounterService
{
    private int count;
    public event Action? OnChange;
    private List<string> Messages { get; set; } = new();

    public CounterService()
    {
        Messages.Add($"Counter service instantiated at {DateTime.Now}");
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

    public List<string> GetMessages()
    {
        return Messages;
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
public class CounterService2 : ICounterService
{
    private int count;
    public event Action? OnChange;
    private List<string> Messages { get; set; } = new();

    public CounterService2()
    {
        Messages.Add($"Counter service 2 instantiated at {DateTime.Now}");
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

    public List<string> GetMessages()
    {
        return Messages;
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
