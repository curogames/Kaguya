using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;
using UnityEngine;


namespace Utage {

    public class KaguyaUguiMessageWindow : AdvUguiMessageWindow
    {

        public GameObject nameWindow;

        public override void OnTextChanged(AdvMessageWindow window)
        {
            //パラメーターを反映させるために、一度クリアさせてからもう一度設定
            if (text)
            {
                text.text = "";
                text.text = window.Text.OriginalText;
                //テキストの長さを設定
                text.LengthOfView = window.TextLength;
            }

            if (nameText)
            {
                nameText.text = "";
                nameText.text = window.NameText;
                if (nameText.text == "" ){
                    nameWindow.SetActive(false);
                }
                else
                {
                    nameWindow.SetActive(true);
                }
            }

            switch (readColorMode)
            {
                case ReadColorMode.Change:
                    text.color = Engine.Page.CheckReadPage() ? readColor : defaultTextColor;
                    if (nameText)
                    {
                        nameText.color = Engine.Page.CheckReadPage() ? readColor : defaultNameTextColor;
                    }
                    break;
                case ReadColorMode.None:
                default:
                    break;
            }

            LinkIcon();
        }


    }

}