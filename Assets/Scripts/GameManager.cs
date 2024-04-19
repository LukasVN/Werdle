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
    public Transform canvas;
    public GameObject wordPanelPrefab;
    public int tryNumber;
    public bool isWordComplete = false;
    private string guessWord;
    private void Awake() {
        instance = this;
    }
    void Start(){
        guessWord = WordCollection.GetGuessWord();
        tryNumber = 0;
    }

    void Update()
    {
        if(isWordComplete && !button.interactable){
            button.interactable = true;
        }
        else if(!isWordComplete && button.interactable){
            button.interactable = false;
        }

        if(wordPanel != null && Input.anyKeyDown){
            if(Input.inputString.Length > 0 && char.IsLetter(Input.inputString[0])){
                Debug.Log("Letter "+Input.inputString[0]);
                wordPanel.AddLetter(Input.inputString.ToUpper()[0]);
            }
            else if(Input.GetKeyDown(KeyCode.Backspace)){
                Debug.Log("Pressed");
                wordPanel.RemoveLetter();
            }
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

    private LetterStatus[] TestWord(string guessTry, string correctWord){
        LetterStatus[] status = new LetterStatus[wordPanel.numberOfLetters];
        int index = 0;
        foreach (char letter in correctWord){
            if(correctWord[index] == guessTry[index]){
                Debug.Log(letter+"  "+correctWord[index]);
                status[index] = LetterStatus.Green;
                index++;
            }
            else if(correctWord.Contains(guessTry[index]) && correctWord[index] != guessTry[index]){
                status[index] = LetterStatus.Orange;
                index++;
            }
            else{
                status[index] = LetterStatus.Gray;
                index++;
            }
        }

        return status;
    }
 

    public void SpawnNextPanel(){
        wordPanel = Instantiate(wordPanelPrefab, canvas).GetComponentInChildren<WordPanel>();
        RectTransform rt = wordPanel.transform.parent.GetComponent<RectTransform>();
        Vector3 newPosition = new Vector3(rt.position.x, rt.position.y -100 * tryNumber, rt.position.z);
        rt.position = newPosition;
    }
}

public enum LetterStatus{
        Green,
        Orange,
        Gray
}