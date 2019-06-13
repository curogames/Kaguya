using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Utage
{

    public class KaguyaUguiBackLog : UguiView
    {

        public enum BacklogType
        {
            MessageWindow,      //メッセージウィンドウ
            FullScreenText,     //全画面テキスト
        };

        BacklogType Type { get { return type; } }
        [SerializeField]
        BacklogType type = BacklogType.MessageWindow;

        /// <summary>ADVエンジン</summary>
        [SerializeField]
        protected AdvEngine engine;

        /// <summary>選択肢のリストビュー</summary>
        public UguiListView ListView
        {
            get { return listView; }
        }
        [SerializeField]
        UguiListView listView = null;

        /// <summary>全画面テキスト</summary>
        public UguiNovelText FullScreenLogText
        {
            get { return fullScreenLogText; }
        }
        [SerializeField]
        UguiNovelText fullScreenLogText = null;

        //バックログデータへのインターフェース
        protected AdvBacklogManager BacklogManager { get { return engine.BacklogManager; } }

        //スクロール最下段でマウスホイール入力で閉じる入力するか
        public bool isCloseScrollWheelDown = false;


        /// <summary>開いているか</summary>
        public virtual bool IsOpen { get { return this.gameObject.activeSelf; } }

        /// <summary>
        /// 開く
        /// </summary>
        public override void Open(UguiView prevView)
        {
            switch (Type)
            {
                case BacklogType.FullScreenText:
                    InitialzeAsFullScreenText();
                    break;
                case BacklogType.MessageWindow:
                default:
                    InitialzeAsMessageWindow();
                    break;
            }

            if (this.status == Status.Closing)
            {
                CancelClosing();
            }
            this.status = Status.Opening;
            this.prevView = prevView;
            this.gameObject.SetActive(true);
            ChangeBgm();
            this.gameObject.SendMessage("OnOpen", SendMessageOptions.DontRequireReceiver);
            onOpen.Invoke();
            StartCoroutine(CoOpening());
        }


        protected virtual void InitialzeAsMessageWindow()
        {
            ListView.CreateItems(BacklogManager.Backlogs.Count, CallbackCreateItem);
        }

        protected virtual void InitialzeAsFullScreenText()
        {
            ListView.CreateItems(BacklogManager.Backlogs.Count, CallbackCreateItem);
        }

        /// <summary>
        /// リストビューのアイテムが作られたときに呼ばれるコールバック
        /// </summary>
        /// <param name="go">作られたアイテムのGameObject</param>
        /// <param name="index">アイテムのインデックス</param>
        protected virtual void CallbackCreateItem(GameObject go, int index)
        {
            AdvBacklog data = BacklogManager.Backlogs[BacklogManager.Backlogs.Count - index - 1];
            AdvUguiBacklog backlog = go.GetComponent<AdvUguiBacklog>();
            backlog.Init(data);
        }

        // 更新
        protected virtual void Update()
        {
            //閉じる入力された
            if (InputUtil.IsMouseRightButtonDown() || IsInputBottomEndScrollWheelDown())
            {
                Back();
            }
        }

        //スクロール最下段でマウスホイール入力で閉じる入力するチェック
        protected virtual bool IsInputBottomEndScrollWheelDown()
        {
            if (isCloseScrollWheelDown && InputUtil.IsInputScrollWheelDown())
            {
                Scrollbar scrollBar = ListView.ScrollRect.verticalScrollbar;
                if (scrollBar)
                {
                    return scrollBar.value <= 0;
                }
            }
            return false;
        }


    }

}
