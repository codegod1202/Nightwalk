using UnityEngine.InputSystem;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform fpsCam;
    public float range = 20;
    InputAction shoot;
    public int firerate = 1;
    private float nextTimeToFire = 0;
    void Start()
    {
        shoot = new InputAction("Shoot", binding: "<mouse>/rightButton");
        shoot.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        bool isShooting = shoot.ReadValue<float>() == 1;

        if(isShooting && Time.time >= nextTimeToFire)  {
            nextTimeToFire = Time.time + (1f/firerate); 
            Fire();
        }
    }

    private void Fire() {
        AudioManager.instance.Play("Shoot");
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.position, fpsCam.forward, out hit, range)) {
            if(hit.rigidbody != null) {
                //hit.rigidbody.
            }
        }
    }
}
