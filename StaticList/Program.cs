namespace StaticList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomArrayList<string> listOfBook = new CustomArrayList<string>();
            listOfBook.Add("Fastlane millionare");
            listOfBook.Add("48 laws of power");
            listOfBook.Add("Data structures, using common sense");
            listOfBook.Insert(2, "How to be better in everything");
            listOfBook.Add("nonsense book");
            listOfBook.Insert(3, "Mental fitness");
            listOfBook.Remove("nonsense book");
            listOfBook.RemoveAt(3);

            Console.WriteLine("I am going to buy: ");
            for(int i = 0; i < listOfBook.Count; i++)
            {
                Console.WriteLine(" * " + listOfBook[i]);
            }

            Console.WriteLine("The psition of 'fastlane millionare' is {0}", listOfBook.IndexOf("Fastlane millionare"));
        }
    }
}