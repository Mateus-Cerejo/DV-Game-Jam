using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageWall : MonoBehaviour
{
    [SerializeField] private DamageWallSO damageWallSO;

    private AudioSource aSource;
    private void Start()
    {
        aSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //aSource.PlayOneShot(damageWallSO.getCollisionSFX());
            //damageWallSO.GetCollisionParticles().Play();
            collision.gameObject.GetComponent<PlayerHealth>().takeDamage(damageWallSO.getDamage());
        }
    }

}
