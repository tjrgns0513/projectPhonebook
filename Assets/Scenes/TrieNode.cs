using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrieNode : MonoBehaviour
{
    public Dictionary<char, TrieNode> Children { get; private set; }
    public List<string> Numbers { get; private set; }

    public TrieNode()
    {
        Children = new Dictionary<char, TrieNode>();
        Numbers = new List<string>();
    }
}
