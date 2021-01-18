using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListExample.Lib
{
    public class IntegerLinkedList
    {
        private IntegerNode _head;

        public IntegerLinkedList(int n)
        {
            _head = new IntegerNode(n);
        }

        public IntegerLinkedList()
        {
            _head = null;
        }

        public int Count 
        {
            get
            {
                if (_head == null)
                {
                    return 0;
                }
                else
                {
                    return _head.Count;
                }
            }
        }

        public int Sum
        {
            get
            {
                if (_head == null)
                {
                    return 0;
                }
                else
                {
                    return _head.Sum;
                }
            }
        }
        
        public void Join(IntegerLinkedList list2)
        {
            IntegerNode head2 = list2._head;
            if (_head != null)
            {
                _head.Join(head2);
            }

        }
        public void Append(int v)
        {
            if(_head == null)
            {
                _head = new IntegerNode(v);
            }
            else
            {
                _head.Append(v);
            }
        }

        public bool Delete(int v)
        {
            if (_head == null)
            {
                return false;
            }
            else
            {
                if (_head.Value == v)  //if the first node is the value
                {
                    _head = _head.Next;
                }
                return _head.Delete(v);                
            }
        }

        public void RemoveDuplicates()
        {
            IntegerNode currentNode = _head;
            while (currentNode != null)
            {
                int count = CountOccurences(currentNode.Value);
                if(count > 1)
                {
                    for(;count>0; --count)
                    {
                        Delete(currentNode.Value);
                    }
                }
                currentNode = currentNode.Next;
            }
        }

        public int CountOccurences(int v)
        {
            return _head.CountOccurences(0, v);
        }
        
        public IntegerLinkedList AlternateMerge(IntegerLinkedList ill2)
        {
            if(_head == null)
            {
                return ill2;
            }
            else if(ill2._head == null)
            {
                return this;
            }
            else
            {
                IntegerLinkedList newList = new IntegerLinkedList(_head.Value);
                newList.Append(ill2._head.Value);
                newList = _head.AlternateMerge(newList, ill2._head);
                return newList;
            }

        }
        public override string ToString()
        {
            string listStr = "{";
            IntegerNode currentNode = _head;
            while (currentNode != null)
            {
                listStr = listStr + currentNode.ToString() + ", ";
                currentNode = currentNode.Next;
            }
            listStr = listStr.Substring(0, listStr.Length - 2) + "}"; //remove the last group of ", " and add the close bracket
            return listStr;
        }
    }

    class IntegerNode
    {
        int _value;
        IntegerNode _next;
        public IntegerNode(int v)
        {
            _value = v;
            _next = null;
        }

        public IntegerNode Next
        { get { return _next; }
          set { _next = value; }
        }
        public int Value
        { get { return _value; } }

        public int Count
        {
            get
            {
                if (_next == null)
                {
                    return 1;
                }
                else
                {
                    return 1 + _next.Count;
                }
            }
        }
        public int Sum
        {
            get
            {
                if (_next == null)
                {
                    return _value;
                }
                else
                {
                    return _value + _next.Sum;
                }
            }
        }

        public void Append(int v)
        {
            if (_next == null)
            {
                _next = new IntegerNode(v);
            }
            else
            {
                _next.Append(v);
            }
        }

        public bool Delete(int v)
        {
            if (_next == null)
            {
                return false;
            }
            else
            {
                if (_next._value == v)
                {
                    _next = _next._next;
                    return true;
                }
                else
                {
                    return _next.Delete(v);
                }
            }
        }

        public void Join(IntegerNode head2)
        {
            if (_next == null)
            {
                _next = head2;
            }
            else
            {
                _next.Join(head2);
            }
        }

        public override string ToString()
        {
            return Convert.ToString(_value);
        }

        public int CountOccurences(int count, int v)
        {
            if (_next == null)
            {
                return count;
            }
            else
            {
                if (_next._value == v)
                {
                    return 1 + _next.CountOccurences(count, v);
                }
                else
                    return _next.CountOccurences(count, v);

            }
        }

        public IntegerLinkedList AlternateMerge(IntegerLinkedList newList, IntegerNode node2)
        {
            if(_next == null)
            {
                if (node2._next == null)  //if both reached end
                {
                    return newList;
                }
                else
                {
                    newList.Append(node2._next._value);
                    return this.AlternateMerge(newList, node2._next);
                }
            }
            else if(node2._next == null)
            {
                newList.Append(_next._value);
                return _next.AlternateMerge(newList, node2);
            }
            else
            {
                newList.Append(_next._value);
                newList.Append(node2._next._value);
                return _next.AlternateMerge(newList, node2._next);
            }
        }
    }

}
