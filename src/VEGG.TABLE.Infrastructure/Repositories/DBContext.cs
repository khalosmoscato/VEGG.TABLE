using System;

namespace VEGG.TABLE.Infrastructure.Data;

public class DBContext : DbContext
{
    public DbSet<Produce> ProduceTable => Set<Produce>();
    public DbSet<User> UserTable => Set<User>();
    public DbSet<UserProduceLike> LikedTable => Set<UserProduceLike>();
    public DbSet<Farm> Farms => Set<Farm>();

    public DBContext(DbContextOptions<DBContext> options)
        : base(options) { }

    public static void DropAndCreateDatabase(DBContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed data for produce
        modelBuilder.Entity<Produce>().HasData(
            new Produce
            {
                ProduceId = 1,
                Name = "Plums",
                Stock = 1,
                Price = 2.00,
                Weight = 2,
                Category = Category.Unkown,
                Description = "Plums for sale",
                PhotograghPath = string.Empty,

                IsLiked = false,
                IsOnSale = false,
                IsPurchased = false,

                UserId = 1,
            },

            new Produce
            {
                ProduceId = 2,
                Name = "Apples",
                Stock = 5,
                Price = 1.50,
                Weight = 3,
                Category = Category.Unkown,
                Description = "Fresh apples for sale",
                PhotograghPath = string.Empty,

                IsLiked = true,
                IsOnSale = false,
                IsPurchased = false,

                UserId = 1,
            },

            new Produce
            {
                ProduceId = 3,
                Name = "Bananas",
                Stock = 10,
                Price = 0.99,
                Weight = 2,
                Category = Category.Unkown,
                Description = "Organic bananas",
                PhotograghPath = string.Empty,

                IsLiked = false,
                IsOnSale = true,
                IsPurchased = false,

                UserId = 2,
            },

            new Produce
            {
                ProduceId = 4,
                Name = "Carrots",
                Stock = 7,
                Price = 1.20,
                Weight = 4,
                Category = Category.Unkown,
                Description = "Crunchy carrots for cooking",
                PhotograghPath = string.Empty,

                IsLiked = false,
                IsOnSale = false,
                IsPurchased = true,

                UserId = 2,
            },

            new Produce
            {
                ProduceId = 5,
                Name = "Tomatoes",
                Stock = 8,
                Price = 2.75,
                Weight = 3,
                Category = Category.Unkown,
                Description = "Juicy red tomatoes",
                PhotograghPath = string.Empty,

                IsLiked = true,
                IsOnSale = true,
                IsPurchased = false,

                UserId = 3,
            },

            new Produce
            {
                ProduceId = 6,
                Name = "Potatoes",
                Stock = 15,
                Price = 3.00,
                Weight = 10,
                Category = Category.Unkown,
                Description = "Farm fresh potatoes",
                PhotograghPath = string.Empty,

                IsLiked = false,
                IsOnSale = false,
                IsPurchased = false,

                UserId = 3,
            },

            new Produce
            {
                ProduceId = 7,
                Name = "Strawberries",
                Stock = 6,
                Price = 4.50,
                Weight = 1,
                Category = Category.Unkown,
                Description = "Sweet strawberries",
                PhotograghPath = string.Empty,

                IsLiked = true,
                IsOnSale = true,
                IsPurchased = true,

                UserId = 4,
            },

            new Produce
            {
                ProduceId = 8,
                Name = "Lettuce",
                Stock = 4,
                Price = 1.10,
                Weight = 1,
                Category = Category.Unkown,
                Description = "Fresh green lettuce",
                PhotograghPath = string.Empty,

                IsLiked = false,
                IsOnSale = false,
                IsPurchased = false,

                UserId = 4,
            },

            new Produce
            {
                ProduceId = 9,
                Name = "Oranges",
                Stock = 12,
                Price = 2.30,
                Weight = 5,
                Category = Category.Unkown,
                Description = "Citrus oranges for juice",
                PhotograghPath = string.Empty,

                IsLiked = true,
                IsOnSale = false,
                IsPurchased = true,

                UserId = 5,
            },

            new Produce
            {
                ProduceId = 10,
                Name = "Cucumbers",
                Stock = 9,
                Price = 1.80,
                Weight = 2,
                Category = Category.Unkown,
                Description = "Cool fresh cucumbers",
                PhotograghPath = string.Empty,

                IsLiked = false,
                IsOnSale = true,
                IsPurchased = false,

                UserId = 5,
            }
        );
        // Seed data for users
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Name = "VegManDan",
                Email = "bossman@live.co.uk",
                Password = "$2a$11$.L.EhNZir7n.hylCEenduOkBlqrdyXHt0jtDqMrW46jy0.pKbkMw2",
                UserType = UserType.Seller
            },
            new User
            {
                Id = 2,
                Name = "FreshFarmers",
                Email = "contact@fresh.co.uk",
                Password = "$2a$11$G7VbY4W8z1zW7F4Q1j6Qj.qH8zM8G.VzS6LhZ9KqW.0f2gQ8m8hXy", //hashed_pw_2
                UserType = UserType.Seller
            },
            new User
            {
                Id = 3,
                Name = "LondonGreens",
                Email = "info@londongreens.co.uk",
                Password = "$2a$11$uK8fS9j2lK7mN4Q2x5P5e.rJ0hZ7G.VzS6LhZ9KqW.0f2gQ8m8hXy", //hashed_pw_3
                UserType = UserType.Seller
            },
            new User
            {
                Id = 4,
                Name = "SpitalFieldsOrg",
                Email = "hello@spital.co.uk",
                Password = "$2a$11$vN2mX5Q8k1jL4H3x6T9a.rJ0hZ7G.VzS6LhZ9KqW.0f2gQ8m8hXy", //hashed_pw_4
                UserType = UserType.Seller
            },
            new User
            {
                Id = 5,
                Name = "CrystalVeg",
                Email = "team@crystalveg.co.uk",
                Password = "$2a$11$wL3bV8k9m2pQ5D4y7R1b.rJ0hZ7G.VzS6LhZ9KqW.0f2gQ8m8hXy", //hashed_pw_5
                UserType = UserType.Seller
            },
            new User
            {
                Id = 6,
                Name = "GreenShopper",
                Email = "buyer1@test.com",
                Password = "$2a$11$G7VbY4W8z1zW7F4Q1j6Qj.qH8zM8G.VzS6LhZ9KqW.0f2gQ8m8hXy", //password123
                UserType = UserType.Buyer
            },
            new User
            {
                Id = 7,
                Name = "OrganicFan",
                Email = "buyer2@test.com",
                Password = "$2a$11$fK5Qz7n.uV.z8L3M9KqW.0f2gQ8m8hXyLhZ9KqW.0f2gQ8m8hXy", //veggie4life
                UserType = UserType.Buyer
            }
        );
        // Configure the relationship between Farm and User
        modelBuilder.Entity<Farm>()
            .HasOne(f => f.Owner)
            .WithMany(u => u.Farms)
            .HasForeignKey(f => f.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);
        // Seed data for farms
        modelBuilder.Entity<Farm>().HasData(
            new Farm { Id = 1, Name = "Hackney City Farm", Lat = 51.5332, Lng = -0.0632, OwnerId = 1 },
            new Farm { Id = 2, Name = "Surrey Docks Farm", Lat = 51.4988, Lng = -0.0416, OwnerId = 2 },
            new Farm { Id = 3, Name = "Kentish Town City Farm", Lat = 51.5478, Lng = -0.1456, OwnerId = 3 },
            new Farm { Id = 4, Name = "Spitalfields Farm", Lat = 51.5195, Lng = -0.0645, OwnerId = 4 },
            new Farm { Id = 5, Name = "Crystal Palace Park Farm", Lat = 51.4225, Lng = -0.0635, OwnerId = 5 });
        //Junction table for likes
        modelBuilder.Entity<UserProduceLike>()
          .HasKey(like => new { like.UserId, like.ProduceId });

        modelBuilder.Entity<UserProduceLike>()
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);

        modelBuilder.Entity<UserProduceLike>()
            .HasOne(x => x.Produce)
            .WithMany()
            .HasForeignKey(x => x.ProduceId);

    }
}