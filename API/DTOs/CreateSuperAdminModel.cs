using BulbEd.Entities;

namespace BulbEd.DTOs;
    
public class CreateSuperAdminModel
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public Institution? Institution { get; set; }
        
    }
