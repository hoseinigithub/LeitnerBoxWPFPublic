using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class LeitnerBoxDataAccess:DbContext
    {
        DataBaseContext _context = new DataBaseContext();
       
        public LeitnerBoxDataAccess()
        {
          
        }

        LeitnerBox leitBox = new LeitnerBox();

        public void Create(LeitnerBox leitnerBox)
        {
        
            
                 leitBox = leitnerBox;
                 _context.LeitnerBoxes.Add(leitBox);
                _context.SaveChanges();
            
         
        }

        public ObservableCollection<LeitnerBox> Read()
        {
           
                ObservableCollection<LeitnerBox> result = new ObservableCollection<LeitnerBox>();
                var list1 = _context.LeitnerBoxes.ToList();

                foreach (var item in list1)
                {
                    result.Add(item);
                }
                return result;
            
            
        }

        public bool IsAny()
        {
            using (DataBaseContext _context = new DataBaseContext())
            {
                if (_context.LeitnerBoxes.Any())
                    return true;
                else
                    return false;
            }

            
        }
        public void Update(LeitnerBox leitnerBox)
        {
            //leitBox = leitnerBox;

            //_context.LeitnerBoxes.Add(leitBox);                    
        }

        public void Delete(int id)
        {
            var leitner = _context.LeitnerBoxes.First(u => u.Id == id);
            _context.LeitnerBoxes.Remove(leitner);
            _context.SaveChanges();
        }

        //public int GetNextId()
        //{
        //    int index = _context.LeitnerBoxes.Any() ? _context.LeitnerBoxes.Max(x => x.Id) + 1 : 1;
        //    return index;
        //}
    }
}
