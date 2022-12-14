using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public LifeBar lifeBar;

    public int hp = 100;
    public int swordDamage = 35;
    // Start is called before the first frame update
    void Start()
    {
        lifeBar = FindObjectOfType<LifeBar>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hp < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        {
        Debug.Log("Entro al collider de "+ other.gameObject.tag);
            lifeBar.currentValue -= 75 * Time.deltaTime;
            lifeBar.currentValue = Mathf.Clamp(lifeBar.currentValue, lifeBar.minValue, lifeBar.maxValue);
            lifeBar.linearIndicator.SetValue(lifeBar.currentValue);
        }
    }
}
