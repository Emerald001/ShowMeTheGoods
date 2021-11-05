using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("Definables")]
    public Animator attackAnimator;
    public float idleDuration;
    public KeyCode attackInput = KeyCode.Mouse0;

    protected bool Attacked;
    protected bool IdleReset;
    protected float idleTime;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(attackInput)) {
            if (!IdleReset) {
                idleTime = idleDuration;
                attackAnimator.SetTrigger("AttackStart");
                IdleReset = true;
            }
            else {
                attackAnimator.SetTrigger("SecondAttackStart");
                IdleReset = false;
                idleTime = 0;
            }
        }

        if (IdleReset) {
            if (idleTime > 0) {
                idleTime -= Time.deltaTime;
            }
            else {
                attackAnimator.SetTrigger("AttackIdleReset");
                IdleReset = false;
            }
        }
    }
}