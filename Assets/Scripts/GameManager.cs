using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject notAValidWord;
    public WordPanel wordPanel;
    public Button button;
    public bool isWordComplete = false;
    private string guessWord;
    private void Awake() {
        instance = this;
    }
    void Start(){
        guessWord = WordCollection.GetGuessWord();
    }

    void Update()
    {
        if(isWordComplete && !button.interactable){
            button.interactable = true;
        }
        else if(!isWordComplete && button.interactable){
            button.interactable = false;
        }
    }

    public void ButtonSendOnClick(){
        if(WordCollection.TestValidWord(wordPanel.GetWord())){
            wordPanel.SetStatus(TestWord(wordPanel.GetWord(),guessWord));
        }
        else{
            notAValidWord.SetActive(true);
        }
    }

    private int[] TestWord(string guessTry, string correctWord){
        int[] status = new int[wordPanel.numberOfLetters];

        foreach (char letter in correctWord){
            
        }

        return status;
    }
}
