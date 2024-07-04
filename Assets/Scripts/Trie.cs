using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
            node.IsEndWord = true;

            node.PhoneNumbers.Add(phoneNumber);
        }

        
    }

    public List<string> Search(string phoneNumber)
    {
        var result = new List<string>();
        var node = root;

        foreach (var ch in phoneNumber)
        {
            if (!node.Children.ContainsKey(ch))
            {
                return new List<string>();
            }
            node = node.Children[ch];
        }

        result = CollectPhoneNumbers(node);

        return result;
    }

    private List<string> CollectPhoneNumbers(TrieNode node)
    {
        var result = new List<string>();

        if (node.IsEndWord)
        {
            result.AddRange(node.PhoneNumbers);
        }

        foreach (var ch in node.Children)
        {
            result.AddRange(CollectPhoneNumbers(ch.Value));
        }

        return result;
    }
}
