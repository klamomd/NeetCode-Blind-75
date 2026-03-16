public class MedianFinder {

    PriorityQueue<int, int> minHeap;
    PriorityQueue<int, int> maxHeap;

    public MedianFinder() {
        // Init heaps
        minHeap = new PriorityQueue<int, int>();
        maxHeap = new PriorityQueue<int, int>(
            Comparer<int>.Create((a, b) => b.CompareTo(a))
        );
    }
    
    public void AddNum(int num) {
        // If num is > min element of min heap, push onto min heap.
        int minHeapMinElement;
        // No elements in min heap yet, or num is greater than min element -> push num onto min heap.
        if (!minHeap.TryPeek(out minHeapMinElement, out _) || num > minHeapMinElement) {
            minHeap.Enqueue(num, num);
        }
        // Otherwise, push num onto the max heap.
        else {
            maxHeap.Enqueue(num, num);
        }

        // While min heap has 2+ elements more than max heap, rebalance by popping from min and pushing onto max.
        while (minHeap.Count - maxHeap.Count > 1) {
            int element = minHeap.Dequeue();
            maxHeap.Enqueue(element, element);
        }

        // While max heap has 2+ elements more than min heap, rebalance by popping from max and pushing onto min.
        while (maxHeap.Count - minHeap.Count > 1) {
            int element = maxHeap.Dequeue();
            minHeap.Enqueue(element, element);
        }
    }
    
    public double FindMedian() {
        // If heaps are of different sizes, peek and return the element at the top of the larger heap.
        if (minHeap.Count > maxHeap.Count) {
            return minHeap.Peek();
        } else if (minHeap.Count < maxHeap.Count) {
            return maxHeap.Peek();
        }

        // Otherwise we have an even # of elements. Peek the top of both heaps, and return the mean.
        double mean = ((double) minHeap.Peek() + (double) maxHeap.Peek()) / 2.0;
        
        return mean;
    }
}
