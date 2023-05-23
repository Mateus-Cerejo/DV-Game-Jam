using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BouncyWallSO", menuName = "Bouncy Wall", order = 0)]
public class BouncyWallSO : ScriptableObject {
    [SerializeField] private float _force;

    public float force
    {
        get => _force;
        set => _force = value;
    }
}
