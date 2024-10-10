namespace WhatEverIWant.DataAccess.Entities;

public class Setting
{
    public Guid Id { get; set; }
    public required string Key { get; set; }
    public required string Value { get; set; }
    public string? Description { get; set; }
}