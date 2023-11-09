using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class InstructionAnimationManipulator : MonoBehaviour {
    [SerializeField] Slider animProgressSlider;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject pauseButton;
    Animator currentAnim;
    bool isPlaying;
    float animTime;
    
    void Start() {
        isPlaying = true;
        playButton.SetActive(false);
        pauseButton.SetActive(true);
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
        switch (isPlaying)
        {
            case true:
                playButton.SetActive(false);
                pauseButton.SetActive(true);
                break;
            case false:
                playButton.SetActive(true);
                pauseButton.SetActive(false);
                break;
        }
        if (!currentAnim) return;
        // currentAnim.SetFloat("SpeedMultiplier", Convert.ToSingle(isPlaying));
        animTime = animProgressSlider.value;
        currentAnim.speed = Convert.ToSingle(isPlaying);
        //Lav en ny ting der hedder isplaying eller noget i stedet for SpeedMultiplier??????
        //Da vi skal bruge SpeedMultiplier i ChangeAnimationSpeed
    }
    
    //Assign denne funktion til en knap, giv knappen en float som bliver animationens SpeedMultiplier 
    public void ChangeAnimationSpeed(float speed) {
        currentAnim.SetFloat("SpeedMultiplier", speed);
    }
}
