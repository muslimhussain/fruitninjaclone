using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitPrefab;
    public float explosionRadius = 5f;
    private GameManager myGM;
    public int scoreAmount = 3;

    public void CreateSlicedFruit()
    {
        GameObject inst = Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

        Rigidbody[] rbOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rbOnSliced)
        {
            rigidbody.transform.rotation = Random.rotation;
            rigidbody.AddExplosionForce(Random.Range(500, 1000), transform.position, explosionRadius);
        }
        myGM.IncreaseScore(scoreAmount);

        myGM.PlayRandomSliceSound();

        Destroy(inst, 5f);

        Destroy(gameObject);
    }

    private void Start()
    {
        myGM = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Blade b = other.GetComponent<Blade>();

        if (!b) {return;}

        CreateSlicedFruit();
    }
}
