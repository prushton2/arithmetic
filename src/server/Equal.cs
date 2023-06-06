using LogicAPI.Server.Components;
using LogicAPI.Server;
using LogicLog;
using LogicWorld.Server.Circuitry;
using System;

namespace prArithmetic
{
    public class Equal : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            //  input
            // 0-7 is a
            // 8-15 is b

            //  output
            // 0 is y
            for(int i = 0; i<8; i++) {
                if(Inputs[i].On != Inputs[i+8].On) {
                    Outputs[0].On = false;
                    return;
                }
            }
            Outputs[0].On = true;
        }
    }
}