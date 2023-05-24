using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalBeahaviour : MonoBehaviour
{
    [SerializeField] private GameObject levelUI;

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Se a colisão for o jogador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Se a distância do jogador ao buraco for menor que um terço do diâmetro do jogador, puxa o para sí
            if (Vector2.Distance(transform.position, collision.transform.position) < transform.localScale.x / 3)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().MovePosition(transform.position);
                if (Vector2.Distance(transform.position, collision.transform.position) < 0.0001)
                {
                    collision.GetComponent<PlayerMovement>().enabled = false;
                    collision.GetComponent<CircleCollider2D>().enabled = false;
                    collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    GetComponent<AudioSource>().Play();
                    GetComponent<ParticleSystem>().Play();
                    collision.GetComponent<PlayerScore>().Win();
                    levelUI.GetComponent<LevelManager>().DisplayNextLevelBtn();
                    PlayerInfo.UpdateProgress(int.Parse(SceneManager.GetActiveScene().name.Split(" ")[1]) + 1);
                }
            }
        }
    }
}
