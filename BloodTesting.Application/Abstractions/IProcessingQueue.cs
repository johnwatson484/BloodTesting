
using BloodTesting.Domain.Testing;

namespace BloodTesting.Application.Abstractions;

public interface IProcessingQueue
{
    Task Enqueue<BloodTest>(BloodTest item);
    Task<BloodTest?> TryDequeue<BloodTest>();
}
