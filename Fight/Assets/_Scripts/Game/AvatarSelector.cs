using UnityEngine;

namespace KODUA
{
    public class AvatarSelector : MonoBehaviour
    {
        [SerializeField] GameObject[] _avatarGameObjects;
        int _currentAvatarID = 0;
        public GameObject CurrentAvatarGameObject { get => _avatarGameObjects[_currentAvatarID]; }
        public Animator CurrentAnimator { get => CurrentAvatarGameObject.GetComponent<Animator>(); }
        public FaceSprite CurrentFaceSpriteRenderer { get => CurrentAvatarGameObject.GetComponent<FaceSprite>(); }

        [SerializeField] FightManager _fightManager;

        public void ScrollRight()
        {
            _avatarGameObjects[_currentAvatarID].SetActive(false);
            _currentAvatarID++;
            if (_currentAvatarID >= _avatarGameObjects.Length)
            {
                _currentAvatarID = 0;
            }
            _avatarGameObjects[_currentAvatarID].SetActive(true);
            print("Scroll Right");
            DisplayCurrent();
        }

        public void ScrollLeft()
        {
            _avatarGameObjects[_currentAvatarID].SetActive(false);
            _currentAvatarID--;
            if(_currentAvatarID < 0)
            {
                _currentAvatarID = _avatarGameObjects.Length - 1;
            }
            print("Scroll Left");
            _avatarGameObjects[_currentAvatarID].SetActive(true);
            DisplayCurrent();
        }
        void DisplayCurrent()
        {
            
            _fightManager.SetAnimator(CurrentAnimator);
        }


        private Vector2 startPos;
        private float minSwipeDistance = 50.0f;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                Vector2 swipe = (Vector2) Input.mousePosition - startPos;
                if (swipe.magnitude > minSwipeDistance)
                {
                    if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
                    {
                        if (swipe.x > 0)
                        {
                            ScrollRight();
                        }
                        else
                        {
                            ScrollLeft();
                        }
                    }
                }
            }
        }
    }

}