using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

[Serializable]
public class SerializableDictionary<TKey, TValue> : IDictionary<TKey, TValue>
{
    [SerializeField]
    private List<TKey> keys = new List<TKey>();
    [SerializeField]
    private List<TValue> values = new List<TValue>();
    [NonSerialized]
    private int dictionaryModificationCount;

    public TValue this[TKey key]
    {
        get
        {
            if(key == null)
            {
                throw new ArgumentNullException("key");
            }
            var index = keys.IndexOf(key);
            if(index != -1)
            {
                return values[index];
            }
            throw new KeyNotFoundException(key.ToString());
        }
        set 
        {
            if(key == null)
            {
                throw new ArgumentNullException("key");
            }
            var index = keys.IndexOf(key);
            if(index == -1)
            {
                keys.Add(key);
                values.Add(value);
            }
            else
            {
                values[index] = value;
            }
            dictionaryModificationCount++;
        }
    }

    public int Count => keys.Count;

    public bool IsReadOnly { get => false; }

    public ICollection<TKey> Keys { get => keys; }

    public ICollection<TValue> Values { get => values; }

    public void Add(TKey key, TValue value)
    {
        if(!keys.Contains(key))
        {
            keys.Add(key);
            values.Add(value);

        }
    }

    public void Add(KeyValuePair<TKey, TValue> item)
    {
        if(!keys.Contains(item.Key))
        {
            keys.Add(item.Key);
            values.Add(item.Value);
            dictionaryModificationCount++;
        }
        else
        {
            throw new ArgumentException("The key already exists.");
        }
    }

    public void Clear()
    {
        keys.Clear();
        values.Clear();
        dictionaryModificationCount++;
    }

    public bool Contains(KeyValuePair<TKey, TValue> item)
    {
        var index = keys.IndexOf(item.Key);
        if(index != -1)
        {
            return values[index].Equals(item.Value);
        }
        return false;
    }

    public bool ContainsKey(TKey key)
    {
        if(keys.Contains(key))
            return true;
        return false;
    }

    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
        var count = 0;
        foreach(var key in keys)
        {
            var index = keys.IndexOf(key);
            array[arrayIndex + count] = new KeyValuePair<TKey, TValue>(key, values[index]);
            ++count;
        }
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        throw new System.NotImplementedException();
    }

    public bool Remove(TKey key)
    {
        var index = keys.IndexOf(key);
        if(index != -1)
        {
            keys.RemoveAt(index);
            values.RemoveAt(index);
            dictionaryModificationCount++;
            return true;
        }
        else
        {
            throw new KeyNotFoundException(key.ToString());
        }
    }

    public bool Remove(KeyValuePair<TKey, TValue> item)
    {
        return Remove(item.Key);
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        if (keys.Contains(key))
        {
            var index = keys.IndexOf(key);
            value = values[index];
            return true;
        }
        value = default(TValue);
        return false;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new System.NotImplementedException();
    }

    private class DictionaryEnumerator : IEnumerator<KeyValuePair<TKey, TValue>>
    {
        private SerializableDictionary<TKey, TValue> dictionary;
        private KeyValuePair<TKey, TValue> currentKvP;
        private int position = -1;
        private int syncCounter;

        public DictionaryEnumerator(SerializableDictionary<TKey, TValue> dictionary)
        {
            if(dictionary == null)
            {
                throw new ArgumentNullException("dictionary");
            }
            this.dictionary = dictionary;
            syncCounter = dictionary.dictionaryModificationCount;
        }

        private void VerifyState()
        {
            if(dictionary == null)
            {
                throw new ObjectDisposedException(null);
            }
            if(dictionary.dictionaryModificationCount != syncCounter)
            {
                throw new InvalidOperationException("out of Sync");
            }
        }

        public KeyValuePair<TKey, TValue> Current 
        {
            get
            {
                VerifyCurrent();
                return currentKvP;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            dictionary = null;
        }

        public bool MoveNext()
        {
            VerifyState();
            position++;
            if(position < dictionary.keys.Count)
            {
                currentKvP = new KeyValuePair<TKey, TValue>(dictionary.keys[position], dictionary.values[position]);
                return true;
            }
            position = -1;
            return false;
        }

        public void Reset()
        {
            VerifyState();
            position = -1;
        }

        private void VerifyCurrent()
        {
            VerifyState();
            if(position < 0 || position >= dictionary.keys.Count)
            {
                throw new InvalidOperationException("current is not valid.");
            }
        }
    }
}
