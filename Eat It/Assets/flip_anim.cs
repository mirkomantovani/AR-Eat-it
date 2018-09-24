using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class flip_anim : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject flipbtnObj;
    public GameObject closebtnObj;
    public Animator flipanim;
    public Animator flipanim2;

    int magazineState = 0;

    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        switch (vb.VirtualButtonName)
        {
            case "flipbtn":
                //if the cover is not yet opened I can open it
                if (magazineState == 0)
                {
                    flipanim.Play("openmagazineanim");
                    magazineState = 1;
                }
                else if (magazineState == 1)
                {
                    //if the cover was already been opened I can flip the second 2D page
                    flipanim2.Play("openmagazinesecondanim");
                    magazineState = 2;
                }
                break;
            case "closebtn":
                if (magazineState == 1)
                {
                    flipanim.Play("closemagazineanim");
                    magazineState = 0;
                }
                else if (magazineState == 2)
                {
                    //if the cover was already been opened I can flip the second 2D page
                    flipanim2.Play("closemagazinesecondanim");
                    magazineState = 1;
                }
                break;
            default:
                throw new UnityException("Button not supported: " + vb.VirtualButtonName);

        }
        Debug.Log("pageup button pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        //flipanim.Play("none");  
        flipanim.StopPlayback(); //not really needed
        Debug.Log("pageup button released");
    }

    // Use this for initialization
    void Start () {
        flipbtnObj = GameObject.Find("flipbtn");
        flipbtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        closebtnObj = GameObject.Find("closebtn");
        closebtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        flipanim.GetComponent<Animator>();
        //not really needed? the others?
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
