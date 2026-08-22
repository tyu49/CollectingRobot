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
        [SerializeField] private TextMeshProUGUI button;
        [SerializeField] private float showingDelay;
        [SerializeField] private float typeTime;

        private int _currentState; //0 = 제작, 1 = 장착, 2 = 해제
        private PartSelector _currentData;
        
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
            title.DOTypeText("None", typeTime,Ease.OutQuad);
            main.DOTypeText("None", typeTime,Ease.OutQuad);
            button.DOTypeText("Error", typeTime, Ease.OutQuad);
            
        }

        public void SetData(PartSelector data)
        {
            _currentData = data;
            title.DOTypeText(data.MyData.Name, typeTime,Ease.OutQuad);
            main.DOTypeText(data.MyData.Description, typeTime,Ease.OutQuad);
            switch (_currentState)
            {
                case 0:
                    button.DOTypeText("제작", typeTime, Ease.OutQuad);
                    break;
                case 1:
                    button.DOTypeText("장착", typeTime, Ease.OutQuad);
                    break;
                case 2:
                    button.DOTypeText("해제", typeTime, Ease.OutQuad);
                    break;
            }
        }

        public void Button()
        {
            switch (_currentState)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }
        
        
        
    }
}
