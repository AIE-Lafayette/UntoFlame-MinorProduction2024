using UnityEngine;

[CreateAssetMenu(fileName = "Integer", menuName = "Variables/Integer")]
public class Integer_SO : ScriptableObject
{
    [SerializeField]
    private int _value;   

    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public static int operator +(int a, Integer_SO b)
    {
        return a + b.Value;
    }

    public static int operator +(Integer_SO a, int b)
    {
        return b + a.Value;
    }
}
