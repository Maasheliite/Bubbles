using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{

    public AudioSource ding;
    public GoalPotion goalPotion;
    public Animator animator;

    void Start()
    {
        Invoke("SetNumbers", 1f);
        animator = GetComponent<Animator>();
        goalPotion = GameObject.FindObjectOfType<GoalPotion>();

    }

    void SetNumbers()
    {
        goalPotion.TurnOnGoals();
        ding.Play();

        int ran1 = Random.Range(0, 255);
        int ran2 = Random.Range(0, 255);
        int ran3 = Random.Range(0, 255);
        float sum = 255.0f/(ran1+ran2+ran3);

        ran1 = (int)(ran1 * sum);
        ran2 = (int)(ran2 * sum);
        ran3 = (int)(ran3 * sum);

        goalPotion.updateGoal(ran1, ran2, ran3);
    }

    public void LeaveScene()
    {
        goalPotion.TurnOffGoals();
        animator.Play("outClient");
        Destroy(gameObject, 1f);
    }


}
