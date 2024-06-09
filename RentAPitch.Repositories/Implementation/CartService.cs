﻿using Microsoft.EntityFrameworkCore;
using RentAPitch.Data;
using RentAPitch.Data.Models;
using RentAPitch.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPitch.Repositories.Implementation
{
    public class CartService : ICartService
    {
        private readonly RentAPitchDbContext _context;

        public CartService(RentAPitchDbContext context)
        {
            _context = context;
        }

        public async Task AddToCart(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        public async Task ClearCart(string userId)
        {
            var cartItems = await _context.Carts.Where(x => x.User.Id == userId).ToListAsync();
            _context.Carts.RemoveRange(cartItems);
            await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetCartItems(string userId, int pitchId)
        {
            var cart = await _context.Carts.Where(c => c.User.Id == userId && c.PitchId == pitchId).FirstOrDefaultAsync();
            return cart;
        }

        public async Task<List<Cart>> GetCartItems(string userId)
        {
            var cartItems = await _context.Carts.Where(x => x.User.Id == userId).ToListAsync();
            return cartItems;
        }
    }
}
