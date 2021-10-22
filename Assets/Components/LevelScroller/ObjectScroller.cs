using UnityEngine;

namespace LevelScroll
{
    public class ObjectScroller : MonoBehaviour
    {
        LevelScroller levelScroller;
        bool isInit = false;

        float Speed { get => levelScroller.Speed; }
        public void Inject(LevelScroller levelScroller)
        {
            isInit = true;
            this.levelScroller = levelScroller;
        }
        void Update()
        {
            if (isInit)
            {
                ScrollObject();
                if (IsOutOfScreen())
                    Destroy(gameObject);
            }
        }

        void ScrollObject()
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;
        }

        bool IsOutOfScreen()
        {
            return transform.position.x < -Helper.GetScreenHalfWidthUnit();
        }
    }
}
