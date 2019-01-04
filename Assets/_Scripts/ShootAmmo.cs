using UnityEngine;

public class ShootAmmo : MonoBehaviour
{
    public Rigidbody ammo;
    public float speed = 20.0f;
    public Vector3 ammo_offset;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        if(Input.GetButtonDown("Fire1"))
        {
            //create new instance of ammo
            //TODO: launch from an offset that looks natural
            var obj = (Rigidbody)Instantiate(this.ammo, transform.position + ammo_offset, transform.rotation);
            obj.velocity = (transform.forward + transform.up / 2) * speed;
        }
    }
}
