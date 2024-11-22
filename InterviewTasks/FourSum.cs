namespace InterviewTasks;

/// <summary>
/// 18.
/// Given an array nums of n integers, return an array of all the unique quadruplets
/// [nums[a], nums[b], nums[c], nums[d]] are distinct
/// You may return the answer in any order.
/// </summary>
public class FourSum
{
    public IList<IList<int>> Sums(int[] nums, int target) {
        Array.Sort(nums);
        var result = new List<IList<int>>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;

            for (var j = i + 1; j < nums.Length - 1; j++)
            {
                if (j > i + 1 && nums[j] == nums[j - 1])
                    continue;

                var left = j + 1;
                var right = nums.Length - 1;
                while (left < right)
                {
                    var sum1 = nums[i] + nums[j];
                    var sum2 = nums[left] + nums[right];
                    if (sum1 > 0 && sum2 > 0 && int.MaxValue - sum1 < sum2)
                    {
                        right--;
                        continue;
                    }
                    
                    if (sum1 < 0 && sum2 < 0 && int.MinValue - sum1 > sum2)
                    {
                        left++;
                        continue;
                    }

                    var sum = sum1 + sum2;
                    if (sum < target)
                    {
                        left++;
                        continue;
                    }

                    if (sum > target)
                    {
                        right--;
                        continue;
                    }

                    result.Add(new List<int> { nums[i], nums[j], nums[left], nums[right] });
                    left++;
                    right--;
                    while (nums[left] == nums[left - 1] && right > left)
                        left++;
                    while (nums[right] == nums[right + 1] && right > left)
                        right--;
                }
            }
        }
        return result;
    }
}