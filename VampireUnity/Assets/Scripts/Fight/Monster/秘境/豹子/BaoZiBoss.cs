using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Equip;
using Spine;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Fight.Monster.秘境.豹子
{
    public enum BaoZiSkillType
    {
        None,
        ChuChang,
        LvXuanFen,
        LvZhuiZong
    }
    public class BaoZiBoss:MonsterBase
    {
        public BaoZiBoss() : base(MonsterType.Boss, "BaoZiBoss", 1, MJConfig.BossMonsterAttribute.hp*MJConfig.MonsterAttributeDic[MJLevel.Blue].hp, 1.3f, MJConfig.BossMonsterAttribute.atk*MJConfig.MonsterAttributeDic[MJLevel.Blue].atk, MJConfig.BossMonsterAttribute.def*MJConfig.MonsterAttributeDic[MJLevel.Blue].def, MJConfig.BossMonsterAttribute.ex*MJConfig.PlayerAttributeDic[MJLevel.Blue].ex, MJConfig.BossMonsterAttribute.linhun*MJConfig.PlayerAttributeDic[MJLevel.Blue].linhun, 0)
        {
        }
        
        public Transform attackTrans;
        private float skill1Time = 13;
        private float skill2Time = 8;
        private float skill3Time = 11;
        private float currentSkill1Time = 2;
        private float currentSkill2Time = 3;
        private float currentSkill3Time = 4;
        [NonSerialized] public BaoZiSkillType BaoZiSkillType = BaoZiSkillType.None;
        
        
        
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
                monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill1", false);
                monsterSkeletonAnimation.timeScale = 1.2f;
                BaoZiSkillType = BaoZiSkillType.LvXuanFen;
            }
            else if (isSkill2)
            {
                IsSkill = true;
                isSkill2 = false;
                monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill2", false);
                monsterSkeletonAnimation.timeScale = 1.5f;
            }
            else if (isSkill3)
            {
                IsSkill = true;
                isSkill3 = false;
                monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill1", false);
                BaoZiSkillType = BaoZiSkillType.LvZhuiZong;
                monsterSkeletonAnimation.timeScale = 1.2f;
            }
            else if (isAttack)
            {
                monsterSkeletonAnimation.timeScale = 2f;
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
            CreateBloodEnergy();
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
            size = 2.5f;
            AddMonsterEquip();
            AddMonsterProp();
        }

        private void OnDestroy()
        {
            monsterSkeletonAnimation.AnimationState.Event -= OnSpineEvent;
        }

        IEnumerator LvXuanFenSkill(int count,float dis)
        {
            List<Vector2> posList = new List<Vector2>();
            for (int i = 0; i < count; i++)
            {
                float randomx=Random.Range(0, dis);
                float randomy=Random.Range(0, dis);
                Vector2 pos=new Vector2(randomx,randomy);
                posList.Add(pos);
            }
            foreach (var item in posList)
            {
                GameController.S.CreateCircleAttack(item,0.8f);
            }
            yield return  new WaitForSeconds(0.5f);
            foreach (var item in posList)
            {
                var LvXuanFen = GameController.S.LvXuanFenQueue.Dequeue();
                LvXuanFen.damage = Attack;
                LvXuanFen.transform.position = item;
                LvXuanFen.gameObject.SetActive(true);            }
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
            
            if (e.Data.Name == "damage" && trackEntry.Animation.Name == "skill1")
            {
                switch (BaoZiSkillType)
                {
                    case BaoZiSkillType.LvXuanFen:
                        StartCoroutine(LvXuanFenSkill(1, 6f));
                        break;
                    case BaoZiSkillType.LvZhuiZong:
                        float waveOffset = Random.Range(0, 30);
                        int bulletCount = 12;
                        float angleStep = 360f / bulletCount; 
            
                        for (int i = 0; i < bulletCount; i++)
                        {
                            var xieZiSkill1 = GameController.S.LvZhuiZongQueue.Dequeue();
                            float angle = i * angleStep + waveOffset;
                            float angleRad = angle * Mathf.Deg2Rad;
                            Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
                            xieZiSkill1.transform.position = transform.position;
                            xieZiSkill1.MoveDirection = direction;
                            xieZiSkill1.damage = Attack;
                            xieZiSkill1.gameObject.SetActive(true);
                        }
                        break;
                }
            }
            
            if (e.Data.Name == "damage" && trackEntry.Animation.Name == "skill2")
            {
                Vector2 baseDir = (GameController.S.gamePlayer.transform.position-transform.position).normalized;

                // 两个偏移角度：+10° 和 -10°
                Vector2[] dirs =
                {
                    Quaternion.AngleAxis( 10f, Vector3.forward) * baseDir,
                    Quaternion.AngleAxis( 0f, Vector3.forward) * baseDir,
                    Quaternion.AngleAxis(-10f, Vector3.forward) * baseDir
                };

                // 连发两颗
                foreach (Vector2 dir in dirs)
                {
                    var bullet = GameController.S.BaoZiSkill2Queue.Dequeue();
                    bullet.transform.position = transform.position;
                    bullet.direction = dir;
                    bullet.damage = Attack;
                    bullet.gameObject.SetActive(true);
                }
            }
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