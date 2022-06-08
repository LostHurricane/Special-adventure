using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class SpriteAnimator
    {
        

        private SpriteAnimatorConfig _config;
        private Dictionary<SpriteRenderer, Animation> _activeAnimation = new Dictionary<SpriteRenderer, Animation>();

        public void Execute(float deltaTime)
        {
            foreach (var animation in _activeAnimation)
            {
                animation.Value.Execute(deltaTime);
                if (animation.Value.Counter < animation.Value.Sprites.Count)
                {
                    animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
                }
            }
        }

        public SpriteAnimator(SpriteAnimatorConfig config)
        {
            _config = config;
        }

        public void StartAnimation( SpriteRenderer spriteRenderer, AnimStatePlayer track, bool loop, float speed)
        {
            if (_activeAnimation.TryGetValue(spriteRenderer, out var animation))
            {
                animation.Sleep = false;
                animation.Loop = loop;
                animation.Speed = speed;

                if (animation.Track != track)
                {
                    animation.Track = track;
                    animation.Sprites = _config.Sequences.Find(sequence => sequence.Track == track).Sprites;
                    animation.Counter = 0;
                }
            }

            else
            {
                _activeAnimation.Add(spriteRenderer, new Animation()
                {
                    Loop = loop,
                    Speed = speed,
                    Track = track,
                    Sprites = _config.Sequences.Find(sequence => sequence.Track == track).Sprites
                });

                Debug.Log("aded new animation");

            }
        }

        public void StopAnimation (SpriteRenderer spriteRenderer)
        {
            if (_activeAnimation.TryGetValue(spriteRenderer, out var animation))
            {
                animation.Sleep = true;
                
            }
        }

        public void Dispose()
        {
            _activeAnimation.Clear();
        }

        public void Dispose(SpriteRenderer spriteRenderer)
        {
            _activeAnimation.Remove(spriteRenderer);
        }


        private sealed class Animation
        {
            public AnimStatePlayer Track;
            public List<Sprite> Sprites;
            public bool Loop;
            public bool Sleep;
            public float Speed = 10;
            public float Counter;

            public void Execute(float deltaTime)
            {
                if (Sleep) return;
                Counter += deltaTime * Speed;
                if (Loop)
                {
                    while (Counter > Sprites.Count)
                    {
                        Counter -= Sprites.Count;
                    }
                }

                else if (Counter > Sprites.Count)
                {
                    Counter = Sprites.Count;
                    Sleep = true;
                }
            }
        }
    }
}
