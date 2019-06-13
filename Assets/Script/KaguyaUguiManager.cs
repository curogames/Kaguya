using UnityEngine;
using UnityEngine.EventSystems;

namespace Utage
{

    [AddComponentMenu("Utage/ADV/UiManager")]
    public class KaguyaUguiManager : AdvUguiManager
    {
        public AudioClip sendcharse;
        private AudioSource sendchar;
        private int beforecharlength;

        void Awake()
        {
            sendchar = this.GetComponent<AudioSource>();
        }

        protected override void Update()
        {
            //読み進みなどの入力
            bool IsInput = (Engine.Config.IsMouseWheelSendMessage && InputUtil.IsInputScrollWheelDown())
                                || InputUtil.IsInputKeyboadReturnDown();
            switch (Status)
            {
                case UiStatus.Backlog:
                    break;
                case UiStatus.HideMessageWindow:    //メッセージウィンドウが非表示
                                                    //右クリック
                    if (InputUtil.IsMouseRightButtonDown())
                    {   //通常画面に復帰
                        Status = UiStatus.Default;
                    }
                    else if (!disableMouseWheelBackLog && InputUtil.IsInputScrollWheelUp())
                    {
                        //バックログ開く
                        Status = UiStatus.Backlog;
                    }
                    break;
                case UiStatus.Default:
                    if (IsShowingMessageWindow)
                    {
                        //テキストの更新
                        Engine.Page.UpdateText();
                        if (Engine.Page.Status == AdvPage.PageStatus.SendChar && beforecharlength != Engine.Page.CurrentTextLength)
                        {
                            sendchar.Stop();
                            sendchar.PlayOneShot(sendcharse);
                            beforecharlength = Engine.Page.CurrentTextLength;
                        }

                    }
                    if (IsShowingMessageWindow || Engine.SelectionManager.IsWaitInput)
                    {   //入力待ち
                        if (InputUtil.IsMouseRightButtonDown())
                        {   //右クリックでウィンドウ閉じる
                            Status = UiStatus.HideMessageWindow;
                        }
                        else if (!disableMouseWheelBackLog && InputUtil.IsInputScrollWheelUp())
                        {   //バックログ開く
                            Status = UiStatus.Backlog;
                        }
                        else
                        {
                            if (IsInput)
                            {
                                //メッセージ送り
                                Engine.Page.InputSendMessage();
                                base.IsInputTrig = true;
                            }
                        }
                    }
                    else
                    {
                        if (IsInput)
                        {
                            base.IsInputTrig = false;
                        }
                    }
                    break;
            }
        }

        public void EnableSendCharSE()
        {
            sendchar.enabled = true;
        }

        public void DisableSendCharSE()
        {
            sendchar.enabled = false;
        }



    }

}
