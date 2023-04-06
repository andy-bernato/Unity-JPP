using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steve : Unit
{

    // new variables
    private ResourcePile m_CurrentPile = null;
    public float ProductivityMultiplier = 2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BuildingInRange();
    }

    protected override void BuildingInRange()
    {
        // start of new code
        if (m_CurrentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *=  ProductivityMultiplier;
            }
        }
    // end of new code
    }

    void ResetProductivity()
    {
        if (m_CurrentPile != null)
        {
            m_CurrentPile.ProductionSpeed /= ProductivityMultiplier;
            m_CurrentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity(); // call your new method
        base.GoTo(target); // run method from base class
    }

    public override void GoTo(Vector3 position)
    {
        ResetProductivity(); // call your new method
        base.GoTo(position); // run method from base class
    }
}
