using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SlimeCharacteristics
{
    public Types type;
    public Sprite sprite;
}
public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject slime;
    public SlimeCharacteristics[] slimesDatabase;
    public int adultAge, elderAge;
    public Dictionary<Types, Sprite> slimesDatabaseRegister = new Dictionary<Types, Sprite>();
    // Start is called before the first frame update
    void Awake()
    {
         instance = this;
         foreach (SlimeCharacteristics character in slimesDatabase)
        {
            slimesDatabaseRegister.Add(character.type, character.sprite);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
