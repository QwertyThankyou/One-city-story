using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    
    public int countHit = 3;
    public int money = 10;
    public int ecology = 1;
    
    private AudioManager _audioManager;
    private GameController _gameController;
    
    private bool _isHit = false;
    private Animator animator;
    void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Axe") && _isHit == false)
        {
            animator.SetTrigger("Hit");
            _isHit = true;
            countHit--;
            _audioManager.Play("AxeChop");
            if (countHit == 0)
            {
                _gameController.money += money;
                _gameController.ecology -= 1;
                _audioManager.Play("TreeFall");
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Axe")) _isHit = false;
    }
}
