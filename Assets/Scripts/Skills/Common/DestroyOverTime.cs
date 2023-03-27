using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    
    private void Start()
    {
        Invoke(nameof(Destroy), _lifeTime);
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}