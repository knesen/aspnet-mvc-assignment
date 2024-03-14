﻿using Infrastructure.Models;

namespace WebApp.Models.Views;

public class SignUpViewModel
{
    public string Title { get; set; } = "Sign up";
    public SignUpModel Form { get; set; } = new SignUpModel();

}
