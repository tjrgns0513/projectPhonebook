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

        // 전화번호부에 번호 삽입
        string[] phoneNumbers = { "010-1234-1234", "010-1234-5678", "010-5678-5678", "010-5678-1234" }; // 중복된 번호 포함
        foreach (var number in phoneNumbers)
        {
            trie.Insert(number);
        }

        // InputField의 값이 변경될 때마다 OnValueChanged 함수를 호출
        inputField.onValueChanged.AddListener(OnValueChanged);
    }

    void OnValueChanged(string input)
    {
        var results = trie.SearchPartial(input);
        if (results.Count > 0)
        {
            resultText.text = $"검색 결과: {string.Join(", ", results)}";
        }
        else
        {
            resultText.text = $"전화번호 {input}은(는) 전화번호부에 없습니다.";
        }
    }
}
