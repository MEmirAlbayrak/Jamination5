using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    private PlayerMovement _player;
    private NavMeshAgent _agent;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    [SerializeField] private float attackRange = 0.75f;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float angleOffset = 90;
    [SerializeField] private float minDistance = 1f;
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private float attackDuration = 1f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int attackCount = 3;
    [SerializeField] private float bulletPosX = 1;
    [SerializeField] private float bulletPosY = 1;
    [SerializeField] private float hp = 200;
    private int currentAttackCount = 0;
    private float attackCurrentDuration = 0f;
    private float attackCurrentCooldown = 0;
    private bool isAttacking = false;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _agent = GetComponent<NavMeshAgent>();
		_agent.updateRotation = false;
		_agent.updateUpAxis = false;
     _agent.updatePosition = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        attackCurrentCooldown -= Time.fixedDeltaTime;

        if (isAttacking){
            Attack();
        }

        if (Vector2.Distance(_player.transform.position, _rigidbody.position) > minDistance)
        {
            Go();
        }
        else
        {
            StartAttack();
        }
    }

    private void Attack(){
        attackCurrentDuration += Time.fixedDeltaTime;

        if (currentAttackCount < attackCount){
            if (attackCurrentDuration > attackDuration){
                currentAttackCount++;
                attackCurrentDuration = 0;
                SpawnBullet();
            }

            if (currentAttackCount == attackCount){
                currentAttackCount = 0;
                isAttacking = false;
                _animator.SetBool("Attack", false);
                attackCurrentCooldown = attackCooldown;
            }
        }
    }

    private void SpawnBullet(){
        Vector3 bulletRotationVector = new Vector3(attackPoint.rotation.eulerAngles.x, attackPoint.rotation.eulerAngles.y, attackPoint.rotation.eulerAngles.z - 90);
        Quaternion bulletRot = Quaternion.Euler(bulletRotationVector);

        float randomPosX = Random.Range(-bulletPosX, bulletPosX);
        float randomPosY = Random.Range(-bulletPosY, bulletPosY);
        Vector3 bulletPosition = new Vector3(attackPoint.position.x + randomPosX, attackPoint.position.y + randomPosY, attackPoint.position.z);

        GameObject bullet = Instantiate(bulletPrefab, bulletPosition, bulletRot);
    }

    private void StartAttack(){
        _agent.isStopped = true;
        _agent.nextPosition = _rigidbody.position;

        Vector2 playerPos = _player.transform.position;
        Vector2 dir = playerPos - _rigidbody.position;
        float nextAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        _rigidbody.MoveRotation(nextAngle + angleOffset);

        if (attackCurrentCooldown <= 0){
            isAttacking = true;
            _animator.SetBool("Attack", true);
        }
    }

       private void Go()
    {
        _agent.isStopped = false;
        _agent.SetDestination(_player.transform.position);

        Vector2 agentNextPosition = _agent.nextPosition;
        Vector2 dir = agentNextPosition - _rigidbody.position;
        float nextAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        _rigidbody.MoveRotation(nextAngle + angleOffset);

        _rigidbody.position = _agent.nextPosition;
    }

    private void TakeDamage(double damage){
        
    }

        private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, minDistance);
    }
}
