﻿namespace BulbEd.Entities;
// Represents the token blacklist entity
public class TokenBlackList
{
    public int Id { get; set; }
    public string Token { get; set; }
    public DateTime ExpirationDate { get; set; }
    
}