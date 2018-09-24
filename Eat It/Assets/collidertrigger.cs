using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidertrigger : MonoBehaviour {

    public Animator hatterText;

    public Animator allMadHereText;

    public Animator drinkMe;

    public Animator pencilHole;
    public Animator cokeHole;
    public Animator jamHole;

    public AudioSource rabbitHole;


    void OnTriggerStay(Collider other)
    {
        Debug.Log("Object entered in cereal1 trigger: "+other.name);

        switch (other.name)
        {
            case "collidercerealcube":
                rabbitHole.Play();
                pencilHole.Play("pencilholeanim");
                cokeHole.Play("cokeholeanim");
                jamHole.Play("jamholeanim");
                hatterText.Play("hattertextanim");
                break;
            case "collidercereal2":
                hatterText.Play("hattertextanim");
                allMadHereText.Play("allmadhereanim");
                break;
            case "collidercan":
                hatterText.Play("hattertextanim");
                drinkMe.Play("drinkmeanim");
                break;
            default:
                Debug.Log("Unidentified object entered");
                break;
        }
    }


    // Use this for initialization
    void Start () {
        hatterText.GetComponent<Animator>();
        pencilHole.GetComponent<Animator>();
        cokeHole.GetComponent<Animator>();
        jamHole.GetComponent<Animator>();
        allMadHereText.GetComponent<Animator>();
        drinkMe.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
