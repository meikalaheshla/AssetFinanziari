using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssetFinanziari.Abstract;
using AssetFinanziari.Interface;

namespace AssetFinanziari
{
    internal class SwiftCentralBank : CentralBank, ISwiftSystem
    {

        public SwiftCentralBank(string name, string headquarter, string ceo, string country) : base(name, headquarter, ceo, country)
        {

        }


    }
}