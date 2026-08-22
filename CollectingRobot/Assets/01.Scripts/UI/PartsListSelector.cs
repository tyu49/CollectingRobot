using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _01.Scripts.UI
{
    public class PartsListSelector : MonoBehaviour
    {
        [SerializeField] private Image headImg;
        [SerializeField] private Image bodyImg;
        [SerializeField] private Image tireImg;
        [SerializeField] private PartListShowing head;
        [SerializeField] private PartListShowing body;
        [SerializeField] private PartListShowing tire;
        [SerializeField] private float colorChangeDelay;
        public void SelectOption(int type)
        {
            switch (type)
            {
                case 0:
                    headImg.DOColor(new Color(0.6320754f, 1f, 0.9338118f, .5f), colorChangeDelay).SetEase(Ease.OutQuad);
                    bodyImg.DOColor(new Color(1f, 1f, 1f, 0.5f), colorChangeDelay).SetEase(Ease.OutQuad);
                    tireImg.DOColor(new Color(1f, 1f, 1f, 0.5f), colorChangeDelay).SetEase(Ease.OutQuad);
                    head.ShowList();
                    body.DisableList();
                    tire.DisableList();
                    break;
                case 1:
                    bodyImg.DOColor(new Color(0.6320754f, 1f, 0.9338118f, .5f), colorChangeDelay).SetEase(Ease.OutQuad);
                    headImg.DOColor(new Color(1f, 1f, 1f, 0.5f), colorChangeDelay).SetEase(Ease.OutQuad);
                    tireImg.DOColor(new Color(1f, 1f, 1f, 0.5f), colorChangeDelay).SetEase(Ease.OutQuad);
                    body.ShowList();
                    head.DisableList();
                    tire.DisableList();
                    break;
                case 2:
                    tireImg.DOColor(new Color(0.6320754f, 1f, 0.9338118f, .5f), colorChangeDelay).SetEase(Ease.OutQuad);
                    bodyImg.DOColor(new Color(1f, 1f, 1f, 0.5f), colorChangeDelay).SetEase(Ease.OutQuad);
                    headImg.DOColor(new Color(1f, 1f, 1f, 0.5f), colorChangeDelay).SetEase(Ease.OutQuad);
                    tire.ShowList();
                    body.DisableList();
                    head.DisableList();
                    break;
            }
        }
    }
}