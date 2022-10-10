using OrderedList;
namespace OrderedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var quickPushObject = new QuickPushOrderedList<char>();
            var quickPopObject = new QuickPopOrderedList<char>();

            quickPushObject.Push('C');
            quickPushObject.Push('D');
            quickPushObject.Push('A');
            quickPushObject.Push('B');
            quickPushObject.Push('A');

            for (int i = 0; i < 5; i++) 
            {
                Console.WriteLine(quickPushObject.Pop());
            }

            quickPopObject.Push('C');
            quickPopObject.Push('D');
            quickPopObject.Push('A');
            quickPopObject.Push('B');
            quickPopObject.Push('A');

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(quickPopObject.Pop());
            }
        }
    }
}