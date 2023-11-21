using UnityEngine;
using UnityEngine.UI;
using System;

public class InstructionAnimationManipulator : MonoBehaviour {
    public static InstructionAnimationManipulator instance;
    [SerializeField] Slider animProgressSlider;
    [Header("Button Images")] 
    [SerializeField] Image buttonImage1;
    [SerializeField] Image buttonImage2;
    [SerializeField] Image buttonImage3;
    [Header("Colors")] 
    [SerializeField] Color[] colors;
    [Header("Buttons")]
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject speedButtonMenu;
    public bool speedMenuOpened;
    Animator currentAnim;
    [HideInInspector] public bool isPlaying;
    float animTime;
    float currentMultiplier = 1;

    void Awake() {
        instance = this;
    }

    void Start() {
        isPlaying = true;
        speedMenuOpened = false;
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        buttonImage3.color = colors[1];
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
        currentAnim.SetFloat("SpeedMultiplier", currentMultiplier);
    }
    
    public void ProgressSlider() {
        if (!SliderDrag.Instance.isDragging) return;
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
    
    public void ChangeAnimationSpeed(float multiplier) {
        currentMultiplier = multiplier;
        //currentAnim.SetFloat("SpeedMultiplier", currentMultiplier);
        SliderColorChange(multiplier);
    }

    void SliderColorChange(float multiplier)
    {
        switch (multiplier)
        {
            case 0.25f:
                buttonImage1.color = colors[1];
                buttonImage2.color = colors[0];
                buttonImage3.color = colors[0];
                break;
            case 0.5f:
                buttonImage1.color = colors[0];
                buttonImage2.color = colors[1];
                buttonImage3.color = colors[0];
                break;
            case 1:
                buttonImage1.color = colors[0];
                buttonImage2.color = colors[0];
                buttonImage3.color = colors[1];
                break;
        }
    }
}
