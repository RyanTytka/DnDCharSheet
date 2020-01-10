using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Feat
    {
        //fields
        string name, rollName, abilities;
        int numRolls;
        bool useRoll;
        Roll roll;

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
        public int NumRolls
        {
            get { return numRolls; }
        }
        public string RollName
        {
            get { return rollName; }
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
        public Feat(string name, string rollName, string abilities, bool useRoll, Roll roll)
        {
            this.name = name;
            this.rollName = rollName;
            this.abilities = abilities;
            this.useRoll = useRoll;
            this.roll = roll;
        }

    }
}
