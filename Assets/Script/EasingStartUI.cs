using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EasingStartUI : MonoBehaviour
{
    public float time = 1;
    public Vector3 endSize;
    public Ease ease;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(endSize,time).SetEase(ease);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
