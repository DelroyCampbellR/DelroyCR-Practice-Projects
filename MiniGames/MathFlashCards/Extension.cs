using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathFlashCards
{
    public static class Extension
    {
        public static string GetSymbol(this OperationEnum operation) 
        {
            switch (operation)
            {
                case OperationEnum.Addition:
                    return "+";
                    
                case OperationEnum.Multiplication:
                    return "*";
                   
                default:
                    throw new Exception("Operation not supported.");
            }
        }

        public static int GetResult(this OperationEnum operation, int x, int y)
        {
            switch(operation) 
            {
                case OperationEnum.Addition:
                    return x + y;

                case OperationEnum.Multiplication:
                    return x * y;

                default:
                    throw new Exception("Operation not supported.");
            }   
        }
    }
}
