using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phonebook : MonoBehaviour
{
    public InputField inputField;
    public Text resultText;

    private Trie trie;

    void Start()
    {
        trie = new Trie();

        // ��ȭ��ȣ�ο� ��ȣ ����
        string[] phoneNumbers = { "010-1234-1234", "010-1234-5678", "010-5678-5678", "010-5678-1234" }; // �ߺ��� ��ȣ ����
        foreach (var number in phoneNumbers)
        {
            trie.Insert(number);
        }

        // InputField�� ���� ����� ������ OnValueChanged �Լ��� ȣ��
        inputField.onValueChanged.AddListener(OnValueChanged);
    }

    void OnValueChanged(string input)
    {
        var results = trie.SearchPartial(input);
        if (results.Count > 0)
        {
            resultText.text = $"�˻� ���: {string.Join(", ", results)}";
        }
        else
        {
            resultText.text = $"��ȭ��ȣ {input}��(��) ��ȭ��ȣ�ο� �����ϴ�.";
        }
    }
}
