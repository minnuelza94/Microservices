﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BankManagementMicroservice.Service.Model
{
    public class RegisterModel
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
        public string Username { get; set; }

        [StringLength(20, ErrorMessage = "Password cannot exceed 20 characters.")]
        public string Password { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Address cannot exceed 300 characters.")]
        public string Address { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "EmailAddress cannot exceed 50 characters.")]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Pan cannot exceed 10 characters.")]
        public string PAN { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "ContactNo cannot exceed 10 characters.")]
        public string ContactNo { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "AccountType cannot exceed 10 characters.")]
        public string AccountType { get; set; }

        [Required]
        public DateTime CreatedOnUtc { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }


    }
}