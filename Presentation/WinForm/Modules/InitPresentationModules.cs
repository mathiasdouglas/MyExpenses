﻿/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace WinForm.Modules
{
    using CrossCutting.IoC;

    public static class InitPresentationModules
    {
        public static void Init()
        {
            MyKernelService.AddModule(new MyPresentationModule());
        }
    }
}
