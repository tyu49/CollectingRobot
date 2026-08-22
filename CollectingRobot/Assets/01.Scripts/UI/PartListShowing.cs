using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _01.Scripts.UI
{
    public class PartListShowing : MonoBehaviour
    {
        [SerializeField] private List<CanvasGroup> options;
        [SerializeField] private CanvasGroup group;
        [SerializeField] private float appearingDelay;
        [SerializeField] private float appearingTime;

        private WaitForSeconds AppearingDelay => new WaitForSeconds(appearingDelay);
        private bool _isOn;
        public void ShowList() => StartCoroutine(ShowListCo());
        public void DisableList() => StartCoroutine(DisableListCo());

        private IEnumerator DisableListCo()
        {
            _isOn = false;
            group.blocksRaycasts = false;
            group.interactable = false;
            for (int i = options.Count - 1; i >= 0; i--)
            {
                if(_isOn)
                    yield break;
                options[i].DOFade(0, appearingTime);
                yield return AppearingDelay;
            }
            if(_isOn)
                yield break;
        }

        private IEnumerator ShowListCo()
        {
            _isOn = true;
            foreach (var image in options)
            {
                if (!_isOn)
                    yield break;
                image.DOFade(0.7f, appearingTime);
                yield return AppearingDelay;
            }
            if(!_isOn)
                yield break;
            group.blocksRaycasts = true;
            group.interactable = true;
        }   
    }
}