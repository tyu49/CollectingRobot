using _01.Scripts.SO;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _01.Scripts.UI
{
    public class PartSelector : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Image image;
        [SerializeField] private float colorTime;
        [SerializeField] private int index;
        public PlayerPartSO MyData { get; private set; }
        public bool Made { get; private set; }
        private bool _selected;
        
        
        public void Initialize(PlayerPartSO data)
        {
            MyData = data;
            text.SetText(data.Name);
            GameManger.GameManger.Instance.Part.OnEquippedPart += Select;
        }

        public void Make()
        {
            Made = true;
        }

        public void Select(PartSelector data, int index)
        {
            if (index != this.index) return;
            if (data == this)
            {
                image.DOColor(new Color(0.429f, 0.9545284f, 1f, 0.5f), colorTime);
                Player.Player.Instance.PartManager.GetPart(MyData, index);
            }
            else
            {
                image.DOColor(new Color(1f, 1f, 1f, 0.5f), colorTime);
            }
        }
    }
}