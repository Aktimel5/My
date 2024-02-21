using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float damage = 10;
    // Start is called before the first frame update
    private void Start()
    {
        Invoke("DestroyFiredall", lifetime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collosion)
    {
        DamageEnemy(collosion);
        DestroyFiredall();
    }
    private void DamageEnemy(Collision collosion)
    {
        var enemyHealth = collosion.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }
    }

    private void DestroyFiredall()
    {
        Destroy(gameObject);
        Invoke("MethodName", 3);
    }
}
