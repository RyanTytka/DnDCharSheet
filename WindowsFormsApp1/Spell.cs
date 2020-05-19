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
        int level;

        public Spell(string _name, string _castTime, string _range, string _duration, string _components, List<Roll> _rolls,
            int _level, string _description)
        {
            name = _name;
            castTime = _castTime;
            range = _range;
            duration = _duration;
            components = _components;
            rolls = _rolls;
            level = _level;
            description = _description;
        }
    }
}
