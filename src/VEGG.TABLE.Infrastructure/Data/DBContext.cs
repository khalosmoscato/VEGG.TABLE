using System;

namespace VEGG.TABLE.Infrastructure.Data;

    public class DBContext : DbContext
    {
        public DbSet<Produce> ProduceTable { get; set; }
        public DbSet<User> UserTable { get; set; }

        public DbSet<UserProduceLike> LikedTable { get; set; }
        public DbSet<UserProduceTransaction> TransactionTable { get; set; }


        public DBContext(DbContextOptions<DBContext> options)
            : base(options) { }

        public static void DropAndCreateDatabase(DBContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "VegManDan",
                    Email = "bossman@live.co.uk",
                    Password = "highthere",
                    UserType = UserType.Buyer
                }
            );
            //Juuction table for likes
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

            //junction table for Transactions
            modelBuilder.Entity<UserProduceTransaction>()
              .HasKey(transaction => new { transaction.SellerId, transaction.BuyerId });

            modelBuilder.Entity<UserProduceTransaction>()
                .HasOne(transaction => transaction.Seller)
                .WithMany()
                .HasForeignKey(transaction => transaction.SellerId);

            modelBuilder.Entity<UserProduceTransaction>()
                .HasOne(transaction => transaction.Buyer)
                .WithMany()
                .HasForeignKey(transaction => transaction.ProduceId);
        }
    }




