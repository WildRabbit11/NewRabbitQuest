using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private Tilemap groundTilemap;
    //[SerializeField] private Tilemap collisionTilemap;


    public float moveSpeed = 4f;
    public Transform movePoint;

    public LayerMask whatStopsMovement;

    private Animator animator;
    private int currentDirection = 1;

    private OverworldControls ovCon;

    private bool moveDelay = true;//fixes the issue of the player returning to their origianl spot after loading in scene in new location

    // Start is called before the first frame update
    void Start()
    {
        ovCon = FindObjectOfType<OverworldControls>();
        animator = GetComponent<Animator>();
        StartCoroutine(MoveDelaySort());
    }



    // Update is called once per frame
    void Update()
    {
        if (!moveDelay)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
            {
                float horizontalInput = ovCon.playerCS.Overworld.MoveHorizontal.ReadValue<float>();
                float verticalInput = ovCon.playerCS.Overworld.MoveVertical.ReadValue<float>();
                if (Mathf.Abs(horizontalInput) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(horizontalInput, 0f, 0f), 0.2f, whatStopsMovement))
                    {
                        movePoint.position += new Vector3(horizontalInput, 0f, 0f);
                    }
                    //animation section
                    if (horizontalInput == -1f)
                    {
                        SetAnimationDirection(2);
                    }
                    else if (horizontalInput == 1f)
                    {
                        SetAnimationDirection(3);
                    }
                }
                //else if rather than just second if statement prevents diagonal movement
                else if (Mathf.Abs(verticalInput) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, verticalInput, 0f), 0.2f, whatStopsMovement))
                    {
                        movePoint.position += new Vector3(0f, verticalInput, 0f);
                    }
                    //animation section
                    if (verticalInput == -1f)
                    {
                        SetAnimationDirection(1);
                    }
                    else if (verticalInput == 1f)
                    {
                        SetAnimationDirection(4);
                    }
                }
                animator.SetBool("Moving", false);
            }
            else
            {
                animator.SetBool("Moving", true);
            }
        }
    }

    public void SetAnimationDirection(int direction)//direction: 1=front, 2=left, 3=right, 4=back
    {
        if (direction != currentDirection)
        {
            animator.SetInteger("Direction", direction);
            animator.SetTrigger("ChangeDirection");
            currentDirection = direction;
        }
    }

    IEnumerator MoveDelaySort()
    {
        yield return new WaitForSeconds(0.2f);
        movePoint.transform.position = transform.position;
        movePoint.parent = null;
        moveDelay = false;
    }
}
