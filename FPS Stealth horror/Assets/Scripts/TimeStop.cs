using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TimeStop : MonoBehaviour
{
    bool isTimeStopped = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isTimeStopped = !isTimeStopped;
            foreach (EnemyMovement enemy in FindObjectsOfType<EnemyMovement>())
            {

                if (enemy.GetComponent<NavMeshAgent>())
                {
                    if (isTimeStopped)
                    {
                        enemy.GetComponent<Rigidbody>().isKinematic = true;
                        enemy.GetComponent<NavMeshAgent>().isStopped = true;
                        enemy.enabled = false;


                    }
                    else
                    {
                        enemy.GetComponent<Rigidbody>().isKinematic = false;
                        enemy.GetComponent<NavMeshAgent>().isStopped = false;
                        enemy.enabled = true;
                    }
                }
            }
        }
    }
}
