using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class WeaponScripts : MonoBehaviour
{
    public GameObject rifle;
    public GameObject pistol;
    public GameObject rocketlauncher;
    public int distanceout = 30;
    public GameObject target;
    public GameObject target2;
    public GameObject target3;

    public Transform pistolmuzzle;
    public Transform riflemuzzle;
    public Transform bazookamuzzle;

    public bool pistolIsOut = true;
    public bool rifleIsOut = false;
    public bool launcherIsOut = false;
    public SteamVR_Action_Single triggerAction;
    public GameObject controllerR;
    public GameObject laserPrefab;                     // reference to the laserbeam prefab that we will make
    private GameObject laser;                          // a variable to hold the actual laser that we DO make

    public GameObject WaveNumber;

    // Start is called before the first frame update
    void Start()
    {
        laser = Instantiate(laserPrefab);
        pistol.SetActive(true);
        rifle.SetActive(false);
        rocketlauncher.SetActive(false);
        triggerAction.AddOnChangeListener(WillShoot, SteamVR_Input_Sources.RightHand);
    }

    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true);
        laser.transform.position = Vector3.Lerp(pistolmuzzle.position, hit.point, .5f);
        laser.transform.LookAt(hit.point);
        laser.transform.localScale = new Vector3(laser.transform.localScale.x, laser.transform.localScale.y, hit.distance);
    }

    // Update is called once per frame
    void Update()
    {
        laser.transform.position = pistolmuzzle.position;
        if (WaveNumber.GetComponent<WaveNumber>().RoundNum == 2)
        {
            pistol.SetActive(false);
            rifle.SetActive(true);

        }
        if (WaveNumber.GetComponent<WaveNumber>().RoundNum == 3)
        {
            rifle.SetActive(false);
            rocketlauncher.SetActive(true);

        }
    }


    public void pistolDamage()
    {
        RaycastHit hit;
        if (Physics.Raycast(pistolmuzzle.transform.position, transform.TransformDirection(Vector3.forward), out hit, distanceout))
        {
            if (hit.collider.gameObject.tag == "Chicken")
            {
                hit.collider.gameObject.GetComponent<ChickenBehavior>().currentHealth -= 10;
                
                    
            }
        }
    }

    public void rifleDamage()
    {
        RaycastHit hit;
        if (Physics.Raycast(riflemuzzle.transform.position, transform.TransformDirection(Vector3.forward), out hit, distanceout*1.5f))
        {
            if (hit.collider.gameObject.tag == "Chicken")
            {
                hit.collider.gameObject.GetComponent<ChickenBehavior>().currentHealth -= 25;
            }
        }
    }


    public void rocketlauncherDamage()
    {
        RaycastHit hit;
        if (Physics.Raycast(bazookamuzzle.transform.position, transform.TransformDirection(Vector3.forward), out hit, distanceout*2.0f))
        {
            if (hit.collider.gameObject.tag == "Chicken")
            {
                hit.collider.gameObject.GetComponent<ChickenBehavior>().currentHealth -= 50;
            }
        }
    }

    private void WillShoot(SteamVR_Action_Single fromAction, SteamVR_Input_Sources fromSource, float newAxis, float newDelta)
    {
        if (fromSource == SteamVR_Input_Sources.RightHand && newAxis > 0.9)
        {
            if(pistolIsOut == true)
            {
                pistolDamage();
            }

            if (rifleIsOut == true)
            {
                rifleDamage();
            }

            if (launcherIsOut == true)
            {
                rocketlauncherDamage();
            }

        }
    }

}
