using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    private Transform transform;
    private float shootCoolDown = 0;       //射击冷却
    Weapons w;

    // Use this for initialization
    void Start () {
        transform = gameObject.GetComponent<Transform>();
        w = gameObject.GetComponent<Weapons>();
        w.ChooseWeapon();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        /**************控制移动****************/
        if (Input.GetKey(KeyCode.W) == true)
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.A) == true)
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.D) == true)
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.S) == true)
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.Self);

        /**************控制旋转***************/
        Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
        obj.z = obj.y;
        obj.y = 0;
        Vector3 myMouse = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
        Vector3 direction = myMouse - obj;
        //Debug.Log(direction);
        direction = direction.normalized;
        transform.forward = direction;
        //Debug.Log(myMouse);
        //Debug.Log(obj);

        /****************武器**************/
        shootCoolDown++;
        if (Input.GetKey(KeyCode.Mouse0) && shootCoolDown >= w.bulletSpeed)
        {
            Debug.Log("shoot");
            Debug.Log(w.bulletDamege);
            Debug.Log(w.bulletSpeed);
            Debug.Log(w.bulletNumber);
            shootCoolDown = 0;
            w.Shoot();
        }
    }
}
