using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSpheres : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<obstacles>() != null)
        {
            Destroy(gameObject);
            return;
        }
        if (other.gameObject.name != "Player")
        {
            return;
        }
        sounds.PlaySound("bluespheres");
        GameManager.inst.IncrementScore("BSphere");
        Destroy(gameObject);
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
