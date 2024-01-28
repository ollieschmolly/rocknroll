using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript2D : MonoBehaviour
{

    public float fieldofImpact;
    public float force;
    public LayerMask LayerToHit;

    //audio variables
    public AudioSource audioSource;
    public AudioClip timerSound;

    public ParticleSystem explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bombCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.E))
        {
            explode();
        }
    }

    IEnumerator bombCountdown()
    {
        audioSource.PlayOneShot(timerSound);
        yield return new WaitForSeconds(timerSound.length);
        explode();


    }
    void explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, LayerToHit);
    
        foreach(Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldofImpact);
    }
    
}
