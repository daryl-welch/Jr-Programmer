using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    private ResourcePile m_CurrentPile = null;
    public float ProductivityMultiplier = 2;

    protected override void BuildingInRange()
    {
     if (m_CurrentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *= ProductivityMultiplier;
            }
        }

    }   // end BuildingInRange


    void ResetProductivity()
    {
        if (m_CurrentPile != null)
        {
            m_CurrentPile.ProductionSpeed *= ProductivityMultiplier;
            m_CurrentPile = null;
        }
    }   // end ResetProductivity


    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target);  // base means run the original pluse the override
    }   // end GoTo


    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }   // end GoTo


}
