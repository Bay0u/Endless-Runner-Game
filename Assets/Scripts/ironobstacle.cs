using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ironobstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        //kill the player
        if (collision.gameObject.name == "Player")
        {
            GameManager.inst.DecrementScore();
        }
        if (collision.gameObject.GetComponent<obstacles>() != null)
        {
            return;
        }
        Destroy(gameObject);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
