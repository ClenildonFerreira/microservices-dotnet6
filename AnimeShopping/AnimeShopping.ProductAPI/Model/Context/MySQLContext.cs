﻿using Microsoft.EntityFrameworkCore;

namespace AnimeShopping.ProductAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() {}
        public MySQLContext(DbContextOptions<MySQLContext> options) : base() {}
    }
}
