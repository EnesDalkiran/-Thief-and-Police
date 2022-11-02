using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ColliderEnter : MonoBehaviour
{
    GameManager gm;
    CharacterController characterController;
    GameObject target;
    Animator animator;
    [SerializeField]
    GameObject bang;
    GameObject bangpanel;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Police"&& target == null && gm.starList.Count!=0)
        {

            other.gameObject.GetComponent<Animator>().SetTrigger("Attack");
            Destroy(Instantiate(bang, bangpanel.transform),1f);
            

            if (gm.guiltylist.Count == 0)
            {

                target = other.gameObject; // burda suçlu yoksa else gidiyor guiltylistten bakýyor
            }
            else
            {
                target = gm.guiltylist[gm.guiltylist.Count - 1];
            }
            gm.Catch(gameObject);
        }
        
    }
  
   
    void Start()
    {
        
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        characterController = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
        bangpanel= GameObject.Find("Bang");

    }

    void Update()
    {
        if (target != null)
        {
            
            Vector3 direction = target.transform.position-transform.position;

            Vector3 motion=direction*5;
            
            if (direction.magnitude >= 1.5f)
            {
                animator.SetBool("run", true);
                characterController.Move(motion.normalized*Time.deltaTime*5);
                transform.LookAt(target.transform);
            }
            else
            {
                animator.SetBool("run", false);
            }
            
        }

    }
}
