using System;
using System.Collections.Generic;
using _01.Scripts.SO;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _01.Scripts.Trash
{
    public class TrashManager : MonoBehaviour
    {
        [SerializeField] private TrashCreatListSO data;
        [SerializeField] private GameObject trashPrefab;
        private void Start()
        {
            List<Vector3> points = new List<Vector3>(data.Points);
            for (int i = 0; i < data.Count; i++)
            {
                int ran = Random.Range(0, points.Count);
                GameObject trash = Instantiate(trashPrefab, points[ran], Quaternion.identity);
                trash.SetActive(true);
                points.RemoveAt(ran);
            }
        }
    }
}