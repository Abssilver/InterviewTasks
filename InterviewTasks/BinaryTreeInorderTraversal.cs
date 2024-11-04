namespace InterviewTasks;

/// <summary>
/// 94.
/// Given the root of a binary tree, return the inorder traversal of its nodes' values.
/// </summary>
public class BinaryTreeInorderTraversal
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public IList<int> InorderTraversal(TreeNode root)
    {
        var route = new List<int>();
        var traverseStack = new Stack<TreeNode>();
        var node = root;
        while (traverseStack.Count != 0 || node != null)
        {
            if (node != null)
            {
                traverseStack.Push(node);
                node = node.left;
                continue;
            }
            
            node = traverseStack.Pop();
            route.Add(node.val);
            node = node.right;
        }
        return route;
    }
}