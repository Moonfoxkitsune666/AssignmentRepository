using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] [Range(0, 1)] float explosionSoundVolume = 0.7f;
    [SerializeField] GameObject Death;
    [SerializeField] float explosionDuration = 1f;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();
        if (!dmgDealer)
        {
            return;
        }
        RegisterHit(dmgDealer);
    }

    private void RegisterHit(DamageDealer dmgDealer)
    {
        health -= dmgDealer.GetDamage();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(Death, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, explosionSoundVolume);
        Destroy(explosion, explosionDuration);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
