using System;
using System.Collections;
public class MyList
{
    private int[] _array = new int[4];
    
    private int _count = 0;

    public int Count 
    {
        get 
        {
             return _count;
             
        }
          
    }

    
    public int Add (int item) 
    {
       if (_count < _array.Length)
        {
            _array[_count] = item;
            _count++;

            return (_count - 1);
        }

        return -1;

    }

    public int IndexOf(int item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (_array[i] == item)
            {
                return i;
            }
        }
        return -1;
        
    }
    public void Remove(int item) 
    {
        RemoveAt(IndexOf(item));

        
    }

    public void RemoveAt(int index) 
    {
       if ((index >= 0) && (index < Count))
        {
            for (int i = index; i < Count - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            _count--;
        }
       
    }

    public void Insert(int index, int item) 
    {
        if ((_count + 1 <= _array.Length) && (index < Count) && (index >= 0))
        {
            _count++;

            for (int i = Count - 1; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[index] = item;
            
        }
        
    }

    public void Clear() 
    {
        _count = 0;
        
    }

    public string ToString() 
    { 
         return string.Join(", ", _array); 
    }


}
