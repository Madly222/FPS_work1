using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform fpsCam;
    public float range = 20;
    public float impactForce = 150;
    public int damageAmount = 20;
    public int fireRate = 10;
    private float nextTimeToFire = 0;

    public int currentAmmo;
    public int maxAmmo = 10;
    public int magazineSize = 30;

    public float reloadTime = 2f;
    private bool isReloading = false;

    public Animator animator;

    public ParticleSystem muzzleFlush;
    public GameObject impactEffect;

    InputAction shoot;

    void Start()
    {
        shoot = new InputAction("Shoot", binding: "<mouse>/leftButton");
        shoot.AddBinding("<Gamepad>/x");
        shoot.Enable();

        currentAmmo = maxAmmo;
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("isReloading", false);
    }

    void Update()
    {   if (PauseMenu.pause == false && PlayerManager.isGameOver == false)
        {
            if (currentAmmo == 0 && magazineSize == 0)
            {
                animator.SetBool("isShooting", false);
                return;
            }

            if (isReloading)
            {
                return;
            }

            bool isShooting = shoot.ReadValue<float>() == 1;

            animator.SetBool("isShooting", isShooting);

            if (isShooting && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Fire();
            }
            if (currentAmmo != maxAmmo && magazineSize != 0 && Input.GetKeyDown(KeyCode.R))
            {
                Invoke("rbut", reloadTime);
                StartCoroutine(Reload());
            }
            if (currentAmmo == 0 && magazineSize > 0 && !isReloading)
            {
                StartCoroutine(Reload());
            }
        }
    }

    private void rbut()
    {
        magazineSize += currentAmmo;
    }

    private void Fire()
    {
        muzzleFlush.Play();
        currentAmmo--;
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.position, fpsCam.forward, out hit, range))
        {
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            Enemy e = hit.transform.GetComponent<Enemy>();

            if(e != null)
            {
                e.TakeDamage(damageAmount);
                return;
            }


            Quaternion impactRotation = Quaternion.LookRotation(hit.normal);
            GameObject impact = Instantiate(impactEffect, hit.point, impactRotation);
            Destroy(impact, 5);

        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        animator.SetBool("isReloading", true);
        yield return new WaitForSeconds(reloadTime);
        animator.SetBool("isReloading", false);
        if (magazineSize >= maxAmmo)
        {
            currentAmmo = maxAmmo;
            magazineSize -= maxAmmo;
        }
        else
        {
            currentAmmo = magazineSize;
            magazineSize = 0;
        }
        isReloading = false;
    }

}
