using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{

    public GoalPotion goalPotion;
    public Animator animator;

    void Start()
    {
        Invoke("SetNumbers", 1f);
        animator = GetComponent<Animator>();
        
    }

    void SetNumbers()
    {
        goalPotion = GameObject.FindObjectOfType<GoalPotion>();

        int ran1 = Random.Range(0, 101);
        int ran2 = Random.Range(0, 101);
        int ran3 = Random.Range(0, 101);


        goalPotion.updateGoal(ran1, ran2, ran3);
    }

    public void LeaveScene()
    {
        animator.Play("outClient");
        Destroy(gameObject, 1f);
    }

}
