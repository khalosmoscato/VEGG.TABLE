using System.Reflection.Metadata.Ecma335;

using VEGG.TABLE.Core.Entities;
using VEGG.TABLE.Core.Interfaces;

namespace VEGG.TABLE.Infrastructure.Data;

public class ProduceRepository : IProduceRepository
{
    private readonly DBContext _context;

    public ProduceRepository(DBContext context)
    {
        _context = context;
    }

    public List<Produce> GetAllProduces()
    {
        return _context.ProduceTable.ToList();
    }

    public Produce? GetProduceById(int id)
    {
        return _context.ProduceTable.FirstOrDefault(p => p.ProduceId == id);
    }

    public List<Produce>? GetProduceByUserId(int userId)
    {
        var user = _context.UserTable.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            return null;
        }
        var produceList = _context.ProduceTable.Where(p => p.UserId == userId && p.IsOnSale == true).ToList();
        return produceList;   
    }
    public List<Produce>? GetProduceByUserIdAll(int userId)
    {
        var user = _context.UserTable.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            return null;
        }
        var produceList = _context.ProduceTable.Where(p => p.UserId == userId).ToList();
        return produceList;
    }

    public List<Produce>? GetAllProduceOnSale()
    {
        var onSaleList = _context.ProduceTable
            .Where(p => p.IsOnSale == true)
            .ToList();
        if (!onSaleList.Any()) {return onSaleList;}
        return null;
    }
    public Produce AddProduce(ProduceDTO produceDTO)
    {
        Produce produce = new Produce {
            Category = produceDTO.Category,
            Name = produceDTO.Name,
            Description = produceDTO.Description,
            IsOnSale =   produceDTO.IsOnSale,
            Stock = produceDTO.Stock,
            Price = produceDTO.Price,
            Weight = produceDTO.Weight,
            PhotograghPath = produceDTO.PhotograghPath,
            UserId = produceDTO.UserId,
        };

        _context.ProduceTable.Add(produce);
        _context.SaveChanges();
        return produce;
    }

    public Produce? UpdateProduce(int id, ProduceDTO produceDTO)
    {
        var targetProduce = _context.ProduceTable.FirstOrDefault(p => p.ProduceId == id);
        //if there is no produce to modify we will return null
        if (targetProduce == null)
        {
            return null;
        }

        if (produceDTO.Name != null && produceDTO.Name != targetProduce.Name)
        {
            targetProduce.Name = produceDTO.Name;
        }
        if (produceDTO.Description != null && produceDTO.Description != targetProduce.Description)
        {
            targetProduce.Description = produceDTO.Description;
        }
        if (produceDTO.PhotograghPath != null && produceDTO.PhotograghPath != targetProduce.PhotograghPath)
        {
            targetProduce.PhotograghPath = produceDTO.PhotograghPath;
        }
        if (produceDTO.Category != targetProduce.Category)
        {
            targetProduce.Category = produceDTO.Category;
        }
        if (produceDTO.IsOnSale != targetProduce.IsOnSale)
        {
            targetProduce.IsOnSale = produceDTO.IsOnSale;
        }
        if (produceDTO.Stock != targetProduce.Stock)
        {
            targetProduce.Stock = produceDTO.Stock;
        }
        if (produceDTO.Price != targetProduce.Price)
        {
            targetProduce.Price = produceDTO.Price;
        }
        if (produceDTO.Weight != targetProduce.Weight)
        {
            targetProduce.Weight = produceDTO.Weight;
        }
        if (produceDTO.UserId != targetProduce.UserId)
        {
            targetProduce.UserId = produceDTO.UserId;
        }

        _context.SaveChanges();
        return targetProduce;
    }

    public bool DeleteProduce(int id)
    {
        var existing = _context.ProduceTable.FirstOrDefault(p => p.ProduceId == id);
        if (existing == null) return false;
        _context.ProduceTable.Remove(existing);
        _context.SaveChanges();
        return true;
    }

}