using System;
using System.Collections.Generic;

namespace Task_4_1
{
    interface IValueProvider<T>  
    {
        T GetRandomValue();

        T GetUserValue();
    }    
}
