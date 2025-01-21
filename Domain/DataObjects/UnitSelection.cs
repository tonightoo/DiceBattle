using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataObjects
{
    public class UnitSelection
    {

        public Unit[,] Units;

        public Point CurrentSelection;

        public Point RightUnitSelection;

        public Point LeftUnitSelection;

        public bool IsExit;

        public bool IsSelected;

        public bool IsLargerSquare;

        public int XNum;

        public int YNum;

        public Unit RightUnit
        {
            get
            {
                if (RightUnitSelection == null)
                {
                    return null;
                }
                return Units[RightUnitSelection.Y, RightUnitSelection.X];
            }
        }

        public Unit LeftUnit
        {
            get
            {
                if (LeftUnitSelection == null) 
                { 
                    return null;
                }
                return Units[LeftUnitSelection.Y, LeftUnitSelection.X];
            }
        }


        public UnitSelection(int xNum, int yNum) 
        {
            Units = new Unit[yNum, xNum];
            CurrentSelection = new Point(0, 0);
            RightUnitSelection = null;
            LeftUnitSelection = null;
            XNum= xNum;
            YNum= yNum;
            IsExit = false;
            IsSelected = false;  
            IsLargerSquare = false;
        }

        public UnitSelection Initialize()
        {
            return new UnitSelection(XNum, YNum);
        }


    }
}
