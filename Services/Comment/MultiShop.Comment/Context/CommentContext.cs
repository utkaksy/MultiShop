﻿using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entites;

namespace MultiShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442; initial Catalog=MultiShopCommentDb; User=sa;Password=Utk+bilgisayar01;TrustServerCertificate=True");
        }

        public DbSet<UserComment> UserComments { get; set; }
    }
}
