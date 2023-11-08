using BookCenter.Models;
using BookCenter.Services.Classes;
using BookCenter.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookCenter.ViewModels;

class OrderViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly IRegexCheck _regexCheckService;

    public CardModel Card { get; set; } = new();


    public OrderViewModel(INavigationService navigationService, IRegexCheck regexCheckService)
    {
        _navigationService = navigationService;
        _regexCheckService = regexCheckService;
    }

    public RelayCommand GoBackCommand
    {
        get => new(
    () =>
    {
        _navigationService.NavigateTo<InfoViewModel>();
    }
    );
    }

    public MyRelayCommand PaymentCommand
    {
        get => new(
            () =>
            {
                MessageBox.Show("Sucessful purchase.", "PAyment", MessageBoxButton.OK);

                _navigationService.NavigateTo<SearchViewModel>();

            },
            () =>
            {
                if (Card.CardNumber!= null && Card.Year != null && Card.CvsCode != null)
                    return _regexCheckService.AllRegexCheck(Card);
                return false;
            });
    }
}
