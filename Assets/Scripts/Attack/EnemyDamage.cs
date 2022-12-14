using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public LifeBar lifeBarPlayer;

    public float hp = 100;
    public int swordDamage = 35;

    public LinearIndicator linearIndicator;
    public float maxValue = 100;
    public float minValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        lifeBarPlayer = FindObjectOfType<LifeBar>();
        Debug.Log(linearIndicator.gameObject.name);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hp < 0)
        {
            Destroy(gameObject);
        }

        hp = Mathf.Clamp(hp, minValue, maxValue);
        linearIndicator.SetValue(hp);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            lifeBarPlayer.currentValue -= 75 * Time.deltaTime;
            lifeBarPlayer.currentValue = Mathf.Clamp(lifeBarPlayer.currentValue, lifeBarPlayer.minValue, lifeBarPlayer.maxValue);
            lifeBarPlayer.linearIndicator.SetValue(lifeBarPlayer.currentValue);
        }
    }
}
