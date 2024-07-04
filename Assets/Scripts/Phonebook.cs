using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Phonebook : MonoBehaviour
{
    public InputField inputField;
    public Text resultText;
    public Button searchButton;
    private Trie trie;

    void Start()
    {
        trie = new Trie();

        trie.Insert("01012345678");
        trie.Insert("01012341234");
        trie.Insert("01087654321");
        trie.Insert("01122334455");

        searchButton.onClick.AddListener(OnSearchButton);

    }
    void OnSearchButton()
    {
        string phoneNumber = inputField.text;
        var results = SearchPhoneNumber(phoneNumber);

        // 결과 출력
        resultText.text = "검색 결과:\n" + string.Join("\n", results);
    }

    public List<string> SearchPhoneNumber(string phoneNumber)
    {
        return trie.Search(phoneNumber).Distinct().ToList();
    }


}
