using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
 public float value = 100;
 public RectTransform valueRectTransform;

 public GameObject gamepiayUT;
 public GameObject gameOverScreen;
 public Animator animator;

 private float _maxValue;

 private void Start()
 {
    _maxValue = value;
    DrawHealthDar();
 }


    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            PlayerIsDead();
        }
        DrawHealthDar();
    }

    public void AddHealth(float amount)
    {
        value += amount;
        value = Mathf.Clamp(value, 0, _maxValue);
        DrawHealthDar();
    }

    private void PlayerIsDead()
    {
    gamepiayUT.SetActive(false);
            gameOverScreen.SetActive(true);
            GetComponent<PlayerController>().enabled = false;
            GetComponent<FireballCaster>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;
            animator.SetTrigger("deat");
    }

    private void DrawHealthDar()
    {
        valueRectTransform.anchorMax = new Vector2(value/ _maxValue, 1);
    }
}
