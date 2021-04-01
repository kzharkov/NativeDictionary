using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class NativeDictionary<T>
    {
        public int size;
        public string[] slots;
        public T[] values;

        public NativeDictionary(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
        }

        public int HashFun(string key)
        {
            int sum = 0;
            Array.ForEach(key.ToCharArray(), delegate (char i) { sum += i; });
            return sum % size;
        }

        public bool IsKey(string key)
        {
            if (slots[HashFun(key)] == key)
            {
                return true;
            }
            return false;
        }

        public void Put(string key, T value)
        {
            int slot = HashFun(key);
            slots[slot] = key;
            values[slot] = value;
        }

        public T Get(string key)
        {
            if (IsKey(key))
            {
                return values[HashFun(key)];
            }
            return default;
        }
    }
}