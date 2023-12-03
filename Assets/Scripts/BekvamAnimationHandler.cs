using UnityEngine;

public class BekvamAnimationHandler : MonoBehaviour
{
    bool isAnimationPlaying;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        //anim.Play($"Bekväm Step {currentStep}");
    }

    void Update()
    {
        //if(isAnimationPlaying) return;
        //anim.Play($"Bekväm Step {currentStep}");
        //isAnimationPlaying = true;
        PlayAnimation(StepCounter.CurrentStep);
    }

    void PlayAnimation(int index)
    {
        if (index < StepCounter.MaxSteps)
            anim.Play($"Bekväm Step {index}");
        if (index == StepCounter.MaxSteps)
            anim.Play("Bekväm Completed");
    }
}
