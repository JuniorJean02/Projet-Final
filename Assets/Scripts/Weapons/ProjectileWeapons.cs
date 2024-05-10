using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapons : MonoBehaviour
{
    public WeaponScriptableObjects weaponData;

    protected Vector3 direction;
    public float destroyAfterSecond;

  
   protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSecond);     
    }

    public void Directioncheker(Vector3 dir)
    {
        direction = dir;

        float dirx = direction.x;
        float diry = direction.y;   

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if(dirx < 0 && diry == 0)// left
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        }
        else if (dirx == 0 && diry < 0)//down
        {
            scale.y = scale.y * -1;
        }

        else if(dirx == 0 && diry > 0)//up
        {
            scale.x = scale.x * -1;
            
        }
        else if(dir.x > 0 && dir.y > 0)//right up
        {
            rotation.z = 0f;
        }

        else if (dir.x < 0 && dir.y < 0)//right down
        {
            rotation.z = -90f;
        }

        else if (dir.x < 0 && dir.y > 0)
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = 0f;
            
        }
        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
