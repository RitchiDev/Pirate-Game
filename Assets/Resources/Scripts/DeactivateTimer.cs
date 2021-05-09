using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateTimer : MonoBehaviour
{
    [SerializeField] private float m_DeactivateTime = 3f;
    [SerializeField] private bool m_Destroy;

    private void OnDisable()
    {
        StopCoroutine(Deactivate());
    }

    private void OnEnable()
    {
        StartCoroutine(Deactivate());
    }

    private IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(m_DeactivateTime);

        if (m_Destroy)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
