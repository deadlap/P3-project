using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionAnimationManipulator : MonoBehaviour
{
    [SerializeField] Slider animProgressSlider;
    Animator currentAnim;
    bool isPlaying;
    float animTime;
    
    void Start()
    {
        isPlaying = true;
    }

    void Update()
    {
        if(transform.childCount == 0) return;
        if(!isPlaying) return;
        currentAnim = GetComponentInChildren<Animator>();
        if (animProgressSlider.value < 1)
        {
            animProgressSlider.value = animTime;
            animTime = currentAnim.GetCurrentAnimatorStateInfo(0).normalizedTime;
        }
        
        if (animTime >= 1)
        {
            animTime -= currentAnim.GetCurrentAnimatorStateInfo(0).normalizedTime;
            animProgressSlider.value = 0;
        }
        print(animTime);
    }
    
    public void ProgressSlider()
    {
        currentAnim.SetFloat("AnimationTime", animProgressSlider.value);    
    }

    public void StartPlayback()
    {
        isPlaying = !isPlaying;
    }
    void ChangeAnimationSpeed()
    {
    }
}
