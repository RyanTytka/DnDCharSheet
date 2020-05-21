using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Spell
    {
        string name, castTime, range, duration, components, description;
        List<Roll> rolls;
        bool usesRoll;
        int level, attackType;

        public string Name
        {
            get { return name; }
        }
        public int Level
        {
            get { return level; }
        }
        public string CastTime
        {
            get { return castTime; }
        }
        public string Range
        {
            get { return range; }
        }
        public string Duration
        {
            get { return duration; }
        }
        public string Components
        {
            get { return components; }
        }
        public string Description
        {
            get { return description; }
        }
        public List<Roll> Rolls
        {
            get { return rolls; }
        }
        public int AttackType
        {
            get { return attackType; }
        }

        public Spell(string _name, string _castTime, string _range, string _duration, string _components, List<Roll> _rolls,
            int _level, string _description, int atkRoll)
        {
            name = _name;
            castTime = _castTime;
            range = _range;
            duration = _duration;
            components = _components;
            rolls = _rolls;
            level = _level;
            description = _description;
            attackType = atkRoll;
        }

        //makes roll and returns output
        public string Roll(int rollID, int multiplier)
        {
            return "";
        }
    }
}
