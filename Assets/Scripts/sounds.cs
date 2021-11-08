using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{
    public static AudioClip Coin, BSphere, tab , die, invin ,game;
    public static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        Coin = Resources.Load<AudioClip>("Coin");
        BSphere = Resources.Load<AudioClip>("bluespheres");
        tab = Resources.Load<AudioClip>("chill");
        die = Resources.Load<AudioClip>("losing");
        invin = Resources.Load<AudioClip>("invinsable");
        game = Resources.Load<AudioClip>("game");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Coin":
                audioSrc.PlayOneShot(Coin);
                break;
            case "bluespheres":
                audioSrc.PlayOneShot(BSphere);
                break;
            case "chill":
                audioSrc.clip = tab;
                audioSrc.loop = true;
                audioSrc.Play();
                break;
            case "losing":
                audioSrc.PlayOneShot(die);
                break;
            case "invinsable":
                audioSrc.PlayOneShot(invin);
                break;
            case "game":
                audioSrc.PlayOneShot(game);
                break;


        }
    }
}
