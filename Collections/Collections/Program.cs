using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList(); // dynamic sized array
            List<string> list = new List<string>();

            arrayList.Add("hello");
            list.Add("generic hello");

            Console.WriteLine(arrayList[0]);
            Console.WriteLine(list[0]);

            Hashtable hashTable = new Hashtable();
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            hashTable.Add("myKey", "myValue");
            dictionary.Add("genericKey", "genericValue");

            Console.WriteLine(hashTable["myKey"]);
            Console.WriteLine(dictionary["genericKey"]);


            HashSet<string> hashSet = new HashSet<string>();
            hashSet.Add("hello");
            hashSet.Add("hello");

            Console.WriteLine(hashSet.ElementAt(0));

            SortedList sortedList = new SortedList();
            SortedList<string, string> genericSortedList = new SortedList<string, string>();

            sortedList.Add("sortedListKey", "sortedKeyValue");

            Console.WriteLine(sortedList["sortedListKey"]);

            genericSortedList.Add("genericKey", "generic value");

            Console.WriteLine(genericSortedList["genericKey"]);

            Stack stack = new Stack();
            stack.Push("World");
            stack.Push("Hello");

            var genericStack = new Stack<string>();

            genericStack.Push("generic hello");
            genericStack.Push("generic goodbye");

            Console.WriteLine(genericStack.Pop());
            Console.WriteLine(genericStack.Pop());

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            Queue queue = new Queue();
            Queue<string> gQueue = new Queue<string>();

            queue.Enqueue("Hello");
            queue.Enqueue("from the other side");

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());

            gQueue.Enqueue("Hello genics");
            gQueue.Enqueue("goodbye generics");

            Console.WriteLine(gQueue.Dequeue());
            Console.WriteLine(gQueue.Dequeue());

            BitArray bitArray = new BitArray(new bool[] { false, true, false, true });
            Console.WriteLine(bitArray[3]);

            Console.ReadKey();
        }
    }
}
