using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int initHealth = 1;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private PlayerStats playerStats;

    private Vector3 initialPos;
    private int curHealth;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        curHealth = initHealth;
    }

    private void ResetPosition()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.position = initialPos;
    }

    private void ResetHealth()
    {
        curHealth = initHealth;
    }

    public void takeDamage(int amount)
    {
        curHealth -= amount;
        if (curHealth > 0)
        {
            StartCoroutine(WaitForAnimationPlay("Take Damage"));
        }
        else
        {
            StartCoroutine("Die");
        }
    }

    IEnumerator Die()
    {
        GetComponent<PlayerMovement>().enabled = false;
        //GetComponent<AudioSource>().PlayOneShot(deathSound);
        StartCoroutine(WaitForAnimationPlay("Die"));
        yield return new WaitForSeconds(1.5f);
        ResetPosition();
        ResetHealth();
        playerStats.UnlockStats();
        gameObject.GetComponent<PlayerScore>().RestartLevel();
        GetComponent<PlayerMovement>().enabled = true;
    }

    IEnumerator WaitForAnimationPlay(string animationName)
    {
        GetComponent<Animator>().SetBool(animationName, true);
        yield return new WaitForSeconds(1f);
        GetComponent<Animator>().SetBool(animationName, false);
    }

    public void SetInitialHealth(int newInitialHealth)
    {
        initHealth = newInitialHealth;
        curHealth = newInitialHealth;
    }

    public void RestartLevel()
    {
        ResetPosition();
        ResetHealth();
        GameObject.FindAnyObjectByType<PlayerStats>().UnlockStats();
    }
}
