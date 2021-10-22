using System;
using UnityEngine;

namespace Collision
{
    public class CollisionTwoSpriteRenderer : MonoBehaviour
    {
        struct Segments
        {
            public float p1;
            public float p2;
        }

        SpriteRenderer first;
        SpriteRenderer second;

        bool isInit;

        public event Action EventCollisionDetected;
        public void Inject(SpriteRenderer first, SpriteRenderer second)
        {
            this.first = first;
            this.second = second;
            isInit = true;
        }

        private void Update()
        {
            if (isInit)
            {
                if (IsCollision())
                    CollisionDetected();
            }
        }

        void CollisionDetected()
        {
            EventCollisionDetected?.Invoke();
        }

        bool IsCollision()
        {
            float HorizontalIntersectionLength = SegmentsIntersectionLength(GetHorizontalSegment(first), GetHorizontalSegment(second));
            float VerticalIntersectionLength = SegmentsIntersectionLength(GetVerticalSegment(first), GetVerticalSegment(second));

            float sintersectionArea = HorizontalIntersectionLength * VerticalIntersectionLength;

            return sintersectionArea != 0f;
        }

        float SegmentsIntersectionLength(Segments s1, Segments s2)
        {
            float maxP1 = Math.Max(s1.p1, s2.p1);
            float minP2 = Math.Min(s1.p2, s2.p2);

            return Math.Max(minP2 - maxP1, 0);
        }

        Segments GetHorizontalSegment(SpriteRenderer sr)
        {
            return new Segments() { p1 = LeftSidePos(sr), p2 = RightSidePos(sr) };
        }
        Segments GetVerticalSegment(SpriteRenderer sr)
        {
            return new Segments() { p1 = BottomSidePos(sr), p2 = TopSidePos(sr) };
        }

        float TopSidePos(SpriteRenderer sr)
        {
            return sr.transform.position.y + sr.size.y / 2f;
        }
        float BottomSidePos(SpriteRenderer sr)
        {
            return sr.transform.position.y - sr.size.y / 2f;
        }

        float RightSidePos(SpriteRenderer sr)
        {
            return sr.transform.position.x + sr.size.x / 2f;
        }

        float LeftSidePos(SpriteRenderer sr)
        {
            return sr.transform.position.x - sr.size.x / 2f;
        }
    }
}
