using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttackHandler : MonoBehaviour
{
    [SerializeField] private GameObject meleeHitEffect; // 히트 효과 프리팹


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            Debug.Log("몬스터에게 근접 공격!");
            //collision.SendMessage("Damaged", 10);  // TODO
            Instantiate(meleeHitEffect, collision.transform.position, Quaternion.identity);
        }
    }
}
