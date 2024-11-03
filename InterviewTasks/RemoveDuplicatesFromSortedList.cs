namespace InterviewTasks;

/// <summary>
/// 83.
/// Given the head of a sorted linked list, delete all duplicates such that each element appears only once.
/// Return the linked list sorted as well.
/// </summary>
public class RemoveDuplicatesFromSortedList
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public ListNode DeleteDuplicates(ListNode head)
    {
        var current = head;
        while (current is { next: { } })
        {
            if (current.val == current.next.val)
                current.next = current.next.next;
            else
                current = current.next;
        }

        return head;
    }
}