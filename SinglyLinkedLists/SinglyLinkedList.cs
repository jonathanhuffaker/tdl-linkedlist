using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        SinglyLinkedListNode firstLocation { get; set;}
        SinglyLinkedList list { get; set; }
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
                while (index < 1)
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
            for (int i=0; i< index; i++)
            {
                location = location.Next;
            }

            return location.ToString();
           //throw new NotImplementedException();
        }


        public int IndexOf(string value)
        {
            int index = 0;
            SinglyLinkedListNode node = firstLocation;
            while (true)
            {
                if (node.Value == value)
                {
                    break;
                }
                node = node.Next;
                index++;
            }
            return index;

            // throw new NotImplementedException();
        }

        public bool IsSorted()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
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
