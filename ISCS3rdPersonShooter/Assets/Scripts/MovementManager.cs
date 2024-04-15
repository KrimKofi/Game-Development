using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public float moveSpeed = 4;
    [HideInInspector] public Vector3 dir;
    CharacterController controller;
    float horizontal, vertical;

    [SerializeField] float groundYoffset;
    [SerializeField] LayerMask groundMask;
    Vector3 spherePos;

    [SerializeField] float gravity = -9.81f;
    Vector3 velocity;

    MovementStateBase currentState;
    public IdleState idle = new IdleState();
    public MoveState move = new MoveState();

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        switchState(idle);
    }

    // Update is called once per frame
    void Update()
    {
        getDirectionAndMove();
        Gravity();

        currentState.UpdateState(this);

        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("Vertical", vertical);
    }

    public void switchState(MovementStateBase state) {
        currentState = state;
        currentState.EnterState(this);
        //Debug.Log(this.name);
    }

    void getDirectionAndMove() {

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        dir = transform.forward * vertical + transform.right * horizontal;

        controller.Move(dir.normalized * moveSpeed * Time.deltaTime);
    }

    bool IsGrounded() {
        spherePos = new Vector3(transform.position.x, transform.position.y - groundYoffset, transform.position.z);
        if (Physics.CheckSphere(spherePos, controller.radius - 0.05f, groundMask)) return true;
        return false;
    }
    void Gravity() {
        if (!IsGrounded()) velocity.y += gravity * Time.deltaTime;
        else if (velocity.y<0) velocity.y = -2;

        controller.Move(velocity * Time.deltaTime);
    }

    /**private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spherePos, controller.radius-0.05f);
    }**/
}
