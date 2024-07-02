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
        node.Numbers.Add(number);
    }

    //전화번호 수집
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

    //부분 문자열 검색
    public List<string> SearchPartial(string part)
    {
        List<string> results = new List<string>();
        SearchPartialRecursive(root, part, 0, "", results);
        return results;
    }

    //부분 문자열 재귀적으로 검색
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
                //현재 문자와 일치하는 경우 다음으로 이동
                SearchPartialRecursive(child.Value, part, index + 1, current + child.Key, results);
            }
            else
            {
                //일치하지 않는 경우 현재 문자 유지하고 계속 탐색
                SearchPartialRecursive(child.Value, part, index, current + child.Key, results);
            }
        }
    }
}
