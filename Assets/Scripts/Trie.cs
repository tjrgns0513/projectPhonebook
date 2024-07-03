using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Trie
{
    private TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    //전화번호 삽입
    public void Insert(string number)
    {
        var node = root;

        foreach (var digit in number)
        {
            if (!node.Children.ContainsKey(digit))
            {
                node.Children[digit] = new TrieNode();
            }

            node = node.Children[digit];
        }

        node.IsEndOfNumber = true;

        if (node.Numbers == null)
        {
            node.Numbers = new List<PhoneNumber>();
        }

        node.Numbers.Add(new PhoneNumber(number));
    }

    public List<PhoneNumber> Search(string number)
    {
        var result = new List<PhoneNumber>();

        var node = root;

        foreach (var digit in number)
        {
            if(!node.Children.ContainsKey(digit))
            {
                return result;
            }

            node = node.Children[digit];
        }

        result = CollectPhoneNum(node);

        return result;
    }

    private List<PhoneNumber> CollectPhoneNum(TrieNode node)
    {
        var result = new List<PhoneNumber>();

        if (node.IsEndOfNumber) 
        {
            result.AddRange(node.Numbers);
        }

        foreach (var child in node.Children) 
        {
            result.AddRange(CollectPhoneNum(child.Value));
        }

        return result;
    }
}
