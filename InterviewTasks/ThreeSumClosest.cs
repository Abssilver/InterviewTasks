namespace InterviewTasks;

/// <summary>
/// 16.
/// Given an integer array nums of length n and an integer target,
/// find three integers in nums such that the sum is closest to target.
/// Return the sum of the three integers.
/// You may assume that each input would have exactly one solution.
/// </summary>
public class ThreeSumClosest
{
    public int Closest(int[] nums, int target) {
        Array.Sort(nums);
        var closest = int.MaxValue;
        var difference = int.MaxValue;
        for (var i = 0; i < nums.Length; i++)
        {
            var left = i + 1;
            var right = nums.Length - 1;
            while (left < right)
            {
                var sum = nums[i] + nums[left] + nums[right];
                if (sum < target)
                {
                    var currentDifference = Math.Abs(target - sum);
                    if (currentDifference < difference)
                    {
                        closest = sum;
                        difference = currentDifference;
                    }
                    left++;
                    while (nums[left - 1] == nums[left] && left < right)
                        left++;
                    
                    continue;
                }

                if (sum > target)
                {
                    var currentDifference = Math.Abs(sum - target);
                    if (currentDifference < difference)
                    {
                        closest = sum;
                        difference = currentDifference;
                    }
                    right--;
                    while (nums[right + 1] == nums[right] && left < right)
                        right--;
                    continue;
                }

                return target;
            }
        }
        return closest;
    }
}