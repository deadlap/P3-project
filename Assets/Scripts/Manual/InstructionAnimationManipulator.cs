using UnityEngine;
using UnityEngine.UI;
using System;

public class InstructionAnimationManipulator : MonoBehaviour {
    [SerializeField] Slider animProgressSlider;
    [Header("Images")]
    [Header("Buttons")]
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject speedButtonMenu;
    bool speedMenuOpened;
    Animator currentAnim;
    bool isPlaying;
    float animTime;

    void Start() {
        isPlaying = true;
        speedMenuOpened = false;
        playButton.SetActive(false);
        pauseButton.SetActive(true);
    }

    void Update() {
        if(transform.childCount == 0) return;
        if(!isPlaying) return;
        currentAnim = GetComponentInChildren<Animator>();
        if(!currentAnim) return;
        currentAnim.speed = Convert.ToSingle(!SliderDrag.Instance.isDragging);
        if (SliderDrag.Instance.isDragging) return;
        animTime = currentAnim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1;
        animProgressSlider.value = animTime;
    }
    
    public void ProgressSlider() {
        currentAnim.Play(currentAnim.GetCurrentAnimatorClipInfo(0)[0].clip.name, -1, animProgressSlider.value);
    }
    
    public void SwitchPlayState() {
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
