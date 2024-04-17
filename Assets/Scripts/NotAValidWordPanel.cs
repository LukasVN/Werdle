using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotAValidWordPanel : MonoBehaviour
{
    private void OnEnable() {
        Invoke("Disable", 3f);
    }


    private void Disable(){
        gameObject.SetActive(false);
    }
}
