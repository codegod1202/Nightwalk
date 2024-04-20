using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float damage = 30f;
    [SerializeField]
    private GameObject player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 3f)
        {
            // Decrement the number every 2 seconds
            if (Time.time % 2f < Time.deltaTime)
            {
                player.GetComponent<EndManager>().playerHP -= damage;
            }
        }
    }
}
