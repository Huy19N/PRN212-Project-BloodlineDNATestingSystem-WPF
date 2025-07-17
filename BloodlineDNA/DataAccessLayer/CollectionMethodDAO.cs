using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CollectionMethodDAO
    {
        private readonly GeneCareContext _context;
        public CollectionMethodDAO()
        {
            _context = new GeneCareContext();
        }
        public CollectionMethodDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<CollectionMethod?> GetCollectionMethodByIdAsync(int methodId)
        {
            try
            {
                return await _context.CollectionMethods.FindAsync(methodId);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the collection method.", ex);
            }
        }

        public async Task<List<CollectionMethod>> GetAllCollectionMethodsAsync()
        {
            try
            {
                return await _context.CollectionMethods.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all collection method.", ex);
            }
        }

        public async Task<CollectionMethod> CreateCollectionMethodAsync(CollectionMethod collectionMethod)
        {
            try
            {
                _context.CollectionMethods.Add(collectionMethod);
                await _context.SaveChangesAsync();
                return collectionMethod;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the collection method.", ex);
            }
        }

        public async Task<CollectionMethod> UpdateCollectionMethodAsync(CollectionMethod collectionMethod)
        {
            try
            {
                _context.Entry(collectionMethod).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return collectionMethod;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the collection method.", ex);
            }
        }

        public async Task<bool> DeleteCollectionMethodAsync(int methodId)
        {
            try
            {
                var collectionMethod = await _context.CollectionMethods.FindAsync(methodId);
                if (collectionMethod == null)
                {
                    return false; // Collection method not found
                }
                _context.CollectionMethods.Remove(collectionMethod);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the collection method.", ex);
            }
        }
    }
}
