using System.Collections;

namespace List.CSharp.MyList
{
    public class Node<T> where T : notnull
    {
        public T Data { get; set; }
        public Node<T>? Next { get; set; }

        public Node(T x)
        {
            this.Data = x;
        }
    }

    public class List<T> : IList<T> where T : notnull, IEquatable<T>
    {
        public Node<T>? First { get; private set; }
        public Node<T>? Last { get; private set; }
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
            var current = this.First;
            for (var i = 0; i < index; i++)
            {
                current = current?.Next;
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
            this.First = first;
            this.Last = first;
            this.Count++;
        }

        public List()
        {
            this.First = null;
            this.Last = null;
        }

        public T GetAt(int index)
        {
            CheckIndex(index);
            var current = GetByIndex(index);
            return current.Data;
        }

        public void SetAt(int index, T item)
        {
            CheckIndex(index);
            var current = GetByIndex(index);
            current.Data = item;
        }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item);
            if (this.Count == 0)
            {
                this.First = newNode;
                this.Last = newNode;
            }
            else
            {
                newNode.Next = this.First;
                this.First = newNode;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>(item);
            if (this.Count == 0)
            {
                this.First = newNode;
                this.Last = newNode;
            }
            else if (this.Last is not null)
            {
                this.Last.Next = newNode;
                this.Last = newNode;
            }

            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0 || this.First is null || this.Last is null)
            {
                throw new IndexOutOfRangeException("list is empty");
            }

            var data = this.Last.Data;

            if (this.Count == 1)
            {
                this.First = null;
                this.Last = null;
                return data;
            }

            var previous = this.First;
            var current = this.First;

            while (current.Next is not null)
            {
                previous = current;
                current = current.Next;
            }

            this.Last = previous;
            this.Count--;
            return data;
        }

        public void RemoveLast()
        {
            if (this.Count == 0 || this.First is null || this.Last is null)
            {
                throw new IndexOutOfRangeException("list is empty");
            }

            var data = this.Last.Data;

            if (this.Count == 1)
            {
                this.First = null;
                this.Last = null;
                return;
            }

            var previous = this.First;
            var current = this.First;

            while (current.Next is not null)
            {
                previous = current;
                current = current.Next;
            }

            this.Last = previous;
            this.Count--;
        }

        public int IndexOf(T item)
        {
            var current = this.First;
            if (current is null) return -1;
            if (item is null) throw new ArgumentNullException(nameof(item));

            var index = 0;
            while (current is not null && !current.Data.Equals(item))
            {
                index++;
                current = current.Next;
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

            var previous = this.First;
            var current = this.First;

            for (var i = 1; i < index; i++)
            {
                if (current is not null)
                {
                    previous = current;
                    current = current.Next;
                }
            }

            if (previous is null)
            {
                throw new NullReferenceException("Internal error: list corrupted");
            }

            var node = new Node<T>(item);
            previous.Next = node;
            node.Next = current;
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);

            if (this.Count == 0 || this.First is null || this.Last is null)
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
                this.First = this.First.Next;
                return;
            }

            var previous = this.First;
            var current = this.First;

            for (var i = 1; i < index; i++)
            {
                if (current is not null)
                {
                    previous = current;
                    current = current.Next;
                }
            }

            if (current is null)
            {
                throw new NullReferenceException("Internal error: list corrupted");
            }

            previous.Next = current.Next;
        }

        public void Add(T item) => AddLast(item);

        public void Clear()
        {
            this.First = null;
            this.Last = null;
            this.Count = 0;
        }

        public bool Contains(T item)
        {
            var current = this.First;
            if (current is null) return false;
            if (item is null) throw new ArgumentNullException(nameof(item));

            var index = 0;
            while (current is not null && !current.Data.Equals(item))
            {
                index++;
                current = current.Next;
            }

            return index != this.Count;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            if (array.Length < this.Count + arrayIndex)
                throw new ArgumentException("Array's size is less than list", nameof(array));

            var k = arrayIndex;
            var current = this.First;
            for (var i = 0; i < this.Count; i++)
            {
                if (current == null) throw new NullReferenceException("List is corrupted");
                array[k] = current.Data;
                current = current.Next;
                k += 1;
            }
        }

        public bool Remove(T item)
        {
            var current = this.First;
            if (current is null) return false;
            if (item is null) throw new ArgumentNullException(nameof(item));

            var index = 0;
            while (current is not null && !current.Data.Equals(item))
            {
                index++;
                current = current.Next;
            }

            if (index == this.Count) return false;
            if (index == this.Count - 1) this.RemoveLast();
            else this.RemoveAt(index);
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public struct ListEnumerator : IEnumerator<T>, IEnumerator
        {
            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public T Current { get; }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}