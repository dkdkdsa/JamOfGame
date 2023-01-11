using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.AI;
using System;
using UnityEditor.SearchService;
using System.Linq;

namespace Classs
{

    public abstract class EnemyRoot : MonoBehaviour
    {

        #region Hash

        protected readonly int AttackHash = Animator.StringToHash("Attack");
        protected readonly int DieHash = Animator.StringToHash("Die");

        #endregion

        [SerializeField] protected float attackDelTime; 
        [SerializeField] protected float speed;
        [SerializeField] protected float maxHp = 50;
        [SerializeField] protected bool isBoss = false;
        [SerializeField] protected bool isFly = false;
        [SerializeField] protected int money = 70;

        protected bool isDie;
        protected bool attackCoolDown;
        protected bool isAttack;
        protected FAED_AI aiCore;
        protected Rigidbody2D rigid;
        protected Animator animator;
        protected Transform target;
        protected float HP = 50;

        protected virtual void Awake()
        {

            rigid = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            aiCore = GetComponent<FAED_AI>();

        }

        protected virtual void Start()
        {

            target = GameManager.instance.enemyTarget;

        }

        protected void StartEnemyAttack(Action action)
        {

            if (isAttack) return;
            isAttack = true;

            StartCoroutine(AttackCo(action));

        }

        private void DieAnimeShow()
        {

            animator.SetTrigger(DieHash);

        }
        public void Die()
        {

            FAED.Push(gameObject);
            if (isBoss)
            {

                GameManager.instance.waveManager.ClearWave();
                FindObjectsOfType<EnemyRoot>().ToList().ForEach(x => FAED.Push(x.gameObject));
                FindObjectsOfType<EnemyBullet>().ToList().ForEach(x => FAED.Push(x.gameObject));
                FindObjectsOfType<SuReGum>().ToList().ForEach(x => FAED.Push(x.gameObject));

            }

        }
        public void TakeDamage(float damage)
        {

            if (isDie) return;

            HP -= damage;
            if(HP <= 0)
            {

                isDie = true;
                ChangeAIState("Die");
                DieAnimeShow();
                if(isFly) rigid.gravityScale = 1;
                Debug.Log(money);
                GameManager.instance.walletManager.AddMoney(money);
            }

        }
        public virtual void Attack()
        {

            if (isAttack) return;
            animator.SetTrigger(AttackHash);

        }
        public abstract void Chase();
        public void ChangeAIState(string value)
        {

            aiCore.ChangeState(value);

        }

        public void ChangeChaseState()
        {

            aiCore.ChangeState("Chase");

        }

        public void ChangeisAttackFalse()
        {

            isAttack = false;

        }

        IEnumerator AttackCo(Action action)
        {

            attackCoolDown = true;
            yield return new WaitForSeconds(attackDelTime);
            action?.Invoke();
            yield return new WaitForSeconds(9f);
            attackCoolDown = false;

        }

        protected virtual void OnEnable()
        {

            isDie = false;
            if(GameManager.instance == null) return;
            HP = maxHp + (Mathf.Pow(GameManager.instance.waveManager.clearCount, GameManager.instance.waveManager.clearCount) * 10);
            ChangeChaseState();

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.transform.CompareTag("Player"))
            {

                GameManager.instance.player.hp.GetDamage(10);
                FAED.Push(gameObject);

            }

        }

    }

}
