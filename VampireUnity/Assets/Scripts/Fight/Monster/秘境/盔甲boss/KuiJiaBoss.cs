using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Equip;
using Spine;
using UnityEngine;
using Random = UnityEngine.Random;

public enum KuiJiaSkillType
{
    None,
    ChuChang,
    HeiXuanFen,
    HuDun
}
namespace Fight.Monster.秘境.盔甲boss
{
    public class KuiJiaBoss : MonsterBase
    {
        public KuiJiaBoss() : base(MonsterType.Boss, "KuiJiaBoss", 1, MJConfig.BossMonsterAttribute.hp*MJConfig.MonsterAttributeDic[MJLevel.Green].hp, 1.3f, MJConfig.BossMonsterAttribute.atk*MJConfig.MonsterAttributeDic[MJLevel.Green].atk, MJConfig.BossMonsterAttribute.def*MJConfig.MonsterAttributeDic[MJLevel.Green].def, MJConfig.BossMonsterAttribute.ex*MJConfig.PlayerAttributeDic[MJLevel.Green].ex, MJConfig.BossMonsterAttribute.linhun*MJConfig.PlayerAttributeDic[MJLevel.Green].linhun, 0)
        {
        }

        public Transform attackTrans;
        private float skill1Time = 15;
        private float skill2Time = 12;
        private float skill3Time = 8;
        private float currentSkill1Time = 5;
        private float currentSkill2Time = 5;
        private float currentSkill3Time = 5;
        public GameObject hudun;
        public Animator hudunAnimator;
        [NonSerialized] public KuiJiaSkillType KuiJiaSkillType = KuiJiaSkillType.None;
        public Collider2D Skill3Collider2D;
        private Vector2 skill3Position = Vector2.zero;

        public void Awake()
        {
            MaxHp /= 100;
            Attack /= 100;
            Defense/= 100;
            Exp/= 100;
            BloodEnergy/= 100;
            base.Awake();
            MonsterSpineName.AttackName = "attack1";
            MonsterSpineName.HitName = "injured";
            MonsterSpineName.MoveName = "move";
            MonsterSpineName.DieName = "fail";
            monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;
            monsterSkeletonAnimation.AnimationState.Complete += Complete;
        }

