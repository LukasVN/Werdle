using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterPanel : MonoBehaviour
{
    public TextMeshProUGUI letterText;
    public GameObject whitePanel;
    public GameObject grayPanel;
    public GameObject orangePanel;
    public GameObject greenPanel;

    void Start(){
    }

    void Update(){
        
    }

    public void SetLetter(char letterChar){
        letterText.text = letterChar.ToString();
    }

    public void ClearLetter(){
        letterText.text = "";
    }

    public string GetLetter(){
        return letterText.text;
    }

}
