using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource _AudioSource;
    public AudioClip _AudioClip1;
    public AudioClip _AudioClip2;
    public AudioClip _AudioClip3;
    public AudioClip _AudioClip4;
    public AudioClip _AudioClip5;
    public AudioClip _AudioClip6;
    
    void Start()
    {
        _AudioSource.clip = _AudioClip1;

        _AudioSource.Play();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rock" || collision.gameObject.tag == "Rock Key" || collision.gameObject.tag == "Rock Key 2")
        {
            _AudioSource.clip = _AudioClip2;
            _AudioSource.Play();
        }
        if (collision.gameObject.tag == "Pop" || collision.gameObject.tag == "Pop Key")
        {
            _AudioSource.clip = _AudioClip3;
            _AudioSource.Play();
        }
        if (collision.gameObject.tag == "Electronic")
        {
            _AudioSource.clip = _AudioClip4;
            _AudioSource.Play();
        }
        if (collision.gameObject.tag == "Jazz")
        {
            _AudioSource.clip = _AudioClip5;
            _AudioSource.Play();
        }
        if (collision.gameObject.tag == "Epic")
        {
            _AudioSource.clip = _AudioClip6;
            _AudioSource.Play();
        }
    }
}
