using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = GameObject.FindObjectOfType<PlayerMove>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<obstacles>() != null)
        {
            return;
        }
        //kill the player
        if (collision.gameObject.name == "Player" && !GameManager.inst.invincible)
        {
            GameManager.inst.score = 0;
            playerMove.Die();
        }
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
