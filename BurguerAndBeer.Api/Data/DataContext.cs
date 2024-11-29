using BurguerAndBeer.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BurguerAndBeer.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Burguer> Burguer { get; set; }
        public DbSet<Beer> Beer { get; set; }
        public DbSet<Chips> Chips { get; set; }
        public DbSet<Dessert> Dessert { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            AddSeedData(modelBuilder);
        }

        private static void AddSeedData(ModelBuilder modelBuilder)
        {
            Burguer[] burgers = new Burguer[]
            {
        new Burguer
        {
            Id = 1,
            Name = "Classic Supreme",
            Description = "Burger with beef patty, cheddar cheese, lettuce, tomato, and special sauce.",
            Price = 5.99,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer1.png?raw=true",
            CategoryId = 1
        },
        new Burguer
        {
            Id = 2,
            Name = "BBQ Texan",
            Description = "Smoked meat with BBQ sauce, crispy onion, and gouda cheese.",
            Price = 6.99,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer2.png?raw=true",
            CategoryId = 1
        },
        new Burguer
        {
            Id = 3,
            Name = "Cheddar Bacon Deluxe",
            Description = "Loaded with cheddar cheese, crispy bacon, and special mayonnaise.",
            Price = 7.49,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer3.png?raw=true",
            CategoryId = 1
        },
        new Burguer
        {
            Id = 4,
            Name = "Tropical Hawaiian",
            Description = "Beef patty with Swiss cheese, caramelized pineapple, and teriyaki sauce.",
            Price = 6.49,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer4.png?raw=true",
            CategoryId = 1
        },
        new Burguer
        {
            Id = 5,
            Name = "Inferno Spicy",
            Description = "With jalapeños, hot sauce, pepper jack cheese, and onion.",
            Price = 6.99,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer5.png?raw=true",
            CategoryId = 1
        },
        new Burguer
        {
            Id = 6,
            Name = "Double Smashburger",
            Description = "Double smashed patty, cheddar cheese, and special sauce.",
            Price = 7.99,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer6.png?raw=true",
            CategoryId = 1
        },
        new Burguer
        {
            Id = 7,
            Name = "Veggie Lovers",
            Description = "Vegetarian burger with fresh vegetables and hummus.",
            Price = 5.49,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer7.png?raw=true",
            CategoryId = 1
        },
        new Burguer
        {
            Id = 8,
            Name = "Portobello Melt",
            Description = "Grilled portobello mushroom, Swiss cheese, and garlic mayonnaise.",
            Price = 6.99,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer8.png?raw=true",
            CategoryId = 1
        },
        new Burguer
        {
            Id = 9,
            Name = "Gourmet Truffle",
            Description = "Beef patty with truffle oil, brie cheese, and arugula.",
            Price = 8.99,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer9.png?raw=true",
            CategoryId = 1
        }
            };

            Beer[] beers = new Beer[]
   {
        new Beer
        {
            Id = 1,
            Name = "Pale Ale",
            Description = "A refreshing pale ale with hints of citrus and a balanced malt profile.",
            Price = 4.99,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer1.png?raw=true",
            CategoryId = 2
        },
        new Beer
        {
            Id = 2,
            Name = "IPA",
            Description = "A bold India Pale Ale with strong hoppy aromas and a crisp finish.",
            Price = 5.49,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer2.png?raw=true",
            CategoryId = 2
        },
        new Beer
        {
            Id = 3,
            Name = "Stout",
            Description = "A dark stout with rich chocolate and coffee flavors.",
            Price = 5.99,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer3.png?raw=true",
            CategoryId = 2
        },
        new Beer
        {
            Id = 4,
            Name = "Wheat Beer",
            Description = "A light and crisp wheat beer with notes of banana and clove.",
            Price = 4.49,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer4.png?raw=true",
            CategoryId = 2
        },
        new Beer
        {
            Id = 5,
            Name = "Lager",
            Description = "A classic lager with a clean taste and a smooth finish.",
            Price = 4.99,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer5.png?raw=true",
            CategoryId = 2
        },
        new Beer
        {
            Id = 6,
            Name = "Pilsner",
            Description = "A crisp and refreshing pilsner with a slight floral hop aroma.",
            Price = 4.79,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer6.png?raw=true",
            CategoryId = 2
        },
        new Beer
        {
            Id = 7,
            Name = "Amber Ale",
            Description = "A smooth amber ale with caramel notes and a balanced bitterness.",
            Price = 5.29,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer7.png?raw=true",
            CategoryId = 2
        },
        new Beer
        {
            Id = 8,
            Name = "Porter",
            Description = "A rich porter with roasted malt flavors and hints of vanilla.",
            Price = 5.79,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer8.png?raw=true",
            CategoryId = 2
        },
        new Beer
        {
            Id = 9,
            Name = "Saison",
            Description = "A farmhouse ale with fruity and spicy notes, perfect for summer.",
            Price = 5.49,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer9.png?raw=true",
            CategoryId = 2
        },
        new Beer
        {
            Id = 10,
            Name = "Brown Ale",
            Description = "A nutty brown ale with hints of toffee and a smooth finish.",
            Price = 5.29,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer10.png?raw=true",
            CategoryId = 2
        },
        new Beer
        {
            Id = 11,
            Name = "Belgian Ale",
            Description = "A complex Belgian ale with fruity esters and a spicy yeast character.",
            Price = 6.49,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Beers/beer11.png?raw=true",
            CategoryId = 2
        }


   };

            Dessert[] desserts = new Dessert[]
    {
        new Dessert
        {
            Id = 1,
            Name = "Chocolate Cupcake ",
            Description = "A rich chocolate cupcake topped with creamy chocolate frosting.",
            Price = 2.99,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Desserts/cupcake_chocolate.png?raw=true",
            CategoryId = 4
        },
        new Dessert
        {
            Id = 2,
            Name = "Strawberry Cupcake",
            Description = "A delightful strawberry cupcake with a fresh strawberry glaze.",
            Price = 2.79,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Desserts/cupcake_fresa.png?raw=true",
            CategoryId = 4
        },
        new Dessert
        {
            Id = 3,
            Name = "Blackberry Cupcake",
            Description = "A moist blackberry cupcake with a tangy cream cheese frosting.",
            Price = 2.89,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Desserts/cupcake_mora.png?raw=true",
            CategoryId = 4
        },
        new Dessert
        {
            Id = 4,
            Name = "Red Velvet Cupcake",
            Description = "A classic red velvet cupcake with a smooth cream cheese frosting.",
            Price = 3.19,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Desserts/cupcake_redvelvet.png?raw=true",
            CategoryId = 4
        },
        new Dessert
        {
            Id = 5,
            Name = "Chocolate Pie",
            Description = "A decadent chocolate tart with a buttery crust and rich ganache filling.",
            Price = 4.99,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Desserts/tarta_chocolate.png?raw=true",
            CategoryId = 4
        },
        new Dessert
        {
            Id = 6,
            Name = "Butter Pie",
            Description = "A creamy butter tart with a flaky pastry and smooth filling.",
            Price = 4.49,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Desserts/tarta_mantequilla.png?raw=true",
            CategoryId = 4
        } 
    };

        Chips[] chips = new Chips[]
    {
        new Chips
        {
            Id = 1,
            Name = "French Fries",
            Description = "Crispy golden French fries, lightly salted.",
            Price = 2.49,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Chips/patatas1.png?raw=true",
            CategoryId = 3
        },
        new Chips
        {
            Id = 2,
            Name = "Bacon Fries",
            Description = "French fries topped with crispy bacon and a savory sauce.",
            Price = 3.29,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Chips/patatas2.png?raw=true",
            CategoryId = 3
        },
        new Chips
        {
            Id = 3,
            Name = "Wedges Fries",
            Description = "Thick-cut potato wedges, perfectly seasoned and baked until golden.",
            Price = 2.99,
            Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Chips/patatas3.png?raw=true",
            CategoryId = 3
        }
    };

            Category[] category = new Category[]
  {
        new Category
        {
            Id = 1,
            Name = "Burguer",          
        },
         new Category
        {
            Id = 2,
            Name = "Beer",
        },
          new Category
        {
            Id = 3,
            Name = "Chips",
        },
           new Category
        {
            Id = 4,
            Name = "Dessert",
        },

  };
            modelBuilder.Entity<Chips>().HasData(chips);        

            modelBuilder.Entity<Dessert>().HasData(desserts);

            modelBuilder.Entity<Beer>().HasData(beers);

            modelBuilder.Entity<Burguer>().HasData(burgers);

            modelBuilder.Entity<Category>().HasData(category);
        }



        //private static void AddSeedData(ModelBuilder modelBuilder)
        //{
        //    Burguer[] burguers = new Burguer[]
        //    {
        //new Burguer
        //{
        //    Id = 1,
        //    Name = "Clásica Suprema",
        //    Description = "Hamburguesa con carne de res, queso cheddar, lechuga, tomate y aderezo especial.",
        //    Price = 5.99,
        //    Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer1.png?raw=true"
        //},
        //new Burguer
        //{
        //    Id = 2,
        //    Name = "BBQ Texana",
        //    Description = "Carne ahumada con salsa BBQ, cebolla crujiente y queso gouda.",
        //    Price = 6.99,
        //    Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer2.png?raw=true"
        //},
        //new Burguer
        //{
        //    Id = 3,
        //    Name = "Cheddar Bacon Deluxe",
        //    Description = "Cargada de queso cheddar, bacon crujiente y mayonesa especial.",
        //    Price = 7.49,
        //    Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer3.png?raw=true"
        //},
        //new Burguer
        //{
        //    Id = 4,
        //    Name = "Hawaiana Tropical",
        //    Description = "Carne con queso suizo, piña caramelizada y salsa teriyaki.",
        //    Price = 6.49,
        //    Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer4.png?raw=true"
        //},
        //new Burguer
        //{
        //    Id = 5,
        //    Name = "Picante Infernal",
        //    Description = "Con jalapeños, salsa picante, queso pepper jack y cebolla.",
        //    Price = 6.99,
        //    Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer5.png?raw=true"
        //},
        //new Burguer
        //{
        //    Id = 6,
        //    Name = "Doble Smashburger",
        //    Description = "Doble carne aplastada, queso cheddar y salsa especial.",
        //    Price = 7.99,
        //    Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer6.png?raw=true"
        //},
        //new Burguer
        //{
        //    Id = 7,
        //    Name = "Veggie Lovers",
        //    Description = "Hamburguesa vegetariana con vegetales frescos y hummus.",
        //    Price = 5.49,
        //    Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer7.png?raw=true"
        //},
        //new Burguer
        //{
        //    Id = 8,
        //    Name = "Portobello Melt",
        //    Description = "Seta portobello a la parrilla, queso suizo y mayonesa de ajo.",
        //    Price = 6.99,
        //    Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer8.png?raw=true"
        //},
        //new Burguer
        //{
        //    Id = 9,
        //    Name = "Trufa Gourmet",
        //    Description = "Carne de res con aceite de trufa, queso brie y rúcula.",
        //    Price = 8.99,
        //    Image = "https://github.com/Kaligulah123/Images-Icons/blob/main/Burguers/burguer9.png?raw=true"
        //}
        //    };

        //    modelBuilder.Entity<Burguer>().HasData(burguers);
        //}


    }

}
