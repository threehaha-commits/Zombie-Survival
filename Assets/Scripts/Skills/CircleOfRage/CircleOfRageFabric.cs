using UnityEngine;

public class CircleOfRageFabric
{
    private CircleOfRage _cor;
    
    public CircleOfRageFabric()
    {
        _cor = Resources.Load<CircleOfRage>("CircleOfRage");
    }

    public CircleOfRage Create()
    {
        return Object.Instantiate(_cor);
    }
}