using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Utage
{

    public class KaguyaUguiOption : UguiView
    {
        public AdvEngine Engine { get { return this.engine ?? (this.engine = GetComponent<AdvEngine>()); } }
        [SerializeField]
        protected AdvEngine engine;

        /// <summary>タイトル画面</summary>
        public UtageUguiTitle title;

        /// <summary>コンフィグ画面</summary>
        public UtageUguiConfig config;

        /// <summary>セーブロード画面</summary>
        public UtageUguiSaveLoad saveLoad;

        /// <summary>バックログ画面</summary>
        public KaguyaUguiBackLog backlog;

        public virtual bool IsInit { get { return isInit; } set { isInit = value; } }
        protected bool isInit = false;

        protected virtual void Update()
        {
            //右クリックで戻る
            if (isInit && InputUtil.IsMouseRightButtonDown())
            {
                Back();
            }
        }

        public virtual void OnTapSave()
        {
            Close();
            saveLoad.OpenSave(this);
        }

        public virtual void OnTapConfig()
        {
            Close();
            config.Open(this);
        }

        public virtual void OnTapLoad()
        {
            Close();
            saveLoad.OpenLoad(this);
        }

        public virtual void OnTapBackLog()
        {
            Close();
            backlog.Open(this);
        }

        public virtual void OnTapBackTitle()
        {
            Engine.EndScenario();
            this.Close();
            title.Open();
        }

    }

}
