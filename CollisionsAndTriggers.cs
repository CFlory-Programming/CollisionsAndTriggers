using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EasyElements
{
    public class NewColorChanger : MonoBehaviour
    {
        [SerializeField]
        Color[] colors;
        int colorIndex = 0;
        int lastTime = 0;
        public Vector3 rotationSpeed;
        public Space rotateRelativeTo;
        private Quaternion initialRotation;
        private Renderer rend;
        private void OnTriggerEnter(Collider other)
        {
            Renderer r =other.gameObject.GetComponent<Renderer>();
            if (r != null )
                r.material.color = colors[colorIndex % colors.Length];
        }
        private void Awake()
        {
            initialRotation = transform.localRotation;
            rend = GetComponent<Renderer>();
            Color c = colors[colorIndex];
            c.a = 0.25f;
            rend.material.color = c;
        }
        void FixedUpdate()
        {
            transform.Rotate(rotationSpeed * Time.fixedDeltaTime, rotateRelativeTo);
            if (lastTime != (int)Time.time)
            {
                lastTime = (int)Time.time;
                if ((int)Time.time % 5 == 0)
                {
                    Color c = colors[++colorIndex % colors.Length];
                    c.a = 0.25f;
                    rend.material.color = c;
                }
            }
        }
    }
}
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NewBallPush : MonoBehaviour
{
    [SerializeField]
    float speed=10;
    Rigidbody rb;
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(Vector3.forward * Time.fixedDeltaTime * speed, ForceMode.VelocityChange);
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            rb.AddForce(Vector3.back * Time.fixedDeltaTime * speed, ForceMode.VelocityChange);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            rb.AddForce(Vector3.left * Time.fixedDeltaTime * speed, ForceMode.VelocityChange);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            rb.AddForce(Vector3.right * Time.fixedDeltaTime * speed, ForceMode.VelocityChange);
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NewLightMeUp : MonoBehaviour
{
    [SerializeField]
    Color highlight = Color.white;
    Material mat;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        mat = rend.material;
        mat.SetColor("_EmissionColor", Color.black);
        rend.material = mat;
    }
    private void OnCollisionEnter(Collision other)
    {
        Renderer r = other.gameObject.GetComponent<Renderer>();
        if (r != null)
            highlight = r.material.color;
        mat.SetColor("_EmissionColor", highlight);
        rend.material = mat;
    }
    private void OnCollisionExit(Collision collision)
    {
        mat.SetColor("_EmissionColor", Color.black);
        rend.material = mat;
    }
}
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NewTeleporter : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = new Vector3(0, 0, 0);
    }
}