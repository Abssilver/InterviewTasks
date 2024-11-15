namespace InterviewTasks;

/// <summary>
/// 15.
/// Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]]
/// such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
/// Notice that the solution set must not contain duplicate triplets.
/// </summary>
public class ThreeSum {
    public IList<IList<int>> Sums(int[] nums)
    {
        var result = new List<IList<int>>();
        Array.Sort(nums);

        for (var i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;

            var left = i + 1;
            var right = nums.Length - 1;
            while (left < right)
            {
                var sum = nums[i] + nums[left] + nums[right];
                if (sum < 0)
                {
                    left++;
                    continue;
                }

                if (sum > 0)
                {
                    right--;
                    continue;
                }

                result.Add(new List<int> { nums[i] , nums[left], nums[right] });
                left++;
                right--;
                while (nums[left] == nums[left - 1] && right > left)
                    left++;
                while (nums[right] == nums[right + 1] && right > left)
                    right--;
            }
        }
        return result;
    }
}