using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copter : MonoBehaviour {

    public float maxAngVel = 100.0f;
    public float angDrag = 1.0f;
    public float spinForce = 100.0f;
    public float turnForce = 10.0f;
    public float nudgeForce = 2.0f;


    private float hudY = -50f;

    private Transform rocketHolder1;
    private Transform rocketHolder2;

    public GameObject rocket;

    //public Transform propeler;
    //public Component[] rigidbodys;
    public Rigidbody propelerBody;
    public GameObject propeler;
    public float upForce = 1.0f;

    private RectTransform hud_pink;
 	// Use this for initialization
	void Start () {
        rocketHolder1 = transform.Find("rocketHolder1");
        rocketHolder2 = transform.Find("rocketHolder2");

        hud_pink = GameObject.Find("hud_pink").GetComponent<RectTransform>();

     

        propelerBody = transform.Find("propelers").GetComponent<Rigidbody>();
        //foreach (Rigidbody body in rigidbodys){
        //    if (body.GetComponentInParent<Transform>().name == "propelers"){
        //        Debug.Log("found");
        //        propelerBody = body;
        //    }
        //}

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        propelerBody.angularDrag = angDrag;
        propelerBody.maxAngularVelocity = maxAngVel;

        if (Input.GetKey("space"))
        {
            if (propelerBody.angularVelocity.y >= 10.0f){
               

                gameObject.GetComponent<Rigidbody>().AddForce(transform.up * upForce);
            }

           
            propelerBody.AddTorque(transform.up * spinForce);
        }
        if (Input.GetKey("e")){
            gameObject.GetComponent<Rigidbody>().AddTorque(transform.up * turnForce);
        }
        if (Input.GetKey("q"))
        {
            gameObject.GetComponent<Rigidbody>().AddTorque(transform.up * -turnForce);
        }
        if (Input.GetKey("w"))
        {
            gameObject.GetComponent<Rigidbody>().AddTorque(transform.right * nudgeForce);
          
        }
        if (Input.GetKey("s"))
        {
          
            gameObject.GetComponent<Rigidbody>().AddTorque(transform.right * -nudgeForce);
        }
        if (Input.GetKey("a"))
        {
            gameObject.GetComponent<Rigidbody>().AddTorque(transform.forward * nudgeForce);
        }
        if (Input.GetKey("d"))
        {
            gameObject.GetComponent<Rigidbody>().AddTorque(transform.forward * -nudgeForce);
        }
        if (Input.GetKeyDown("u"))
        {
            Instantiate(rocket, rocketHolder1.position, rocketHolder1.rotation);
            Instantiate(rocket, rocketHolder2.position, rocketHolder1.rotation);
        }
        if (transform.eulerAngles.x > 90){
            hudY = (0.55f * transform.eulerAngles.x % 270f) - 250f;

        } else {
            hudY = (0.55f * transform.eulerAngles.x % 270f) -50f;
        }
        Debug.Log(hudY);

        //hudY = 0.55f * (transform.eulerAngles.x +90f);
        //Debug.Log(transform.eulerAngles.x % 9);
        //Debug.Log(hudY);

        //hud_pink.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z);
        hud_pink.transform.position = new Vector3(0f, hudY, 0f);
	}
}
