public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {

        int n = nums.Length;

        // Create a 2D list of frequencies. The index 'i' is the number of occurrences, and the
        // list returned by 'freq[i]' will contain all integers that occur exactly 'i' times in 'nums'.
        var freq = new List<int>[n + 1];
        for (int i=0; i<freq.Length; i++) {
            freq[i] = new List<int>();
        }
        
        
        // Run through nums once and keep track of how many times each int shows up.
        var count = new Dictionary<int, int>();

        foreach (int i in nums) {
            if (!count.ContainsKey(i))
                count[i] = 1;
            else
                count[i]++;
        }

        // Convert the count into frequency.
        foreach (var key in count.Keys) {
            int number = key;
            int occurrences = count[key];

            freq[occurrences].Add(number);
        }

        // Grab and return the K most frequent results.
        var result = new int[k];
        int ctr = 0;
        
        for (int i = freq.Length - 1; i >= 0; i--) {
            // Any frequencies of 0 can be skipped.
            if (freq[i].Count == 0)
                continue;
            
            // Some frequencies have multiple values, so make sure we're adding all of them to the list.
            // WARNING: This assumes that we'll never have a situation where we reach "K" results before we
            //  finish going through the current frequency bucket!!
            foreach (int j in freq[i]) {
                result[ctr++] = j;
            }

            // Done with first K elements.
            if (ctr >= k)
                return result;
        }

        // Return the result if we haven't already.
        return result;
    }
}
