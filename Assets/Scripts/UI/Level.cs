using UnityEngine;

public class Level : MonoBehaviour
{
        [SerializeField] private int _currentLevel = 1;

        public void Up()
        {
                _currentLevel++;
        }
        
        public int GetLevel()
        {
                return _currentLevel;
        }
}