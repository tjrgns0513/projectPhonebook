using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();
    public List<string> PhoneNumbers { get; } = new List<string>();
}
