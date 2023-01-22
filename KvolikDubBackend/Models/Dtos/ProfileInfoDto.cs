﻿namespace KvolikDubBackend.Models.Dtos;

public class ProfileInfoDto
{
    public Guid Id { get; set; }
    
    public String username { get; set; }
    
    public String? name { get; set; }
    
    public String avatarImageUrl { get; set; }
}