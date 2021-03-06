﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public enum RefillType {SHORT = 0, LONG, OTHER};
    
    public class Feat
    {

        //fields
        string name, abilities;
        int numUses, usesLeft;
        bool useRoll, limitedUse;
        Roll roll;
        RefillType refillType;

        //properties
        public Roll Roll
        {
            get { return roll; }
        }
        public string Name
        {
            get { return name; }
        }
        public bool UseRoll
        {
            get { return useRoll; }
        }
        public bool LimitedUse
        {
            get { return limitedUse; }
        }
        public int NumUses
        {
            get { return numUses; }
        }
        public int UsesLeft
        {
            get { return usesLeft; }
            set { usesLeft = value; }
        }
        public RefillType RefillTypeProperty
        {
            get { return refillType; }
        }

        public string Abilities
        {
            get
            {
                //string s = "";
                //foreach (string s2 in abilities)
                //{
                //    s += s2 + Environment.NewLine;
                //}
                //return s;
                return abilities;
            }
        }

        //constructor
        public Feat(string name, string abilities, bool useRoll, Roll roll, 
            bool limited, RefillType refill, int numUses = 0)
        {
            this.name = name;
            this.abilities = abilities;
            this.useRoll = useRoll;
            this.roll = roll;
            this.numUses = numUses;
            usesLeft = numUses;
            limitedUse = limited;
            refillType = refill;
        }

    }
}
