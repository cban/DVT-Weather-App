﻿using System.Threading.Tasks;

namespace DVTWeather.Services.Dialog
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string message, string title, string buttonLabel);
    }
}
