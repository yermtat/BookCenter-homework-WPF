using BookCenter.Models;
using BookCenter.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookCenter.Services.Classes;

class RegexCheck : IRegexCheck
{
    private Regex _cardNumberRegex = new Regex(@"\d{4} \d{4} \d{4} \d{4}");
    private Regex _yearRegex = new Regex(@"[0|1]\d\/[1-3]\d");
    private Regex _cvsRegex = new Regex(@"\d{3}");

    public bool CardNumberCheck(string cardNumber)
    {
        return _cardNumberRegex.IsMatch(cardNumber);
    }

    public bool CvsCheck(string cvs)
    {
        return _cvsRegex.IsMatch(cvs);
    }

    public bool YearCheck(string year)
    {
        return _yearRegex.IsMatch(year);
    }

    public bool AllRegexCheck(CardModel card)
    {
        return CardNumberCheck(card.CardNumber) && YearCheck(card.Year) && CvsCheck(card.CvsCode);
    }
}
