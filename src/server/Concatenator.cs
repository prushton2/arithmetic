using LogicAPI.Server.Components;
using LogicAPI.Server;
using LogicLog;
using LogicWorld.Server.Circuitry;
using System;

namespace prArithmetic
{
    public class Concatenator : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            //  input
            // 0-7 is a
            // 8 is s

            //  output
            // 0-7 is outputs

            if(Inputs[8].On) {
                for(int i = 0; i<8; i++) {
                    Outputs[i].On = Inputs[i].On;
                }
            }
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