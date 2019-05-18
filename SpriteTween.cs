using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Syy.Logics.UI
{
    [RequireComponent(typeof(Image))]
    public class SpriteTween : MonoBehaviour
    {
        [SerializeField]
        Sprite[] _sprites = null;

        [SerializeField]
        float _duration = 0.2f;

        Image _image;
        int _index;
        Tween _tween;

        void Awake()
        {
            _image = GetComponent<Image>();
            if (_image != null && _sprites.Length != 0)
            {
                _tween = DOVirtual.DelayedCall(_duration, OnAction);
            }
        }

        void OnAction()
        {
            var length = _sprites.Length;
            if (_image != null && length != 0)
            {
                _index += 1;
                if (_index == length)
                {
                    _index = 0;
                }
                _image.sprite = _sprites[_index];
                _tween = DOVirtual.DelayedCall(_duration, OnAction);
            }
        }

        void OnDestroy()
        {
            _tween?.Kill();
        }
    }
}
