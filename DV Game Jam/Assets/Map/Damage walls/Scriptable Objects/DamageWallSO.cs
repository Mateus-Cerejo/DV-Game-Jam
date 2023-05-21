using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DamageWall", fileName = "New DamageWall")]

public class DamageWallSO : ScriptableObject
{
    [SerializeField] private int damage;
    [SerializeField] private ParticleSystem collisionParticles;
    [SerializeField] private AudioClip collisionSFX;

    public int getDamage() { return damage; }
    public ParticleSystem GetCollisionParticles() { return collisionParticles; }
    public AudioClip getCollisionSFX() { return collisionSFX; }

}
