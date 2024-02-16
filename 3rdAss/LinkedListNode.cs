﻿using System.Diagnostics;

namespace _3rdAss;

public class LinkedListNode
{
    public KeyValuePair Pair { get; set; }
    
    public LinkedListNode Next { get; set; }

    public LinkedListNode(KeyValuePair pair, LinkedListNode next = null)
    {
        Pair = pair;
        Next = next;
    }

    public bool IsNull()
    {
        if (Next == null)
        {
            return true;
        }

        return false;
    }
}