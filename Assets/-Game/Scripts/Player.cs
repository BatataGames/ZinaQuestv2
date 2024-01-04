using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public GameObject heartContainer;
    public GameObject fullHeartPrefab;
    public GameObject halfHeartPrefab;
    public GameObject emptyHeartPrefab;

    void Start()
    {
        health = 50;
        UpdateHearts();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            TakeDamage(5);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        // Ensure health doesn't fall below 0
        if (health < 0) health = 0;
        UpdateHearts();
    }

    public void Heal(float amount)
    {
        health += amount;
        // Ensure health doesn't exceed max health (50 in this case)
        if (health > 50) health = 50;
        UpdateHearts();
    }

    private void UpdateHearts()
    {
        // Destroy all current hearts
        foreach (Transform child in heartContainer.transform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate new hearts
        for (int i = 0; i < health; i += 10)
        {
            if (health - i >= 10)
            {
                Instantiate(fullHeartPrefab, heartContainer.transform);
            }
            else if (health - i >= 5)
            {
                Instantiate(halfHeartPrefab, heartContainer.transform);
            }
        }

        // Instantiate empty hearts for the remaining health
        for (int i = Mathf.CeilToInt(health / 10) * 10; i < 50; i += 10)
        {
            if (i < health)
            {
                Instantiate(halfHeartPrefab, heartContainer.transform);
            }
            else
            {
                Instantiate(emptyHeartPrefab, heartContainer.transform);
            }
        }
    }
}