using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour

{
    private bool isDead = false;
    private Rigidbody2D rb2d;

    public float upForce = 200f;
    private Animator anim;

    AudioSource audioSource;

    public AudioClip flap;
    public AudioClip die;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                PlaySound(flap);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Death");
        PlaySound(die);
        GameControl.instance.BirdDied();
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);   
    }
}
