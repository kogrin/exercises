namespace MyList
{
    class Node<T>
    {
        public T data { get; private set; }
        public Node<T>? next { get; set; }

        public Node(T x)
        {
            this.data = x;
        }
    }

    class List<T>
    {
        public Node<T>? first { get; private set; }
        public Node<T>? last { get; private set; }
        public int Length { get; private set; } = 0;

        public List(Node<T> first)
        {
            this.first = first;
            this.last = first;
            this.Length++;
        }

        public List()
        {
            this.first = null;
            this.last = null;
        }

        public T GetAt(int index)
        {
            if (index >= this.Length)
            {
                throw new IndexOutOfRangeException(
                    $"Index: {index} is out if list bounds, length: {this.Length}"
                );
            }

            if (this.Length == 0 || this.first == null || this.last == null)
            {
                throw new IndexOutOfRangeException("list is empty");
            }

            var tmp = this.first;

            for (var i = 0; i < index; i++)
            {
                if (tmp != null)
                {
                    tmp = tmp.next;
                }
            }

            if (tmp == null)
            {
                throw new Exception("Internal error: list corrupted");
            }

            return tmp.data;
        }

        public void AddFirst(T x)
        {
            var newNode = new Node<T>(x);
            if (this.Length == 0)
            {
                this.first = newNode;
                this.last = newNode;
            }
            else
            {
                newNode.next = this.first;
                this.first = newNode;
            }

            this.Length++;

        }

        public void AddLast(T x)
        {
            var newNode = new Node<T>(x);
            if (this.Length == 0)
            {
                this.first = newNode;
                this.last = newNode;
            }
            else if (this.last != null)
            {
                this.last.next = newNode;
                this.last = newNode;
            }

            this.Length++;
        }

        public T Pop()
        {
            if (this.Length == 0 || this.first == null || this.last == null)
            {
                throw new IndexOutOfRangeException("list is empty");
            }

            var data = this.last.data;

            if (this.Length == 1)
            {
                this.first = null;
                this.last = null;
                return data;
            }

            var previous = this.first;
            var current = this.first;

            while (current.next != null)
            {
                previous = current;
                current = current.next;
            }

            this.last = previous;
            this.Length--;
            return data;
        }

        public void RemoveLast()
        {
            if (this.Length == 0 || this.first == null || this.last == null)
            {
                throw new IndexOutOfRangeException("list is empty");
            }

            var data = this.last.data;

            if (this.Length == 1)
            {
                this.first = null;
                this.last = null;
                return;
            }

            var previous = this.first;
            var current = this.first;

            while (current.next != null)
            {
                previous = current;
                current = current.next;
            }

            this.last = previous;
            this.Length--;
        }
    }

}