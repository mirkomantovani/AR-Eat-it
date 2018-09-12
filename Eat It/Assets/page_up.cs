using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class page_up : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject pageupbtnObj;
    public Animator pageupanim;

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        pageupanim.Play("pageupanim");
        Debug.Log("pageup button pressed");

    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        pageupanim.Play("none");
        Debug.Log("pageup button released");
    }

    // Use this for initialization
    void Start () {
        pageupbtnObj = GameObject.Find("pageupbtn");
        pageupbtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        pageupanim.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
