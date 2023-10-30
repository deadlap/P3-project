using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class ManualStep {
    public List<GameObject> parts; //Which parts are needed for this step
    public List<int> amounts; //How many of each part.
    public GameObject instruction;
}
