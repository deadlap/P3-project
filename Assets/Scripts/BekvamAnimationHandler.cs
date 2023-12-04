using UnityEngine;

public class BekvamAnimationHandler : MonoBehaviour
{
    bool isAnimationPlaying;
    Animator anim;
    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        PlayAnimation(StepCounter.CurrentStep);
    }

    void PlayAnimation(int index) {
        if (index < StepCounter.MaxSteps)
            anim.Play($"Bekväm Step {index}");
        if (index == StepCounter.MaxSteps)
            anim.Play("Bekväm Completed");
    }
}
