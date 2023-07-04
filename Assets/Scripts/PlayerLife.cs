using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] AudioSource DieSound;
    [SerializeField] AudioSource KillSound;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.transform.CompareTag("EnemyBody"))
        {
            Die();
        }
        else if(collision.gameObject.transform.CompareTag("EnemyHead"))
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
            KillSound.Play();
            GetComponent<PlayerMovement>().Jump();
        }
    }

    public void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        DieSound.Play();
        Invoke(nameof(reloadScene), 1.3f);
    }

    private void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
