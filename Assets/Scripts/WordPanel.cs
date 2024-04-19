using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordPanel : MonoBehaviour
{
    public GameObject letterPanelPrefab;
    public int numberOfLetters = 5;
    private int letterIndex;
    private List<LetterPanel> letters = new List<LetterPanel>();
    void Start()
    {
        SpawnLetterPanel();
        letterIndex = 0;
    }

    public void AddLetter(char letterChar){
        if(letterIndex < numberOfLetters){
            letters[letterIndex].SetLetter(letterChar);
            letterIndex++;
            if(letterIndex == numberOfLetters){
                GameManager.instance.isWordComplete = true;
            }
        }
    }

    public void RemoveLetter(){
        if(letterIndex > 0){
            letters[--letterIndex].ClearLetter();
            GameManager.instance.isWordComplete = false;
        }
    }

    private void SpawnLetterPanel(){
        for (int i = 0; i < numberOfLetters; i++)
        {
            GameObject letterPanelGO = Instantiate(letterPanelPrefab,transform);
            LetterPanel letterPanel = letterPanelGO.GetComponent<LetterPanel>();
            letters.Add(letterPanel);
            Debug.Log(letterPanelGO.GetComponent<LetterPanel>());
            letterPanelGO.name = "LetterPanel "+ (i+1);
            Debug.Log(letterPanelGO.name);


        }
    }

    public string GetWord(){
        string word = "";
        for(int i=0; i<letterIndex;i++){
            word+= letters[i].GetLetter();
        }
        return word;
    }

    public void SetStatus(LetterStatus[] status) {
        for (int i = 0; i < numberOfLetters; i++){
            letters[i].whitePanel.SetActive(false);
            switch (status[i])
            {
                case LetterStatus.Green: letters[i].greenPanel.SetActive(true);
                break;
                case LetterStatus.Orange: letters[i].orangePanel.SetActive(true);
                break;
                case LetterStatus.Gray: letters[i].grayPanel.SetActive(true);
                break;
            }
        }
        GameManager.instance.wordPanel = null;
        if(!isWordGuessed(status)){
            Invoke("NextTry",1.5f);
        }
    }

    public void NextTry(){
        GameManager.instance.tryNumber++;
        GameManager.instance.SpawnNextPanel(); 
    }

    public bool isWordGuessed(LetterStatus[] status){
        foreach (LetterStatus color in status){
            if(color != LetterStatus.Green){
                return false;
            }
        }
        return true;
    }
    
}
