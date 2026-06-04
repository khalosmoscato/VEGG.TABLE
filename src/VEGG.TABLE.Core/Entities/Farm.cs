using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VEGG.TABLE.Core.Entities;

public class Farm
{
    public int Id { get; set; }
    [Required, StringLength(100)]
    public required string Name { get; set; }
    public double Lat { get; set; }
    public double Lng { get; set; }
    public int OwnerId { get; set; }
    public User? Owner { get; set; }
}
