using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBall : MonoBehaviour
{
    private SpawnManager spawnManager;
    bool dying = false;
    private void Awake() => spawnManager = FindObjectOfType<SpawnManager>();

    private void OnCollisionEnter(Collision collision)
    {               
        if (collision.gameObject.CompareTag("Blue") && dying == false)
        {
            var blueBall = collision.gameObject.GetComponent<BlueBall>();
            if (blueBall.Dying == true)
                return;
            Debug.Log("Destroying");
            blueBall.Dying = true;
            dying = true;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            spawnManager.AddDestroyCount();
            //Debug.Log($"Id {gameObject.GetInstanceID()} Collision with tag " + collision.gameObject.tag + " frame: " + Time.frameCount  + " Dead " + spawnManager.destroyCount);
        }        
    }

    private void OnDestroy() => spawnManager.AddRedDestroyed();
}
