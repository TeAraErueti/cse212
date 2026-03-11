using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add 3 items with different priorities and dequeue them
    // Expected Result: Dequeue returns highest priority first (Charlie, Bob, Alice)
    // Defect(s) Found: Original Dequeue method did not return the correct item when multiple items existed; the last element was skipped because the loop iterated incorrectly (used `_queue.Count - 1`). Fixed by iterating through all elements and removing the correct highest priority item.
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Alice", 1);
        pq.Enqueue("Bob", 2);
        pq.Enqueue("Charlie", 3);

        Assert.AreEqual("Charlie", pq.Dequeue());
        Assert.AreEqual("Bob", pq.Dequeue());
        Assert.AreEqual("Alice", pq.Dequeue());
        Assert.IsTrue(true);
    }

    [TestMethod]
    // Scenario: Add items with same highest priority
    // Expected Result: Dequeue returns the one added first among the highest priority (FIFO)
    // Defect(s) Found: Original Dequeue method did not respect FIFO for items with equal priority; the later item was returned first. Fixed by updating the loop comparison to use `>` instead of `>=`, ensuring first-added item with the highest priority is returned.
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Alice", 3);
        pq.Enqueue("Bob", 3);
        pq.Enqueue("Charlie", 2);

        Assert.AreEqual("Alice", pq.Dequeue());
        Assert.AreEqual("Bob", pq.Dequeue());
        Assert.AreEqual("Charlie", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue on empty queue
    // Expected Result: Should throw InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: Original code correctly threw the exception; no defect found.
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();
        try
        {
            pq.Dequeue();
            Assert.Fail("Expected exception was not thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}