using System.Collections;
using UnityEngine;

public class DamageArea: MonoBehaviour
{
    [SerializeField] Collider2D areaCollider = null; 
    [SerializeField] GameObject explosionEffect = null;

    //Public References
    public Collider2D AreaCollider => areaCollider; 
    public GameObject ExplosionEffect => explosionEffect;

    //Cached References
    public float coolDownDamageArea = 2f;
    public float areaDamage = 2f;
    public float explosionOffSetY = 1f;
    public bool areaSlimeActivated = true;
    public bool abovePlayer = true;


    // Start is called before the first frame update
    private void Update()
    {
        if (abovePlayer) transform.position = GameManager.Player.transform.position;
    }


}
