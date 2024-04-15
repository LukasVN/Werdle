using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordPanel : MonoBehaviour
{
    public GameObject letterPanelPrefab;
    void Start()
    {
        SpawnLetterPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnLetterPanel(){
        for (int i = 0; i <= 5; i++)
        {
            Instantiate(letterPanelPrefab,transform);
        }
    }
}
