namespace InterviewTasks;

/// <summary>
/// 31.
/// A permutation of an array of integers is an arrangement of its members into a sequence or linear order.
/// The next permutation of an array of integers is the next lexicographically greater permutation of its integer.
/// More formally, if all the permutations of the array are sorted in one container according to their
/// lexicographical order, then the next permutation of that array is the permutation that follows it in
/// the sorted container. If such arrangement is not possible, the array must be rearranged as the lowest
/// possible order (i.e., sorted in ascending order).
/// Given an array of integers nums, find the next permutation of nums.
/// The replacement must be in place and use only constant extra memory.
/// </summary>
public class NextPermutation
{
    public void Solution(int[] nums)
    {
        if (nums.Length < 2)
            return;

        var indexToReplace = -1;
        for (var i = nums.Length - 2; i >= 0; i--)
        {
            if (nums[i] >= nums[i + 1])
                continue;

            indexToReplace = i;
            break;
        }

        if (indexToReplace == -1)
        {
            Array.Reverse(nums);
            return;
        }
        

        for (var i = nums.Length - 1; i > indexToReplace; i--)
        {
            if (nums[i] <= nums[indexToReplace])
                continue;
            
            (nums[indexToReplace], nums[i]) = (nums[i], nums[indexToReplace]);
            break;
        }
        
        Array.Reverse(nums, indexToReplace + 1, nums.Length - indexToReplace - 1);
    }
}