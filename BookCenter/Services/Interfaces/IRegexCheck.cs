using BookCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCenter.Services.Interfaces
{
    interface IRegexCheck


    {
        public bool CardNumberCheck(string cardNumber);

        public bool YearCheck(string year);

        public bool CvsCheck(string cvc);

        public bool AllRegexCheck(CardModel card);
    }
}
