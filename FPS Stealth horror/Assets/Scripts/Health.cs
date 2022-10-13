using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100;



    private void Update()
    {
        if(healthAmount <= 0)
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene("Init");
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            TakeDamage(20);
            Debug.Log("took 20 damage. current health is: " + healthAmount);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Healing(10);
            Debug.Log("healed 10. current health is: " + healthAmount);
        }
    }

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;
        healthBar.fillAmount = healthAmount / 100;
    }

    public void Healing(float healPoints)
    {
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Enemy")
        {
            TakeDamage(20);
        }
    }
}
