using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public int myHealth = 100;
    public int normalChickenDamage = 5;
    public int armoredChickenDamage = 10;
    public int mothercluckerdamage = 20;
    public bool okToDamage = true;

    // Start is called before the first frame update
    void Start()
    {
        okToDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(myHealth <= 0)
        {

            print("Game Over");


        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "normalChicken" && okToDamage == true)
        {
            myHealth = myHealth - normalChickenDamage;
            okToDamage = false;
            StartCoroutine("normalDamage");
        }
        if (collision.gameObject.tag == "armoredChicken" && okToDamage == true)
        {
            myHealth = myHealth - armoredChickenDamage;
            okToDamage = false;
            StartCoroutine("armoredDamage");
        }
        if (collision.gameObject.tag == "motherClucker" && okToDamage == true)
        {
            myHealth = myHealth - mothercluckerdamage;
            okToDamage = false;
            StartCoroutine("bossDamage");
        }
    }

    IEnumerator normalDamage()
    {
        yield return new WaitForSeconds(1.5f);
        okToDamage = true;

    }

    IEnumerator armoredDamage()
    {
        yield return new WaitForSeconds(2.0f);
        okToDamage = true;

    }
    IEnumerator bossDamage()
    {
        yield return new WaitForSeconds(1.5f);
        okToDamage = true;
    }
}
