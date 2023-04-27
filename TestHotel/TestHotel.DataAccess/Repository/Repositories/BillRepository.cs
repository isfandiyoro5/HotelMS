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
            try
            {
                _context.Bills.Add(bill);
                await _context.SaveChangesAsync();
                return bill.InvoiceNumber;
            }
            catch 
            {
                throw new Exception("Invoice qo'shilmadi");
            }
        }

        public async Task<int> DeleteBillAsync(Bill bill)
        {
            try
            {
                _context.Bills.Remove(bill);
                await _context.SaveChangesAsync();
                return bill.InvoiceNumber;
            }
            catch
            {
                throw new Exception("Invoiceda o'chirilmadi");
            }
        }

        public async Task<List<Bill>> GetAllBillsAsync() => await _context.Bills
            .Include(u => u.Guest)
            .Include(u => u.Booking)
            .ToListAsync();

        public async Task<Bill> GetBillByInvoiceNumberAsync(int invoiceNumber)
        {
            try
            {
                return await _context.Bills
                    .Include(u => u.Guest)
                    .Include(u => u.Booking)
                    .FirstOrDefaultAsync(u => u.InvoiceNumber == invoiceNumber);
            }
            catch
            {
                throw new Exception("Invoice number topilmadi");
            }
        }
        public async Task<int> UpdateBillAsync(Bill bill)
        {
            try
            {
                _context.Bills.Update(bill);
                await _context.SaveChangesAsync();
                return bill.InvoiceNumber;
            }
            catch
            {
                throw new Exception("O'zgartirish kiritilmadi");
            }
        }
    }
}
