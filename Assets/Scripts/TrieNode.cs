using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; private set; }
    public List<PhoneNumber> Numbers { get; set; }
    public bool IsEndOfNumber { get;  set; }

    public TrieNode()
    {
        Children = new Dictionary<char, TrieNode>();
        Numbers = new List<PhoneNumber>();
        IsEndOfNumber = false;
    }
}
