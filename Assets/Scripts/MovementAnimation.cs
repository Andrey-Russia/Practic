using UnityEngine;

public class MovementAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            animator.SetTrigger("ForwardTrigger");

        else if (Input.GetKeyDown(KeyCode.S))
            animator.SetTrigger("BackTrigger");

        else if (Input.GetKeyDown(KeyCode.A))
            animator.SetTrigger("LeftTrigger");

        else if (Input.GetKeyDown(KeyCode.D))
            animator.SetTrigger("RightTrigger");

       else
            animator.SetTrigger("IdleTrigger");
    }
}
