using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.DbConnection;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.InterfaceRepository;

namespace TestHotel.DataAccess.Repository.InterfaceRepository
{
    public class BillRepository : IBillRepository
    {
        private readonly HotelDbContext _context;

        public BillRepository(HotelDbContext context)
        {
            _context = context;
        }

        public Bill AddBill(Bill bill)
        {
            _context.Bills.Add(bill);
            _context.SaveChanges();
            return bill;
        }

        public int DeleteBill(Bill bill)
        {
            _context.Bills.Remove(bill);
            _context.SaveChanges();
            return bill.InvoiceNumber;
        }

        public List<Bill> GetAllBills() => _context.Bills
            .Include(u => u.Guest).ThenInclude(n => n.Bookings).ToList();

        public Bill GetBillByInvoiceNumber(int invoiceNumber) => _context.Bills.Include(u => u.Guest)
            .ThenInclude(n => n.Bookings).FirstOrDefault(u => u.InvoiceNumber == invoiceNumber);

        public int UpdateBill(Bill bill)
        {
            _context.Bills.Update(bill);
            _context.SaveChanges();
            return bill.InvoiceNumber;
        }
    }
}
