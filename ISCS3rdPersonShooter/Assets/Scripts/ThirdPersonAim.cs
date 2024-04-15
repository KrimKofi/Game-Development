using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Animations.Rigging;
public class ThirdPersonAim : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aim;
    [SerializeField] Rig rig;
   
    // Start is called before the first frame update
    void Start()
    {
        aim.gameObject.SetActive(false);
        rig.weight = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse1)) //if user pressed right click
        {
            
            if(aim.gameObject.activeSelf){//checks if user has aim toggled (this means its true)
                aim.gameObject.SetActive(false);
                rig.weight = 0f;
            }
            else{
                aim.gameObject.SetActive(true);
                rig.weight = 1f;
                }
            }
            
        }
        
       
        
    }
