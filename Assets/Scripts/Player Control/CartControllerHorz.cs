using UnityEngine;

public class CartControllerHorz : MonoBehaviour
{
    private enum MoveState
    {
        STOP,
        UP,
        DOWN,
        RIGHT,
        LEFT,
    }

    [Header("Cart status")]
    [SerializeField]
    private MoveState moveState = MoveState.STOP;
    [SerializeField]
    private float baseSpeed = 0.01f;
    [SerializeField]
    private float speedMultiplier = 1f;

    [Header("Trigger references")]
    [SerializeField]
    BoxCollider2D turnTrigger;
    [SerializeField]
    BoxCollider2D pickupTrigger;
    [SerializeField]
    BoxCollider2D returnTrigger;

    #region Monobehaviour func
    private void Update()
    {
        // movement
        if (moveState == MoveState.UP)
        {
            transform.position += new Vector3(0, baseSpeed * speedMultiplier, 0);
        }
        else if (moveState == MoveState.DOWN)
        {
            transform.position += new Vector3(0, -(baseSpeed * speedMultiplier), 0);
        }
        else if (moveState == MoveState.RIGHT)
        {
            transform.position += new Vector3(baseSpeed * speedMultiplier, 0, 0);
        }
        else if (moveState == MoveState.LEFT)
        {
            transform.position += new Vector3((-baseSpeed * speedMultiplier), 0, 0);
        }



        // player tap to either start moving, or start moving sideways
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (moveState == MoveState.LEFT || moveState == MoveState.RIGHT)
            {
                returnTrigger.gameObject.SetActive(true);
                moveState = MoveState.DOWN;
            }
            else if (moveState == MoveState.STOP)
            {
                moveState = MoveState.RIGHT;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == turnTrigger)
        {
            TriggerTurn();
        }
        else if (collision == pickupTrigger)
        {
            TriggerPickup();
        }
        else if (collision == returnTrigger)
        {
            TriggerReturn();
        }
        else
        {
            // must be a customer alr (im lazy to add the triggers here during runtime)
            TriggerCustomer();
        }
    }
    #endregion

    #region Custom functions
    private void TriggerCustomer()
    {
        Debug.Log("trigger customer");

        moveState = MoveState.UP;
    }

    private void TriggerTurn()
    {
        Debug.Log("trigger turn");
        moveState = MoveState.LEFT;
    }

    private void TriggerPickup()
    {
        Debug.Log("trigger pickup");

        // stop the cart
        moveState = MoveState.STOP;

        // reset pos to prevent problems with returnTrigger
        transform.localPosition = new Vector3(-6, transform.localPosition.y, 0);

        // toss the currently held food, pick up the next available thing on the conveyor

        // return speed mult to normal
        speedMultiplier = 1f;
    }

    private void TriggerReturn()
    {
        Debug.Log("trigger return");
        returnTrigger.gameObject.SetActive(false);
        transform.localPosition = new Vector3(-6, transform.localPosition.y, 0);
        //transform.position = new Vector3(transform.position.x, -5.5f, 0);
        moveState = MoveState.LEFT;
        speedMultiplier = 1.35f;
    }
    #endregion
}
