using System.Collections.Generic;
using _01.Scripts.Interactable;
using _01.Scripts.Pooling;
using _01.Scripts.SO;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _01.Scripts.Trash
{
    public class Trash : InteractableAbstract
    {
        [SerializeField] private SpriteRenderer sr;
        [SerializeField] private List<Sprite> sprites;
        [SerializeField] private PoolItemSO particleItem;

        private void OnEnable()
        {
            sr.sprite = sprites[Random.Range(0, sprites.Count)];
        }

        public override void Interact(Player.Player owner)
        {
            base.Interact(owner);
            Player.TrashInventory.GetTrash(this);
        }

        public void Pickup()
        {
            PoolManager.Instance.Pop(transform.position, particleItem);
            Destroy(gameObject);
        }
    }
}