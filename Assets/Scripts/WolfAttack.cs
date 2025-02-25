using System;
using UnityEngine;

public class WolfAttack : MonoBehaviour
{
    private Animator anim;
    private Transform target;
    private SpriteRenderer spriteRenderer;
    public GameObject exclamation;
    
    public bool gethit = false;
    public bool isAttacking = false;
    public float speed = 3f;
    public float attackRange = 1.5f;
    public float damageAttackRange = 2f;
    public float attackCooldown = 2f;
    public float lastAttackTime = 0f;
    public float verticalThreshold = 1f;
    public float runRange = 3f;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update()
    {
        if (gethit)
        {
            anim.Play("Death");
            return;
        }
        
        float horizontalDistanceToPlayer = Mathf.Abs(transform.position.x - target.position.x);
        float verticalDistanceToPlayer = Mathf.Abs(transform.position.y - target.position.y);
        
        Vector2 direction = (target.position - transform.position).normalized;
        spriteRenderer.flipX = direction.x > 0;

        if (isAttacking)
        {
            return;

        }
            
        if (horizontalDistanceToPlayer <= attackRange && 
            verticalDistanceToPlayer <= verticalThreshold && 
            Time.time >= lastAttackTime + attackCooldown)
        {
            Attack();
            return;
        }
        

        if ((horizontalDistanceToPlayer <= attackRange - 0.5f && verticalDistanceToPlayer >= verticalThreshold) || 
            (horizontalDistanceToPlayer >= runRange && verticalDistanceToPlayer >= verticalThreshold))
        {
            anim.Play("Idle");
            return;
        }
        
        if (horizontalDistanceToPlayer <= runRange)
        {
            exclamation.SetActive(true);
            anim.Play("Run");
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            exclamation.SetActive(false);
            anim.Play("Idle"); 
        }
    }
    
    private void Attack()
    {
        isAttacking = true;
        anim.Play("Attack");
        lastAttackTime = Time.time;
        Invoke("EndAttack", 1f);
    }
    
    
    private void EndAttack()
    {
        isAttacking = false;
    }
    
    public void EndDeathAnimation()
    {
        anim.speed = 0;
        Destroy(gameObject);
    }
}