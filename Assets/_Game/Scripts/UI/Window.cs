using System;
using GeneralUtils.UI;

namespace _Game.Scripts.UI {
    public class Window : UIElement {
        protected override void PerformShow(Action onDone = null) {
            GameUIController.Instance.ShowWindow(this);
            base.PerformShow(onDone);
        }

        protected override void PerformHide(Action onDone = null) {
            GameUIController.Instance.HideWindow(this);
            base.PerformHide(onDone);
        }
    }
}