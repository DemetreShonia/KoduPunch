using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KODUA
{
    public class FaceSprite : MonoBehaviour
    {
        [SerializeField] SpriteRenderer _faceSpriteRenderer;
        public SpriteRenderer GetSpriteRenderer() => _faceSpriteRenderer;
    } 
}
