using System;
using Config;
using Unity.VisualScripting;
using UnityEngine;

namespace Prop.BaoShi
{
    public class BaoShi:PropBase
    {
        public BaoShi() : base( new PropTable()){}
        public ParticleSystem whiteParticle;
        public ParticleSystem greenParticle;
        public ParticleSystem blueParticle;
        public ParticleSystem purpleParticle;
        public ParticleSystem orangeParticle;
        public ParticleSystem redParticle;
        public SpriteRenderer spriteRenderer;

        private void Awake()
        {
            //.EquipName = "BlueChiBang";
            propTables.Count = 1;
            propTables.Desc = null;
           // propTables.PropType = PropConfig.PropType.ChiBang;
           // propTables.Quality = 3;
        }

        public void HideParticles()
        {
            whiteParticle.gameObject.SetActive(false);
            greenParticle.gameObject.SetActive(false);
            blueParticle.gameObject.SetActive(false);
            purpleParticle.gameObject.SetActive(false);
            orangeParticle.gameObject.SetActive(false);
            redParticle.gameObject.SetActive(false);
        }

        public void OnEnable()
        {
            base.OnEnable();
            HideParticles();
            BaoShiInfo baoShiInfo = new BaoShiInfo();
            baoShiInfo.BaoShiType=(BaoShiType)(propTables.PropType-5);
            baoShiInfo.Quality=propTables.Quality;
            spriteRenderer.sprite = ResourcesConfig.GetBaoShiSprite(baoShiInfo);
            switch (baoShiInfo.Quality)
            {
                case 1:
                    whiteParticle.gameObject.SetActive(true);
                    whiteParticle.Play();
                    break;
                case 2:
                    greenParticle.gameObject.SetActive(true);
                    greenParticle.Play();
                    break;
                case 3:
                    blueParticle.gameObject.SetActive(true);
                    blueParticle.Play();
                    break;
                case 4:
                    purpleParticle.gameObject.SetActive(true);
                    purpleParticle.Play();
                    break;
                case 5:
                    orangeParticle.gameObject.SetActive(true);
                    orangeParticle.Play();
                    break;
                case 6:
                    redParticle.gameObject.SetActive(true);
                    redParticle.Play();
                    break;
            }
        }
    }
}