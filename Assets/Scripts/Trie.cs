using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Trie
{
    private TrieNode root = new TrieNode();

    public void Insert(string phoneNumber)
    {
        for (int i = 0; i < phoneNumber.Length; i++)
        {
            var node = root;
            for (int j = i; j < phoneNumber.Length; j++)
            {
                char ch = phoneNumber[j];
                if (!node.Children.ContainsKey(ch))
                {
                    node.Children[ch] = new TrieNode();
                }
                node = node.Children[ch];
                node.PhoneNumbers.Add(phoneNumber);
            }
        }
    }

    public List<string> Search(string phoneNumber)
    {
        var node = root;
        foreach (var ch in phoneNumber)
        {
            if (!node.Children.ContainsKey(ch))
            {
                return new List<string>();
            }
            node = node.Children[ch];
        }
        return node.PhoneNumbers;
    }
}
