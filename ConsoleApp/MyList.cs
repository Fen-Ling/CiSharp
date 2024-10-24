using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
public class MyList<TItem>
{
    private int[] _array;
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
        _array = new int[_capacity];
    }

    public MyList(int capacity)
    {
        _array = new int[capacity];
        this.Capacity = capacity;
    }

    
    public void Add(int item) 
    {
        
        if (_count >= _capacity)
        {
            int[] new_array = new int[_capacity*2];
            for (int i = 0; i < _capacity; i++)
            {
                new_array[i] = _array[i];
            }
            _array = new_array;
        }

        _array[_count] = item;
        _count++;
    }

    public void Remove(int item) 
    {
       for (int i = 0; i < _count; i++)
       {
            if(_array[i] >= item)
            {
            RemoveAt (i);
            return;
            }
       }
    }

    public void RemoveAt(int index) 
    {
       if (index < 0 && index >= _count)
        {
            Console.WriteLine ($"Ошибка ввода индекса");
            return;
        }
       
       
       if ((index >= 0) && (index <= _count))
        {
            for (int i = index; i < _count - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            _count--;

        }
    }

    public void Insert(int index, int item) 
    {

        if (index < 0 && index > _count)
        {
            Console.WriteLine ($"Ошибка ввода индекса");
            return;
        }
        
        for (int i = _count; i > index; i--)
            _array [i] = _array [i-1];

        _array[index] = item;
        _count++;
    }

    public void Clear() 
    {
        _array = new int[_capacity];
        _count = 0;
        
    }

    public int IndexOf(int item)
    {
        for (int i = 0; i < _array.Length; i++)
        {
            if (_array[i] == item)
            {
                return i;
            }
        }
        return -1;
        
    }

    public void ForEach(System.Action<int> action)
    {
        for (int i = 0; i < _count; i++)
        {
            action(_array[i]); 
        }

    }

        
    public int Find(System.Func<int, bool>  predicate)
    {
        for (int i = 0; i < _count; i++)
        {
            if (predicate(_array[i]))
            {
                return _array[i]; 
            }
        }
        return default;
    }

    public void Sort(System.Func<int, int, int> sort)
    {
        for (int i = 0; i < _count - 1; i++)
        {
            for (int j = 0; j < _count - 1 - i; j++)
            {
                if (sort(_array[j], _array[j + 1]) > 0)
                {
                    int temp = _array[j];
                    _array[j] = _array[j + 1];
                    _array[j + 1] = temp;
                }
            }
        }
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


}
