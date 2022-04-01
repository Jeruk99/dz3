using System;

namespace dz3
{
    public class Node
    {
        public int Info { get; set; }
        public Node Link { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr;
            Console.Write("Введите длину массива >> ");
            int n;
            while (!Int32.TryParse(Console.ReadLine(), out n) && n <= 0)
                Console.Write("Некорректный ввод, повторите >> ");
            arr = new int[n];
            Console.Write("Введите элементы массива через пробел >> ");
            string[] enteredElem = Console.ReadLine().Split();
         
            bool allAreInts = false;
            while (enteredElem.Length != n || !allAreInts)
            {
                if (enteredElem.Length  ==  n)
                {
                        allAreInts = true;
                        foreach (string element in enteredElem)
                            if (!Int32.TryParse(element, out _))
                                allAreInts = false;
                        if (!allAreInts)
                        {
                            Console.Write("Некорректный ввод, повторите >> ");
                            enteredElem = Console.ReadLine().Split();
                        }
                }
                else
                {
                    Console.Write("Некорректный ввод, повторите >> ");
                    enteredElem = Console.ReadLine().Split();
                }
            }
            
            for (int i =  0; i  <  arr.Length;  i++)
                arr[i]  =  int.Parse(enteredElem[i]); 
            Node list = GetLinkedList(arr);
            PrintList(list);
        }
        public static Node GetLinkedList(int[] arr)
        {
            Node list = null;
            foreach (int element in arr)
                Append(element, ref list);
            return list;
        }
        public static void PrintList(Node list)
        {
            string Out = "Сформированный список: ";
            Node curNode = list;
            while(curNode != null)
            {
                Out+= curNode.Info + " ";
                curNode = curNode.Link;
            }
            Console.WriteLine(Out);
        }
        public static void Append(int value, ref Node Head)
        {
             Node newNode = new Node();
            newNode.Info = value;
            if (Head != null)
            {
                Node currentNode = Head;
                while (currentNode.Link != null)
                {
                    currentNode = currentNode.Link;
                }
                currentNode.Link = newNode;
            }
            else
                Head = newNode;
        }
    }

}
