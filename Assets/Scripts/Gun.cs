using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 120f;
    [SerializeField] float timeBetweenShots = 0.5f;  
    InputAction shoot;    
    [SerializeField] LayerMask mask;
    bool canShoot = true;
    void Start()
    {
        canShoot = true;
        shoot = new InputAction("Shoot", binding: "<mouse>/leftButton");
        shoot.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        bool isShooting = shoot.ReadValue<float>() == 1;

        if (isShooting && Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }   
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        Fire();
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }
    private void Fire() {
        AudioManager.instance.Play("Shoot");
        
        RaycastHit hit;

        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            //Debug.DrawLine(Vector3.zero, new Vector3(5, 0, 0), Color.white, 2.5f);
            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target == null) return;
            Debug.Log("Shottttt");
            target.takeDamage(damage);
        }
        else {
            return;
        }
    }
}
