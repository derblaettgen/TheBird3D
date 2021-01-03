using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlaceholder : MonoBehaviour
{
    public bool usePlaceholderTag = true;

    // Start is called before the first frame update
    void Start()
    {
        if(transform.childCount > 0)
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;

                if (!usePlaceholderTag)
                {
                    Destroy(child);
                    continue;
                }

                if (child.tag == "Placeholder")
                {
                    Destroy(child);
                }
            }
        }   
    }
}
