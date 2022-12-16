using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public LifeBar lifeBarPlayer;

    bool canAttack;

    public float hp = 100;
    public int swordDamage = 35;

    public LinearIndicator linearIndicator;
    public float maxValue = 100;
    public float minValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        lifeBarPlayer = FindObjectOfType<LifeBar>();
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
        canAttack = AttackEnemy.ShouldAttackPlayer(transform.position);
        if (other.gameObject.tag == "Player" && canAttack)
        {
            lifeBarPlayer.currentValue -= 1000 * Time.deltaTime;
            lifeBarPlayer.currentValue = Mathf.Clamp(lifeBarPlayer.currentValue, lifeBarPlayer.minValue, lifeBarPlayer.maxValue);
            lifeBarPlayer.linearIndicator.SetValue(lifeBarPlayer.currentValue);
        }
    }
}
