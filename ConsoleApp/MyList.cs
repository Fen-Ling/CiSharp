public class MyList<TItem>
{
    private TItem[] _array;
    private int _count = 0;
    public int _capacity = 4;

    public int Capacity
    {
        set
        {
            if (_capacity > value)
            {
                System.Array.Resize(ref _array, value);
                _capacity = value;
            }
        }
        get => _capacity;
    }

    public int Count => _count;

    public MyList()
    {
        _array = new TItem[_capacity];
    }

    public MyList(int capacity)
    {
        _array = new TItem[capacity];
        this.Capacity = capacity;
    }

    public void Add(TItem item) 
    {
        if (_count + 1 >= _capacity)
        {
            this.Capacity *= 2;
        }

        _array[_count++] = item;
    }

    public void Remove(TItem item) 
    {
        int index = Array.IndexOf(_array, item, 0, _count);
        if (index >= 0) 
        {
            for (int i = index; i < _count - 1; i++)
            {
            _array[i] = _array[i + 1];
            }
            _count--;
            return;
        }
    }

    public void RemoveAt(int index) 
    {
        if (index < 0 && index >= _count)
        {
            Console.WriteLine ($"Ошибка ввода индекса");
            return;
        }
        for (int i = index; i < _count - 1; i++)
        {
            _array[i] = _array[i + 1];
        }
    
        _count--; 
    }

    public void Insert(int index, TItem item) 
    {
        if (index < 0 && index > _count)
        {
            Console.WriteLine ($"Ошибка ввода индекса");
            return;
        }
        if (_count >= _capacity)
            {
                Capacity *= 2;
            }

        for (int i = _count; i > index; i--)
            {
            _array[i] = _array[i - 1];
            }

        _array[index] = item; 
        _count++; 
    }

    public void Clear() 
    {
    _array = new TItem[_capacity]; 
    _count = 0;
    }

    public override string ToString() 
    { 
        string result = "[";

        for(int i = 0; i < Count; i++)
        {
            result += _array [i];
            if(i < Count - 1)
                result += ", ";
        }

        result += "}";
        return result;
    }

    public int IndexOf(TItem item)
    {
        for (int i = 0; i < _count; i++) 
        {
            if (EqualityComparer<TItem>.Default.Equals(_array[i], item)) 
            {
                return i; 
            }
        }
        return -1; 
    }

    public void ForEach(System.Action<TItem> action)
    {
        if (action == null) 
    {
        throw new ArgumentNullException(nameof(action), "Действие не может быть null.");
    }

    for (int i = 0; i < _count; i++) 
    {
        action(_array[i]); 
    }
    }

    public TItem Find(System.Func<TItem, bool>  predicate)
    {
        if (predicate == null) 
        {
            throw new ArgumentNullException(nameof(predicate), "Предикат не может быть null.");
        }

        for (int i = 0; i < _count; i++) 
        {
            if (predicate(_array[i])) 
            {
                return _array[i]; 
            }
        }

        return default; 
    }

    public void Sort(System.Func<TItem, TItem, int> sort)
    {
        for (int i = 1; i < _count; i++)
    {
        var current = _array[i];
        int j = i - 1;

        while (j >= 0 && sort(_array[j], current) > 0)
        {
            _array[j + 1] = _array[j];
            j--;
        }
        
        _array[j + 1] = current; 
    }
    }
}