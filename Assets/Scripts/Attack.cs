using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private static Attack _instance;
    public float AttackDamage = 5f;
    public static Attack Instance 
    { get { return _instance; } }

    // GameManager �ʱ�ȭ
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject); // �̹� �ν��Ͻ��� �����ϸ� ���� ������ ���� �ı�
            return;
        }
        _instance = this;
    }

    private void Update()
    {
        AttackDamage += Character.Instance.AttackPower;
    }
}
