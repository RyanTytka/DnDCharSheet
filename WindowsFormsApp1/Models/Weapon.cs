using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Weapon
    {
        //fields
        string name;
        string properties;
        List<Roll> bonusRolls;
        bool finesse, profiient;
        Roll damageRoll;

        //properties
        public List<Roll> BonusRolls
        {
            get { return bonusRolls; }
        }
        public string Name
        {
            get { return name; }
        }
        public bool Finesse
        {
            get { return finesse; }
        }
        public bool Proficient
        {
            get { return profiient; }
        }
        public Roll Damage
        {
            get { return damageRoll; }
        }
        public string Properties
        {
            get
            {
                return properties;
            }
        }

        
        public Weapon(string nm, List<Roll> bonus, string prop, bool fin, bool prof, Roll damage)
        {
            bonusRolls = new List<Roll>();

            name = nm;
            bonusRolls = bonus;
            properties = prop;
            finesse = fin;
            profiient = prof;
            damageRoll = damage;

        }



    }
}
