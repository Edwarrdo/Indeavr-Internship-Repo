using System;
using System.Collections;
using System.Collections.Generic;

namespace Problem13
{
    //the easy basic solution wont work if we have 10000000+ elements, so we will use treemultiset class
    //and save top 10 sequences, that satisfy us
    //that way we save much memory and our program will work with larger quantities of numbers
    class TreeMultiSet<T> : IEnumerable<KeyValuePair<T, int>> where T : IList
    {
        private SortedDictionary<T, int> container;

        public int Count
        {
            get
            {
                int count = container.Count;
                return count;
            }
        }

        public TreeMultiSet()
        {
            this.container = new SortedDictionary<T, int>();
        }

        public TreeMultiSet(IComparer<T> comparer)
        {
            this.container = new SortedDictionary<T, int>(comparer);
        }

        public void Add(T element)
        {
            int count;
            bool containsElement = this.container.TryGetValue(element, out count);
            if (containsElement)
            {
                count++;
            }
            else
            {
                count = 1;
            }

            this.container[element] = count;
        }

        public int CountOf(T element)
        {
            int count;
            bool containsElement = this.container.TryGetValue(element, out count);
            if (!containsElement)
            {
                count = 0;
            }
            return count;
        }
        public bool Remove(T element)
        {
            bool result = this.container.Remove(element);
            return result;
        }

        public T SmallestElement()
        {
            T result = default(T);
            foreach (var item in container)
            {
                result = item.Key;
                break;
            }
            return result;
        }

        public T LargestElement()
        {
            T result = default(T);
            foreach (var item in container)
            {
                result = item.Key;
            }
            return result;
        }

        public bool RemoveSmallestElement()
        {
            T elementToRemove = this.SmallestElement();
            bool result = this.container.Remove(elementToRemove);
            return result;
        }

        public bool RemoveLargestElement()
        {
            T elementToRemove = this.LargestElement();
            int elementToRemoveCount = this.container[elementToRemove];
            bool result;
            if (elementToRemoveCount == 1)
            {
                result = this.container.Remove(elementToRemove);
            }
            else
            {
                int newCount = elementToRemoveCount - 1;
                this.container[elementToRemove] = newCount;
                return true;
            }
            return result;
        }

        IEnumerator<KeyValuePair<T, int>> IEnumerable<KeyValuePair<T, int>>.GetEnumerator()
        {
            foreach (KeyValuePair<T, int> entry in this.container)
            {
                yield return entry;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<T, int>>)this).GetEnumerator();
        }

        public int AllElementsCount()
        {
            int count = 0;
            foreach (var item in this.container)
            {
                count += item.Value;
            }
            return count;
        }
    }

    public class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string inputLine = Console.ReadLine();
            string[] tokens = inputLine.Split(' ');

            int[] array = new int[tokens.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(tokens[i]);
            }

            Comparer<List<int>, int> comparer = new Comparer<List<int>, int>();
            TreeMultiSet<List<int>> set = new TreeMultiSet<List<int>>(comparer);

            FindHappySequences(array, number, set);

            PrintHappySubsets(set);
        }

        private static void PrintHappySubsets(TreeMultiSet<List<int>> set)
        {
            foreach (var subset in set)
            {
                for (int i = 0; i < subset.Value; i++)
                {
                    foreach (var element in subset.Key)
                    {

                        Console.Write("{0} ", element);
                    }
                    if (i < subset.Value - 1)
                    {
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
            }
        }

        private static void FindHappySequences(int[] array, int number, TreeMultiSet<List<int>> set)
        {
            for (int startIndex = 0; startIndex < array.Length; startIndex++)
            {
                int currentSum = 0;
                List<int> newSequence = new List<int>();
                for (int endIndex = startIndex; endIndex < array.Length; endIndex++)
                {
                    int newElement = array[endIndex];
                    currentSum += newElement;
                    newSequence.Add(newElement);
                    if (currentSum == number)
                    {
                        List<int> happySequence = new List<int>(newSequence);
                        set.Add(happySequence);
                        if (set.AllElementsCount() == 11)
                        {
                            set.RemoveLargestElement();
                        }
                    }
                }
            }
        }
    }

    public class Comparer<T, K> : IComparer<T>
        where T : IList<K>
        where K : IComparable
    {
        public int Compare(T x, T y)
        {
            if (x.Count == y.Count)
            {
                for (int index = 0; index < x.Count; index++)
                {
                    if (x[index].CompareTo(y[index]) > 0)
                    {
                        return -1;
                    }
                    else if (x[index].CompareTo(y[index]) < 0)
                    {
                        return 1;
                    }
                }
                return 0;
            }
            else
            {
                int result = -x.Count.CompareTo(y.Count);
                return result;
            }
        }
    }
}
