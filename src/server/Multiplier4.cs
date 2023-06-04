using LogicAPI.Server.Components;
using LogicAPI.Server;
using LogicLog;
using LogicWorld.Server.Circuitry;
using System;

namespace prArithmetic
{
    public class Multiplier4 : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            //  input
            // 8 is carry
            // 0-3 is a
            // 4-7 is b

            //  output
            // 8 is carry
            // 0-7 is outputs
            string a_bin = "0000";
            string b_bin = "0000";

            for(int i = 0; i<4; i++) {
                a_bin += Inputs[i].On   ? "1":"0";
                b_bin += Inputs[i+4].On ? "1":"0";
            }

            int a_int = Convert.ToInt32(a_bin, 2);
            int b_int = Convert.ToInt32(b_bin, 2);

            string result = Convert.ToString(a_int * b_int, 2);
            
            for(int i = 0; i<8; i++) {
                Outputs[i].On = false;
                if(i >= 8-result.Length) {
                    Outputs[i].On = (result[i - (8-result.Length)].ToString() == "1".ToString());
                }
            }

            // carry out
            // Outputs[0].On = false;
        }

        private void Add(int index, ref bool carry)
        {
            bool a = Inputs[index].On;
            bool b = Inputs[index + 8].On;
            bool ab = a ^ b;
            Outputs[index].On = ab ^ carry;
            carry = (ab & carry) | (a & b);
        }
    }
}