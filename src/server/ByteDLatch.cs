using LogicAPI.Server.Components;
using LogicAPI.Server;
using LogicLog;
using LogicWorld.Server.Circuitry;
using System;

namespace prArithmetic
{
    public class ByteDLatch : LogicComponent
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
    }
}