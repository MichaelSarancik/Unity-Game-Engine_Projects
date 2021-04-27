using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChickenBehavior : MonoBehaviour
{

    //public GameObject chicken;
    public GameObject normalChicken;
    public GameObject armoredChicken;
    public GameObject motherClucker;

    public GameObject target;
    public int normalChickenHealth = 100;
    public int armoredChickenHealth = 200;
    public int motherCluckerHealth = 1000;

    public int currentHealth;
    public ChickenType type;

    public bool isAlive = true;
    public bool isAlive2 = true;
    public SpawningScript spawner;

    public enum ChickenType { NORMAL, ARMORED, MOTHERCLUCKER }

    //private float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Chicken";
        spawner = GameObject.FindWithTag("Spawner").GetComponent<SpawningScript>();

        switch(type)
        {
            case ChickenType.NORMAL:
                {
                    currentHealth = normalChickenHealth;
                    break;
                }
            case ChickenType.ARMORED:
                {
                    currentHealth = armoredChickenHealth;
                    break;
                }
            case ChickenType.MOTHERCLUCKER:
                {
                    currentHealth = motherCluckerHealth;
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<NavMeshAgent>().destination = target.transform.position;
        //chicken.transform.position = Vector3.MoveTowards(chicken.transform.position, target.transform.position, speed * Time.deltaTime);
        if(currentHealth <= 0 && isAlive == true)
        {
            gameObject.SetActive(false);
            spawner.ChickensRemaining--;
            isAlive = false;
        }
    }
}
