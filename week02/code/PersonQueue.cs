/// <summary>
/// A basic FIFO Queue
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the **back** of the queue
    /// </summary>
    public void Enqueue(Person person)
    {
        _queue.Add(person); // <-- ADD to back
    }

    /// <summary>
    /// Remove a person from the **front** of the queue
    /// </summary>
    public Person Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty.");

        var person = _queue[0];   // FRONT of the queue
        _queue.RemoveAt(0);       // remove FRONT
        return person;
    }

    public bool IsEmpty()
    {
        return _queue.Count == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue.Select(p => p.Name))}]";
    }
}