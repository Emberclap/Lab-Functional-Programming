namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {  
           double[] prices = Console.ReadLine()
               .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
               .Select(double.Parse)
               .Select(n => n * 1.2)
               .ToArray();
            foreach (var pr in prices)
            {
                Console.WriteLine($"{pr:f2}") ;
            }
           
       

        }
    }
}