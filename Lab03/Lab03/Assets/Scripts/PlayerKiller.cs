
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKiller : MonoBehaviour
{
    public GameObject player;
    public float chaseDistance = 4f;
    public float moveSpeed = 2f;
    public float rotationSpeed = 2.0f;
    public bool findPlayer = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (findPlayer)
        {
            if (collision.gameObject.name == player.gameObject.name)
            {
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
        }
        
    }
    private void Update()
    {
        if (player != null)
        {
            KillPlayer();
        }
        else
        {
            player = GameObject.Find("Player");
            if (player != null)
            {
                KillPlayer();
            }
        }  
    }
    public void KillPlayer()
    {
        if (!findPlayer)
        {
            if (Vector3.Distance(transform.position, player.transform.position) <= chaseDistance)
            {
                if (Vector3.Dot(transform.forward, (player.transform.position - transform.position)) > 0.6)
                {
                    findPlayer = true;
                }
            }
        }
        else
        {
            Vector3 direction = player.transform.position - transform.position;

            direction.Normalize();
            transform.LookAt(player.transform);

            transform.position += direction * moveSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}
