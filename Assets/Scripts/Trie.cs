using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

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
                
            }
            node.PhoneNumbers.Add(phoneNumber);
        }
    }

    public List<string> Search(string phoneNumber)
    {
        var currentNode = root;
        foreach (var ch in phoneNumber)
        {
            if (!currentNode.Children.ContainsKey(ch))
            {
                return new List<string>();
            }
            currentNode = currentNode.Children[ch];
        }

        var result = new HashSet<string>();
        CollectPhoneNumbers(currentNode, result);
        return result.ToList();
    }

    private static void CollectPhoneNumbers(TrieNode node, HashSet<string> result)
    {
        result.AddRange(node.PhoneNumbers);
        foreach (var child in node.Children.Values)
        {
            CollectPhoneNumbers(child, result);
        }
    }
}
