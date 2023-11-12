using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class InstructionAnimationManipulator : MonoBehaviour {
    public static InstructionAnimationManipulator instance;
    [SerializeField] Slider animProgressSlider;
    [Header("Images")]
    [SerializeField] Image handleImage; 
    [SerializeField] Image sliderFillImage;
    [SerializeField] Image sliderBackgroundImage;
    [SerializeField] Color[] sliderColors;
    [Header("Buttons")]
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject speedButtonMenu;
    bool speedMenuOpened;
    Animator currentAnim;
    bool isPlaying;
    float animTime;

    void Awake() {
        instance = this;
    }

    void Start() {
        isPlaying = true;
        speedMenuOpened = false;
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        //handleImage.color = sliderColors[0];
        //sliderFillImage.color = sliderColors[0];
        //sliderBackgroundImage.color = sliderColors[2];
    }

    void Update() {
        if(transform.childCount == 0) return;
        if(!isPlaying) return;
        currentAnim = GetComponentInChildren<Animator>();
        if(!currentAnim) return;
        if(SliderDrag.instance.isDragging) return;
        animTime = currentAnim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1;
        animProgressSlider.value = animTime;
    }
    
    public void ProgressSlider() {
        currentAnim.Play(currentAnim.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, animProgressSlider.value);
        //currentAnim.SetFloat("AnimationTime", animProgressSlider.value);
    }
    
    public void SwitchPlayState() {
        isPlaying = !isPlaying;
        switch (isPlaying)
        {
            case true:
                playButton.SetActive(false);
                pauseButton.SetActive(true);
                //handleImage.color = sliderColors[0];
                //sliderFillImage.color = sliderColors[0];
                //sliderBackgroundImage.color = sliderColors[2];
                break;
            case false:
                playButton.SetActive(true);
                pauseButton.SetActive(false);
                //handleImage.color = sliderColors[1];
                //sliderFillImage.color = sliderColors[1];
                //sliderBackgroundImage.color = sliderColors[3];
                break;
        }
        if (!currentAnim) return;
        currentAnim.speed = Convert.ToSingle(isPlaying);
    }
    
    //Assign denne funktion til en knap, giv knappen en float som bliver animationens SpeedMultiplier 
    public void OpenSpeedMenu()
    {
        speedMenuOpened = !speedMenuOpened;
        speedButtonMenu.SetActive(speedMenuOpened);
    }
    
    public void ChangeAnimationSpeed(float speed) {
        currentAnim.SetFloat("SpeedMultiplier", speed);
    }
}
