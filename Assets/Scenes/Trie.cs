using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trie : MonoBehaviour
{
    private TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    //��ȭ��ȣ ����
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
        node.Numbers.Add(number);
    }

    //�κ� ���ڿ� �˻�
    public List<string> SearchPartial(string part)
    {
        List<string> results = new List<string>();
        SearchPartialRecursive(root, part, 0, "", results);
        return results;
    }

    //�κ� ���ڿ� ��������� �˻�
    private void SearchPartialRecursive(TrieNode node, string part, int index, string current, List<string> results)
    {
        foreach (var number in node.Numbers)
        {
            if (number.Contains(part))
            {
                results.Add(number);
            }
        }

        foreach (var child in node.Children)
        {
            SearchPartialRecursive(child.Value, part, index, current + child.Key, results);
        }
    }
}
