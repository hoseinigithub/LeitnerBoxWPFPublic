using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class CardDataAccess:DbContext
    {
        DataBaseContext _context = new DataBaseContext();

        Card card = new Card();

        public void Create(Card card)
        {
            this.card = card;
            _context.Add(this.card);
            _context.SaveChanges();
        }

        public List<Card> Read()
        {
            List<Card> cards = new List<Card>();
            var list = _context.Cards.ToList();
            foreach (var item in list)
            {
                cards.Add(item);
            }
            return cards;
        }

        public void Update(Card card)
        {
            _context.Update(card);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            var card = _context.Cards.First(c => c.Id == id);

            _context.Remove(card);
            _context.SaveChanges();
        }
    }
}
