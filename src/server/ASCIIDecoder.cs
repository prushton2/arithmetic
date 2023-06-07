using LogicAPI.Server.Components;
using LogicAPI.Server;
using LogicLog;
using LogicWorld.Server.Circuitry;
using System;
using System.Collections.Generic; 


namespace prArithmetic
{
    public class ASCIIDecoder : LogicComponent
    {
        private Dictionary<string, string> chars = new Dictionary<string, string>{
            {"01000001", "01101001111110011001"},
            {"01000010", "11101001111010011110"},
            {"01000011", "11101000100010001110"},
            {"01000100", "11101001100110011110"},
            {"01000101", "11101000111010001110"},
            {"01000110", "11101000111010001000"},
            {"01000111", "11111000101110011111"},
            {"01001000", "10011001111110011001"},
            {"01001001", "11100100010001001110"},
            {"01001010", "11100100010001001110"},
            {"01001011", "00100010001010101110"},
            {"01001100", "10101010110010101010"},
            {"01001101", "10001000100010001110"},
            {"01001110", "10101110101010101010"},
            {"01001111", "10011101101110011001"},
            {"01010000", "11111001100110011111"},
            {"01010001", "11101010111010001000"},
            {"01010010", "00001110101011100010"},
            {"01010011", "11101010110010101010"},
            {"01010100", "11101000111000101110"},
            {"01010101", "11100100010001000100"},
            {"01010110", "10101010101010101110"},
            {"01010111", "10101010101010100100"},
            {"01011000", "10101010101011101010"},
            {"01011001", "10010110011001101001"},
            {"01011010", "10101010111000101110"},
            {"01011011", "11100010010010001110"},
            // {"01011100", "11100010010010001110"},
        };
        
        //[false, true, true, false, true, false, false, true, true, true, true, true, true, false, false, true, true, false, false, true]
        protected override void DoLogicUpdate()
        {
            
            
            //  input
            // 0-7 is a
            
            //  output
            // 0-3 is top, 4-7 is row 1, 8-11 is row 2, etc
            

            string index = "";

            for(int i = 0; i<8; i++) {
                index += Inputs[i].On ? "1" : "0";
            }

            if(chars.ContainsKey(index)) {
                for(int i = 0; i<20; i++) {
                    Outputs[i].On = chars[index][i] == '1';
                }
            } else {
                for(int i = 0; i<20; i++) {
                    Outputs[i].On = false;
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