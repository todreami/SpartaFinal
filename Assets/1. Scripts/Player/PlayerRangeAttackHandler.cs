using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttackHandler : MonoBehaviour
{
    [SerializeField] private GameObject RangeHitEffect; // 히트 효과 프리팹
    [SerializeField] private bool isChargeShot = false; // 차지샷 프리팹은 true

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyTime", 7.0f);
    }

    void DestroyTime()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            if (!isChargeShot) // 일반 샷인 경우에만 벽이나 플랫폼에 부딪혔을 때 사라짐
            {
                Instantiate(RangeHitEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

        }

        else if (collision.gameObject.CompareTag("Monster"))
        {
            Instantiate(RangeHitEffect, transform.position, Quaternion.identity); // 히트 효과 생성
            // collision.SendMessage("Demaged", 1); // Demaged 함수 호출, 원거리 공격력(1, 임시)만큼 피해  TODO
            
            if (!isChargeShot) 
            {
                Destroy(gameObject);
            }
        }
    }
}
