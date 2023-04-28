using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPageController : MonoBehaviour
{
    [SerializeField]
    private GameObject tree;

    private void Awake()
    {
        StartCoroutine(SpawnTree());
    }

    private void OnDestroy()
    {
        tree.SetActive(false);
    }

    private IEnumerator SpawnTree()
    {
        yield return new WaitForSeconds(2f);
        tree.SetActive(true);
    }
}
