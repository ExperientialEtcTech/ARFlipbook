using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPageController : MonoBehaviour
{
    [SerializeField]
    private GameObject crows;

    private void Awake()
    {
        StartCoroutine(SpawnCrows());
    }

    private void OnDestroy()
    {
        crows.SetActive(false);
    }

    private IEnumerator SpawnCrows()
    {
        yield return new WaitForSeconds(4f);
        crows.SetActive(true);
    }
}
