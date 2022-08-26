using UnityEngine;

namespace DefaultNamespace
{
    public class DifficultLevel 
    {
        public int DifficultHeight => _difficultHeight;
        public float PlatformsStep => _platformsStep;
        
        private int _difficultHeight;
        private float _platformsStep;
        


        public DifficultLevel(int height, float platforms)
        {
            _difficultHeight = height;
            _platformsStep = platforms;
        }
    }
}