namespace InterviewTasks;

/// <summary>
/// 88.
/// You are given two integer arrays nums1 and nums2, sorted in non-decreasing order,
/// and two integers m and n, representing the number of elements in nums1 and nums2 respectively.
/// Merge nums1 and nums2 into a single array sorted in non-decreasing order.
/// The final sorted array should not be returned by the function, but instead be stored inside the array nums1.
/// To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that
/// should be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n.
/// </summary>
public class MergeSortedArray
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        if (n == 0)
            return;
        
        var index1 = 0;
        var index2 = 0;
        var sortedQueue = new Queue<int>();
        while (index1 != m + n)
        {
            if (index2 == n)
            {
                if (sortedQueue.Count == 0)
                    break;

                if (index1 < m)
                    sortedQueue.Enqueue(nums1[index1]);
                nums1[index1] = sortedQueue.Dequeue();
                index1++;
                continue;
            }
            
            if (sortedQueue.Count != 0)
            {
                var queued = sortedQueue.Peek();
                if (queued <= nums2[index2])
                {
                    if (index1 < m)
                        sortedQueue.Enqueue(nums1[index1]);
                    nums1[index1] = sortedQueue.Dequeue();
                    index1++;
                    continue;
                }

                if (index1 < m)
                    sortedQueue.Enqueue(nums1[index1]);
                nums1[index1] = nums2[index2];
                index1++;
                index2++;
                continue;
            }

            if (index1 >= m)
            {
                nums1[index1] = nums2[index2];
                index2++;
                index1++;
                continue;
            }
            
            if (nums1[index1] <= nums2[index2])
            {
                index1++;
                continue;
            }

            sortedQueue.Enqueue(nums1[index1]);
            nums1[index1] = nums2[index2];
            index2++;
            index1++;
        }
    }
}