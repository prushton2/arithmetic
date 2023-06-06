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
            // 0-3 is a
            // 4-7 is b
            // 8-11 is c

            //  output
            // 0-7 is outputs


            string a_bin = "";
            string b_bin = "";
            string c_bin = "";

            for(int i = 0; i<4; i++) {
                a_bin += Inputs[i].On   ? "1":"0";
                b_bin += Inputs[i+4].On ? "1":"0";
                c_bin += Inputs[i+8].On ? "1":"0";
            }

            int a_int = Convert.ToInt32(a_bin, 2);
            int b_int = Convert.ToInt32(b_bin, 2);
            int c_int = Convert.ToInt32(c_bin, 2);

            string result = Convert.ToString((a_int * 100) + (10 * b_int) + c_int, 2);
            
            for(int i = 0; i<8; i++) {
                Outputs[i].On = false;
                if(i >= 8-result.Length) {
                    Outputs[i].On = (result[i - (8-result.Length)].ToString() == "1".ToString());
                }
            }
        }
    }
}