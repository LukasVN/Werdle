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

    void Update()
    {
        if(Input.anyKeyDown){
            if(Input.inputString.Length > 0 && char.IsLetter(Input.inputString[0])){
                Debug.Log("Letter "+Input.inputString[0]);
                AddLetter(Input.inputString.ToUpper()[0]);
            }
            else if(Input.GetKeyDown(KeyCode.Backspace)){
                Debug.Log("Pressed");
                RemoveLetter();
            }
        } 
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

    public void SetStatus(int[] status) {

    }
}
