using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemyDamage : MonoBehaviour
{
    public LifeBar lifeBarPlayer;
    bool   canAttack;


    // Start is called before the first frame update
    void Start()
    {
    }
    void OnEnable()
    {
        lifeBarPlayer = FindObjectOfType<LifeBar>();
        Debug.Log(lifeBarPlayer);
        
    }

    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
        //if (lifeBarPlayer == null) GetPlayerLifeBar();
        canAttack = AttackEnemy.ShouldAttackPlayer(transform.position);
        if (other.gameObject.tag == "Player" && canAttack)
        {
            if (other.gameObject.GetComponent<Attack>().isRoll)
            {
                //Debug.Log("Inmune");
                return;
            }

            lifeBarPlayer.currentValue -= 500 * Time.deltaTime;
            lifeBarPlayer.currentValue = Mathf.Clamp(lifeBarPlayer.currentValue, lifeBarPlayer.minValue, lifeBarPlayer.maxValue);
            lifeBarPlayer.ChekLife();
            lifeBarPlayer.linearIndicator.SetValue(lifeBarPlayer.currentValue);
        }
    }
}
