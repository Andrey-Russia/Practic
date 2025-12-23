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
        animator.SetBool("Forward", false);
        animator.SetBool("Back", false);
        animator.SetBool("Left", false);
        animator.SetBool("Right", false);

        if (Input.GetKeyDown(KeyCode.W))   
            animator.SetBool("Forward", true);

        else if (Input.GetKeyDown(KeyCode.S)) 
            animator.SetBool("Back", true);

        else if (Input.GetKeyDown(KeyCode.A)) 
            animator.SetBool("Left", true);

        else if (Input.GetKeyDown(KeyCode.D)) 
            animator.SetBool("Right", true);
    }

}
