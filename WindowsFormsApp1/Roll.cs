using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Roll
    {
        int rollType; //1 = atk, 2 = dmg, 3 = both;
        int flat; //flat bonus
        List<int> dieNum, dieAmount;  //parallel arrays: the number on the die (d4 etc.) , the number of those dice 
        string name;
        bool optional, currentState; 

        public bool Optional
        {
            get { return optional; }
        }
        public string Name
        {
            get { return name; }
        }
        public int Type
        {
            get { return rollType; }
        }
        public bool CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }
        public List<int> DieNum
        {
            get { return dieNum; }
        }
        public List<int> DieAmount
        {
            get { return dieAmount; }
        }
        public int Flat
        {
            get { return flat; }
        }


        //constructor
        public Roll(List<int> dieNum, List<int> dieAmount, int flat = 0, int RollType = 0, string s = "", bool opt = false)
        {
            this.dieNum = dieNum;
            this.dieAmount = dieAmount;
            rollType = RollType;
            name = s;
            optional = opt;
            currentState = true;
            this.flat = flat;
        }


        static Random rng = new Random();

        /// <summary>
        /// param: 3,4,6,8,10,12,20,100, proficiency, advantage, disadvantage, abilityModifier
        /// </summary>
        public static List<int>[] RollDice(int d3 = 0, int d4 = 0, int d6 = 0, int d8 = 0, int d10 = 0, int d12 = 0,
            int d20 = 0, int d100 = 0, int prof = 0, bool adv = false, bool disadv = false, int abilMod = 0)
        {
            List<int>[] rolls = new List<int>[10]; //stores the rolls
            rolls[0] = new List<int>();
            rolls[1] = new List<int>();
            rolls[2] = new List<int>();
            rolls[3] = new List<int>();
            rolls[4] = new List<int>();
            rolls[5] = new List<int>();

            //roll the dice  
            rolls[0] = RollDie(3, d3);
            rolls[1] = RollDie(4, d4);
            rolls[2] = RollDie(6, d4);
            rolls[3] = RollDie(8, d4);
            rolls[4] = RollDie(10, d4);
            rolls[5] = RollDie(12, d4);

            //add modifiers

            //connect it all together
            //rolls += sum + Environment.NewLine;

            return rolls;
        }

        /// <summary>
        /// roll a single die
        /// </summary>
        /// <returns></returns>
        public static int RollSingleDie(int die)
        {
            return rng.Next(die) + 1;
        }

        /// <summary>
        /// Roll a single die i times
        /// </summary>
        private static List<int> RollDie(int d, int i)
        {
            List<int> sum = new List<int>();

            for(int n =0; n < i; n++)
            {
                sum.Add(rng.Next(d) + 1);
            }

            return sum;
        }

        public override string ToString()
        {
            string s = "";


            for(int i = 0; i < dieAmount.Count; i++)
            {
                s += dieNum[i] + "d" + dieAmount[i] + " + ";
            }
            if(flat != 0)
                s = flat + " + " + s;
            s = s.Substring(0, s.Length - 3); //take off last comma


            return s;
        }


        public int RollDice()
        {
            int rolls = 0;

            for (int i = 0; i < dieNum.Count; i++)
            {
                int sum = 0;
                for (int n = 0; n < dieNum[i]; n++)
                {
                    sum += RollSingleDie(dieAmount[i]);
                }

                rolls += sum;// + ", ";
            }

            rolls += flat;

            return rolls;
        }
    }
}
