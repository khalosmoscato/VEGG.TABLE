using System;
using System.Collections.Generic;
using System.Text;

namespace VEGG.TABLE.Core.Entities.DTOs;

public class FarmDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Lat { get; set; }
    public double Lng { get; set; }
    public string OwnerName { get; set; } = string.Empty;
    public string OwnerEmail { get; set; } = string.Empty;
}