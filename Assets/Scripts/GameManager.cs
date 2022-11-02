using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    [SerializeField]
    int amount = 2;
    public GameObject star;
    public GameObject Stars;
    internal List<GameObject> starList = new List<GameObject>();
    internal List<GameObject> guiltylist = new List<GameObject>();
    public void stars(int count)
    {
        int starlistcount=starList.Count;
        for (int i = starlistcount; i < starlistcount + count; i++)
        {
            GameObject klon = GameObject.Instantiate(star, Stars.transform);
            klon.transform.position += Vector3.up * 0.25f *i;
            starList.Add(klon);

        }

    }
    public void Catch(GameObject guilty)
    {
         
        if (starList.Count > 0)
        {
            Destroy(starList[starList.Count - 1]);
            starList.RemoveAt(starList.Count - 1);
            guiltylist.Add(guilty);
            
            
        }
           
    }
    public void car()
    {
        if (guiltylist.Count == 0)
        {
            return; //polis hiç hýrsýz yakalamamýþsa kod çalýþmasýn
        }
        stars(guiltylist.Count);
        foreach (GameObject guilty in guiltylist)
        {
            Destroy(guilty);
          
            
        }
        guiltylist.Clear();
        
    }

    
    void Start()
    {
        stars(amount);
    }

   
   
}
