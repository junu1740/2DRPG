using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private static Attack _instance;
    public float AttackDamage = 5f;
    public static Attack Instance 
    { get { return _instance; } }

    // GameManager 초기화
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject); // 이미 인스턴스가 존재하면 새로 생성된 것을 파괴
            return;
        }
        _instance = this;
    }

    private void Update()
    {
        AttackDamage += Character.Instance.AttackPower;
    }
}
