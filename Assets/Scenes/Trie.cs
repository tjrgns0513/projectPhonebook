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

    //��ȭ��ȣ ����
    private void CollectAllNumbers(TrieNode node, List<string> results)
    {
        if (node.Numbers.Count > 0)
        {
            results.AddRange(node.Numbers);
        }

        foreach (var child in node.Children.Values)
        {
            CollectAllNumbers(child, results);
        }
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
        if (index == part.Length)
        {
            CollectAllNumbers(node, results);
            return;
        }

        foreach (var child in node.Children)
        {
            if (child.Key == part[index])
            {
                //���� ���ڿ� ��ġ�ϴ� ��� �������� �̵�
                SearchPartialRecursive(child.Value, part, index + 1, current + child.Key, results);
            }
            else
            {
                //��ġ���� �ʴ� ��� ���� ���� �����ϰ� ��� Ž��
                SearchPartialRecursive(child.Value, part, index, current + child.Key, results);
            }
        }
    }
}
