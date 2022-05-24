using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private InputField grammarInput;
    private Text grammarText;
    static public string grammarInputText;
    static public bool isPress = false;
    private void Start()
    {
        grammarInput = GameObject.Find("GrammarInput").GetComponent<InputField>();
        grammarText = GameObject.Find("GrammarText").GetComponent<Text>();
    }
    private void Update()
    {
        if (grammarInput.text != null)
        {
            grammarInputText = grammarInput.text;
        }
        
    }
    public void OnButtonPress()
    {
        isPress = true;
    }
    public void ClearButtonPress()
    {
        grammarText.text = null;
    }
    public void ExitButtonPress()
    {
        Application.Quit();
    }
}
