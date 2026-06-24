using BloodTesting.Domain.Testing;

namespace BloodTesting.Adapters.InMemoryQueue.Processing;

public sealed class ProcessingQueue
{
    private readonly PriorityQueue<BloodTest, (TestPriority Priority, DateTime TestDate)> _queue = new(
        Comparer<(TestPriority Priority, DateTime TestDate)>.Create((x, y) =>
        {
            int priorityComparison = y.Priority.CompareTo(x.Priority);
            if (priorityComparison != 0)
            {
                return priorityComparison;
            }

            return x.TestDate.CompareTo(y.TestDate);
        }));

    public async Task Enqueue(BloodTest test)
    {
        _queue.Enqueue(test, (test.Priority, test.TestDate));
    }

    public async Task<BloodTest?> TryDequeue()
    {
        return _queue.TryDequeue(out var test, out _) ? test : null;
    }
}
