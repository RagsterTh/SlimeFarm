using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public enum AgePhase
{
    Child, Adult, Elder
}
public enum Types
{//Tenho que ver quais vou fazer
    Green, Blue, Red, Purple
}
public class Slime : MonoBehaviour
{
    public AgePhase agePhase;
    [Range(1, 4)]public int reproductionQtd;
    public Types type;

    public Transform[] reproductionPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (agePhase.Equals(AgePhase.Adult))
        {
            Reproduce();
        }
    }

    void Reproduce()
    {
        int babiesNumber = Random.Range(1, reproductionQtd);
        List<Transform> points = reproductionPoints.ToList<Transform>();
        for (int i = 0; i < babiesNumber; i++)
        {
            int randPos = Random.Range(0, points.Count);
            Instantiate(GameController.instance.slime, points[randPos].position, transform.rotation);
            points.RemoveAt(randPos);
        }
        Destroy(gameObject);
    }
}
