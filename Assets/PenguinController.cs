
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PenguinController : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(Control());
    }

    int action;
    float rotation;
    float Speed = 0.5f;
    // Update is called once per frame
    void Update()
    {
        if(anim.GetBool("Walk") == true) {
            transform.Translate((-1) * Speed * Time.deltaTime * transform.forward, Space.World); //i don't know why but it's negative
        }

        
    }
    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Ocean") {
            //Debug.Log("fall into the ocean");
            transform.position = new Vector3(Random.Range(2, -22), 5, Random.Range(2, -24));
        }
    }

    //automatically control the penguin's behaviour, randomly move around after idle for a while
    IEnumerator Control() {
        //Random.InitState(System.DateTime.Now.Millisecond);
        while (true) {
            action = Random.Range(0, 2);
            if (action == 0) {
                //controller.SimpleMove(new Vector3(0, 0, 0));
                anim.SetBool("Walk", false);
            }
            else if (action == 1) {
                rotation = Random.Range(-180, 180);
                transform.Rotate(0, rotation, 0);
                //controller.SimpleMove(new Vector3(x, 0, z));
                anim.SetBool("Walk", true);
            }
            int time = Random.Range(0, 6);
            yield return new WaitForSeconds(time);
        }
    }
}
