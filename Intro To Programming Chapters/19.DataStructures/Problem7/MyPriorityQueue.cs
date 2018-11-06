using System;
using System.Collections.Generic;
using System.Text;

namespace Problem7
{
    public class MyPriorityQueue<T>
    {
        private const int INIT_CAPACITY = 16;
        private int capacity;
        private KeyValuePair<int, T>[] priorityArray;
        private int firstFreeCell;
        private Stack<int> earlyFreedCells;
        private int count;

        public MyPriorityQueue()
        {
            this.capacity = INIT_CAPACITY;
            this.priorityArray = new KeyValuePair<int, T>[capacity];
            this.firstFreeCell = 0;
            this.earlyFreedCells = new Stack<int>();
            this.count = 0;
        }

        public int Count
        {
            get { return this.count; }
        }

        public void Add(T element, int priority)
        {
            KeyValuePair<int, T> addedElement = new KeyValuePair<int, T>(priority, element);

            if (this.earlyFreedCells.Count == 0)
            {
                priorityArray[firstFreeCell] = addedElement;
                int addedCell = firstFreeCell;
                RearrangePriorityWhenAdding(addedCell);
                firstFreeCell++;
            }
            else
            {
                int earlyFreedCellIndex = earlyFreedCells.Pop();
                priorityArray[earlyFreedCellIndex] = addedElement;
                int addedCell = earlyFreedCellIndex;
                RearrangePriorityWhenAdding(addedCell);
            }

            this.count++;

            if (count == capacity - 1)
            {
                DoubleGrowArray();
            }
        }

        public T ExtractTheSmallestElement()
        {
            int currentCell = 0;
            T result = this.priorityArray[currentCell].Value;
            earlyFreedCells.Push(currentCell);
            this.priorityArray[currentCell] = new KeyValuePair<int, T>(int.MaxValue, this.priorityArray[currentCell].Value);

            RearrangePriorityWhenExtracting(currentCell);
            this.count--;

            return result;
        }

        private void DoubleGrowArray()
        {
            KeyValuePair<int, T>[] oldPriorityArray = new KeyValuePair<int, T>[capacity];

            for (int i = 0; i < this.priorityArray.Length; i++)
            {
                oldPriorityArray[i] = this.priorityArray[i];
            }

            this.priorityArray = new KeyValuePair<int, T>[capacity * 2];

            for (int i = 0; i < oldPriorityArray.Length; i++)
            {
                this.priorityArray[i] = oldPriorityArray[i];
            }

            this.capacity = this.capacity * 2;
        }

        private void RearrangePriorityWhenAdding(int addedCell)
        {
            int currentCell = addedCell;

            while (currentCell != 0)
            {
                if (currentCell % 2 == 1)
                {
                    if (priorityArray[currentCell].Key < priorityArray[currentCell / 2].Key)
                    {
                        KeyValuePair<int, T> exchangeVariable = priorityArray[currentCell];
                        priorityArray[currentCell] = priorityArray[currentCell / 2];
                        priorityArray[currentCell / 2] = exchangeVariable;
                        currentCell = currentCell / 2;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (priorityArray[currentCell].Key < priorityArray[currentCell / 2 - 1].Key)
                    {
                        KeyValuePair<int, T> exchangeVariable = priorityArray[currentCell];
                        priorityArray[currentCell] = priorityArray[currentCell / 2 - 1];
                        priorityArray[currentCell / 2 - 1] = exchangeVariable;
                        currentCell = currentCell / 2 - 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void RearrangePriorityWhenExtracting(int extractedCell)
        {
            int currentCell = extractedCell;
            int child1Index = currentCell * 2 + 1;
            int child2Index = currentCell * 2 + 2;

            while (child1Index < firstFreeCell && child2Index < firstFreeCell)
            {
                if (child2Index < firstFreeCell)
                {
                    if (this.priorityArray[child1Index].Key < this.priorityArray[child2Index].Key)
                    {
                        this.priorityArray[currentCell] = this.priorityArray[child1Index];
                        this.priorityArray[child1Index] = new KeyValuePair<int, T>(int.MaxValue, this.priorityArray[child1Index].Value);
                        earlyFreedCells.Pop();
                        earlyFreedCells.Push(child1Index);

                        currentCell = child1Index;
                        child1Index = currentCell * 2 + 1; ;
                        child2Index = currentCell * 2 + 2;
                    }
                    else
                    {
                        this.priorityArray[currentCell] = this.priorityArray[child2Index];
                        this.priorityArray[child2Index] = new KeyValuePair<int, T>(int.MaxValue, this.priorityArray[child2Index].Value);
                        earlyFreedCells.Pop();
                        earlyFreedCells.Push(child2Index);

                        currentCell = child2Index;
                        child1Index = currentCell * 2 + 1; ;
                        child2Index = currentCell * 2 + 2;
                    }
                }
                else
                {
                    this.priorityArray[currentCell] = this.priorityArray[child1Index];
                    this.priorityArray[child1Index] = new KeyValuePair<int, T>(int.MaxValue, this.priorityArray[child1Index].Value);
                    earlyFreedCells.Pop();
                    earlyFreedCells.Push(child1Index);

                    currentCell = child1Index;
                    child1Index = currentCell * 2 + 1; ;
                    child2Index = currentCell * 2 + 2;
                }
            }

            this.priorityArray[currentCell] = new KeyValuePair<int, T>(int.MaxValue, this.priorityArray[currentCell].Value);
        }
    }
}
