using System;
using _01.Scripts.SO;
using UnityEngine;

namespace _01.Scripts.Trash
{
    public class TrashPointMaker : MonoBehaviour
    {
        [SerializeField] private TrashCreatListSO data;
        [SerializeField] private int[] button;

        private void OnValidate()
        {
            data.CreatPoint(transform.position);
            button = Array.Empty<int>();
        }
    }
}