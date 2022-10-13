using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EnemyHealth : MonoBehaviour
{
    public float healthAmount = 100;



    private void Update()
    {
        if (healthAmount <= 0)
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
            Debug.Log("took 20 damage. current health is: " + healthAmount);
        }
    }

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.transform.name == "Player")
        {
            if(Input.GetKeyDown(KeyCode.F))
            TakeDamage(100);
        }
    }
}
