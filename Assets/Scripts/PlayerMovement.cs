using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;

    //public GameObject DialogueController;

    private bool isMoving = false;

    //private bool interacting = false;
    private Vector2 input; 

    public Animator animator;
   

    // Update is called once per frame
    void Update()
    {

        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal"); //move with A/D or left/right arrow keys
            input.y = Input.GetAxisRaw("Vertical"); //move with W/S or up/down arrow keys

            animator.SetFloat("Horizontal", input.x);
            animator.SetFloat("Vertical", input.y);
            animator.SetFloat("Speed", input.sqrMagnitude);

            if (input.x != 0) input.y = 0; //restrict movement diagonally

            if (input != Vector2.zero)
            {
                var movement = transform.position;
                movement.x += input.x;
                movement.y += input.y;

                if (isPassable(movement)){
                    StartCoroutine(Move(movement));
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
            Interact();
            
    }


    void Interact()
    {
        var facingDir = new Vector3(input.x, input.y);
        //change to this after animations are done:
        //var facingDir = new Vector3 (animator.GetFloat("moveX"), animator.GetFloat("moveY"));

        var interactPos = transform.position + facingDir; //position of the tile to which the player is facing

        //Debug.DrawLine(transform.position, interactPos, Color.red, 2f);

        var colliderNPC = Physics2D.OverlapCircle(interactPos, 0.5f, interactableLayer);
        
        if (colliderNPC != null)
        {
            //colliderNPC.GetComponent<Interactable>()?.Interact();
            //colliderNPC.GetComponent<NPCController>()?.DialogueController.SetActive(true);
            Debug.Log("interacting");
        }
        else if(colliderNPC == null){
            //colliderNPC.GetComponent<NPCController>()?.DialogueController.SetActive(false);
            Debug.Log("not interacting");
        }
    }


    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }

    private bool isPassable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.3f, solidObjectsLayer | interactableLayer) != null)
        {
            return false;
        }
        return true;
    }
}
