using System.Collections;

namespace List.CSharp.MyList
{
    // List methods:
    //  - New
    //  - GetAt
    //  - AddLast
    //  - PopLast

    public class Node<T> where T : notnull
    {
        public T data { get; set; }
        public Node<T>? next { get; set; }

        public Node(T x)
        {
            this.data = x;
        }
    }

    public class List<T> : IList<T> where T : notnull, IEquatable<T>
    {
        public Node<T>? first { get; private set; }
        public Node<T>? last { get; private set; }
        public int Count { get; private set; } = 0;

        public bool IsReadOnly => false;

        private void CheckIndex(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException($"List length is: {this.Count}, unexpected index: {index}");
            }
        }

        private Node<T> GetByIndex(int index)
        {
            var current = this.first;
            for (var i = 0; i < index; i++)
            {
                if (current is not null) { current = current.next; }
            }

            return current ?? throw new NullReferenceException("Internal error: list corrupted");
        }

        public T this[int index]
        {
            get => GetAt(index);
            set => SetAt(index, value);
        }

        public List(Node<T> first)
        {
            this.first = first;
            this.last = first;
            this.Count++;
        }

        public List()
        {
            this.first = null;
            this.last = null;
        }

        public T GetAt(int index)
        {
            CheckIndex(index);
            var current = GetByIndex(index);
            return current.data;
        }

        public void SetAt(int index, T item)
        {
            CheckIndex(index);
            var current = GetByIndex(index);
            current.data = item;
        }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item);
            if (this.Count == 0)
            {
                this.first = newNode;
                this.last = newNode;
            }
            else
            {
                newNode.next = this.first;
                this.first = newNode;
            }

            this.Count++;

        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>(item);
            if (this.Count == 0)
            {
                this.first = newNode;
                this.last = newNode;
            }
            else if (this.last is not null)
            {
                this.last.next = newNode;
                this.last = newNode;
            }

            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0 || this.first is null || this.last is null)
            {
                throw new IndexOutOfRangeException("list is empty");
            }

            var data = this.last.data;

            if (this.Count == 1)
            {
                this.first = null;
                this.last = null;
                return data;
            }

            var previous = this.first;
            var current = this.first;

            while (current.next is not null)
            {
                previous = current;
                current = current.next;
            }

            this.last = previous;
            this.Count--;
            return data;
        }

        public void RemoveLast()
        {
            if (this.Count == 0 || this.first is null || this.last is null)
            {
                throw new IndexOutOfRangeException("list is empty");
            }

            var data = this.last.data;

            if (this.Count == 1)
            {
                this.first = null;
                this.last = null;
                return;
            }

            var previous = this.first;
            var current = this.first;

            while (current.next is not null)
            {
                previous = current;
                current = current.next;
            }

            this.last = previous;
            this.Count--;
        }

        public int IndexOf(T item)
        {
            var current = this.first;
            if (current is null) return -1;
            if (item is null) throw new ArgumentNullException(nameof(item));
            
            var index = 0;
            while (current is not null && !current.data.Equals(item))
            {
                index++;
                current = current.next;
            }

            return (index == this.Count) ? -1 : index;
        }

        public void Insert(int index, T item)
        {
            if (index == 0)
            {
                AddFirst(item);
                return;
            }

            if (index == this.Count)
            {
                AddLast(item);
                return;
            }

            var previous = this.first;
            var current = this.first;

            for (var i = 1; i < index; i++)
            {
                if (current is not null)
                {
                    previous = current;
                    current = current.next;
                }
            }

            if (previous is null) { throw new NullReferenceException("Internal error: list corrupted"); }
            var node = new Node<T>(item);
            previous.next = node;
            node.next = current;
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);

            if (this.Count == 0 || this.first is null || this.last is null)
            {
                throw new IndexOutOfRangeException("list is empty");
            }

            if (index == Count - 1)
            {
                RemoveLast();
                return;
            }

            if (index == 0)
            {
                this.first = this.first.next;
                return;
            }

            var previous = this.first;
            var current = this.first;

            for (var i = 1; i < index; i++)
            {
                if (current is not null)
                {
                    previous = current;
                    current = current.next;
                }
            }

            if (current is null)
            {
                throw new NullReferenceException("Internal error: list corrupted");
            }

            previous.next = current.next;
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}