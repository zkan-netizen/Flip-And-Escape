using DG.Tweening;
using UnityEngine;

public class GoldMove : MonoBehaviour
{
    private Vector3 _originalScale;

    private Vector3 _scaleTo;

    void Start()
    {
        if (this.gameObject != null)
        {
            _originalScale = transform.localScale;
            _scaleTo = _originalScale * 1.25f;
            transform
                .DOScale(_scaleTo, 0.6f)
                .SetEase(Ease.InOutSine)
                .SetLoops(-1, LoopType.Yoyo);
        }
    }
}
