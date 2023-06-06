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

            bool c1 = Add(0, Inputs[8].On);
            bool c2 = Add(1, c1);
            bool c3 = Add(2, c2);
            Outputs[4].On = Add(3, c3);
        }
        

        private bool Add(int index, bool carry)
        {
            bool a = Inputs[index].On;
            bool b = Inputs[index + 4].On;
            bool ab = a ^ b;
            Outputs[index].On = ab ^ carry;
            return (ab & carry) | (a & b);
        }
    }
}