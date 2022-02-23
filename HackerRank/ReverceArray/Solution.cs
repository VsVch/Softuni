
public class Result
{   
    public static List<int> reverseArray(List<int> a)
    {
        var result = new List<int>();

        for (int i = a.Count - 1; i >= 0; i--)
        {
            var num = a[i];
            result.Add(num);
        }
       
        return result;
    }
}

public class Solution
{
    public static void Main(string[] args)
    {     
      
        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').Select(int.Parse).ToList();

        List<int> res = Result.reverseArray(arr);

        Console.WriteLine(String.Join(" ", res));
        
    }
}
