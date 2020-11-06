using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameController gameController;
    public ParticleSystem hitParticle;
    private float _time;

    public void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        hitParticle = gameObject.GetComponent<ParticleSystem>();
        _time = 0.0f;
        StartCoroutine(DestroyTime());
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Katana"))
        {
            gameController.money += 1;
            hitParticle.Play();
        }
    }

    void Update()
    {
        /*if (transform.position.y < .8f)
            Destroy(this.gameObject);*/
    }

    IEnumerator DestroyTime()
    {
        while (_time <= 1.7f)
        {
            yield return null;
            _time += Time.deltaTime;
        }
        Destroy(this.gameObject);
    }
}
