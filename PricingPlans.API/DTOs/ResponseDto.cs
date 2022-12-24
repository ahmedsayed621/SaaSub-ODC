﻿namespace PricingPlans.API.DTOs
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessag { get; set; } = "";
        public List<string> ErrorMessages { get; set; }
    }
}
