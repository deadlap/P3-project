using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PartButton : MonoBehaviour {
    public GameObject partNeeded;
    public int amount;
    public Sprite partSprite;
    [SerializeField] TextMeshProUGUI amountText;
    [SerializeField] Image objectImage;
    public void SetPart(GameObject _part, int _amount, Sprite _sprite){
        amount = _amount;
        partNeeded = _part;
        partSprite = _sprite;
    }

    void Start() {
        amountText.text = amount + "x";
        objectImage.sprite = partSprite;
    }
}
