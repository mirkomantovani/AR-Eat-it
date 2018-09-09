using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class cashire_btn_anim : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject cheshireBtnObj;
    public Animator cheshireAnim;

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        cheshireAnim.Play("cheshireanim");
        Debug.Log("cheshire button pressed");

    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        cheshireAnim.Play("none");
        Debug.Log("cheshire button released");
    }

    // Use this for initialization
    void Start () {
        cheshireBtnObj = GameObject.Find("cheshire_btn");
        cheshireBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        cheshireAnim.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
