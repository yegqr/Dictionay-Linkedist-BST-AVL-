﻿namespace _3rdAss;

public class StringsDictionary
{
    private static int Size = 10;

    private LinkedList[] buckets = new LinkedList[Size];
    
    public void Add(string key, string value)
    {
        var slot = CalculateHash(key) % Size ;
        if (buckets[slot] == null)
        {
            buckets[slot] = new LinkedList() ;
        }
        buckets[slot].Add(new KeyValuePair(key , value)) ;

        if (LoadFactor() > 0.7)
        {
            Size *= 2 ;
            LinkedList[] newBuckets = new LinkedList[Size] ;
            foreach (var LL in buckets)
            {
                foreach ( var pair in LL.GetAllPairs () )
                {
                    slot = CalculateHash(pair.Key) % Size ;
                    if (newBuckets[slot] == null)
                    {
                        newBuckets[slot] = new LinkedList() ;
                    }
                    newBuckets[ slot ].Add( pair ) ;
                }
            }
            buckets = newBuckets ;
        }
    }
    
    public void Remove(string key)
    {
        if (buckets[CalculateHash(key) % Size] == null)
        {
            Console.WriteLine("No such KEY in my data .");
        }
        else
        {
            buckets[CalculateHash(key) % Size].RemoveByKey(key);
        }
    }
    
    public string Get(string key)
    {
        if (buckets[CalculateHash(key) % Size] == null )
        {
            return "No such KEY in my data ." ;
        }
        return buckets[CalculateHash(key) % Size].GetItemWithKey(key).Value ;
    }
    

    private int CalculateHash( string key )
    {
        var result = 0 ;
        foreach ( var elemant in key )
        {
            result += Convert.ToChar(elemant) ;
        }
        return result ; 
    }

    private float LoadFactor()
    {
        var full = 0 ;
        foreach (var linkedlist in buckets)
        {
            full += (linkedlist != null) ? 1 : 0 ;
        }
        
        return full / buckets.Length ;
    }
}