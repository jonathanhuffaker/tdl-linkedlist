using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        public SinglyLinkedListNode firstLocation { get; set;}
        public SinglyLinkedList list { get; set; }
        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            foreach(string value in values)
            {
                this.AddLast(value);
            }
            //throw new NotImplementedException();
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get
            {
                return this.ElementAt(i);
                //throw new NotImplementedException();
            }
            set
            {
                SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
                if (i == 0)
                {
                    newNode.Next = firstLocation.Next;
                    firstLocation = newNode;
                }
                SinglyLinkedListNode thaNodeRightHere = firstLocation;
                int index = 1;
                while (index < i)
                {
                    thaNodeRightHere = thaNodeRightHere.Next;
                    index++;
                }

                thaNodeRightHere.Next = newNode;


                //throw new NotImplementedException(); 
            }
        }

        public void AddAfter(string existingValue, string value)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
            if(firstLocation == null)
            {
                throw new ArgumentException();
            }
            else
            {
                SinglyLinkedListNode newestOfNodes = firstLocation;
                while(newestOfNodes.Value != existingValue)
                {
                    newestOfNodes = newestOfNodes.Next;
                    if(newestOfNodes == null)
                    {
                        throw new ArgumentException();
                    }
                }
                if (newestOfNodes.Value == existingValue)
                {
                    newNode.Next = newestOfNodes.Next;
                    newestOfNodes.Next = newNode;
                }
            }
            //throw new NotImplementedException();
        }

        public void AddFirst(string value)
        {
            SinglyLinkedListNode firstNode = new SinglyLinkedListNode(value);
            if (firstLocation == null)
            {
                firstLocation = firstNode; 
            }
            else
            {
                firstNode.Next = firstLocation;
                firstLocation = firstNode;
            }

            
            //throw new NotImplementedException();
        }

        public void AddLast(string value)
        {
            SinglyLinkedListNode firstOne = new SinglyLinkedListNode(value);

            if (firstLocation == null)
            {
                firstLocation = firstOne;
            }
            else
            {
                SinglyLinkedListNode newnode = firstLocation;
                while (!newnode.IsLast())
                {
                    newnode = newnode.Next;

                }
                    newnode.Next = firstOne;
            }

            //  throw new NotImplementedException();
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            int count = 0;
            if(this.First() == null)
            {
                return count;
            }
            else
            {
                SinglyLinkedListNode countNode = firstLocation;
                count++;
                while (!countNode.IsLast())
                {
                    countNode = countNode.Next;
                    count++;
                }
                return count;
            }
            // throw new NotImplementedException();
        }

        public string ElementAt(int index)
        {
            SinglyLinkedListNode location = firstLocation;
            if (this.First() == null)
            {
                throw new ArgumentOutOfRangeException("No nodes");
            }

            //if(location.Next == null)
            //{
            //    throw new ArgumentOutOfRangeException();
            //}

            for (int i=0; i< index; i++)
            {
                location = location.Next;
                if (location == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
               
            }
           

            return location.ToString();
           //throw new NotImplementedException();
        }

        public string First()
        {
         return firstLocation?.ToString();
        }



        public int IndexOf(string value)
        {

            int index = 0;
            var node = firstLocation;
            if (firstLocation == null)
            {
                return -1;
            }
            while (!(node.Value == value))
            //while (true)
            {
                if (node.Next == null)
                {
                    return -1;
                }
                node = node.Next;
                index++;
            }
            return index;

            // throw new NotImplementedException();
        }

        public bool IsSorted()
        {
            if (firstLocation == null)
            {
                return true;
            }
            SinglyLinkedListNode sortNode = firstLocation;
            while (sortNode.Next != null)
            {
                if (String.Compare(sortNode.Value, sortNode.Next.Value) > 0)
                {
                    return false;
                }
                sortNode = sortNode.Next;
            }
            return true;
            //throw new NotImplementedException();
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            //throw new NotImplementedException();

            if (this.First() == null)
            {
                return null;
            }
            SinglyLinkedListNode lastNode = firstLocation;

            while (!lastNode.IsLast())
            {
                lastNode = lastNode.Next;
            }
            return lastNode?.ToString();
        }

        public void Remove(string value)
        {
            if (firstLocation.Value == value)
            {
                firstLocation = firstLocation.Next;
                return;
            }
            SinglyLinkedListNode newNode = firstLocation;
            int index = 0;

            while(newNode.Next != null)
            {
                if(newNode.Next.Value == value)
                {
                    newNode.Next = newNode.Next.Next;
                    return;
                }
                newNode = newNode.Next;
                index++;
            }
            return;
           
        }

        public void Sort()
        {

            //leaving my first try implementation so I can walk through it, but refactored sort is passing
            //if (firstLocation == null)
            //{
            //    return;
            //}

            //SinglyLinkedListNode sortNode = firstLocation;
            //while (sortNode.Next != null)
            //{
            //    int c = string.Compare(sortNode.Value, sortNode.Next.Value);

            //    if (c == -1)
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        if (c == 1)
            //        {

            //            SinglyLinkedListNode anotherNode = sortNode;
            //            var temp = sortNode.Next;
            //            sortNode = temp;
            //            anotherNode.Next = sortNode;
            //            sortNode.Next = anotherNode.Next.Next;
            //        }

            //    }


            //    sortNode = sortNode.Next;
            //    throw new NotImplementedException();
            //}



            // =================================
            SinglyLinkedListNode sortNode = firstLocation;
            string[] list = this.ToArray();
            if (!this.IsSorted())
            {
                while (sortNode != null)
                {
                    if (sortNode.CompareTo(sortNode.Next) == 1)
                    {
                        this.AddLast(sortNode.ToString());


                        //this.AddAfter(node.Next.ToString(), node.ToString());


                        this.Remove(sortNode.ToString());
                        break;
                    }
                    else
                    {
                        sortNode = sortNode.Next;
                    }
                }
            }

            if (!this.IsSorted())
            {
                this.Sort();
            }

            // ====================================

        }

        public string[] ToArray()
        {
            int count = this.Count();
            string[] arrayNode = new string [count];

            if(arrayNode == null)
            {
                return new string[] { };
            }

            else
            {
                for (int i=0; i<count; i++)
                {
                    arrayNode[i] = this.ElementAt(i);
                }
                return arrayNode;
                
            }
            
            
            
            //throw new NotImplementedException();
        }

        public override string ToString()
        {
            SinglyLinkedListNode stringNode = firstLocation;
            //string toString = " { ";

            if (stringNode == null)
            {
                return "{ }";
            }
           else 
            {
                StringBuilder stringOfNodes = new StringBuilder();
                stringOfNodes.Append("{ \"" + stringNode + "\"");
               if (firstLocation == null)
                {
                    stringOfNodes.Append(" }");
                    return stringOfNodes.ToString();
                }
                while (!stringNode.IsLast())
                {
                    stringNode = stringNode.Next;
                    stringOfNodes.Append(", \"" + stringNode.ToString() + "\"");
                }
                stringOfNodes.Append(" }");
                return stringOfNodes.ToString();
            }
        }
    }
}
