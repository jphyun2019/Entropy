using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour
{

    public ParticleSystem trail;
    public ParticleSystem explosion;
    public Transform player;
    public Rigidbody[] playerbox;
    public Rigidbody body;


    // Start is called before the first frame update
    void Start()
    {
        body.isKinematic = true;
        trail.Stop();
        explosion.Stop();
        
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("map") || (other.CompareTag("dice")))
        {
            body.isKinematic = true;

            trail.Stop();
            explosion.Play();
            

            foreach (Rigidbody r in playerbox)
            {
                r.AddExplosionForce(15, transform.position, 25, 8, ForceMode.Impulse);
            }



        }
    }
    public void hurl()
    {
        body.isKinematic = false;
        trail.Play();

        transform.position = new Vector3(player.position.x + Random.Range(-30, 30), 50, player.position.z + Random.Range(-30, 30));
        transform.LookAt(player);
        transform.eulerAngles += new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));

        body.velocity = new Vector3(0, 0, 0);
        body.AddRelativeForce(Vector3.forward *15000);


        
        
    }



}
