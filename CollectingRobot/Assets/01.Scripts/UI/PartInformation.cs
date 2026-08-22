using System;
using _01.Scripts.StaticClass;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _01.Scripts.UI
{
    public class PartInformation : MonoBehaviour
    {
        [SerializeField] private RectTransform upperBorder;
        [SerializeField] private RectTransform underBorder;
        [SerializeField] private CanvasGroup group;
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI main;
        [SerializeField] private float showingDelay;
        [SerializeField] private float typeTime;

        private void Start()
        {
            GameManger.GameManger.Instance.OnBaseCanvasOn += StartAnimation;
        }

        private void OnDestroy()
        {
            GameManger.GameManger.Instance.OnBaseCanvasOn -= StartAnimation;
        }

        private void StartAnimation()
        {
            upperBorder.sizeDelta = new Vector2(0f, 25f);
            underBorder.sizeDelta = new Vector2(15f, 0f);
            upperBorder.DOSizeDelta(new Vector2(500f, 25f), showingDelay).SetEase(Ease.OutExpo);
            underBorder.DOSizeDelta(new Vector2(15f,615f), showingDelay).SetEase(Ease.OutExpo);
            title.SetText(string.Empty);
            main.SetText(string.Empty);
            title.DOTypeText("None", typeTime,Ease.OutQuad);
            main.DOTypeText("대충 아무말이나 적는 중인데 이거 이렇게 해도 되는거 맞겠죠? 그렇겠죠?", typeTime,Ease.OutQuad);
        }
        
        
        
    }
}
