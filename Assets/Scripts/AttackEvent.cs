using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEvent : MonoBehaviour
{
    public EnemyAI enemyAI;
    public void AttackEvant()
    {
        enemyAI.AttacDamage();
    }

}
