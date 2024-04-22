using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class LetterPanel : MonoBehaviour
{
    public TextMeshProUGUI letterText;
    public GameObject whitePanel;
    public GameObject grayPanel;
    public GameObject orangePanel;
    public GameObject greenPanel;
    private float rotationSpeed = 150f;
    public bool rotating;
    private bool rotated;

    void Start(){
        rotating = false;
        rotated = false;
    }

    void Update(){
        if(rotating){
            RotateLetter();
        }
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

    public void RotateLetter(){
        // Rotate the GameObject
        if(!rotated){
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
        else{
            transform.Rotate(-Vector3.right, rotationSpeed * Time.deltaTime);
        }

        if(transform.rotation.eulerAngles.x >= 89 && !rotated){
            rotated = true;
            transform.Rotate(0,transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z);
        }
        if (transform.rotation.eulerAngles.x <= 1 && rotated)
        {
            rotating = false;
        }
    }

    

}
