using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class AimStateManager : MonoBehaviour
{
    AimBaseState currentState;
    public HipFireState hipfire = new HipFireState();
    public AimState aim = new AimState();
    
   
    [SerializeField] float mouseSense = 1;
    float xAxis, yAxis;
    [SerializeField] Transform camFollowPos;

    public Animator anim;

    [SerializeField] private LayerMask aimMask;
    [SerializeField] private Transform debugTransform;

    [SerializeField] private Transform bullet;
    [SerializeField] private Transform spawnerPos;

    [SerializeField] private Transform rig;

    // Start is called before the first frame update
    void Start()
    {
        switchState(hipfire);
    }

    void Update()
    {
        xAxis += Input.GetAxisRaw("Mouse X") * mouseSense;
        yAxis += Input.GetAxisRaw("Mouse Y") * mouseSense *-1;
        yAxis = Mathf.Clamp(yAxis, -80, 80);
        currentState.UpdateState(this);

        Vector2 centerScreen = new Vector2(Screen.width/2f, Screen.height/2f);
        Ray ray = Camera.main.ScreenPointToRay(centerScreen);
        Vector3 mousePosition = Vector3.zero;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimMask)){
            debugTransform.position = raycastHit.point;
            mousePosition = raycastHit.point;
            //Debug.DrawLine(ray.origin, raycastHit.point, Color.white, 5f);
        }
        
        Vector3 aimTarget = mousePosition;
        aimTarget.y =  transform.position.y;

        Vector3 aimDirection = (aimTarget - transform.position).normalized;
        
        if (Input.GetKeyDown(KeyCode.Mouse0)){//if user press left click
            Vector3 direct = (mousePosition-spawnerPos.position).normalized;
            Instantiate(bullet,spawnerPos.position, Quaternion.LookRotation(direct, Vector3.up));
            //Debug.DrawLine(ray.origin, hit.point, Color.white, 5f);
        }
        //transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime*20f);
    }

    private void LateUpdate()
    {
        camFollowPos.localEulerAngles = new Vector3(yAxis, transform.localEulerAngles.y, transform.localEulerAngles.z);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, xAxis, transform.localEulerAngles.z);
        rig.localEulerAngles = new Vector3(yAxis, transform.localEulerAngles.y, transform.localEulerAngles.z);
        
    }
    public void switchState(AimBaseState state) {
        currentState = state;
        currentState.EnterState(this);
    }
    
}
