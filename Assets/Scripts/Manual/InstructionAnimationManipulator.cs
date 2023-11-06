using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InstructionAnimationManipulator : MonoBehaviour {
    [SerializeField] Slider animProgressSlider;
    Animator currentAnim;
    bool isPlaying;
    float animTime;
    
    void Start() {
        isPlaying = true;
    }

    void Update() {
        if(transform.childCount == 0) return;
        if(!isPlaying) return;
        currentAnim = GetComponentInChildren<Animator>();
        if (!currentAnim) return;
        animTime = currentAnim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1;
        animProgressSlider.value = animTime;
    }
    
    public void ProgressSlider() {
        currentAnim.SetFloat("AnimationTime", animProgressSlider.value);
    }

    public void StartPlayback() {
        isPlaying = !isPlaying;
        if (!currentAnim) return;
        currentAnim.SetFloat("SpeedMultiplier", Convert.ToSingle(isPlaying)); 
        //Lav en ny ting der hedder isplaying eller noget i stedet for SpeedMultiplier
        //Da vi skal bruge SpeedMultiplier i ChangeAnimationSpeed
    }
    
    void ChangeAnimationSpeed() {
    }
}
