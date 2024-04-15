using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour //this shoots the bullet
{
    [SerializeField] private Transform bullet;
    [SerializeField] private Transform spawnerPos;

    [SerializeField] private LayerMask aimMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 centerScreen = new Vector2(Screen.width/2f, Screen.height/2f);
        Ray ray = Camera.main.ScreenPointToRay(centerScreen);
        Vector3 mousePosition = Vector3.zero;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimMask)){
            //debugTransform.position = raycastHit.point;
            mousePosition = raycastHit.point;

            if (Input.GetKeyDown(KeyCode.Mouse0)){//if user press left click
            Vector3 direct = (mousePosition - spawnerPos.position).normalized;
            Instantiate(bullet,spawnerPos.position, Quaternion.LookRotation(direct, Vector3.up));
        }
        }
        
        
    }
}
