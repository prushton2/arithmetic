using LogicAPI.Server.Components;
using LogicAPI.Server;
using LogicLog;
using LogicWorld.Server.Circuitry;
using System;

namespace prArithmetic
{
    public class Adder4 : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            //  input
            // 0-7 is a
            // 8-15 is b

            //  output
            // 0 is y
            // for(int i = 0; i<8; i++) {
            //     if(Inputs[i].On != Inputs[i+8].On) {
            //         Outputs[0].On = false;
            //         return;
            //     }
            // }
            // Outputs[0].On = true;
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