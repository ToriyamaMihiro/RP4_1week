using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasingRoop : MonoBehaviour
{
    public float time = 0.5f;
    public Vector3 size = new Vector3(1.5f, 1.5f, 1);
    public Ease ease;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(size, time).SetEase(ease).SetLoops(-1, LoopType.Yoyo).SetLink(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
