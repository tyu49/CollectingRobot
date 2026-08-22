using DG.Tweening;
using TMPro;

namespace _01.Scripts.StaticClass
{
    public static class TextMeshProTweenExtensions
    {
        public static Tween DOTypeText(
            this TextMeshProUGUI text,
            string target,
            float time,
            Ease type)
        {
            text.text = target;
            text.maxVisibleCharacters = 0;
            text.ForceMeshUpdate();

            return DOTween.To(
                    () => text.maxVisibleCharacters,
                    value => text.maxVisibleCharacters = value,
                    text.textInfo.characterCount,
                    time)
                .SetEase(type);
        }
    }
}