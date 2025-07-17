using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RefreshTokenDAO
    {
        private readonly GeneCareContext _context;
        public RefreshTokenDAO()
        {
            _context = new GeneCareContext();
        }
        public RefreshTokenDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<RefreshToken?> GetRefreshTokenByIdAsync(int refreshTokenId)
        {
            try
            {
                return await _context.RefreshTokens.FindAsync(refreshTokenId);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the refresh token.", ex);
            }
        }

        public async Task<List<RefreshToken>> GetAllRefreshTokensAsync()
        {
            try
            {
                return await _context.RefreshTokens.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all refresh token.", ex);
            }
        }

        public async Task<RefreshToken> CreateRefreshTokenAsync(RefreshToken refreshToken)
        {
            try
            {
                _context.RefreshTokens.Add(refreshToken);
                await _context.SaveChangesAsync();
                return refreshToken;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the refresh token.", ex);
            }
        }

        public async Task<RefreshToken> UpdateRefreshTokenAsync(RefreshToken refreshToken)
        {
            try
            {
                _context.Entry(refreshToken).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return refreshToken;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the refresh token.", ex);
            }
        }

        public async Task<bool> DeleteRefreshTokenAsync(int refreshTokenId)
        {
            try
            {
                var refreshToken = await _context.RefreshTokens.FindAsync(refreshTokenId);
                if (refreshToken == null)
                {
                    return false; // Refresh Token not found
                }
                _context.RefreshTokens.Remove(refreshToken);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the refresh token.", ex);
            }
        }
    }
}
