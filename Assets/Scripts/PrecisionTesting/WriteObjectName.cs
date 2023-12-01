using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WriteObjectName : MonoBehaviour {
    [SerializeField] private TMP_Text textBox;
    [SerializeField] private string standardText;
    [SerializeField] private string foundObjectText;
    
    void Start(){
        textBox.text = "Start";
    }

    public void OnObjectFound(GameObject objectFound){
        textBox.text = foundObjectText + objectFound.name;
    }

    public void OnObjectLost(GameObject objectLost){
        textBox.text = standardText + objectLost.name;
    }
}
