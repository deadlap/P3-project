using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Manual", menuName = "ScriptableObjects/Manual", order = 1)]
public class Manual : ScriptableObject {
    [SerializeField] public List<ManualStep> steps;
}
