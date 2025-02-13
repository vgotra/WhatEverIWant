namespace WhatEverIWant.DataAccess.Entities;

public class Setting : EntityBase<long>
{
    public required string Key { get; set; }
    public required string Value { get; set; }
    public string? Description { get; set; }
}