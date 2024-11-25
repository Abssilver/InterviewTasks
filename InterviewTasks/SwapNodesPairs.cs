namespace InterviewTasks;

/// <summary>
/// 24.
/// Given a linked list, swap every two adjacent nodes and return its head.
/// You must solve the problem without modifying the values in the list's nodes
/// (i.e., only nodes themselves may be changed.)
/// </summary>
public class SwapNodesPairs
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

    public ListNode SwapPairs(ListNode head)
    {
        if (head == null)
            return head;
        var currentIndex = 1;
        var current = head;
        ListNode nodeParentToSwap = null;
        var toReturn = head;

        while (current != null)
        {
            if (currentIndex % 2 == 0)
            {
                if (nodeParentToSwap == null)
                {
                    head.next = current.next;
                    current.next = head;
                    toReturn = current;
                    nodeParentToSwap = head;
                    current = head;
                }
                else
                {
                    var toSwap = nodeParentToSwap.next;
                    toSwap.next = current.next;
                    current.next = toSwap;
                    nodeParentToSwap.next = current;
                    nodeParentToSwap = toSwap;
                    current = toSwap;
                }
            }

            currentIndex++;
            current = current.next;
        }
        
        return toReturn;
    }
}