using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PartButton : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject partNeeded;
    public int amount;
    public void SetPart(GameObject _part, int _amount){
        amount = _amount;
        partNeeded = _part;
    }
    // Update is called once per frame
    void Update() {
        this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = amount + "x";
    }
}
