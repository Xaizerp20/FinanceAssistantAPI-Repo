﻿using System.ComponentModel.DataAnnotations;

namespace FinanceAssistantAPI.Models.Dto
{
    public class ApplicationUserUpdateDto
    {
        [Required]   
        public int Id { get; set; } //Id del usuario
        public string FirstName { get; set; }     // Nombre del usuario
        public string LastName { get; set; }      // Apellido del usuario
        public string Email { get; set; }        // Correo electrónico del usuario
        public string PasswordHash { get; set; } // Hash de la contraseña del usuario
        public string Address { get; set; }       // Dirección del usuario
        public string City { get; set; }          // Ciudad del usuario
        public string Country { get; set; }       // País del usuario
    }
}