        public void Complete(TrackEntry trackEntry)
        {
            monsterSkeletonAnimation.timeScale = 1f;
            if (trackEntry.Animation.Name == "skill1" || trackEntry.Animation.Name == "skill2" || trackEntry.Animation.Name == "skill3" )
            {
                IsSkill = false;
            }

            if (isSkill1)
            {
                IsSkill = true;
                isSkill1 = false;
                monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill2", false);
                KuiJiaSkillType = KuiJiaSkillType.HeiXuanFen;
                monsterSkeletonAnimation.timeScale = 1.2f;
            }
            else if (isSkill2)
            {
                IsSkill = true;
                isSkill2 = false;
                monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill2", false);
                KuiJiaSkillType = KuiJiaSkillType.HuDun;
                monsterSkeletonAnimation.timeScale = 1.2f;
            }
            else if (isSkill3)
            {
                IsSkill = true;
                isSkill3 = false;
                monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill3", false);
                skill3Position=GameController.S.gamePlayer.transform.position;
                GameController.S.CreateCircleAttack(skill3Position,1.2f);
                monsterSkeletonAnimation.timeScale = 1.5f;
            }
            else if (isAttack)
            {
                monsterSkeletonAnimation.timeScale = 1.5f;
                monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.AttackName, false);
            }
            else
            {
                monsterSkeletonAnimation.timeScale = 1.2f;
                monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.MoveName, false);
            }
        }

        public override void AddMonsterEquip()
        {
            MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Purple,
                20));
            MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,
                PlayerEquipConfig.EquipLevel.Purple, 20));
            MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,
                PlayerEquipConfig.EquipLevel.Purple, 20));
            MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,
                PlayerEquipConfig.EquipLevel.Purple, 20));
            MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe, PlayerEquipConfig.EquipLevel.Purple,
                20));
            MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,
                PlayerEquipConfig.EquipLevel.Purple, 20));
        }

        public override void Hurt(float damage, bool isCrit, DamageFrom damageFrom)
        {
            base.Hurt(damage, isCrit, damageFrom);
            if (!IsDead)
            {
                AudioController.S.PlayBatHit();
            }
        }

        public override void Skill()
        {
            // Implement the skill logic here
        }

        public override void Die()
        {

            //生成随机数
            int randomDelay = UnityEngine.Random.Range(0, 10);
            StartCoroutine(RandomDelayDie(randomDelay));
        }

        private IEnumerator RandomDelayDie(int delay)
        {
            for (int i = 0; i < delay; i++)
            {
                yield return null;
            }

            AudioController.S.PlaySnotDie();
            GeneralDie();
            GetEx();
            ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy, 1);
            //CreateBloodEnergy();
            CreateEquip();
            CreateProp();
            FightBGController.S.PlaySuccessAnim();
            GameController.S.StartCoroutine(DelayChuanSongMen());
        }

        IEnumerator DelayChuanSongMen()
        {
            yield return new WaitForSeconds(1f);
            var chuansongmen = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/ChuanSongMen"));
            chuansongmen.transform.position =
                new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        private void Start()
        {
            base.Start();
            size = 1.2f;
            AddMonsterEquip();
            AddMonsterProp();
        }

        private void OnDestroy()
        {
            monsterSkeletonAnimation.AnimationState.Event -= OnSpineEvent;
        }
        
        private IEnumerator JumpRoutine(float time, Vector2 target)
        {
            Vector2 startPos = rigidbody2D.position;
            Vector2 endPos   = target;

            float elapsed = 0f;
            while (elapsed < time)
            {
                elapsed += Time.deltaTime;
                float t = Mathf.Clamp01(elapsed / time);

                // 线性插值移动刚体
                Vector2 newPos = Vector2.Lerp(startPos, endPos, t);
                rigidbody2D.MovePosition(newPos);

                yield return null;
            }

            // 确保最后到达精确位置
            rigidbody2D.MovePosition(endPos);
            IsSkill=false;
        }
        
        public void CheckCollisionWithMonsters()
        {
            // 检测所有重叠的碰撞体
            List<Collider2D> results = new List<Collider2D>();
            ContactFilter2D filter = new ContactFilter2D();
            filter.NoFilter();
            filter.useTriggers = true;
    
            Skill3Collider2D.OverlapCollider(filter, results);
    
            // 找出所有怪物并处理
            foreach (Collider2D col in results)
            {
                if (col.gameObject == gameObject) continue;
        
                if (col.CompareTag("Player"))
                {
                    GameController.S.gamePlayer.PlayerHurt(Attack,true);
                }
            }
        }

        public void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
        {
            if (e.Data.Name == "damage" && trackEntry.Animation.Name == "attack1")
            {
                if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < size ||
                    Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < 1.2f)
                {
                    GameController.S.gamePlayer.PlayerHurt(Attack, true);
                }
            }

            if (e.Data.Name == "jump" && trackEntry.Animation.Name == "skill3")
            {
                monsterSkeletonAnimation.timeScale = 1f;
                StartCoroutine(JumpRoutine(0.5f, skill3Position));
            }

            if (e.Data.Name == "damage" && trackEntry.Animation.Name == "skill3")
            {
                CheckCollisionWithMonsters();
            }
            
            if (e.Data.Name == "damage" && trackEntry.Animation.Name == "skill2")
            {
                if (KuiJiaSkillType == KuiJiaSkillType.HeiXuanFen)
                {
                    float waveOffset = Random.Range(0, 30);
                    int bulletCount = 12;
                    float angleStep = 360f / bulletCount; 
            
                    for (int i = 0; i < bulletCount; i++)
                    {
                        var xieZiSkill1 = GameController.S.HeiXuanFenQueue.Dequeue();
                        float angle = i * angleStep + waveOffset;
                        float angleRad = angle * Mathf.Deg2Rad;
                        Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
                        xieZiSkill1.transform.position = transform.position;
                        xieZiSkill1.MoveDirection = direction;
                        xieZiSkill1.damage = Attack;
                        xieZiSkill1.gameObject.SetActive(true);
                    }
                }
                else if(KuiJiaSkillType == KuiJiaSkillType.HuDun)
                {
                    StartCoroutine(HudunSkill());
                }
            }
        }

        IEnumerator HudunSkill()
        {
            hudun.gameObject.SetActive(true);
            hudunAnimator.Play("NewSequenceAnim");
            Defense *= 2;
            yield return new WaitForSeconds(5f);
            Defense /= 2;
            hudun.gameObject.SetActive(false);
        }


        public override void AddMonsterProp()
        {
            MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment, 4), 10));
            MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang, 4), 10));

        }

        public void MonsterMove1()
        {
            Vector3 direction = GameController.S.gamePlayer.transform.position - transform.position;
            if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "move" || IsDash)
            {
                GetComponent<Rigidbody2D>().velocity = direction.normalized * Speed;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = direction.normalized * 0;
            }
        }

        public void SpriteFlipX1(bool isRight)
        {
            if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name != "move")
            {
                return;
            }

            float dis = Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position);
            if (dis < 0.2f)
            {
                //如果距离小于0.2f，则不翻转
                return;
            }

            //翻转精灵
            if (isRight)
            {
                if (GameController.S.gamePlayer.transform.position.x > transform.position.x)
                {
                    parent.transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    parent.transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            else
            {
                if (GameController.S.gamePlayer.transform.position.x > transform.position.x)
                {
                    parent.transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    parent.transform.localScale = new Vector3(1, 1, 1);
                }
            }

        }


        void Update()
        {
            if (IsDead) return;
            base.Update();
            if (!IsSkill)
            {
                currentSkill1Time += Time.deltaTime;
                currentSkill2Time += Time.deltaTime;
                currentSkill3Time += Time.deltaTime;
            }

            if (currentSkill1Time > skill1Time)
            {
                currentSkill1Time = 0;
                isSkill1 = true;
            }

            if (currentSkill2Time > skill2Time)
            {
                currentSkill2Time = 0;
                isSkill2 = true;
            }

            if (currentSkill3Time > skill3Time)
            {
                currentSkill3Time = 0;
                isSkill3 = true;
            }

            if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < size ||
                Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < 1.2f)
            {
                isAttack = true;
            }
            else
            {
                isAttack = false;
            }


            if (!IsDead)
            {
                MonsterMove1();
                SpriteFlipX1(false);
            }
        }


    }
}