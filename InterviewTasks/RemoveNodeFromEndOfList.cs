namespace InterviewTasks;

/// <summary>
/// 19.
/// Given the head of a linked list, remove the nth node from the end of the list and return its head.
/// </summary>
public class RemoveNodeFromEndOfList
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

    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode nMinusOneNode = null;
        var offset = 1;
        var current = head;
        while (current != null)
        {
            if (offset == n + 1)
                nMinusOneNode = head;
            else if (offset > n + 1)
                nMinusOneNode = nMinusOneNode.next;
            
            current = current.next;
            offset++;
        }

        if (nMinusOneNode == null)
            return head.next;

        nMinusOneNode.next = nMinusOneNode.next.next;
        return head;
    }
}