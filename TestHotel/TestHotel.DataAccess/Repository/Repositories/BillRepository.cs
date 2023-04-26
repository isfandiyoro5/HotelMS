using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.DbConnection;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;

namespace TestHotel.DataAccess.Repository.Repositories
{
    public class BillRepository : IBillRepository
    {
        private readonly HotelDbContext _context;

        public BillRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddBillAsync(Bill bill)
        {
            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();
            return bill.InvoiceNumber;
        }

        public async Task<int> DeleteBillAsync(Bill bill)
        {
            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();
            return bill.InvoiceNumber;
        }

        public async Task<List<Bill>> GetAllBillsAsync() => await _context.Bills
            .Include(u => u.Guest)
            .Include(u => u.Booking)
            .ToListAsync();

        public async Task<Bill> GetBillByInvoiceNumberAsync(int invoiceNumber) => await _context.Bills
            .Include(u => u.Guest)
            .Include(u => u.Booking)
            .FirstOrDefaultAsync(u => u.InvoiceNumber == invoiceNumber);

        public async Task<int> UpdateBillAsync(Bill bill)
        {
            _context.Bills.Update(bill);
            await _context.SaveChangesAsync();
            return bill.InvoiceNumber;
        }
    }
}
