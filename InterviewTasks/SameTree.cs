namespace InterviewTasks;

public class SameTree
{
    public class TreeNode {
         public int val;
             public TreeNode left;
             public TreeNode right;
             public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
                 this.val = val;
                 this.left = left;
                 this.right = right;
             }
     }

    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        var stackP = new Stack<TreeNode>();
        var stackQ = new Stack<TreeNode>();
        if (!CheckIfSameAddToStack(p, q, stackP, stackQ))
            return false;
        
        while (stackP.Count != 0)
        {
            var nodeP = stackP.Pop();
            var nodeQ = stackQ.Pop();
            if (nodeP.val != nodeQ.val)
                return false;

            if (!CheckIfSameAddToStack(nodeP.left, nodeQ.left, stackP, stackQ))
                return false;

            if (!CheckIfSameAddToStack(nodeP.right, nodeQ.right, stackP, stackQ))
                return false;
        }

        return stackQ.Count == 0;
    }

    private bool CheckIfSameAddToStack(TreeNode p, TreeNode q, Stack<TreeNode> stackP, Stack<TreeNode> stackQ)
    {
        var pIsEmpty = p == null;
        var qIsEmpty = q == null;
        if (pIsEmpty != qIsEmpty)
            return false;

        if (pIsEmpty)
            return true;
        
        stackP.Push(p);
        stackQ.Push(q);
        return true;
    }
}