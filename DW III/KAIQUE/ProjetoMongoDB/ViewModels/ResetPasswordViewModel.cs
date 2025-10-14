﻿using System.ComponentModel.DataAnnotations;

namespace ProjetoMongoDB.ViewModels
{
    public class ResetPasswordViewModel
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)] // Verifica se a senha tá no formato que o Identity aceita
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "A senha e a confimação não conferem")]
        public string ConfirmPassword { get; set; }
    }
}